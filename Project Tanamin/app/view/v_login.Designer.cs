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
            username = new TextBox();
            password = new TextBox();
            linkLabel1 = new LinkLabel();
            linkdaftar = new LinkLabel();
            button1 = new Button();
            SuspendLayout();
            // 
            // username
            // 
            username.BorderStyle = BorderStyle.None;
            username.Cursor = Cursors.IBeam;
            username.Font = new Font("Segoe UI", 13F);
            username.Location = new Point(1199, 397);
            username.Name = "username";
            username.Size = new Size(491, 35);
            username.TabIndex = 0;
            // 
            // password
            // 
            password.BorderStyle = BorderStyle.None;
            password.Cursor = Cursors.IBeam;
            password.Font = new Font("Segoe UI", 13F);
            password.Location = new Point(1199, 588);
            password.Name = "password";
            password.Size = new Size(491, 35);
            password.TabIndex = 1;
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
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(1314, 761);
            button1.Name = "button1";
            button1.Size = new Size(265, 92);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            // 
            // v_login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(button1);
            Controls.Add(linkdaftar);
            Controls.Add(linkLabel1);
            Controls.Add(password);
            Controls.Add(username);
            Name = "v_login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private TextBox password;
        private LinkLabel linkLabel1;
        private LinkLabel linkdaftar;
        private Button button1;
    }
}
