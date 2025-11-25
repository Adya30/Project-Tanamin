using Project_Tanamin.app.controller;
using Project_Tanamin.app.view;
using Project_Tanamin.view;
using System;
using System.Windows.Forms;

namespace Project_Tanamin
{
    public partial class v_login : Form
    {
        private c_user userController;

        public v_login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            linkdaftar.LinkClicked += Linkdaftarclick;

            userController = new c_user();
        }

        private void Linkdaftarclick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            v_register reg = new v_register();
            reg.Show();
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password wajib diisi!");
                return;
            }

            string result = userController.Login(username, password);

            switch (result)
            {
                case "LOGIN_ADMIN":
                    MessageBox.Show("Login berhasil sebagai Admin!");
                    v_profiladmin adminPage = new v_profiladmin();
                    adminPage.Show();
                    this.Hide();
                    break;

                case "LOGIN_CUSTOMER":
                    MessageBox.Show("Login berhasil sebagai Customer!");
                    v_profilcustomer custPage = new v_profilcustomer();
                    custPage.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Username atau password salah!");
                    break;
            }
        }
    }
}
