using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_Project
{
    public partial class MainForm : Form
    {
        public static int LoggedStaffId;
        public static string LoggedName;
        public static string LoggedRole;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ApplyRolePermissions()
        {
            if (LoggedRole == "admin")
            {
                
                btnUsers.Visible = true;
                btnEvents.Visible = true;
                btnScanner.Visible = true;
            }
            else if (LoggedRole == "employee")
            {
                btnUsers.Visible = false;
                btnEvents.Visible = true;
                btnScanner.Visible = true;
            }
            else
            {
                btnUsers.Visible = false;
                btnEvents.Visible = true;
                btnScanner.Visible = false;
            }
        }
        public void SetUser(int staffId, string name, string role)
        {
            LoggedStaffId = staffId;
            LoggedName = name;
            LoggedRole = role;

            lbwelcome.Text = "Welcome " + name + "!";

            ApplyRolePermissions();
        }
        private void LoadChild(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
        }

        private void btnlogout1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                                  "Confirm Logout",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            LoadChild(new EventListControl());
        }
    }
}
