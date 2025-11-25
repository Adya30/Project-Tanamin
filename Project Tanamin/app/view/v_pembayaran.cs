using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_pembayaran : Form
    {
        private int totalBelanja;
        private string selectedBank = "";

        public v_pembayaran(int total)
        {
            InitializeComponent();
            totalBelanja = total;
            // Tampilkan dengan formatting ribuan
            labeltotal.Text = totalBelanja.ToString("N0", CultureInfo.CurrentCulture);
            labelkembalian.Text = "-";
        }

        // ===============================
        // INPUT NOMINAL & KEMBALIAN
        // ===============================
        private void textBoxnominal_TextChanged(object sender, EventArgs e)
        {
            var txt = textBoxnominal.Text?.Trim();
            if (string.IsNullOrEmpty(txt))
            {
                labelkembalian.Text = "-";
                return;
            }

            // Terima angka dengan ribuan seperti "120.000" atau "120000"
            if (int.TryParse(txt, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out int nominal))
            {
                if (nominal >= totalBelanja)
                {
                    int kembalian = nominal - totalBelanja;
                    labelkembalian.Text = kembalian.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    labelkembalian.Text = "Nominal kurang!";
                }
            }
            else
            {
                labelkembalian.Text = "-";
            }
        }

        // ===============================
        // PILIHAN BANK
        // ===============================
        private void btnbri_Click(object sender, EventArgs e)
        {
            selectedBank = "BRI";
            MessageBox.Show("Metode pembayaran: BRI dipilih");
        }

        private void btnbni_Click(object sender, EventArgs e)
        {
            selectedBank = "BNI";
            MessageBox.Show("Metode pembayaran: BNI dipilih");
        }

        private void btnmandiri_Click(object sender, EventArgs e)
        {
            selectedBank = "Mandiri";
            MessageBox.Show("Metode pembayaran: Mandiri dipilih");
        }

        private void btnbca_Click(object sender, EventArgs e)
        {
            selectedBank = "BCA";
            MessageBox.Show("Metode pembayaran: BCA dipilih");
        }

        private void btnbtn_Click(object sender, EventArgs e)
        {
            selectedBank = "BTN";
            MessageBox.Show("Metode pembayaran: BTN dipilih");
        }

        private void btnjatim_Click(object sender, EventArgs e)
        {
            selectedBank = "Bank Jatim";
            MessageBox.Show("Metode pembayaran: Bank Jatim dipilih");
        }

        // ===============================
        // BUTTON BAYAR
        // ===============================
        private void btnbayar_Click(object sender, EventArgs e)
        {
            //// Validasi form
            //if (string.IsNullOrWhiteSpace(textBoxnominal.Text) ||
            //    string.IsNullOrWhiteSpace(textboxdetailalamat.Text) ||
            //    string.IsNullOrWhiteSpace(textBoxdesa.Text) ||
            //    string.IsNullOrWhiteSpace(textBoxkecamatan.Text))
            //{
            //    MessageBox.Show("Semua form harus diisi!", "Peringatan",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrEmpty(selectedBank))
            //{
            //    MessageBox.Show("Silakan pilih bank terlebih dahulu!",
            //        "Metode Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // parsing nominal
            //if (!int.TryParse(textBoxnominal.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out int nominal) || nominal < totalBelanja)
            //{
            //    MessageBox.Show("Nominal pembayaran kurang atau tidak valid!", "Peringatan",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Buat alamat lengkap
            //string alamatLengkap = $"{textboxdetailalamat.Text.Trim()}, Desa {textBoxdesa.Text.Trim()}, Kec. {textBoxkecamatan.Text.Trim()}, Jember";

            // Panggil controller pembayaran
            //var ctrlPembayaran = new c_Pembayaran();
            //bool sukses = ctrlPembayaran.ProsesPembayaran(Program.userLoginId, Program.KeranjangBelanja, selectedBank, alamatLengkap, "Diantar");

            //    if (!sukses)
            //    {
            //        MessageBox.Show("Gagal menyimpan transaksi! Pastikan stok cukup dan koneksi database tersedia.", "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    MessageBox.Show("Pembayaran berhasil! Pesanan sedang diproses.",
            //        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    // Bersihkan keranjang
            //    Program.KeranjangBelanja.Clear();

            //    // Buka halaman pesanan customer
            //    var v = new v_pesanancustomer();
            //    v.Show();
            //    this.Close();
        }

        // ===============================
        // BUTTON BATAL
        // ===============================
        private void btnbatal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Batalkan pembayaran dan kembali?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // kembali ke katalog (asumsi ada form v_katalogcustomer)
                new v_katalogcustomer().Show();
                this.Close();
            }
        }
    }
}
