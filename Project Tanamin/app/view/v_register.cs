using Project_Tanamin.app.controller;

namespace Project_Tanamin.view
{
    public partial class v_register : Form
    {
        private c_user controller;

        public v_register()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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

            string result = controller.Register(namaLengkap, username, noTelp, password, konfirmasi);

            if (result == "Pendaftaran Berhasil")
            {
                MessageBox.Show("Akun berhasil dibuat!");
                OpenLoginForm();
            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
