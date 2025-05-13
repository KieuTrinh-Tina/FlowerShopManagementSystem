namespace FlowerShopManagementSystem
{
    partial class AddPromotions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearPromotion = new System.Windows.Forms.Button();
            this.btnUpdatePromotion = new System.Windows.Forms.Button();
            this.btnXoaPromotion = new System.Windows.Forms.Button();
            this.btnAddPromotion = new System.Windows.Forms.Button();
            this.btnImportImage_Promo = new System.Windows.Forms.Button();
            this.imageView_Promo = new System.Windows.Forms.PictureBox();
            this.endPromotionDate = new System.Windows.Forms.DateTimePicker();
            this.startPromotionDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiamPhanTramCTKM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNamePromotion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDPromotion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageView_Promo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1974, 501);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 44);
            this.label1.TabIndex = 21;
            this.label1.Text = "Danh sách chương trình khuyến mãi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 44);
            this.label3.TabIndex = 20;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(16, 76);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(1938, 404);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnClearPromotion);
            this.panel2.Controls.Add(this.btnUpdatePromotion);
            this.panel2.Controls.Add(this.btnXoaPromotion);
            this.panel2.Controls.Add(this.btnAddPromotion);
            this.panel2.Controls.Add(this.btnImportImage_Promo);
            this.panel2.Controls.Add(this.imageView_Promo);
            this.panel2.Controls.Add(this.endPromotionDate);
            this.panel2.Controls.Add(this.startPromotionDate);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtGiamPhanTramCTKM);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtNamePromotion);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtIDPromotion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(22, 538);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1974, 465);
            this.panel2.TabIndex = 1;
            // 
            // btnClearPromotion
            // 
            this.btnClearPromotion.BackColor = System.Drawing.Color.LightPink;
            this.btnClearPromotion.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPromotion.ForeColor = System.Drawing.Color.White;
            this.btnClearPromotion.Location = new System.Drawing.Point(1290, 361);
            this.btnClearPromotion.Name = "btnClearPromotion";
            this.btnClearPromotion.Size = new System.Drawing.Size(161, 58);
            this.btnClearPromotion.TabIndex = 40;
            this.btnClearPromotion.Text = "Làm mới";
            this.btnClearPromotion.UseVisualStyleBackColor = false;
            this.btnClearPromotion.Click += new System.EventHandler(this.btnClearPromotion_Click);
            // 
            // btnUpdatePromotion
            // 
            this.btnUpdatePromotion.BackColor = System.Drawing.Color.LightPink;
            this.btnUpdatePromotion.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePromotion.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePromotion.Location = new System.Drawing.Point(1016, 361);
            this.btnUpdatePromotion.Name = "btnUpdatePromotion";
            this.btnUpdatePromotion.Size = new System.Drawing.Size(161, 58);
            this.btnUpdatePromotion.TabIndex = 39;
            this.btnUpdatePromotion.Text = "Cập nhật";
            this.btnUpdatePromotion.UseVisualStyleBackColor = false;
            this.btnUpdatePromotion.Click += new System.EventHandler(this.btnUpdatePromotion_Click);
            // 
            // btnXoaPromotion
            // 
            this.btnXoaPromotion.BackColor = System.Drawing.Color.LightPink;
            this.btnXoaPromotion.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPromotion.ForeColor = System.Drawing.Color.White;
            this.btnXoaPromotion.Location = new System.Drawing.Point(742, 361);
            this.btnXoaPromotion.Name = "btnXoaPromotion";
            this.btnXoaPromotion.Size = new System.Drawing.Size(161, 58);
            this.btnXoaPromotion.TabIndex = 38;
            this.btnXoaPromotion.Text = "Xóa";
            this.btnXoaPromotion.UseVisualStyleBackColor = false;
            this.btnXoaPromotion.Click += new System.EventHandler(this.btnXoaPromotion_Click);
            // 
            // btnAddPromotion
            // 
            this.btnAddPromotion.BackColor = System.Drawing.Color.LightPink;
            this.btnAddPromotion.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPromotion.ForeColor = System.Drawing.Color.White;
            this.btnAddPromotion.Location = new System.Drawing.Point(454, 361);
            this.btnAddPromotion.Name = "btnAddPromotion";
            this.btnAddPromotion.Size = new System.Drawing.Size(161, 58);
            this.btnAddPromotion.TabIndex = 37;
            this.btnAddPromotion.Text = "Thêm";
            this.btnAddPromotion.UseVisualStyleBackColor = false;
            this.btnAddPromotion.Click += new System.EventHandler(this.btnAddPromotion_Click);
            // 
            // btnImportImage_Promo
            // 
            this.btnImportImage_Promo.BackColor = System.Drawing.Color.MistyRose;
            this.btnImportImage_Promo.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportImage_Promo.ForeColor = System.Drawing.Color.Black;
            this.btnImportImage_Promo.Location = new System.Drawing.Point(1673, 232);
            this.btnImportImage_Promo.Name = "btnImportImage_Promo";
            this.btnImportImage_Promo.Size = new System.Drawing.Size(172, 46);
            this.btnImportImage_Promo.TabIndex = 36;
            this.btnImportImage_Promo.Text = "Thêm ảnh";
            this.btnImportImage_Promo.UseVisualStyleBackColor = false;
            this.btnImportImage_Promo.Click += new System.EventHandler(this.btnImportImage_Promo_Click);
            // 
            // imageView_Promo
            // 
            this.imageView_Promo.BackColor = System.Drawing.Color.LavenderBlush;
            this.imageView_Promo.Location = new System.Drawing.Point(1673, 34);
            this.imageView_Promo.Name = "imageView_Promo";
            this.imageView_Promo.Size = new System.Drawing.Size(172, 175);
            this.imageView_Promo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageView_Promo.TabIndex = 35;
            this.imageView_Promo.TabStop = false;
            // 
            // endPromotionDate
            // 
            this.endPromotionDate.Location = new System.Drawing.Point(957, 188);
            this.endPromotionDate.Name = "endPromotionDate";
            this.endPromotionDate.Size = new System.Drawing.Size(427, 31);
            this.endPromotionDate.TabIndex = 32;
            // 
            // startPromotionDate
            // 
            this.startPromotionDate.Location = new System.Drawing.Point(957, 66);
            this.startPromotionDate.Name = "startPromotionDate";
            this.startPromotionDate.Size = new System.Drawing.Size(427, 31);
            this.startPromotionDate.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(952, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 28);
            this.label7.TabIndex = 30;
            this.label7.Text = "Ngày kết thúc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(952, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 28);
            this.label6.TabIndex = 28;
            this.label6.Text = "Ngày bắt đầu:";
            // 
            // txtGiamPhanTramCTKM
            // 
            this.txtGiamPhanTramCTKM.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamPhanTramCTKM.Location = new System.Drawing.Point(168, 279);
            this.txtGiamPhanTramCTKM.Multiline = true;
            this.txtGiamPhanTramCTKM.Name = "txtGiamPhanTramCTKM";
            this.txtGiamPhanTramCTKM.Size = new System.Drawing.Size(358, 51);
            this.txtGiamPhanTramCTKM.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(163, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "Phần trăm giảm:";
            // 
            // txtNamePromotion
            // 
            this.txtNamePromotion.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamePromotion.Location = new System.Drawing.Point(168, 168);
            this.txtNamePromotion.Multiline = true;
            this.txtNamePromotion.Name = "txtNamePromotion";
            this.txtNamePromotion.Size = new System.Drawing.Size(358, 51);
            this.txtNamePromotion.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 28);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tên chương trình:";
            // 
            // txtIDPromotion
            // 
            this.txtIDPromotion.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPromotion.Location = new System.Drawing.Point(168, 60);
            this.txtIDPromotion.Multiline = true;
            this.txtIDPromotion.Name = "txtIDPromotion";
            this.txtIDPromotion.Size = new System.Drawing.Size(358, 51);
            this.txtIDPromotion.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "ID chương trình:";
            // 
            // AddPromotions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "AddPromotions";
            this.Size = new System.Drawing.Size(2013, 1023);
            this.Load += new System.EventHandler(this.AddPromotions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageView_Promo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiamPhanTramCTKM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamePromotion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDPromotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endPromotionDate;
        private System.Windows.Forms.DateTimePicker startPromotionDate;
        private System.Windows.Forms.Button btnImportImage_Promo;
        private System.Windows.Forms.PictureBox imageView_Promo;
        private System.Windows.Forms.Button btnClearPromotion;
        private System.Windows.Forms.Button btnUpdatePromotion;
        private System.Windows.Forms.Button btnXoaPromotion;
        private System.Windows.Forms.Button btnAddPromotion;
    }
}
