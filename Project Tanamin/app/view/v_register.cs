using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.view
{
    public partial class v_register : Form
    {
        private c_user controller;

        public v_register()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            password_register.UseSystemPasswordChar = true;
            konfirmasi_password.UseSystemPasswordChar = true;
            linklogin.LinkClicked += Linkloginclick;
            controller = new c_user();
        }

        private void Linkloginclick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLoginForm();
        }

        public void OpenLoginForm()
        {
            new v_login().Show();
            this.Close();
        }

        private void buttondaftar_Click(object sender, EventArgs e)
        {
            string namaLengkap = nama_lengkap.Text.Trim();
            string username = username_register.Text.Trim();
            string noTelp = no_telp.Text.Trim();
            string password = password_register.Text.Trim();
            string konfirmasi = konfirmasi_password.Text.Trim();

            if (namaLengkap == "" || username == "" || noTelp == "" || password == "" || konfirmasi == "")
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username minimal 4 karakter!");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter!");
                return;
            }

            if (!long.TryParse(noTelp, out _))
            {
                MessageBox.Show("Nomor telepon harus berupa angka!");
                return;
            }

            string result = controller.RegisterCustomer(
                namaLengkap, username, noTelp, password, konfirmasi);

            if (result == "Pendaftaran Berhasil")
            {
                MessageBox.Show("Akun berhasil dibuat! Silakan login.");
                v_login loginForm = new v_login();
                loginForm.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
