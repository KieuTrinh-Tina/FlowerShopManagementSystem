using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlowerShopManagementSystem
{
    public partial class BaoCaoDoanhThu : UserControl
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dtpBCDT_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpBCDT.Value;
            LoadDoanhThuBanHang(selectedDate);
            LoadTiLeSanPham(selectedDate);
            LoadChiTietHoaDon(selectedDate);
        }
        private void LoadDoanhThuBanHang(DateTime ngay) // chart cột dtbh  
        {
            string query = @"SELECT DATEPART(HOUR, NgayLap) AS Gio, SUM(TongTien) AS Tong FROM HoaDon WHERE CAST(NgayLap AS DATE) = @Ngay GROUP BY DATEPART(HOUR, NgayLap) 
ORDER BY Gio";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // xóa các điểm cũ trong biểu đồ 
                chartDThuBH.Series[0].Points.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    chartDThuBH.Series[0].Points.AddXY(row["Gio"], row["Tong"]);
                }
            }
        }
        private void LoadTiLeSanPham(DateTime ngay) // pie chart tỉ lệ sản phẩm 
        {
            string query = @"SELECT TenSP, SUM(SoLuong) AS TongSoLuong FROM HoaDon hd JOIN ChiTietHoaDon ct ON hd.IDHoaDon = ct.IDHoaDon WHERE CAST(NgayLap AS DATE) = @Ngay GROUP BY TenSP";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // xóa các điểm cũ trong biểu đồ 
                chartTLSanPham.Series[0].Points.Clear();
                chartTLSanPham.Series[0].ChartType = SeriesChartType.Pie;
                chartTLSanPham.Series[0].IsValueShownAsLabel = false;
                chartTLSanPham.Series[0].Label = "";

                foreach (DataRow row in dt.Rows)
                {
                    int index = chartTLSanPham.Series[0].Points.AddXY(row["TenSP"], row["TongSoLuong"]);
                    chartTLSanPham.Series[0].Points[index].Label = ""; 
                }
                chartTLSanPham.Invalidate(); 
            }
        }
        private void LoadChiTietHoaDon(DateTime ngay) // chi tiết hóa đơn 
        {
            string query = @"SELECT hd.IDHoaDon, NgayLap, TenSP, SoLuong, DonGia, ThanhTien FROM HoaDon hd JOIN ChiTietHoaDon ct ON hd.IDHoaDon = ct.IDHoaDon 
WHERE CAST(NgayLap AS DATE) = @Ngay";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView8.DataSource = dt;
            }
        }
    }
}
