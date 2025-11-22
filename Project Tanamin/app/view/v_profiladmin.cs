using Project_Tanamin.app.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_profiladmin : Form
    {
        public v_profiladmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            labelusername.Text = c_user.Username;
            labelpassword.Text = c_user.Password;
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

        private void btnprofiladmin_Click(object sender, EventArgs e){}

        private void btneditprofiladmin_Click(object sender, EventArgs e)
        {
            v_editprofiladmin editprofiladmin = new v_editprofiladmin();
            editprofiladmin.Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                v_login loginForm = new v_login();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
