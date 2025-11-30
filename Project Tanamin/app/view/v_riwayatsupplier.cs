using Project_Tanamin.app.controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_riwayatsupplier : Form
    {
        private readonly c_supplier ctrl;

        public v_riwayatsupplier()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ctrl = new c_supplier();
            LoadRiwayatSupplier();
        }

        private void LoadRiwayatSupplier()
        {
            var list = ctrl.GetRiwayatPembelian();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tanggal");
            dt.Columns.Add("Nama Supplier");
            dt.Columns.Add("Produk");
            dt.Columns.Add("Jumlah Beli");
            dt.Columns.Add("Nominal Pembayaran");

            foreach (var item in list)
            {
                dt.Rows.Add(
                    item.pembelian.IdPembelian,
                    item.pembelian.TanggalPembelian.ToString("dd/MM/yyyy"),
                    item.pembelian.NamaSupplier,
                    item.produk.NamaProduk,
                    item.detail.JumlahPembelian,
                    item.pembelian.PembayaranSupplier
                );
            }

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 248, 198);
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

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
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_login().Show();
                this.Close();
            }
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            new v_riwayatadmin().Show();
            this.Close();
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            // tetap di sini
        }
    }
}
