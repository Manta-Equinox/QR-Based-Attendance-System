using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_Project
{
    public partial class AttendanceLogControl : UserControl
    {
        public AttendanceLogControl()
        {
            InitializeComponent();
            Load += AttendanceLogControl_Load;

        }
        private async void AttendanceLogControl_Load(object sender,EventArgs e)
        {
            await LoadAttendance();
        }

        private async Task LoadAttendance()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url =
                        "http://localhost:8080/api/attendance/list.php";

                    HttpResponseMessage response =
                        await client.GetAsync(url);

                    string json =
                        await response.Content.ReadAsStringAsync();

                    JObject obj = JObject.Parse(json);

                    if (obj["status"]?.ToString() != "success")
                    {
                        MessageBox.Show(
                            obj["message"]?.ToString()
                            ?? "Failed to load attendance logs"
                        );
                        return;
                    }

                    DataTable dt =
                        obj["data"].ToObject<DataTable>();

                    dgvAttendance.DataSource = dt;

                    dgvAttendance.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvAttendance.ReadOnly = true;
                    dgvAttendance.AllowUserToAddRows = false;
                    dgvAttendance.RowHeadersVisible = false;
                    dgvAttendance.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dgvAttendance.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "API Error: " + ex.Message
                );
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAttendance();
        }
    }
}
