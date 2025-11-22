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
            SuspendLayout();
            // 
            // btnkatalogadmin
            // 
            btnkatalogadmin.BackgroundImage = (Image)resources.GetObject("btnkatalogadmin.BackgroundImage");
            btnkatalogadmin.Location = new Point(23, 195);
            btnkatalogadmin.Name = "btnkatalogadmin";
            btnkatalogadmin.Size = new Size(338, 65);
            btnkatalogadmin.TabIndex = 0;
            btnkatalogadmin.UseVisualStyleBackColor = true;
            // 
            // btnpesananadmin
            // 
            btnpesananadmin.BackgroundImage = (Image)resources.GetObject("btnpesananadmin.BackgroundImage");
            btnpesananadmin.Location = new Point(23, 280);
            btnpesananadmin.Name = "btnpesananadmin";
            btnpesananadmin.Size = new Size(338, 66);
            btnpesananadmin.TabIndex = 1;
            btnpesananadmin.UseVisualStyleBackColor = true;
            // 
            // btnriwayatadmin
            // 
            btnriwayatadmin.BackgroundImage = (Image)resources.GetObject("btnriwayatadmin.BackgroundImage");
            btnriwayatadmin.Location = new Point(23, 362);
            btnriwayatadmin.Name = "btnriwayatadmin";
            btnriwayatadmin.Size = new Size(338, 65);
            btnriwayatadmin.TabIndex = 2;
            btnriwayatadmin.UseVisualStyleBackColor = true;
            // 
            // btnfeedbackadmin
            // 
            btnfeedbackadmin.BackgroundImage = (Image)resources.GetObject("btnfeedbackadmin.BackgroundImage");
            btnfeedbackadmin.Location = new Point(23, 443);
            btnfeedbackadmin.Name = "btnfeedbackadmin";
            btnfeedbackadmin.Size = new Size(338, 62);
            btnfeedbackadmin.TabIndex = 3;
            btnfeedbackadmin.UseVisualStyleBackColor = true;
            // 
            // btnprofiladmin
            // 
            btnprofiladmin.BackgroundImage = (Image)resources.GetObject("btnprofiladmin.BackgroundImage");
            btnprofiladmin.Location = new Point(23, 523);
            btnprofiladmin.Name = "btnprofiladmin";
            btnprofiladmin.Size = new Size(338, 65);
            btnprofiladmin.TabIndex = 4;
            btnprofiladmin.UseVisualStyleBackColor = true;
            // 
            // btnlogout
            // 
            btnlogout.BackgroundImage = (Image)resources.GetObject("btnlogout.BackgroundImage");
            btnlogout.Location = new Point(23, 936);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(338, 62);
            btnlogout.TabIndex = 5;
            btnlogout.UseVisualStyleBackColor = true;
            // 
            // v_katalogadmin
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
            Name = "v_katalogadmin";
            Text = "v_katalogadmin";
            ResumeLayout(false);
        }

        #endregion

        private Button btnkatalogadmin;
        private Button btnpesananadmin;
        private Button btnriwayatadmin;
        private Button btnfeedbackadmin;
        private Button btnprofiladmin;
        private Button btnlogout;
    }
}