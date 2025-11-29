namespace Project_Tanamin.app.view
{
    partial class v_supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_supplier));
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            btncheckoutcustomer = new Button();
            btnkembaliadmin = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(18, 168);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1242, 860);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 370);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(1275, 168);
            panel2.Name = "panel2";
            panel2.Size = new Size(639, 860);
            panel2.TabIndex = 1;
            // 
            // btncheckoutcustomer
            // 
            btncheckoutcustomer.BackgroundImage = (Image)resources.GetObject("btncheckoutcustomer.BackgroundImage");
            btncheckoutcustomer.Location = new Point(1371, 45);
            btncheckoutcustomer.Name = "btncheckoutcustomer";
            btncheckoutcustomer.Size = new Size(203, 61);
            btncheckoutcustomer.TabIndex = 2;
            btncheckoutcustomer.UseVisualStyleBackColor = true;
            btncheckoutcustomer.Click += btncheckoutcustomer_Click;
            // 
            // btnkembaliadmin
            // 
            btnkembaliadmin.BackgroundImage = (Image)resources.GetObject("btnkembaliadmin.BackgroundImage");
            btnkembaliadmin.Location = new Point(1618, 45);
            btnkembaliadmin.Name = "btnkembaliadmin";
            btnkembaliadmin.Size = new Size(202, 61);
            btnkembaliadmin.TabIndex = 3;
            btnkembaliadmin.UseVisualStyleBackColor = true;
            btnkembaliadmin.Click += btnkembaliadmin_Click;
            // 
            // v_supplier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnkembaliadmin);
            Controls.Add(btncheckoutcustomer);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Name = "v_supplier";
            Text = "v_supplier";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Button btncheckoutcustomer;
        private Button btnkembaliadmin;
    }
}