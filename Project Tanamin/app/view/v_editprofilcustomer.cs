using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_editprofilcustomer : Form
    {
        private c_user ctrl;
        private int? userId = c_user.CurrentUser?.IdUser; 
        private List<(m_produk produk, int jumlah)> keranjangSementara = new List<(m_produk, int)>();

        public v_editprofilcustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            ctrl = new c_user();
            LoadUserToFields();
        }

        private void LoadUserToFields()
        {
            if (c_user.CurrentUser != null)
            {
                Namalengkap.Text = c_user.CurrentUser.NamaLengkap;
                Username.Text = c_user.CurrentUser.Username;
                no_telp.Text = c_user.CurrentUser.NoTelp;
                Password.Text = c_user.CurrentUser.Password;
                konfirmasipassword.Text = c_user.CurrentUser.Password;
            }
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
            new v_riwayatcustomer().Show();
            this.Close();
        }

        private void btnfeedbackcustomer_Click(object sender, EventArgs e)
        {
            new v_feedbackcustomer().Show();
            this.Close();
        }

        private void btnprofilcustomer_Click(object sender, EventArgs e) { }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctrl.Logout();
                new v_login().Show();
                this.Close();
            }
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            string nama = Namalengkap.Text.Trim();
            string user = Username.Text.Trim();
            string telp = no_telp.Text.Trim();
            string pass = Password.Text;
            string konfir = konfirmasipassword.Text;

            string result = ctrl.UpdateProfile(nama, user, telp, pass, konfir);

            MessageBox.Show(result, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == "Update Profil Berhasil")
            {
                new v_profilcustomer().Show();
                this.Close();
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin batal mengubah profil?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_profilcustomer().Show();
                this.Close();
            }
        }
    }
}
