using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_profiladmin : Form
    {
        public v_profiladmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            if (c_user.CurrentUser != null)
            {
                labelusername.Text = c_user.CurrentUser.Username;
                labelpassword.Text = c_user.CurrentUser.Password;
            }
            else
            {
                labelusername.Text = "-";
                labelpassword.Text = "-";
            }
        }

        private void btnkatalaogadmin_Click(object sender, EventArgs e)
        {
            v_katalogadmin katalogadmin = new v_katalogadmin();
            katalogadmin.Show();
            this.Close();
        }

        private void btnpesananadmin_Click(object sender, EventArgs e)
        {
            v_pesananadmin pesananadmin = new v_pesananadmin();
            pesananadmin.Show();
            this.Close();
        }

        private void btnriwayatadmin_Click(object sender, EventArgs e)
        {
            v_riwayatadmin riwayatadmin = new v_riwayatadmin();
            riwayatadmin.Show();
            this.Close();
        }

        private void btnfeedbackadmin_Click(object sender, EventArgs e)
        {
            v_feedbackadmin feedbackadmin = new v_feedbackadmin();
            feedbackadmin.Show();
            this.Close();
        }

        private void btnprofiladmin_Click(object sender, EventArgs e)
        {
           
        }

        private void btneditprofiladmin_Click(object sender, EventArgs e)
        {
            v_editprofiladmin editprofiladmin = new v_editprofiladmin();
            editprofiladmin.Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin keluar?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                c_user controller = new c_user();
                controller.Logout();

                v_login loginForm = new v_login();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
