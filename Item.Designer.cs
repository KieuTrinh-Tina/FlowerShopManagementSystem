namespace FlowerShopManagementSystem
{
    partial class Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item));
            this.blbHoaHongDo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtImageHHD = new System.Windows.Forms.PictureBox();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImageHHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.SuspendLayout();
            // 
            // blbHoaHongDo
            // 
            this.blbHoaHongDo.AutoSize = true;
            this.blbHoaHongDo.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blbHoaHongDo.Location = new System.Drawing.Point(83, 259);
            this.blbHoaHongDo.Name = "blbHoaHongDo";
            this.blbHoaHongDo.Size = new System.Drawing.Size(178, 37);
            this.blbHoaHongDo.TabIndex = 27;
            this.blbHoaHongDo.Text = "Hoa hồng đỏ";
            this.blbHoaHongDo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtImageHHD);
            this.panel1.Location = new System.Drawing.Point(22, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 230);
            this.panel1.TabIndex = 28;
            // 
            // txtImageHHD
            // 
            this.txtImageHHD.Image = ((System.Drawing.Image)(resources.GetObject("txtImageHHD.Image")));
            this.txtImageHHD.Location = new System.Drawing.Point(44, 13);
            this.txtImageHHD.Name = "txtImageHHD";
            this.txtImageHHD.Size = new System.Drawing.Size(210, 214);
            this.txtImageHHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtImageHHD.TabIndex = 1;
            this.txtImageHHD.TabStop = false;
            this.txtImageHHD.Click += new System.EventHandler(this.txtImageHHD_Click);
            // 
            // numSL
            // 
            this.numSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSL.Location = new System.Drawing.Point(110, 308);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(120, 35);
            this.numSL.TabIndex = 29;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.blbHoaHongDo);
            this.Controls.Add(this.panel1);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(340, 353);
            this.Load += new System.EventHandler(this.Item_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImageHHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox txtImageHHD;
        private System.Windows.Forms.Label blbHoaHongDo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numSL;
    }
}
