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
    public partial class v_riwayatcustomer : Form
    {
        public v_riwayatcustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            new v_katalogcustomer().Show();
            this.Close();
        }

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {
            new v_pesanancustomer().Show();
            this.Close();
        }

        private void btnriwayatcustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnfeedbackcustomer_Click(object sender, EventArgs e)
        {
            new v_feedbackcustomer().Show();
            this.Close();
        }

        private void btnprofilcustomer_Click(object sender, EventArgs e)
        {
            new v_profilcustomer().Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c_user controller = new c_user();
                controller.Logout();

                new v_login().Show();
                this.Close();
            }
        }
    }
}
