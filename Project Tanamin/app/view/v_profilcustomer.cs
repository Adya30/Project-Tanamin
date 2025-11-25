using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_profilcustomer : Form
    {
        public v_profilcustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (c_user.CurrentUser != null)
            {
                label1.Text = c_user.CurrentUser.NamaLengkap;
                label2.Text = c_user.CurrentUser.Username;
                label3.Text = c_user.CurrentUser.NoTelp;
                label4.Text = c_user.CurrentUser.Password;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            new v_editprofilcustomer().Show();
            this.Close();
        }

        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            new v_katalogcustomer().Show();
            this.Close();
        }

        private int? userId = c_user.CurrentUser?.IdUser; // misal diambil dari login
        private List<(m_produk produk, int jumlah)> keranjangSementara = new List<(m_produk, int)>(); // keranjang sementara

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {
            var formPesanan = new v_pesanancustomer();
            formPesanan.Show();
            this.Close();
        }

        private void btnriwayatcustomer_Click(object sender, EventArgs e)
        {
            new v_riwayatcustomer().Show();
            this.Close();
        }

        private void btnfeedbackcustomer_Click(object sender, EventArgs e)
        {
            new v_feedbackcustomer().Show();
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
                c_user controller = new c_user();
                controller.Logout();

                new v_login().Show();
                this.Close();
            }
        }
    }
}
