using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_responfeedback : Form
    {
        private int idFeedback;
        private readonly c_feedback ctrl;

        public v_responfeedback()
        {
            InitializeComponent();
            ctrl = new c_feedback();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }

        public void LoadFeedbackForResponse(int id, string tanggal, string pertanyaan)
        {
            idFeedback = id;
            dateTimePicker1.Text = tanggal;
            richTextBox2.Text = pertanyaan;
            richTextBox2.ReadOnly = true;
        }

        private void btnsimpan_Click_1(object sender, EventArgs e)
        {
            string respon = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(respon))
            {
                MessageBox.Show("Respon tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sukses = ctrl.AddResponse(idFeedback, respon);

            if (sukses)
            {
                MessageBox.Show("Respon berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan respon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            new v_profiladmin().Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_login().Show();
                this.Close();
            }
        }
    }
}
