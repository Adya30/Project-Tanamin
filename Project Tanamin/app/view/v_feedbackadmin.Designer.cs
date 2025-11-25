namespace Project_Tanamin.app.view
{
    partial class v_feedbackadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_feedbackadmin));
            dataGridView1 = new DataGridView();
            btnlogout = new Button();
            btnprofiladmin = new Button();
            btnfeedbackadmin = new Button();
            btnriwayatadmin = new Button();
            btnpesananadmin = new Button();
            btnkatalogadmin = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(411, 187);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1464, 805);
            dataGridView1.TabIndex = 20;
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Cursor = Cursors.Hand;
            btnlogout.Location = new Point(23, 934);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(339, 65);
            btnlogout.TabIndex = 26;
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Cursor = Cursors.Hand;
            btnprofiladmin.Location = new Point(23, 523);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(339, 65);
            btnprofiladmin.TabIndex = 25;
            btnprofiladmin.UseVisualStyleBackColor = true;
            btnprofiladmin.Click += btnprofiladmin_Click;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Cursor = Cursors.Hand;
            btnfeedbackadmin.Location = new Point(23, 442);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(339, 65);
            btnfeedbackadmin.TabIndex = 24;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            btnfeedbackadmin.Click += btnfeedbackadmin_Click;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Cursor = Cursors.Hand;
            btnriwayatadmin.Location = new Point(23, 361);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(339, 65);
            btnriwayatadmin.TabIndex = 23;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            btnriwayatadmin.Click += btnriwayatadmin_Click;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Cursor = Cursors.Hand;
            btnpesananadmin.Location = new Point(23, 278);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(339, 65);
            btnpesananadmin.TabIndex = 22;
            btnpesananadmin.UseVisualStyleBackColor = true;
            btnpesananadmin.Click += btnpesananadmin_Click;
            // 
            // btnkatalogadmin
            // 
            btnkatalogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalogadmin.BackgroundImage");
            btnkatalogadmin.Cursor = Cursors.Hand;
            btnkatalogadmin.Location = new Point(23, 196);
            btnkatalogadmin.Name = "btnkatalogadmin";
            btnkatalogadmin.Size = new Size(339, 65);
            btnkatalogadmin.TabIndex = 21;
            btnkatalogadmin.UseVisualStyleBackColor = true;
            btnkatalogadmin.Click += btnkatalogadmin_Click;
            // 
            // v_feedbackadmin
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
            Controls.Add(dataGridView1);
            Name = "v_feedbackadmin";
            Text = "v_feedbackadmin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnlogout;
        private Button btnprofiladmin;
        private Button btnfeedbackadmin;
        private Button btnriwayatadmin;
        private Button btnpesananadmin;
        private Button btnkatalogadmin;
    }
}