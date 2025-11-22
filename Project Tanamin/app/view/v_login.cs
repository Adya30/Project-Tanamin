using Project_Tanamin.app.controller;
using Project_Tanamin.app.view;
using Project_Tanamin.view;

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

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan Password wajib diisi!");
                return;
            }

            string result = userController.Login(username, password);

            if (result == "LOGIN_ADMIN")
            {
                MessageBox.Show("Login berhasil sebagai Admin!");
                new v_profiladmin().Show();
                this.Hide();
            }
            else if (result == "LOGIN_CUSTOMER")
            {
                MessageBox.Show("Login berhasil sebagai Customer!");
                new v_profilcustomer().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah!");
            }
        }
    }
}
