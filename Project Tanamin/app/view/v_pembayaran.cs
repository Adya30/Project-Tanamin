using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_pembayaran : Form
    {
        private int totalBelanja;
        private string selectedBank = "";
        private List<(m_produk produk, int jumlah)> keranjang;

        public v_pembayaran(List<(m_produk produk, int jumlah)> keranjangBelanja)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            keranjang = keranjangBelanja;
            totalBelanja = keranjang.Sum(x => x.produk.HargaSatuan * x.jumlah);
            labeltotal.Text = totalBelanja.ToString("N0", CultureInfo.CurrentCulture);
        }

        private void btnbri_Click(object sender, EventArgs e) => SetBank("BRI");
        private void btnbni_Click(object sender, EventArgs e) => SetBank("BNI");
        private void btnmandiri_Click(object sender, EventArgs e) => SetBank("Mandiri");
        private void btnbca_Click(object sender, EventArgs e) => SetBank("BCA");
        private void btnbtn_Click(object sender, EventArgs e) => SetBank("BTN");
        private void btnjatim_Click(object sender, EventArgs e) => SetBank("Bank Jatim");

        private void SetBank(string bank)
        {
            selectedBank = bank;
            MessageBox.Show($"Metode pembayaran: {bank} dipilih");
        }

        private void btnbayar_Click(object sender, EventArgs e)
        {
            if (keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedBank))
            {
                MessageBox.Show("Silakan pilih bank terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textboxdetailalamat.Text))
            {
                MessageBox.Show("Alamat tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxnominal.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out int nominal) || nominal < totalBelanja)
            {
                MessageBox.Show("Nominal pembayaran kurang atau tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin membayar total Rp {totalBelanja:N0} dengan bank {selectedBank}?",
                "Konfirmasi Pembayaran",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi != DialogResult.Yes)
                return;

            string alamatLengkap = $"{textboxdetailalamat.Text.Trim()}";
            var ctrlPembayaran = new c_Pembayaran();
            bool sukses = ctrlPembayaran.ProsesPembayaran(c_user.CurrentUser.IdUser, keranjang, selectedBank, alamatLengkap, "Diproses");

            if (!sukses)
            {
                MessageBox.Show("Gagal menyimpan transaksi! Pastikan stok cukup dan koneksi database tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Pembayaran berhasil! Pesanan sedang diproses.", "Sukses",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            keranjang.Clear();

            new v_katalogcustomer().Show();
            this.Close();
        }


        private void btnbatal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Batalkan pembayaran dan kembali?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new v_katalogcustomer().Show();
                this.Close();
            }
        }
    }
}