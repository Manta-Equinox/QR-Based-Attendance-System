using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_Project
{
    public partial class EventListControl : UserControl
    {
        public EventListControl()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadEvents();

        }
        private async Task LoadEvents()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:8080/api/events/list.php";

                    HttpResponseMessage response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    JObject obj = JObject.Parse(json);

                    if (obj["status"]?.ToString() != "success")
                    {
                        MessageBox.Show("Failed to load events");
                        return;
                    }

                    DataTable table = new DataTable();

                    JArray data = (JArray)obj["data"];

                    if (data.Count == 0)
                    {
                        dgvEvents.DataSource = table;
                        return;
                    }

                    foreach (JProperty prop in ((JObject)data[0]).Properties())
                    {
                        table.Columns.Add(prop.Name);
                    }

                    foreach (JObject item in data)
                    {
                        DataRow row = table.NewRow();

                        foreach (JProperty prop in item.Properties())
                        {
                            row[prop.Name] = prop.Value?.ToString();
                        }

                        table.Rows.Add(row);
                    }

                    dgvEvents.DataSource = table;
                    dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvEvents.ReadOnly = true;
                    dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadEvents();
        }
    }
}
