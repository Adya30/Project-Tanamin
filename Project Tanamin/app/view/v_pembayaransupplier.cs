using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_pembayaransupplier : Form
    {
        private int? userId;
        private List<(m_produk produk, int jumlah)> keranjang;
        private c_produk ctrlProduk;

        public v_pembayaransupplier()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public v_pembayaransupplier(int? idUser, List<(m_produk, int)> dataKeranjang, int totalItem)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            userId = idUser;
            keranjang = dataKeranjang;
            ctrlProduk = new c_produk();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }

        private void btnbayar_Click(object sender, EventArgs e)
        {
            string namaSupplier = namaspllier.Text.Trim();
            string nominalText = nominalpem.Text.Trim();


            if (string.IsNullOrWhiteSpace(namaSupplier))
            {
                MessageBox.Show("Nama supplier harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(nominalText, out decimal nominal) || nominal <= 0)
            {
                MessageBox.Show("Nominal harus berupa angka lebih besar dari 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ctrl = new c_PembayaranSupplier();

            int idPembelian = ctrl.ProsesPembayaranSupplier(
                namaSupplier,
                nominal,
                keranjang
            );

            if (idPembelian <= 0)
            {
                MessageBox.Show("Gagal menyimpan data pembelian!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idPembelian == -1)
            {
                MessageBox.Show(
                    "Nominal terlalu besar! Maksimal adalah 2.147.483.647.\nSilakan perbaiki input nominal.",
                    "Kesalahan Nominal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; 
            }

            MessageBox.Show(
                $"Pembelian berhasil diproses!",
                "Sukses",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            new v_supplier(userId).Show();
            this.Close();
        }
        private void btnbatal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Apakah Anda yakin ingin membatalkan pembayaran?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                new v_supplier(userId).Show();
                this.Close();
            }
        }
    }
}
