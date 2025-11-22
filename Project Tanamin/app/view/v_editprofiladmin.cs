using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_editprofiladmin : Form
    {
        public v_editprofiladmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username.Text = c_user.Username;
            password.Text = c_user.Password;
            konfirmasipassword.Text = c_user.Password;
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
            // tidak perlu aksi
        }

        private void btneditprofiladmin_Click(object sender, EventArgs e)
        {
            new v_editprofiladmin().Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin keluar?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new v_login().Show();
                this.Close();
            }
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            string newUsername = username.Text.Trim();
            string newPassword = password.Text.Trim();
            string konfirmasi = konfirmasipassword.Text.Trim();

            if (newPassword != konfirmasi)
            {
                MessageBox.Show(
                    "Konfirmasi password tidak cocok!",
                    "Gagal Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            c_updateprofil updater = new c_updateprofil();

            string hasil = updater.UpdateProfilAdmin(newUsername, newPassword, konfirmasi);

            if (hasil == "OK")
            {
                MessageBox.Show(
                    "Profil berhasil diperbarui!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                new v_profiladmin().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    hasil,
                    "Gagal Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        private void btnbatal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin batal mengubah profil?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new v_profiladmin().Show();
                this.Close();
            }
        }
    }
}
