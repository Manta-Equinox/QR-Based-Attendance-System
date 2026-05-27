using AForge.Video;
using AForge.Video.DirectShow;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace AP_Project
{
    public partial class ScannerControl : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        private BarcodeReader reader;

        private Bitmap currentFrame;
        private readonly object frameLock = new object();

        private bool isScanning = false;
        private bool isProcessing = false;

        private string lastToken = "";
        private DateTime lastScanTime = DateTime.MinValue;

        public ScannerControl()
        {
            InitializeComponent();

            reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = false,
                    PossibleFormats = new List<BarcodeFormat>
                    {
                        BarcodeFormat.QR_CODE
                    }
                }
            };
        }
        private void StartCamera()
        {
            try
            {
                StopCamera();

                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("No camera found (install DroidCam if needed)");
                    return;
                }

                int index = 0;

                for (int i = 0; i < videoDevices.Count; i++)
                {
                    string name = videoDevices[i].Name.ToLower();

                    if (name.Contains("droid") || name.Contains("virtual") || name.Contains("usb") || name.Contains("camera"))
                    {
                        index = i;
                        break;
                    }
                }

                videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);
                videoSource.NewFrame += Video_NewFrame;
                videoSource.Start();

                isScanning = true;

                timer1.Interval = 300;
                timer1.Tick -= Timer1_Tick;
                timer1.Tick += Timer1_Tick;
                timer1.Start();

                SetStatus("Camera started: " + videoDevices[index].Name, Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Camera error: " + ex.Message);
            }
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
                Bitmap resized = new Bitmap(frame, new Size(640, 480));
                frame.Dispose();

                lock (frameLock)
                {
                    currentFrame?.Dispose();
                    currentFrame = resized;
                }

                if (pictureBoxCamera.IsHandleCreated)
                {
                    pictureBoxCamera.BeginInvoke((MethodInvoker)(() =>
                    {
                        var old = pictureBoxCamera.Image;
                        pictureBoxCamera.Image = (Bitmap)resized.Clone();
                        old?.Dispose();
                    }));
                }
            }
            catch { }
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
            if (!isScanning || isProcessing) return;

            isProcessing = true;

            Bitmap frameCopy = null;

            try
            {
                lock (frameLock)
                {
                    if (currentFrame == null) return;
                    frameCopy = (Bitmap)currentFrame.Clone();
                }

                var result = reader.Decode(frameCopy);

                if (result != null)
                {
                    string token = ExtractToken(result.Text);

                    if (string.IsNullOrWhiteSpace(token))
                        return;

                    if (token == lastToken &&
                        (DateTime.Now - lastScanTime).TotalSeconds < 3)
                        return;

                    lastToken = token;
                    lastScanTime = DateTime.Now;

                    isScanning = false;
                    timer1.Stop();

                    await SendToAPI(token);

                    await Task.Delay(1200);

                    isScanning = true;
                    timer1.Start();
                }
            }
            catch { }
            finally
            {
                frameCopy?.Dispose();
                isProcessing = false;
            }
        }

        private async void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap snap;

                lock (frameLock)
                {
                    if (currentFrame == null)
                    {
                        MessageBox.Show("No camera frame");
                        return;
                    }

                    snap = (Bitmap)currentFrame.Clone();
                }

                var result = reader.Decode(snap);
                snap.Dispose();

                if (result == null)
                {
                    MessageBox.Show("No QR detected");
                    return;
                }

                string token = ExtractToken(result.Text);
                await SendToAPI(token);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Capture error: " + ex.Message);
            }
        }

        private string ExtractToken(string text)
        {
            try
            {
                if (text.Contains("token="))
                {
                    Uri uri = new Uri(text);
                    string query = uri.Query.TrimStart('?');

                    foreach (var p in query.Split('&'))
                    {
                        var pair = p.Split('=');
                        if (pair.Length == 2 && pair[0] == "token")
                            return pair[1];
                    }
                }

                return text.Trim();
            }
            catch
            {
                return text.Trim();
            }
        }

        private async Task SendToAPI(string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("token", token),
                        new KeyValuePair<string, string>("staff_id",
                            MainForm.LoggedStaffId.ToString())
                    });

                    var response = await client.PostAsync(
                        "http://localhost:8080/api/attendance/scan.php",
                        content
                    );

                    string json = await response.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(json);

                    string status = obj["status"]?.ToString();
                    string message = obj["message"]?.ToString();

                    if (status == "success")
                    {
                        string participant = obj["data"]?["participant_name"]?.ToString();
                        string eventTitle = obj["data"]?["event_title"]?.ToString();

                        MessageBox.Show(
                            $"✔ OK\nParticipant: {participant}\nEvent: {eventTitle}",
                            "Success"
                        );
                    }
                    else
                    {
                        MessageBox.Show("✖ " + message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API error: " + ex.Message);
            }
        }

        private void StopCamera()
        {
            try
            {
                timer1?.Stop();
                isScanning = false;

                if (videoSource != null)
                {
                    videoSource.NewFrame -= Video_NewFrame;

                    if (videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }

                    videoSource = null;
                }

                lock (frameLock)
                {
                    currentFrame?.Dispose();
                    currentFrame = null;
                }

                pictureBoxCamera.Image?.Dispose();
                pictureBoxCamera.Image = null;
            }
            catch { }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCamera();
            SetStatus("Camera Stopped", Color.Red);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopCamera();
            base.OnFormClosing(e);
        }

        private void SetStatus(string text, Color color)
        {
            lblStatus.Text = text;
            lblStatus.ForeColor = color;
        }
    }
}