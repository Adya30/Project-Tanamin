using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_supplier : Form  
    {
        private readonly c_produk ctrlProduk;
        private int? userId;
        private List<(m_produk produk, int jumlah)> keranjang;

        public v_supplier(int? idUser = null)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;

            ctrlProduk = new c_produk();
            userId = idUser;
            keranjang = new List<(m_produk, int)>();

            LoadKatalog();
            UpdateRingkasan();
        }

        public void LoadKatalog()
        {
            flowLayoutPanel1.Controls.Clear();
            var listProduk = ctrlProduk.GetProdukList();

            foreach (var p in listProduk)
            {
                var card = CreateCard(p);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private Panel CreateCard(m_produk produk)
        {
            Panel card = new Panel
            {
                Width = 260,
                Height = 350,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            PictureBox pic = new PictureBox
            {
                Width = card.Width - 20,
                Height = 150,
                Top = 10,
                Left = 10,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (produk.FotoProduk != null)
            {
                try
                {
                    using (var ms = new MemoryStream(produk.FotoProduk))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                }
                catch { }
            }

            Label lblNama = new Label
            {
                Text = produk.NamaProduk,
                Top = pic.Bottom + 10,
                Left = 10,
                Width = card.Width - 20,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoEllipsis = true
            };

            Label lblKategori = new Label
            {
                Text = produk.NamaKategori ?? "",
                Top = lblNama.Bottom + 3, 
                Left = 10,
                Width = card.Width - 20,
                Font = new Font("Arial", 9, FontStyle.Italic),
                ForeColor = Color.DarkGreen,
                AutoEllipsis = true
            };

            Label lblDeskripsi = new Label
            {
                Text = produk.Deskripsi ?? "",
                Top = lblKategori.Bottom + 5,
                Left = 10,
                Width = card.Width - 20,
                Height = 50,
                AutoSize = false,
                MaximumSize = new Size(card.Width - 20, 50),
                Font = new Font("Arial", 9),
                ForeColor = Color.DimGray
            };

            Button btnPesan = new Button
            {
                Text = "Pesan",
                Width = 120,
                Height = 35,
                Top = card.Height - 55,
                Left = (card.Width - 120) / 2,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };


            btnPesan.Click += (s, e) =>
            {
                var idx = keranjang.FindIndex(x => x.produk.IdProduk == produk.IdProduk);
                if (idx >= 0)
                {
                    var item = keranjang[idx];
                    keranjang[idx] = (item.produk, item.jumlah + 1);
                }
                else
                {
                    keranjang.Add((produk, 1));
                }

                UpdateRingkasan();
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblKategori);
            card.Controls.Add(lblDeskripsi);
            card.Controls.Add(btnPesan);

            return card;
        }

        private void UpdateRingkasan()
        {
            panel2.Controls.Clear();

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
                panel2.Controls.Add(lblKosong);
                return;
            }

            int top = 10;
            foreach (var item in keranjang.ToArray())
            {
                Panel row = new Panel
                {
                    Width = panel2.Width - 25,
                    Height = 40,
                    Left = 5,
                    Top = top
                };

                Label lblNama = new Label
                {
                    Text = item.produk.NamaProduk,
                    Left = 5,
                    Top = 10,
                    Width = 220,
                    Font = new Font("Arial", 9)
                };
                row.Controls.Add(lblNama);

                Button btnMin = new Button
                {
                    Text = "-",
                    Width = 30,
                    Height = 30,
                    Left = 230,
                    Top = 5,
                    Font = new Font("Arial", 9)
                };
                btnMin.Click += (s, e) => { KurangiQty(item.produk); };
                row.Controls.Add(btnMin);

                Label lblJumlah = new Label
                {
                    Text = item.jumlah.ToString(),
                    Left = 265,
                    Top = 10,
                    Width = 30,
                    Font = new Font("Arial", 9),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                row.Controls.Add(lblJumlah);

                Button btnPlus = new Button
                {
                    Text = "+",
                    Width = 30,
                    Height = 30,
                    Left = 300,
                    Top = 5,
                    Font = new Font("Arial", 9)
                };
                btnPlus.Click += (s, e) => { TambahQty(item.produk); };
                row.Controls.Add(btnPlus);

                panel2.Controls.Add(row);
                top += 45;

                Button btnBatal = new Button
                {
                    Text = "Batal",
                    Width = 120,
                    Height = 40,
                    BackColor = Color.IndianRed,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Left = 10,
                    Top = panel2.Height - 60
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

                panel2.Controls.Add(btnBatal);
            }
        }

        private void TambahQty(m_produk produk)
        {
            var idx = keranjang.FindIndex(x => x.produk.IdProduk == produk.IdProduk);
            if (idx >= 0)
            {
                var item = keranjang[idx];
                keranjang[idx] = (item.produk, item.jumlah + 1);
                UpdateRingkasan();
            }
        }

        private void KurangiQty(m_produk produk)
        {
            var idx = keranjang.FindIndex(x => x.produk.IdProduk == produk.IdProduk);
            if (idx >= 0)
            {
                var item = keranjang[idx];
                if (item.jumlah - 1 <= 0)
                    keranjang.RemoveAt(idx);
                else
                    keranjang[idx] = (item.produk, item.jumlah - 1);

                UpdateRingkasan();
            }
        }

        private List<(m_produk, int)> ConvertKeranjangSupplier() => new List<(m_produk, int)>(keranjang);

        private int GetTotalItem()
        {
            int total = 0;
            foreach (var x in keranjang) total += x.jumlah;
            return total;
        }

        private void btncheckoutcustomer_Click(object sender, EventArgs e)
        {
            if (keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang kosong!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dataKeranjang = ConvertKeranjangSupplier();
            int totalItem = GetTotalItem();

            v_pembayaransupplier bayarForm = new v_pembayaransupplier(userId, dataKeranjang, totalItem);
            bayarForm.FormClosed += (s, args) =>
            {
                LoadKatalog();
            };
            bayarForm.Show();
            this.Hide();
        }

        private void btnkembaliadmin_Click(object sender, EventArgs e)
        {
            new v_katalogadmin().Show();
            this.Close();
        }
    }
}
