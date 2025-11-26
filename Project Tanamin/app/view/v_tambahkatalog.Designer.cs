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
            btnlogout = new Button();
            btnprofiladmin = new Button();
            btnfeedbackadmin = new Button();
            btnriwayatadmin = new Button();
            btnpesananadmin = new Button();
            btnkatalogadmin = new Button();
            ((System.ComponentModel.ISupportInitialize)btnpicture).BeginInit();
            SuspendLayout();
            // 
            // btnpicture
            // 
            btnpicture.BackgroundImage = (Image)resources.GetObject("btnpicture.BackgroundImage");
            btnpicture.Location = new Point(510, 209);
            btnpicture.Name = "btnpicture";
            btnpicture.Size = new Size(385, 385);
            btnpicture.TabIndex = 0;
            btnpicture.TabStop = false;
            btnpicture.Click += btnpicture_Click;
            // 
            // nama_produk
            // 
            nama_produk.BorderStyle = BorderStyle.None;
            nama_produk.Font = new Font("Segoe UI", 13F);
            nama_produk.Location = new Point(1002, 267);
            nama_produk.Name = "nama_produk";
            nama_produk.Size = new Size(676, 35);
            nama_produk.TabIndex = 1;
            // 
            // stok
            // 
            stok.BorderStyle = BorderStyle.None;
            stok.Font = new Font("Segoe UI", 13F);
            stok.Location = new Point(1010, 540);
            stok.Name = "stok";
            stok.Size = new Size(110, 35);
            stok.TabIndex = 2;
            // 
            // deskripsi
            // 
            deskripsi.BorderStyle = BorderStyle.None;
            deskripsi.Font = new Font("Segoe UI", 13F);
            deskripsi.Location = new Point(532, 704);
            deskripsi.Name = "deskripsi";
            deskripsi.Size = new Size(1126, 274);
            deskripsi.TabIndex = 3;
            deskripsi.Text = "";
            // 
            // comboBoxjenisproduk
            // 
            comboBoxjenisproduk.Font = new Font("Segoe UI", 13F);
            comboBoxjenisproduk.FormattingEnabled = true;
            comboBoxjenisproduk.Items.AddRange(new object[] { "Obat Tanaman", "Pupuk" });
            comboBoxjenisproduk.Location = new Point(995, 400);
            comboBoxjenisproduk.Name = "comboBoxjenisproduk";
            comboBoxjenisproduk.Size = new Size(690, 44);
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
            harga.BorderStyle = BorderStyle.None;
            harga.Font = new Font("Segoe UI", 13F);
            harga.Location = new Point(1195, 537);
            harga.Name = "harga";
            harga.Size = new Size(469, 35);
            harga.TabIndex = 19;
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Cursor = Cursors.Hand;
            btnlogout.Location = new Point(24, 934);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(339, 65);
            btnlogout.TabIndex = 25;
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Cursor = Cursors.Hand;
            btnprofiladmin.Location = new Point(24, 523);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(339, 65);
            btnprofiladmin.TabIndex = 24;
            btnprofiladmin.UseVisualStyleBackColor = true;
            btnprofiladmin.Click += btnprofiladmin_Click;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Cursor = Cursors.Hand;
            btnfeedbackadmin.Location = new Point(24, 442);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(339, 65);
            btnfeedbackadmin.TabIndex = 23;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            btnfeedbackadmin.Click += btnfeedbackadmin_Click;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Cursor = Cursors.Hand;
            btnriwayatadmin.Location = new Point(24, 361);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(339, 65);
            btnriwayatadmin.TabIndex = 22;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            btnriwayatadmin.Click += btnriwayatadmin_Click;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Cursor = Cursors.Hand;
            btnpesananadmin.Location = new Point(24, 278);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(339, 65);
            btnpesananadmin.TabIndex = 21;
            btnpesananadmin.UseVisualStyleBackColor = true;
            btnpesananadmin.Click += btnpesananadmin_Click;
            // 
            // btnkatalogadmin
            // 
            btnkatalogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalogadmin.BackgroundImage");
            btnkatalogadmin.Cursor = Cursors.Hand;
            btnkatalogadmin.Location = new Point(24, 196);
            btnkatalogadmin.Name = "btnkatalogadmin";
            btnkatalogadmin.Size = new Size(339, 65);
            btnkatalogadmin.TabIndex = 20;
            btnkatalogadmin.UseVisualStyleBackColor = true;
            btnkatalogadmin.Click += btnkatalogadmin_Click;
            // 
            // v_tambahkatalog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnlogout);
            Controls.Add(btnprofiladmin);
            Controls.Add(btnfeedbackadmin);
            Controls.Add(btnriwayatadmin);
            Controls.Add(btnpesananadmin);
            Controls.Add(btnkatalogadmin);
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
        private Button btnlogout;
        private Button btnprofiladmin;
        private Button btnfeedbackadmin;
        private Button btnriwayatadmin;
        private Button btnpesananadmin;
        private Button btnkatalogadmin;
    }
}