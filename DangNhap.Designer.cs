namespace FlowerShopManagementSystem
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDK_login = new System.Windows.Forms.Button();
            this.txtUssername_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau_login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkShowPass_login = new System.Windows.Forms.CheckBox();
            this.btnDN_login = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightPink;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnDK_login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 529);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(159, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(145, 141);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(90, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "September Flower Shop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(108, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bạn chưa có tài khoản?";
            // 
            // btnDK_login
            // 
            this.btnDK_login.BackColor = System.Drawing.Color.LightPink;
            this.btnDK_login.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDK_login.ForeColor = System.Drawing.Color.White;
            this.btnDK_login.Location = new System.Drawing.Point(29, 436);
            this.btnDK_login.Name = "btnDK_login";
            this.btnDK_login.Size = new System.Drawing.Size(388, 63);
            this.btnDK_login.TabIndex = 8;
            this.btnDK_login.Text = "Đăng ký";
            this.btnDK_login.UseVisualStyleBackColor = false;
            this.btnDK_login.Click += new System.EventHandler(this.btnDK_login_Click);
            // 
            // txtUssername_login
            // 
            this.txtUssername_login.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUssername_login.Location = new System.Drawing.Point(511, 129);
            this.txtUssername_login.Multiline = true;
            this.txtUssername_login.Name = "txtUssername_login";
            this.txtUssername_login.Size = new System.Drawing.Size(414, 51);
            this.txtUssername_login.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(505, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(505, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtMatKhau_login
            // 
            this.txtMatKhau_login.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau_login.Location = new System.Drawing.Point(511, 235);
            this.txtMatKhau_login.Multiline = true;
            this.txtMatKhau_login.Name = "txtMatKhau_login";
            this.txtMatKhau_login.PasswordChar = '*';
            this.txtMatKhau_login.Size = new System.Drawing.Size(414, 51);
            this.txtMatKhau_login.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(632, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "ĐĂNG NHẬP";
            // 
            // chkShowPass_login
            // 
            this.chkShowPass_login.AutoSize = true;
            this.chkShowPass_login.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPass_login.Location = new System.Drawing.Point(511, 305);
            this.chkShowPass_login.Name = "chkShowPass_login";
            this.chkShowPass_login.Size = new System.Drawing.Size(187, 32);
            this.chkShowPass_login.TabIndex = 6;
            this.chkShowPass_login.Text = "Hiện mật khẩu";
            this.chkShowPass_login.UseVisualStyleBackColor = true;
            this.chkShowPass_login.CheckedChanged += new System.EventHandler(this.chkShowPass_login_CheckedChanged);
            // 
            // btnDN_login
            // 
            this.btnDN_login.BackColor = System.Drawing.Color.LightPink;
            this.btnDN_login.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN_login.ForeColor = System.Drawing.Color.White;
            this.btnDN_login.Location = new System.Drawing.Point(608, 370);
            this.btnDN_login.Name = "btnDN_login";
            this.btnDN_login.Size = new System.Drawing.Size(239, 63);
            this.btnDN_login.TabIndex = 7;
            this.btnDN_login.Text = "Đăng nhập";
            this.btnDN_login.UseVisualStyleBackColor = false;
            this.btnDN_login.Click += new System.EventHandler(this.btnDN_login_Click);
            // 
            // Close
            // 
            this.Close.AutoSize = true;
            this.Close.Location = new System.Drawing.Point(892, 20);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(26, 25);
            this.Close.TabIndex = 8;
            this.Close.Text = "X";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(997, 529);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.btnDN_login);
            this.Controls.Add(this.chkShowPass_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatKhau_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUssername_login);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUssername_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkShowPass_login;
        private System.Windows.Forms.Button btnDN_login;
        private System.Windows.Forms.Button btnDK_login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Close;
    }
}

