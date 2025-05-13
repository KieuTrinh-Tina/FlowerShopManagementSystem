namespace FlowerShopManagementSystem
{
    partial class BaoCaoDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chartDThuBH = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTLSanPham = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBCDT = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDThuBH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTLSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDThuBH
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDThuBH.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDThuBH.Legends.Add(legend1);
            this.chartDThuBH.Location = new System.Drawing.Point(355, 71);
            this.chartDThuBH.Name = "chartDThuBH";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDThuBH.Series.Add(series1);
            this.chartDThuBH.Size = new System.Drawing.Size(1106, 425);
            this.chartDThuBH.TabIndex = 0;
            this.chartDThuBH.Text = "chart1";
            this.chartDThuBH.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chartTLSanPham
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTLSanPham.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTLSanPham.Legends.Add(legend2);
            this.chartTLSanPham.Location = new System.Drawing.Point(1457, 71);
            this.chartTLSanPham.Name = "chartTLSanPham";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTLSanPham.Series.Add(series2);
            this.chartTLSanPham.Size = new System.Drawing.Size(510, 425);
            this.chartTLSanPham.TabIndex = 1;
            this.chartTLSanPham.Text = "chart1";
            // 
            // dataGridView8
            // 
            this.dataGridView8.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView8.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Location = new System.Drawing.Point(354, 550);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.RowHeadersWidth = 82;
            this.dataGridView8.RowTemplate.Height = 33;
            this.dataGridView8.Size = new System.Drawing.Size(1304, 461);
            this.dataGridView8.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(667, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 44);
            this.label3.TabIndex = 20;
            this.label3.Text = "Doanh thu bán hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1524, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 44);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tỉ lệ sản phẩm";
            // 
            // dtpBCDT
            // 
            this.dtpBCDT.Location = new System.Drawing.Point(25, 23);
            this.dtpBCDT.Name = "dtpBCDT";
            this.dtpBCDT.Size = new System.Drawing.Size(427, 31);
            this.dtpBCDT.TabIndex = 32;
            this.dtpBCDT.ValueChanged += new System.EventHandler(this.dtpBCDT_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(795, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(423, 44);
            this.label2.TabIndex = 33;
            this.label2.Text = "Chi tiết hóa đơn trong ngày";
            // 
            // BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBCDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView8);
            this.Controls.Add(this.chartTLSanPham);
            this.Controls.Add(this.chartDThuBH);
            this.Name = "BaoCaoDoanhThu";
            this.Size = new System.Drawing.Size(2013, 1042);
            ((System.ComponentModel.ISupportInitialize)(this.chartDThuBH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTLSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDThuBH;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTLSanPham;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBCDT;
        private System.Windows.Forms.Label label2;
    }
}
