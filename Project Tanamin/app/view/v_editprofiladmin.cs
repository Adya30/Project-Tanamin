using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_editprofiladmin : Form
    {
        private c_user controller;

        public v_editprofiladmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            controller = new c_user();

            LoadUserToFields();
        }

        private void LoadUserToFields()
        {
            if (c_user.CurrentUser != null)
            {
                username.Text = c_user.CurrentUser.Username;
                password.Text = c_user.CurrentUser.Password;
                konfirmasipassword.Text = c_user.CurrentUser.Password;
            }
        }

        private void btnkatalaogadmin_Click(object sender, EventArgs e)
        {
            new v_katalogadmin().Show();
            this.Close();
        }

        private void btnpesananadmin_Click(object sender, EventArgs e)
        {
            new v_pesananadmin().Show();
            this.Close();
        }

        private void btnriwayatadmin_Click(object sender, EventArgs e)
        {
            new v_riwayatadmin().Show();
            this.Close();
        }

        private void btnfeedbackadmin_Click(object sender, EventArgs e)
        {
            new v_feedbackadmin().Show();
            this.Close();
        }

        private void btnprofiladmin_Click(object sender, EventArgs e)
        {

        }

        private void btneditprofiladmin_Click(object sender, EventArgs e)
        {
            new v_editprofiladmin().Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Logout();
                new v_login().Show();
                this.Close();
            }
        }


        private void btnsimpan_Click(object sender, EventArgs e)
        {
            string user = username.Text.Trim();
            string pass = password.Text.Trim();
            string konfirmasi = konfirmasipassword.Text.Trim();

            string hasil = controller.UpdateProfile("",user,"", pass,konfirmasi);

            if (hasil.Contains("Berhasil"))
            {
                MessageBox.Show("Profil Admin berhasil diperbarui!","Sukses",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                new v_profiladmin().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(hasil,"Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Batalkan perubahan?", "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_profiladmin().Show();
                this.Close();
            }
        }
    }
}
