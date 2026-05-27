using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;


namespace AP_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            tbloginpass.PasswordChar='*';
        }
        private void LoginForm_Load(object sender, EventArgs e)
        { 
        }


        private async void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = tbloginpass.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter email and password");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", email),
                        new KeyValuePair<string, string>("password", password)
                    });

                    HttpResponseMessage response =
                        await client.PostAsync("http://localhost:8080/api/auth/staff_login.php", content);

                    string result = await response.Content.ReadAsStringAsync();

                    JObject doc = JObject.Parse(result);

                    if (doc["status"]?.ToString() == "success")
                    {
                        int staffId = (int)doc["data"]["id"];
                        string name = doc["data"]["name"].ToString();
                        string role = doc["role"].ToString();

                        MainForm main = new MainForm();
                        main.SetUser(staffId, name, role);

                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(doc["message"]?.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message);
            }

        }

        private void chkboxshowpass_CheckedChanged(object sender, EventArgs e)
        {
            tbloginpass.PasswordChar = chkboxshowpass.Checked ? '\0' : '*';
        }
    }
}
