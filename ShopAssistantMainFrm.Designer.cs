namespace FlowerShopManagementSystem
{
    partial class ShopAssistantMainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopAssistantMainFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout_AdminHomeFrm = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.salesFrm1 = new FlowerShopManagementSystem.SalesFrm();
            this.shopAssistantKhachHang1 = new FlowerShopManagementSystem.ShopAssistantKhachHang();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "September Flower Management System";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2387, 45);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(441, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(477, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "Xin chào, Trinh";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightPink;
            this.panel2.Controls.Add(this.btnLogout_AdminHomeFrm);
            this.panel2.Controls.Add(this.btnKH);
            this.panel2.Controls.Add(this.btnSell);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 1023);
            this.panel2.TabIndex = 2;
            // 
            // btnLogout_AdminHomeFrm
            // 
            this.btnLogout_AdminHomeFrm.BackColor = System.Drawing.Color.LightPink;
            this.btnLogout_AdminHomeFrm.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout_AdminHomeFrm.ForeColor = System.Drawing.Color.White;
            this.btnLogout_AdminHomeFrm.Location = new System.Drawing.Point(38, 777);
            this.btnLogout_AdminHomeFrm.Name = "btnLogout_AdminHomeFrm";
            this.btnLogout_AdminHomeFrm.Size = new System.Drawing.Size(298, 66);
            this.btnLogout_AdminHomeFrm.TabIndex = 18;
            this.btnLogout_AdminHomeFrm.Text = "Đăng xuất";
            this.btnLogout_AdminHomeFrm.UseVisualStyleBackColor = false;
            this.btnLogout_AdminHomeFrm.Click += new System.EventHandler(this.btnLogout_AdminHomeFrm_Click);
            // 
            // btnKH
            // 
            this.btnKH.BackColor = System.Drawing.Color.LightPink;
            this.btnKH.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.ForeColor = System.Drawing.Color.White;
            this.btnKH.Location = new System.Drawing.Point(38, 506);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(298, 66);
            this.btnKH.TabIndex = 15;
            this.btnKH.Text = "Khách hàng";
            this.btnKH.UseVisualStyleBackColor = false;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.LightPink;
            this.btnSell.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.ForeColor = System.Drawing.Color.White;
            this.btnSell.Location = new System.Drawing.Point(38, 379);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(298, 66);
            this.btnSell.TabIndex = 14;
            this.btnSell.Text = "Bán hàng";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 37);
            this.label4.TabIndex = 13;
            this.label4.Text = "Shop Assistant\'s Portal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(115, 74);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(145, 141);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // salesFrm1
            // 
            this.salesFrm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesFrm1.Location = new System.Drawing.Point(374, 45);
            this.salesFrm1.Name = "salesFrm1";
            this.salesFrm1.Size = new System.Drawing.Size(2013, 1023);
            this.salesFrm1.TabIndex = 5;
            // 
            // shopAssistantKhachHang1
            // 
            this.shopAssistantKhachHang1.BackColor = System.Drawing.Color.White;
            this.shopAssistantKhachHang1.Location = new System.Drawing.Point(374, 45);
            this.shopAssistantKhachHang1.Name = "shopAssistantKhachHang1";
            this.shopAssistantKhachHang1.Size = new System.Drawing.Size(2013, 1023);
            this.shopAssistantKhachHang1.TabIndex = 3;
            // 
            // ShopAssistantMainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2387, 1068);
            this.Controls.Add(this.salesFrm1);
            this.Controls.Add(this.shopAssistantKhachHang1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ShopAssistantMainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopAssistantMainFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout_AdminHomeFrm;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ShopAssistantKhachHang shopAssistantKhachHang1;
        private SalesFrm salesFrm1;
    }
}