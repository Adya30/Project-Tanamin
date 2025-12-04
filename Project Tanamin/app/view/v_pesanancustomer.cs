using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_pesanancustomer : Form
    {
        private readonly c_pesanan ctrl;
        private readonly int userId;

        public v_pesanancustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ctrl = new c_pesanan();

            if (c_user.CurrentUser == null)
            {
                MessageBox.Show("Sesi login berakhir. Silakan login ulang.");
                new v_login().Show();
                this.Close();
                return;
            }

            userId = c_user.CurrentUser.IdUser;
            LoadPesanan();
        }

        private void LoadPesanan()
        {
            var list = ctrl.GetPesananBelumSelesaiByUser(userId);

            DataTable dt = new DataTable();
            dt.Columns.Add("Waktu Transaksi");
            dt.Columns.Add("Nama Produk");
            dt.Columns.Add("Jumlah Transaksi");
            dt.Columns.Add("Harga Satuan");
            dt.Columns.Add("Subtotal");
            dt.Columns.Add("Alamat"); 
            dt.Columns.Add("Kategori");
            dt.Columns.Add("Pembayaran");
            dt.Columns.Add("Status Transaksi");

            foreach (var item in list)
            {
                int subtotal = item.detail.jumlah_transaksi * item.detail.HargaSatuan;

                dt.Rows.Add(
                    item.transaksi.tanggal_transaksi.ToString("dd-MM-yyyy"),
                    item.produk.NamaProduk,
                    item.detail.jumlah_transaksi,
                    item.detail.HargaSatuan,
                    subtotal,
                    item.transaksi.alamat,   
                    item.produk.NamaKategori,
                    item.transaksi.pembayaran,
                    item.transaksi.status_transaksi
                );
            }

            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.Columns["Jumlah Transaksi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Harga Satuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Waktu Transaksi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Status Transaksi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["Alamat"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;


        }

        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            new v_katalogcustomer().Show();
            this.Close();
        }

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {

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
    }
}