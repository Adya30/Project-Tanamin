using Npgsql;
using Project_Tanamin.app.controller;
using System;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_tambahfeedback : Form
    {
        private c_feedback ctrl;

        private bool modeEdit = false;
        private string oldTanggal = "";
        private string oldPertanyaan = "";

        public v_tambahfeedback()
        {
            InitializeComponent();
            ctrl = new c_feedback();

            SetLabelIfExists("lblMode", "Tambah Feedback");
            SetButtonTextIfExists("btnsimpan", "");
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            DateTime tanggal = datetimefeedback.Value;
            string pertanyaan = richTextBoxpertanyaan.Text.Trim();

            if (pertanyaan == "")
            {
                MessageBox.Show("Pertanyaan tidak boleh kosong.");
                return;
            }

            bool sukses = false;

            try
            {
                if (modeEdit)
                {
                    sukses = ctrl.UpdateFeedback(oldTanggal,oldPertanyaan,tanggal,pertanyaan);
                }
                else
                {
                    sukses = ctrl.TambahFeedback(pertanyaan, tanggal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                sukses = false;
            }

            if (sukses)
            {
                MessageBox.Show(
                    modeEdit ? "Feedback berhasil diperbarui!" : "Feedback berhasil ditambahkan!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                new v_feedbackcustomer().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data.");
            }
        }

        public void LoadDataForEdit(string tanggal, string pertanyaan)
        {
            try
            {
                var dtControl = this.Controls.Find("datetimefeedback", true);
                if (dtControl.Length > 0 && DateTime.TryParse(tanggal, out DateTime parsed))
                {
                    var dt = dtControl[0] as DateTimePicker;
                    if (dt != null) dt.Value = parsed;
                }

                var rtControl = this.Controls.Find("richTextBoxpertanyaan", true);
                if (rtControl.Length > 0)
                {
                    var rt = rtControl[0] as RichTextBox;
                    if (rt != null) rt.Text = pertanyaan;
                }

                SetLabelIfExists("lblMode", "Edit Feedback");
                SetButtonTextIfExists("btnsimpan", "");
            }
            catch { }

            modeEdit = true;
            oldTanggal = tanggal;
            oldPertanyaan = pertanyaan;
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            new v_feedbackcustomer().Show();
            this.Close();
        }

        private void SetLabelIfExists(string labelName, string text)
        {
            var found = this.Controls.Find(labelName, true);
            if (found.Length > 0 && found[0] is Label lbl)
            {
                lbl.Text = text;
            }
        }

        private void SetButtonTextIfExists(string buttonName, string text)
        {
            var found = this.Controls.Find(buttonName, true);
            if (found.Length > 0 && found[0] is Button btn)
            {
                btn.Text = text;
            }
        }
    }
}
