namespace Project_Tanamin.app.view
{
    partial class v_tambahkatalog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_tambahkatalog));
            btnpicture = new PictureBox();
            nama_produk = new TextBox();
            stok = new TextBox();
            deskripsi = new RichTextBox();
            comboBoxjenisproduk = new ComboBox();
            btnbatal = new Button();
            btnsimpan = new Button();
            harga = new TextBox();
            ((System.ComponentModel.ISupportInitialize)btnpicture).BeginInit();
            SuspendLayout();
            // 
            // btnpicture
            // 
            btnpicture.BackgroundImage = (Image)resources.GetObject("btnpicture.BackgroundImage");
            btnpicture.Location = new Point(443, 220);
            btnpicture.Name = "btnpicture";
            btnpicture.Size = new Size(418, 412);
            btnpicture.TabIndex = 0;
            btnpicture.TabStop = false;
            btnpicture.Click += btnpicture_Click;
            // 
            // nama_produk
            // 
            nama_produk.Font = new Font("Segoe UI", 13F);
            nama_produk.Location = new Point(942, 265);
            nama_produk.Name = "nama_produk";
            nama_produk.Size = new Size(656, 42);
            nama_produk.TabIndex = 1;
            // 
            // stok
            // 
            stok.Font = new Font("Segoe UI", 13F);
            stok.Location = new Point(942, 501);
            stok.Name = "stok";
            stok.Size = new Size(188, 42);
            stok.TabIndex = 2;
            // 
            // deskripsi
            // 
            deskripsi.Location = new Point(942, 734);
            deskripsi.Name = "deskripsi";
            deskripsi.Size = new Size(656, 235);
            deskripsi.TabIndex = 3;
            deskripsi.Text = "";
            // 
            // comboBoxjenisproduk
            // 
            comboBoxjenisproduk.Font = new Font("Segoe UI", 13F);
            comboBoxjenisproduk.FormattingEnabled = true;
            comboBoxjenisproduk.Items.AddRange(new object[] { "Obat Tanaman", "Pupuk" });
            comboBoxjenisproduk.Location = new Point(942, 388);
            comboBoxjenisproduk.Name = "comboBoxjenisproduk";
            comboBoxjenisproduk.Size = new Size(312, 44);
            comboBoxjenisproduk.TabIndex = 4;
            // 
            // btnbatal
            // 
            btnbatal.BackgroundImage = (Image)resources.GetObject("btnbatal.BackgroundImage");
            btnbatal.Cursor = Cursors.Hand;
            btnbatal.Location = new Point(1670, 48);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(203, 63);
            btnbatal.TabIndex = 18;
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // btnsimpan
            // 
            btnsimpan.BackgroundImage = (Image)resources.GetObject("btnsimpan.BackgroundImage");
            btnsimpan.Cursor = Cursors.Hand;
            btnsimpan.Location = new Point(1420, 48);
            btnsimpan.Name = "btnsimpan";
            btnsimpan.Size = new Size(203, 63);
            btnsimpan.TabIndex = 17;
            btnsimpan.UseVisualStyleBackColor = true;
            btnsimpan.Click += btnsimpan_Click;
            // 
            // harga
            // 
            harga.Font = new Font("Segoe UI", 13F);
            harga.Location = new Point(942, 626);
            harga.Name = "harga";
            harga.Size = new Size(340, 42);
            harga.TabIndex = 19;
            // 
            // v_tambahkatalog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(harga);
            Controls.Add(btnbatal);
            Controls.Add(btnsimpan);
            Controls.Add(comboBoxjenisproduk);
            Controls.Add(deskripsi);
            Controls.Add(stok);
            Controls.Add(nama_produk);
            Controls.Add(btnpicture);
            Name = "v_tambahkatalog";
            Text = "v_tambahkatalog";
            ((System.ComponentModel.ISupportInitialize)btnpicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btnpicture;
        private TextBox nama_produk;
        private TextBox stok;
        private RichTextBox deskripsi;
        private ComboBox comboBoxjenisproduk;
        private Button btnbatal;
        private Button btnsimpan;
        private TextBox harga;
    }
}