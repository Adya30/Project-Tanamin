namespace Project_Tanamin.view
{
    partial class v_register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_register));
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            nama_lengkap = new TextBox();
            username_register = new TextBox();
            no_telp = new TextBox();
            password_register = new TextBox();
            konfirmasi_password = new TextBox();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = SystemColors.Window;
            linkLabel1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(1617, 757);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(83, 36);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Login";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.Location = new Point(1315, 836);
            button1.Name = "button1";
            button1.Size = new Size(262, 88);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // nama_lengkap
            // 
            nama_lengkap.BorderStyle = BorderStyle.None;
            nama_lengkap.Location = new Point(1208, 294);
            nama_lengkap.Name = "nama_lengkap";
            nama_lengkap.Size = new Size(484, 24);
            nama_lengkap.TabIndex = 3;
            // 
            // username_register
            // 
            username_register.BorderStyle = BorderStyle.None;
            username_register.Location = new Point(1208, 394);
            username_register.Name = "username_register";
            username_register.Size = new Size(484, 24);
            username_register.TabIndex = 4;
            // 
            // no_telp
            // 
            no_telp.BorderStyle = BorderStyle.None;
            no_telp.Location = new Point(1208, 499);
            no_telp.Name = "no_telp";
            no_telp.Size = new Size(478, 24);
            no_telp.TabIndex = 5;
            // 
            // password_register
            // 
            password_register.BorderStyle = BorderStyle.None;
            password_register.Location = new Point(1208, 597);
            password_register.Name = "password_register";
            password_register.Size = new Size(484, 24);
            password_register.TabIndex = 6;
            // 
            // konfirmasi_password
            // 
            konfirmasi_password.BorderStyle = BorderStyle.None;
            konfirmasi_password.Location = new Point(1208, 701);
            konfirmasi_password.Name = "konfirmasi_password";
            konfirmasi_password.Size = new Size(478, 24);
            konfirmasi_password.TabIndex = 7;
            // 
            // v_register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(konfirmasi_password);
            Controls.Add(password_register);
            Controls.Add(no_telp);
            Controls.Add(username_register);
            Controls.Add(nama_lengkap);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Name = "v_register";
            Text = "register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkLabel1;
        private Button button1;
        private TextBox nama_lengkap;
        private TextBox username_register;
        private TextBox no_telp;
        private TextBox password_register;
        private TextBox konfirmasi_password;
    }
}