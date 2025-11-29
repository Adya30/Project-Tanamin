namespace Project_Tanamin.app.view
{
    partial class v_pembayaransupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_pembayaransupplier));
            dateTimePicker1 = new DateTimePicker();
            namaspllier = new TextBox();
            nominalpem = new TextBox();
            btnbayar = new Button();
            btnbatal = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 13F);
            dateTimePicker1.Location = new Point(910, 310);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(419, 42);
            dateTimePicker1.TabIndex = 0;
            // 
            // namaspllier
            // 
            namaspllier.BorderStyle = BorderStyle.None;
            namaspllier.Font = new Font("Segoe UI", 13F);
            namaspllier.Location = new Point(910, 572);
            namaspllier.Name = "namaspllier";
            namaspllier.Size = new Size(822, 35);
            namaspllier.TabIndex = 1;
            // 
            // nominalpem
            // 
            nominalpem.BorderStyle = BorderStyle.None;
            nominalpem.Font = new Font("Segoe UI", 13F);
            nominalpem.Location = new Point(996, 792);
            nominalpem.Name = "nominalpem";
            nominalpem.Size = new Size(484, 35);
            nominalpem.TabIndex = 2;
            // 
            // btnbayar
            // 
            btnbayar.BackgroundImage = (Image)resources.GetObject("btnbayar.BackgroundImage");
            btnbayar.Location = new Point(1424, 45);
            btnbayar.Name = "btnbayar";
            btnbayar.Size = new Size(202, 57);
            btnbayar.TabIndex = 3;
            btnbayar.UseVisualStyleBackColor = true;
            btnbayar.Click += btnbayar_Click;
            // 
            // btnbatal
            // 
            btnbatal.BackgroundImage = (Image)resources.GetObject("btnbatal.BackgroundImage");
            btnbatal.Location = new Point(1659, 45);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(200, 57);
            btnbatal.TabIndex = 4;
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // v_pembayaransupplier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnbatal);
            Controls.Add(btnbayar);
            Controls.Add(nominalpem);
            Controls.Add(namaspllier);
            Controls.Add(dateTimePicker1);
            Name = "v_pembayaransupplier";
            Text = "v_pembayaransupplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private TextBox namaspllier;
        private TextBox nominalpem;
        private Button btnbayar;
        private Button btnbatal;
    }
}