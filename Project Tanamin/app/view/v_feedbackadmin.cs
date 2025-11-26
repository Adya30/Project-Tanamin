using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_feedbackadmin : Form
    {
        private readonly c_feedback ctrl;
        private List<Feedback> feedbackList;

        public v_feedbackadmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            ctrl = new c_feedback();

            ApplyModernStyle();
            SetupDataGridView();
            LoadFeedback();

            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void SetupDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Tanggal", "Tanggal");
            dataGridView1.Columns.Add("Pertanyaan", "Pertanyaan");
            dataGridView1.Columns.Add("Respon", "Respon");

            DataGridViewButtonColumn btnRespon = new DataGridViewButtonColumn();
            btnRespon.HeaderText = "Respon";
            btnRespon.Text = "Respon";
            btnRespon.UseColumnTextForButtonValue = true;
            btnRespon.Width = 80;
            dataGridView1.Columns.Add(btnRespon);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LoadFeedback()
        {
            dataGridView1.Rows.Clear();

            feedbackList = ctrl.GetAllFeedback(); // Ambil semua feedback

            foreach (var fb in feedbackList)
            {
                dataGridView1.Rows.Add(
                    fb.tanggal_feedback.ToString("yyyy-MM-dd"),
                    fb.pertanyaan,
                    fb.respon ?? ""
                );
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 3) return; // Hanya tombol Respon

            Feedback fb = feedbackList[e.RowIndex];

            if (!string.IsNullOrEmpty(fb.respon))
            {
                MessageBox.Show("Feedback sudah direspon.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Buka form respon admin
            var formRespon = new v_responfeedback();
            formRespon.LoadFeedbackForResponse(fb.id_feedback, fb.tanggal_feedback.ToString("yyyy-MM-dd"), fb.pertanyaan);
            formRespon.FormClosed += (s, ev) => LoadFeedback(); // Refresh setelah form respon ditutup
            formRespon.ShowDialog();
        }

        // ================= NAVIGASI =================
        private void btnkatalogadmin_Click(object sender, EventArgs e)
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

        private void btnfeedbackadmin_Click(object sender, EventArgs e) { }

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

        // ================= STYLE MODERN =================
        private void ApplyModernStyle()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113); // hijau
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 238);

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(220, 240, 220);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 175, 71);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.RowTemplate.Height = 35;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
        }
    }
}
