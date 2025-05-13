namespace FlowerShopManagementSystem
{
    partial class AdminHomeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHomeFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhaCungCap = new System.Windows.Forms.Button();
            this.btnLogout_AdminHomeFrm = new System.Windows.Forms.Button();
            this.btnBCDT = new System.Windows.Forms.Button();
            this.btnCTKM = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.baoCaoDoanhThu1 = new FlowerShopManagementSystem.BaoCaoDoanhThu();
            this.supplierFrm2 = new FlowerShopManagementSystem.SupplierFrm();
            this.supplierFrm1 = new FlowerShopManagementSystem.SupplierFrm();
            this.addPromotions1 = new FlowerShopManagementSystem.AddPromotions();
            this.addUser1 = new FlowerShopManagementSystem.AddUser();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2387, 45);
            this.panel1.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightPink;
            this.panel2.Controls.Add(this.btnNhaCungCap);
            this.panel2.Controls.Add(this.btnLogout_AdminHomeFrm);
            this.panel2.Controls.Add(this.btnBCDT);
            this.panel2.Controls.Add(this.btnCTKM);
            this.panel2.Controls.Add(this.btnNhanVien);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 1023);
            this.panel2.TabIndex = 1;
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.BackColor = System.Drawing.Color.LightPink;
            this.btnNhaCungCap.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCungCap.ForeColor = System.Drawing.Color.White;
            this.btnNhaCungCap.Location = new System.Drawing.Point(38, 435);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.Size = new System.Drawing.Size(298, 66);
            this.btnNhaCungCap.TabIndex = 20;
            this.btnNhaCungCap.Text = "Nhà cung cấp";
            this.btnNhaCungCap.UseVisualStyleBackColor = false;
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnLogout_AdminHomeFrm
            // 
            this.btnLogout_AdminHomeFrm.BackColor = System.Drawing.Color.LightPink;
            this.btnLogout_AdminHomeFrm.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout_AdminHomeFrm.ForeColor = System.Drawing.Color.White;
            this.btnLogout_AdminHomeFrm.Location = new System.Drawing.Point(38, 894);
            this.btnLogout_AdminHomeFrm.Name = "btnLogout_AdminHomeFrm";
            this.btnLogout_AdminHomeFrm.Size = new System.Drawing.Size(298, 66);
            this.btnLogout_AdminHomeFrm.TabIndex = 18;
            this.btnLogout_AdminHomeFrm.Text = "Đăng xuất";
            this.btnLogout_AdminHomeFrm.UseVisualStyleBackColor = false;
            this.btnLogout_AdminHomeFrm.Click += new System.EventHandler(this.btnLogout_AdminHomeFrm_Click);
            // 
            // btnBCDT
            // 
            this.btnBCDT.BackColor = System.Drawing.Color.LightPink;
            this.btnBCDT.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCDT.ForeColor = System.Drawing.Color.White;
            this.btnBCDT.Location = new System.Drawing.Point(38, 641);
            this.btnBCDT.Name = "btnBCDT";
            this.btnBCDT.Size = new System.Drawing.Size(298, 66);
            this.btnBCDT.TabIndex = 17;
            this.btnBCDT.Text = "Báo cáo doanh thu";
            this.btnBCDT.UseVisualStyleBackColor = false;
            this.btnBCDT.Click += new System.EventHandler(this.btnBCDT_Click);
            // 
            // btnCTKM
            // 
            this.btnCTKM.BackColor = System.Drawing.Color.LightPink;
            this.btnCTKM.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTKM.ForeColor = System.Drawing.Color.White;
            this.btnCTKM.Location = new System.Drawing.Point(38, 539);
            this.btnCTKM.Name = "btnCTKM";
            this.btnCTKM.Size = new System.Drawing.Size(298, 66);
            this.btnCTKM.TabIndex = 15;
            this.btnCTKM.Text = "Chương trình khuyến mãi";
            this.btnCTKM.UseVisualStyleBackColor = false;
            this.btnCTKM.Click += new System.EventHandler(this.btnCTKM_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.LightPink;
            this.btnNhanVien.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Location = new System.Drawing.Point(38, 331);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(298, 66);
            this.btnNhanVien.TabIndex = 14;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(135, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 37);
            this.label4.TabIndex = 13;
            this.label4.Text = "Admin";
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.baoCaoDoanhThu1);
            this.panel3.Controls.Add(this.supplierFrm2);
            this.panel3.Controls.Add(this.supplierFrm1);
            this.panel3.Controls.Add(this.addPromotions1);
            this.panel3.Controls.Add(this.addUser1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(374, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2013, 1023);
            this.panel3.TabIndex = 2;
            // 
            // baoCaoDoanhThu1
            // 
            this.baoCaoDoanhThu1.BackColor = System.Drawing.Color.White;
            this.baoCaoDoanhThu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baoCaoDoanhThu1.Location = new System.Drawing.Point(0, 0);
            this.baoCaoDoanhThu1.Name = "baoCaoDoanhThu1";
            this.baoCaoDoanhThu1.Size = new System.Drawing.Size(2013, 1023);
            this.baoCaoDoanhThu1.TabIndex = 5;
            // 
            // supplierFrm2
            // 
            this.supplierFrm2.BackColor = System.Drawing.Color.White;
            this.supplierFrm2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplierFrm2.Location = new System.Drawing.Point(0, 0);
            this.supplierFrm2.Name = "supplierFrm2";
            this.supplierFrm2.Size = new System.Drawing.Size(2013, 1023);
            this.supplierFrm2.TabIndex = 4;
            this.supplierFrm2.Load += new System.EventHandler(this.supplierFrm2_Load);
            // 
            // supplierFrm1
            // 
            this.supplierFrm1.BackColor = System.Drawing.Color.White;
            this.supplierFrm1.Location = new System.Drawing.Point(-1999, 7);
            this.supplierFrm1.Name = "supplierFrm1";
            this.supplierFrm1.Size = new System.Drawing.Size(2039, 1074);
            this.supplierFrm1.TabIndex = 3;
            this.supplierFrm1.Visible = false;
            // 
            // addPromotions1
            // 
            this.addPromotions1.BackColor = System.Drawing.Color.White;
            this.addPromotions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPromotions1.Location = new System.Drawing.Point(0, 0);
            this.addPromotions1.Name = "addPromotions1";
            this.addPromotions1.Size = new System.Drawing.Size(2013, 1023);
            this.addPromotions1.TabIndex = 1;
            // 
            // addUser1
            // 
            this.addUser1.BackColor = System.Drawing.Color.White;
            this.addUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addUser1.Location = new System.Drawing.Point(0, 0);
            this.addUser1.Name = "addUser1";
            this.addUser1.Size = new System.Drawing.Size(2013, 1023);
            this.addUser1.TabIndex = 0;
            this.addUser1.Load += new System.EventHandler(this.addUser1_Load);
            // 
            // AdminHomeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2387, 1068);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminHomeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminHomeFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminHomeFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBCDT;
        private System.Windows.Forms.Button btnCTKM;
        private System.Windows.Forms.Button btnNhanVien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLogout_AdminHomeFrm;
        private System.Windows.Forms.Button btnNhaCungCap;
        private AddUser addUser1;
        private AddPromotions addPromotions1;
        private SupplierFrm supplierFrm1;
        private System.Windows.Forms.Panel panel3;
        private SupplierFrm supplierFrm2;
        private BaoCaoDoanhThu baoCaoDoanhThu1;
    }
}