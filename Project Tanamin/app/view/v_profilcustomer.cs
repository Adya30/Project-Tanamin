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
    public partial class v_profilcustomer : Form
    {
        public v_profilcustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            label1.Text = c_user.NamaLengkap;
            label2.Text = c_user.Username;
            label3.Text = c_user.NoTelp;
            label4.Text = c_user.Password;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            v_editprofilcustomer editprofiladmin = new v_editprofilcustomer();
            editprofiladmin.Show();
            this.Close();
        }

        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            v_katalogcustomer katalogcustomer = new v_katalogcustomer();
            katalogcustomer.Show();
            this.Close();
        }

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {
            v_pesanancustomer pesanancustomer = new v_pesanancustomer();
            pesanancustomer.Show();
            this.Close();
        }

        private void btnriwayatcustomer_Click(object sender, EventArgs e)
        {
            v_riwayatcustomer riwayatcustomer = new v_riwayatcustomer();
            riwayatcustomer.Show();
            this.Close();
        }

        private void btnfeedbackcustomer_Click(object sender, EventArgs e)
        {
            v_feedbackcustomer feedbackcustomer = new v_feedbackcustomer();
            feedbackcustomer.Show();
            this.Close();
        }

        private void btnprofilcustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_login().Show();
                this.Close();
            }
        }
    }
}
