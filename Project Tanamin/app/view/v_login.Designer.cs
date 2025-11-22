namespace Project_Tanamin
{
    partial class v_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_login));
            login_username = new TextBox();
            login_password = new TextBox();
            linkLabel1 = new LinkLabel();
            linkdaftar = new LinkLabel();
            btnlogin = new Button();
            SuspendLayout();
            // 
            // login_username
            // 
            login_username.BorderStyle = BorderStyle.None;
            login_username.Cursor = Cursors.IBeam;
            login_username.Font = new Font("Segoe UI", 13F);
            login_username.Location = new Point(1199, 397);
            login_username.Name = "login_username";
            login_username.Size = new Size(491, 35);
            login_username.TabIndex = 0;
            // 
            // login_password
            // 
            login_password.BorderStyle = BorderStyle.None;
            login_password.Cursor = Cursors.IBeam;
            login_password.Font = new Font("Segoe UI", 13F);
            login_password.Location = new Point(1199, 588);
            login_password.Name = "login_password";
            login_password.Size = new Size(491, 35);
            login_password.TabIndex = 1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = SystemColors.Window;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.Font = new Font("Segoe UI", 12F);
            linkLabel1.Location = new Point(2080, 459);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(79, 32);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Daftar";
            // 
            // linkdaftar
            // 
            linkdaftar.AutoSize = true;
            linkdaftar.BackColor = SystemColors.Window;
            linkdaftar.Cursor = Cursors.Hand;
            linkdaftar.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkdaftar.Location = new Point(1598, 670);
            linkdaftar.Name = "linkdaftar";
            linkdaftar.Size = new Size(92, 36);
            linkdaftar.TabIndex = 3;
            linkdaftar.TabStop = true;
            linkdaftar.Text = "Daftar";
            // 
            // btnlogin
            // 
            btnlogin.BackgroundImage = (Image)resources.GetObject("btnlogin.BackgroundImage");
            btnlogin.BackgroundImageLayout = ImageLayout.None;
            btnlogin.Cursor = Cursors.Hand;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.Location = new Point(1314, 761);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(265, 92);
            btnlogin.TabIndex = 4;
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // v_login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnlogin);
            Controls.Add(linkdaftar);
            Controls.Add(linkLabel1);
            Controls.Add(login_password);
            Controls.Add(login_username);
            Name = "v_login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox login_username;
        private TextBox login_password;
        private LinkLabel linkLabel1;
        private LinkLabel linkdaftar;
        private Button btnlogin;
    }
}
