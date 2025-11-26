using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Data;
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
            var list = ctrl.GetPesananByUser(userId, "Diproses");

            DataTable dt = new DataTable();
            dt.Columns.Add("Nama Produk");
            dt.Columns.Add("Jumlah Transaksi");
            dt.Columns.Add("Status Transaksi");
            dt.Columns.Add("Pembayaran");
            dt.Columns.Add("Harga Satuan");
            dt.Columns.Add("Subtotal");
            dt.Columns.Add("Deskripsi");
            dt.Columns.Add("Kategori");

            foreach (var item in list)
            {
                int subtotal = item.detail.jumlah_transaksi * item.detail.harga_satuan;

                dt.Rows.Add(
                    item.produk.NamaProduk,
                    item.detail.jumlah_transaksi,
                    item.transaksi.status_transaksi,
                    item.transaksi.pembayaran,
                    item.detail.harga_satuan,
                    subtotal,
                    item.produk.Deskripsi,
                    item.produk.NamaKategori
                );
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
