namespace Project_Tanamin.app.view
{
    partial class v_katalogadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_katalogadmin));
            btnkatalogadmin = new Button();
            btnpesananadmin = new Button();
            btnriwayatadmin = new Button();
            btnfeedbackadmin = new Button();
            btnprofiladmin = new Button();
            btnlogout = new Button();
            btnTambah = new Button();
            panelflow = new FlowLayoutPanel();
            panel1 = new Panel();
            panelflow.SuspendLayout();
            SuspendLayout();
            // 
            // btnkatalogadmin
            // 
            btnkatalogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalogadmin.BackgroundImage");
            btnkatalogadmin.Cursor = Cursors.Hand;
            btnkatalogadmin.Location = new Point(22, 196);
            btnkatalogadmin.Name = "btnkatalogadmin";
            btnkatalogadmin.Size = new Size(339, 65);
            btnkatalogadmin.TabIndex = 0;
            btnkatalogadmin.UseVisualStyleBackColor = true;
            btnkatalogadmin.Click += btnkatalogadmin_Click;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Cursor = Cursors.Hand;
            btnpesananadmin.Location = new Point(22, 278);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(339, 65);
            btnpesananadmin.TabIndex = 1;
            btnpesananadmin.UseVisualStyleBackColor = true;
            btnpesananadmin.Click += btnpesananadmin_Click;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Cursor = Cursors.Hand;
            btnriwayatadmin.Location = new Point(22, 361);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(339, 65);
            btnriwayatadmin.TabIndex = 2;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            btnriwayatadmin.Click += btnriwayatadmin_Click;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Cursor = Cursors.Hand;
            btnfeedbackadmin.Location = new Point(22, 442);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(339, 65);
            btnfeedbackadmin.TabIndex = 3;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            btnfeedbackadmin.Click += btnfeedbackadmin_Click;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Cursor = Cursors.Hand;
            btnprofiladmin.Location = new Point(22, 523);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(339, 65);
            btnprofiladmin.TabIndex = 4;
            btnprofiladmin.UseVisualStyleBackColor = true;
            btnprofiladmin.Click += btnprofiladmin_Click;
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Cursor = Cursors.Hand;
            btnlogout.Location = new Point(22, 934);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(339, 65);
            btnlogout.TabIndex = 5;
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnTambah
            // 
            btnTambah.BackgroundImage = (Image)resources.GetObject("btnTambah.BackgroundImage");
            btnTambah.Cursor = Cursors.Hand;
            btnTambah.Location = new Point(1611, 45);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(240, 65);
            btnTambah.TabIndex = 6;
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click_1;
            // 
            // panelflow
            // 
            panelflow.BackColor = Color.Transparent;
            panelflow.Controls.Add(panel1);
            panelflow.Location = new Point(422, 196);
            panelflow.Name = "panelflow";
            panelflow.Size = new Size(1460, 803);
            panelflow.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 463);
            panel1.TabIndex = 0;
            // 
            // v_katalogadmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(panelflow);
            Controls.Add(btnTambah);
            Controls.Add(btnlogout);
            Controls.Add(btnprofiladmin);
            Controls.Add(btnfeedbackadmin);
            Controls.Add(btnriwayatadmin);
            Controls.Add(btnpesananadmin);
            Controls.Add(btnkatalogadmin);
            Name = "v_katalogadmin";
            Text = "v_katalogadmin";
            panelflow.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnkatalogadmin;
        private Button btnpesananadmin;
        private Button btnriwayatadmin;
        private Button btnfeedbackadmin;
        private Button btnprofiladmin;
        private Button btnlogout;
        private Button btnTambah;
        private FlowLayoutPanel panelflow;
        private Panel panel1;
    }
}