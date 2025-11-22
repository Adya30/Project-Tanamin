using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_editprofilcustomer : Form
    {
        public v_editprofilcustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Namalengkap.Text = c_user.NamaLengkap;
            Username.Text = c_user.Username;
            no_telp.Text = c_user.NoTelp;
            Password.Text = c_user.Password;
            konfirmasipassword.Text = c_user.Password;
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
           
            c_user ctrl = new c_user();
            string result = ctrl.UpdateProfile(c_user.IdUser, nama, user, telp, pass, konfir);

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
