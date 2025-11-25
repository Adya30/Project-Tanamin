using Project_Tanamin.app.controller;
using Project_Tanamin.app.model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_Tanamin.app.view
{
    public partial class v_tambahkatalog : Form
    {
        private c_produk ctrlProduk;
        private v_katalogadmin parentForm;
        private m_produk editProduk;
        private byte[]? fotoByte = null;  

        public v_tambahkatalog(v_katalogadmin parent, m_produk? produk = null)
        {
            InitializeComponent();
            parentForm = parent;
            ctrlProduk = new c_produk();
            editProduk = produk;

            comboBoxjenisproduk.Items.Clear();
            comboBoxjenisproduk.Items.Add("Obat Tanaman");
            comboBoxjenisproduk.Items.Add("Pupuk");

            btnpicture.Text = "";
            btnpicture.SizeMode = PictureBoxSizeMode.Zoom;
            btnpicture.BorderStyle = BorderStyle.FixedSingle;

            // Jika edit
            if (editProduk != null)
            {
                nama_produk.Text = editProduk.NamaProduk;
                comboBoxjenisproduk.SelectedItem = editProduk.NamaKategori;
                stok.Text = editProduk.StokProduk.ToString();
                harga.Text = editProduk.HargaSatuan.ToString();
                deskripsi.Text = editProduk.Deskripsi;

                if (editProduk.FotoProduk != null)
                {
                    try
                    {
                        using var ms = new MemoryStream(editProduk.FotoProduk);
                        btnpicture.Image = new Bitmap(ms);
                        fotoByte = editProduk.FotoProduk;
                    }
                    catch
                    {
                        btnpicture.Image = null;
                        fotoByte = null;
                    }
                }
            }
        }

        private void btnpicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        var img = Image.FromStream(fs);
                        btnpicture.Image = new Bitmap(img);
                    }
                    fotoByte = File.ReadAllBytes(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Gagal memuat gambar.");
                    btnpicture.Image = null;
                    fotoByte = null;
                }
            }
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nama_produk.Text) || comboBoxjenisproduk.SelectedItem == null)
            {
                MessageBox.Show("Nama produk dan kategori harus diisi!");
                return;
            }

            if (!int.TryParse(stok.Text, out int stokValue) || stokValue < 0)
            {
                MessageBox.Show("Stok harus berupa angka bulat >= 0");
                return;
            }

            if (!int.TryParse(harga.Text, out int hargaValue) || hargaValue < 0)
            {
                MessageBox.Show("Harga harus berupa angka bulat >= 0");
                return;
            }

            var produk = editProduk ?? new m_produk();
            produk.NamaProduk = nama_produk.Text;
            produk.NamaKategori = comboBoxjenisproduk.SelectedItem.ToString();
            produk.StokProduk = stokValue;
            produk.HargaSatuan = hargaValue;
            produk.Deskripsi = deskripsi.Text;
            produk.FotoProduk = fotoByte;

            bool success = editProduk == null ? ctrlProduk.AddProduk(produk) : ctrlProduk.UpdateProduk(produk);

            if (success)
            {
                MessageBox.Show("Data berhasil disimpan");
                parentForm.LoadKatalog();
                this.Close();
                parentForm.Show();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data");
            }
        }


        private void btnbatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
