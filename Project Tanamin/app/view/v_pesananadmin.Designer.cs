namespace Project_Tanamin.app.view
{
    partial class v_pesananadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_pesananadmin));
            btnlogout = new Button();
            btnprofiladmin = new Button();
            btnfeedbackadmin = new Button();
            btnriwayatadmin = new Button();
            btnpesananadmin = new Button();
            btnkatalaogadmin = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Cursor = Cursors.Hand;
            btnlogout.Location = new Point(22, 935);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(340, 64);
            btnlogout.TabIndex = 29;
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Cursor = Cursors.Hand;
            btnprofiladmin.Location = new Point(22, 521);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(340, 64);
            btnprofiladmin.TabIndex = 28;
            btnprofiladmin.UseVisualStyleBackColor = true;
            btnprofiladmin.Click += btnprofiladmin_Click;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Cursor = Cursors.Hand;
            btnfeedbackadmin.Location = new Point(22, 442);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(340, 64);
            btnfeedbackadmin.TabIndex = 27;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            btnfeedbackadmin.Click += btnfeedbackadmin_Click;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Cursor = Cursors.Hand;
            btnriwayatadmin.Location = new Point(22, 360);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(340, 64);
            btnriwayatadmin.TabIndex = 26;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            btnriwayatadmin.Click += btnriwayatadmin_Click;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Cursor = Cursors.Hand;
            btnpesananadmin.Location = new Point(22, 279);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(340, 64);
            btnpesananadmin.TabIndex = 25;
            btnpesananadmin.UseVisualStyleBackColor = true;
            // 
            // btnkatalaogadmin
            // 
            btnkatalaogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalaogadmin.BackgroundImage");
            btnkatalaogadmin.Cursor = Cursors.Hand;
            btnkatalaogadmin.Location = new Point(22, 194);
            btnkatalaogadmin.Name = "btnkatalaogadmin";
            btnkatalaogadmin.Size = new Size(340, 64);
            btnkatalaogadmin.TabIndex = 24;
            btnkatalaogadmin.UseVisualStyleBackColor = true;
            btnkatalaogadmin.Click += btnkatalaogadmin_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(416, 186);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1463, 829);
            dataGridView1.TabIndex = 30;
            // 
            // v_pesananadmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(dataGridView1);
            Controls.Add(btnlogout);
            Controls.Add(btnprofiladmin);
            Controls.Add(btnfeedbackadmin);
            Controls.Add(btnriwayatadmin);
            Controls.Add(btnpesananadmin);
            Controls.Add(btnkatalaogadmin);
            Name = "v_pesananadmin";
            Text = "v_pesananadmin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnlogout;
        private Button btnprofiladmin;
        private Button btnfeedbackadmin;
        private Button btnriwayatadmin;
        private Button btnpesananadmin;
        private Button btnkatalaogadmin;
        private DataGridView dataGridView1;
    }
}