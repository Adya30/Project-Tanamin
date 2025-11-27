using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_feedbackcustomer : Form
    {
        private readonly c_feedback ctrl;

        public v_feedbackcustomer()
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
            dataGridView1.Columns.Add("Kritik Saran", "Pertanyaan");
            dataGridView1.Columns.Add("Respon", "Respon");

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Width = 80;
            dataGridView1.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Hapus";
            btnDelete.Text = "Hapus";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 80;
            dataGridView1.Columns.Add(btnDelete);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public void LoadFeedback()
        {
            dataGridView1.Rows.Clear();

            List<Feedback> list = ctrl.GetCustomerFeedback();

            foreach (var fb in list)
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
            if (e.RowIndex < 0) return;

            string tanggal = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
            string pertanyaan = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
            string respon = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();

            if (e.ColumnIndex == 3)
            {
                if (!string.IsNullOrEmpty(respon))
                {
                    MessageBox.Show("Pertanyaan sudah dibalas, tidak dapat diedit.", "Tidak Bisa Edit",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                v_tambahfeedback editForm = new v_tambahfeedback();
                editForm.LoadDataForEdit(tanggal, pertanyaan);
                editForm.Show();
                this.Hide();
            }

            if (e.ColumnIndex == 4)
            {
                if (!string.IsNullOrEmpty(respon))
                {
                    MessageBox.Show("Pertanyaan sudah dibalas, tidak dapat dihapus.", "Tidak Bisa Hapus",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Hapus pertanyaan ini?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool sukses = ctrl.DeleteFeedback(tanggal, pertanyaan);

                    if (sukses)
                    {
                        MessageBox.Show("Berhasil dihapus!");
                        LoadFeedback();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus data.");
                    }
                }
            }
        }

        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            new v_katalogcustomer().Show();
            this.Close();
        }

        private int? userId = c_user.CurrentUser?.IdUser; 
        private List<(m_produk produk, int jumlah)> keranjangSementara = new List<(m_produk, int)>(); // keranjang sementara

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {
            var formPesanan = new v_pesanancustomer();
            formPesanan.Show();
            this.Close();
        }

        private void btnriwayatcustomer_Click(object sender, EventArgs e)
        {
            new v_riwayatcustomer().Show();
            this.Close();
        }

        private void btnfeedbackcustomer_Click(object sender, EventArgs e)
        {
        }

        private void btnprofilcustomer_Click(object sender, EventArgs e)
        {
            new v_profilcustomer().Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_login().Show();
                this.Close();
            }
        }

        private void btnbuatfeedback_Click(object sender, EventArgs e)
        {
            new v_tambahfeedback().Show();
            this.Hide();
        }

        // UI Modern
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

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 238);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 175, 71);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.RowTemplate.Height = 35;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
        }
    }
}
