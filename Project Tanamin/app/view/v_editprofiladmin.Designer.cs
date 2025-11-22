namespace Project_Tanamin.app.view
{
    partial class v_editprofiladmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_editprofiladmin));
            btnlogout = new Button();
            btnprofiladmin = new Button();
            btnfeedbackadmin = new Button();
            btnriwayatadmin = new Button();
            btnpesananadmin = new Button();
            btnkatalaogadmin = new Button();
            username = new TextBox();
            password = new TextBox();
            konfirmasipassword = new TextBox();
            btnsimpan = new Button();
            btnbatal = new Button();
            SuspendLayout();
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Cursor = Cursors.Hand;
            btnlogout.Location = new Point(23, 937);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(340, 64);
            btnlogout.TabIndex = 11;
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Cursor = Cursors.Hand;
            btnprofiladmin.Location = new Point(23, 523);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(340, 64);
            btnprofiladmin.TabIndex = 10;
            btnprofiladmin.UseVisualStyleBackColor = true;
            btnprofiladmin.Click += btnprofiladmin_Click;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Cursor = Cursors.Hand;
            btnfeedbackadmin.Location = new Point(23, 444);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(340, 64);
            btnfeedbackadmin.TabIndex = 9;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            btnfeedbackadmin.Click += btnfeedbackadmin_Click;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Cursor = Cursors.Hand;
            btnriwayatadmin.Location = new Point(23, 362);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(340, 64);
            btnriwayatadmin.TabIndex = 8;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            btnriwayatadmin.Click += btnriwayatadmin_Click;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Cursor = Cursors.Hand;
            btnpesananadmin.Location = new Point(23, 281);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(340, 64);
            btnpesananadmin.TabIndex = 7;
            btnpesananadmin.UseVisualStyleBackColor = true;
            btnpesananadmin.Click += btnpesananadmin_Click;
            // 
            // btnkatalaogadmin
            // 
            btnkatalaogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalaogadmin.BackgroundImage");
            btnkatalaogadmin.Cursor = Cursors.Hand;
            btnkatalaogadmin.Location = new Point(23, 196);
            btnkatalaogadmin.Name = "btnkatalaogadmin";
            btnkatalaogadmin.Size = new Size(340, 64);
            btnkatalaogadmin.TabIndex = 6;
            btnkatalaogadmin.UseVisualStyleBackColor = true;
            btnkatalaogadmin.Click += btnkatalaogadmin_Click;
            // 
            // username
            // 
            username.BorderStyle = BorderStyle.None;
            username.Cursor = Cursors.IBeam;
            username.Font = new Font("Segoe UI", 13F);
            username.Location = new Point(864, 603);
            username.Name = "username";
            username.Size = new Size(490, 35);
            username.TabIndex = 12;
            // 
            // password
            // 
            password.BorderStyle = BorderStyle.None;
            password.Cursor = Cursors.IBeam;
            password.Font = new Font("Segoe UI", 13F);
            password.Location = new Point(863, 770);
            password.Name = "password";
            password.Size = new Size(490, 35);
            password.TabIndex = 13;
            // 
            // konfirmasipassword
            // 
            konfirmasipassword.BorderStyle = BorderStyle.None;
            konfirmasipassword.Cursor = Cursors.IBeam;
            konfirmasipassword.Font = new Font("Segoe UI", 13F);
            konfirmasipassword.Location = new Point(864, 937);
            konfirmasipassword.Name = "konfirmasipassword";
            konfirmasipassword.Size = new Size(490, 35);
            konfirmasipassword.TabIndex = 14;
            // 
            // btnsimpan
            // 
            btnsimpan.BackgroundImage = (Image)resources.GetObject("btnsimpan.BackgroundImage");
            btnsimpan.Cursor = Cursors.Hand;
            btnsimpan.Location = new Point(1410, 47);
            btnsimpan.Name = "btnsimpan";
            btnsimpan.Size = new Size(203, 63);
            btnsimpan.TabIndex = 15;
            btnsimpan.UseVisualStyleBackColor = true;
            btnsimpan.Click += btnsimpan_Click;
            // 
            // btnbatal
            // 
            btnbatal.BackgroundImage = (Image)resources.GetObject("btnbatal.BackgroundImage");
            btnbatal.Cursor = Cursors.Hand;
            btnbatal.Location = new Point(1660, 47);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(203, 63);
            btnbatal.TabIndex = 16;
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // v_editprofiladmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnbatal);
            Controls.Add(btnsimpan);
            Controls.Add(konfirmasipassword);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(btnlogout);
            Controls.Add(btnprofiladmin);
            Controls.Add(btnfeedbackadmin);
            Controls.Add(btnriwayatadmin);
            Controls.Add(btnpesananadmin);
            Controls.Add(btnkatalaogadmin);
            Name = "v_editprofiladmin";
            Text = "v_editprofiladmin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnlogout;
        private Button btnprofiladmin;
        private Button btnfeedbackadmin;
        private Button btnriwayatadmin;
        private Button btnpesananadmin;
        private Button btnkatalaogadmin;
        private TextBox username;
        private TextBox password;
        private TextBox konfirmasipassword;
        private Button btnsimpan;
        private Button btnbatal;
    }
}