using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_katalogcustomer : Form
    {
        private c_produk ctrlProduk;
        private int? userId;

        // Enkapsulasi keranjang
        private List<(m_produk produk, int jumlah)> keranjang;

        public v_katalogcustomer(int? idUser = null)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            ctrlProduk = new c_produk();
            userId = idUser;
            keranjang = new List<(m_produk, int)>();

            LoadKatalog();
            UpdateRingkasan();
        }

        // =====================================================================
        // LOAD KATALOG
        // =====================================================================
        public void LoadKatalog()
        {
            panelflow.Controls.Clear();

            var listProduk = ctrlProduk.GetProdukList();

            foreach (var p in listProduk)
            {
                var card = CreateCard(p);
                panelflow.Controls.Add(card);
            }
        }

        // =====================================================================
        // BUAT CARD PRODUK
        // =====================================================================
        private Panel CreateCard(m_produk produk)
        {
            Panel card = new Panel
            {
                Width = 260,
                Height = 380,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            PictureBox pic = new PictureBox
            {
                Width = card.Width - 20,
                Height = 140,
                Top = 10,
                Left = 10,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (produk.FotoProduk != null)
            {
                using (var ms = new MemoryStream(produk.FotoProduk))
                {
                    pic.Image = Image.FromStream(ms);
                }
            }

            Label lblNama = new Label
            {
                Text = produk.NamaProduk,
                Top = pic.Bottom + 10,
                Left = 10,
                Width = card.Width - 20,
                Font = new Font("Arial", 11, FontStyle.Bold),
                AutoEllipsis = true
            };

            Label lblStok = new Label
            {
                Text = "Stok: " + produk.StokProduk,
                Top = lblNama.Bottom + 5,
                Left = 10,
                Width = card.Width - 20,
                ForeColor = produk.StokProduk == 0 ? Color.Red : Color.Black
            };

            Label lblHarga = new Label
            {
                Text = "Harga: Rp." + produk.HargaSatuan,
                Top = lblStok.Bottom + 5,
                Left = 10,
                Width = card.Width - 20,
                ForeColor = Color.DarkGreen,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblDeskripsi = new Label
            {
                Text = produk.Deskripsi,
                Top = lblHarga.Bottom + 5,
                Left = 10,
                Width = card.Width - 20,
                Height = 50,
                AutoSize = false,
                MaximumSize = new Size(card.Width - 20, 50),
                Font = new Font("Arial", 9),
                ForeColor = Color.DimGray
            };

            card.Controls.Add(lblDeskripsi);

            card.Controls.Add(pic);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblStok);
            card.Controls.Add(lblHarga);

            Button btnPesan = new Button
            {
                Text = "Pesan",
                Width = 120,
                Height = 35,
                Top = card.Height - 60,
                Left = (card.Width - 120) / 2,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnPesan.Click += (s, e) =>
            {
                if (produk.StokProduk <= 0)
                {
                    MessageBox.Show("Maaf, stok produk habis!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TambahKeKeranjang(produk);
                UpdateRingkasan();
            };

            card.Controls.Add(btnPesan);

            return card;
        }

        // Abstraksi → method khusus
        private void TambahKeKeranjang(m_produk produk)
        {
            var idx = keranjang.FindIndex(x => x.produk.IdProduk == produk.IdProduk);
            if (idx >= 0)
            {
                var item = keranjang[idx];
                if (item.jumlah + 1 <= produk.StokProduk)
                    keranjang[idx] = (item.produk, item.jumlah + 1);
                else
                    MessageBox.Show("Jumlah melebihi stok tersedia!");
            }
            else
            {
                keranjang.Add((produk, 1));
            }
        }

        // =====================================================================
        // PANEL RINGKASAN (TOTAL)
        // =====================================================================
        private void UpdateRingkasan()
        {
            panelRingkasan.Controls.Clear();

            Panel panelItems = new Panel
            {
                AutoScroll = true,
                Left = 0,
                Top = 0,
                Width = panelRingkasan.Width - 5,
                Height = panelRingkasan.Height - 120,
                BorderStyle = BorderStyle.None
            };

            panelRingkasan.Controls.Add(panelItems);

            if (keranjang.Count == 0)
            {
                Label lblKosong = new Label
                {
                    Text = "Keranjang kosong",
                    Top = 10,
                    Left = 10,
                    Width = 300,
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    ForeColor = Color.Gray
                };

                panelItems.Controls.Add(lblKosong);
                return;
            }

            int top = 10;
            int total = HitungTotal();

            foreach (var item in keranjang)
            {
                int subtotal = item.produk.HargaSatuan * item.jumlah;

                Label lbl = new Label
                {
                    Text = $"{item.produk.NamaProduk} x {item.jumlah} = Rp {subtotal}",
                    Top = top,
                    Left = 10,
                    Width = panelItems.Width - 35
                };

                panelItems.Controls.Add(lbl);
                top += 25;
            }

            int padding = 10;

            Label lblTotal = new Label
            {
                Text = $"TOTAL = Rp {total}",
                Left = 10,
                Width = 400,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Top = panelRingkasan.Height - 110 - padding
            };

            panelRingkasan.Controls.Add(lblTotal);

            // Button batal
            Button btnBatal = new Button
            {
                Text = "Batal",
                Width = 120,
                Height = 40,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Left = 10,
                Top = panelRingkasan.Height - 60
            };

            btnBatal.Click += (s, e) =>
            {
                if (MessageBox.Show("Batalkan semua pesanan?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    keranjang.Clear();
                    UpdateRingkasan();
                }
            };

            panelRingkasan.Controls.Add(btnBatal);
        }

        private int HitungTotal()
        {
            int total = 0;
            foreach (var item in keranjang)
                total += item.produk.HargaSatuan * item.jumlah;
            return total;
        }

        // =====================================================================
        // BUTTON BAYAR → masuk ke v_pembayaran
        // =====================================================================
        private void btnbayar_Click(object sender, EventArgs e)
        {
            if (keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!");
                return;
            }

            int total = HitungTotal();

            v_pembayaran bayar = new v_pembayaran(total);
            bayar.Show();
            this.Close();
        }

        // =====================================================================
        // MENU
        // =====================================================================
        private void btnkatalaogcustomer_Click(object sender, EventArgs e)
        {
            new v_katalogcustomer(userId).Show();
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

        private void btnpesanancustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
