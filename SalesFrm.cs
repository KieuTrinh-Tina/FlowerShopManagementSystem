using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing; // in hóa đơn 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopManagementSystem
{
    public partial class SalesFrm : UserControl
    {
        public SalesFrm()
        {
            InitializeComponent();
        }

        private void SalesFrm_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }
        private void LoadDanhSachSanPham()
        {
            flowPanelSP.Controls.Clear();
            string query = "SELECT * FROM SanPham";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Item> items = new List<Item>();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.id = Convert.ToInt32(reader["IDSanPham"]);
                    item.Name = reader["TenSP"].ToString();
                    item.Category = reader["LoaiSP"].ToString();
                    item.price = reader["GiaBan"].ToString();
                    item.Image = GetProductImageByName(item.Name);
                    item.onSelect += Item_onSelect;
                    items.Add(item); 
                }
                // LINQ lọc mỗi loại sp chỉ hiển thị 1 lần lên flowPanel 
                var uniqueItems = items .GroupBy(x => x.Name).Select(g => g.First()).ToList();
                foreach (var sp in uniqueItems)
                {
                    flowPanelSP.Controls.Add(sp);
                }
            }
        }
        private Image GetProductImageByName(string productName)
        {
            switch (productName.Trim().ToLower()) // ảnh hiển thị tương ứng với tên sp
            {
                case "hoa hồng đỏ":
                    return Properties.Resources.hoaHongDo;
                case "hoa cúc trắng":
                    return Properties.Resources.hoa2;
                case "hoa lan tím":
                    return Properties.Resources.hoa3;
                case "hoa hướng dương":
                    return Properties.Resources.hoa5;
                case "hoa baby trắng":
                    return Properties.Resources.hoa4;
                case "hoa hồng xanh":
                    return Properties.Resources.hoaHongXanh;
                case "hoa baby hồng":
                    return Properties.Resources.babyHong;
                case "hoa lavender khô":
                    return Properties.Resources.lavender;
                case "hoa đồng tiền":
                    return Properties.Resources.hoaDongTien;
                default: // không tìm thấy 
                    return Properties.Resources.SOS; 
            }
        }

        private void Item_onSelect(object sender, EventArgs e) // thêm sp vào hóa đơn 
        {
            Item item = (Item)sender;
            int soLuong = item.Quantity;
            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal donGia = decimal.Parse(item.price);
            decimal thanhTien = donGia * soLuong;
            dataGridView7.Rows.Add(item.Name, donGia.ToString("N0"), soLuong, thanhTien.ToString("N0"), "+", "-");
            TinhTongHoaDon();
            MessageBox.Show($"Đã thêm {soLuong} x {item.Name} vào hóa đơn.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView7.Columns[e.ColumnIndex].Name == "Giambtn") // giảm số lượng sp 
                {
                    int soLuong = Convert.ToInt32(dataGridView7.Rows[e.RowIndex].Cells["SoLuong"].Value);
                    if (soLuong > 1)
                    {
                        soLuong--;
                        dataGridView7.Rows[e.RowIndex].Cells["SoLuong"].Value = soLuong;
                    }
                    else
                    {
                       // xóa sp khỏi hóa đơn nếu số lượng = 0 
                        dataGridView7.Rows.RemoveAt(e.RowIndex);
                        TinhTongHoaDon();
                        return;
                    }
                }
                else if (dataGridView7.Columns[e.ColumnIndex].Name == "Tangbtn") // tăng số lượng sp 
                {
                    int soLuong = Convert.ToInt32(dataGridView7.Rows[e.RowIndex].Cells["SoLuong"].Value);
                    soLuong++;
                    dataGridView7.Rows[e.RowIndex].Cells["SoLuong"].Value = soLuong;
                }
                CapNhatThanhTien(e.RowIndex);
            }
        }

        private void CapNhatThanhTien(int rowIndex) // cập nhật lại Thành tiền sau khi tăng giảm SL 
        {
            int soLuong = Convert.ToInt32(dataGridView7.Rows[rowIndex].Cells["SoLuong"].Value);
            decimal donGia = Convert.ToDecimal(dataGridView7.Rows[rowIndex].Cells["DonGia"].Value);
            dataGridView7.Rows[rowIndex].Cells["ThanhTien"].Value = donGia * soLuong;
            TinhTongHoaDon();
        }

        private void TinhTongHoaDon() // tính tổng tiền hóa đơn 
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dataGridView7.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }
            txtTongHoaDonBH.Text = tong.ToString("N0");
        }

        private void flowPanelSP_Paint(object sender, PaintEventArgs e)
        {

        }
        // Tính tổng hóa đơn 
        private decimal TinhTong()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dataGridView7.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    decimal thanhTien = decimal.Parse(row.Cells["ThanhTien"].Value.ToString());
                    tong += thanhTien;
                }
            }
            return tong;
        }
        private void btnThanhToanBH_Click(object sender, EventArgs e) // thanh toán hóa đơn 
        {
            string tenKH = txtKHName.Text.Trim();
            string sdt = txtKHsdt.Text.Trim();
            string phuongThuc = cbPTTT.Text;
            decimal tongTien = decimal.Parse(txtTongHoaDonBH.Text);
            decimal tienKhachTra = decimal.Parse(txtTienKhachTraBH.Text);
            decimal tienThua = tienKhachTra - tongTien;

            if (tienKhachTra < tongTien)
            {
                MessageBox.Show("Tiền khách trả không đủ!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                { // hóa đơn 
                    string insertHoaDon = @"INSERT INTO HoaDon (NgayLap, TenKH, SDT, TongTien, TienKhachTra, TienThua, PhuongThucThanhToan)
                VALUES (@NgayLap, @TenKH, @SDT, @TongTien, @TienKhachTra, @TienThua, @PhuongThuc);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertHoaDon, conn, transaction);
                    cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@TienKhachTra", tienKhachTra);
                    cmd.Parameters.AddWithValue("@TienThua", tienThua);
                    cmd.Parameters.AddWithValue("@PhuongThuc", phuongThuc);
                    int idHoaDon = Convert.ToInt32(cmd.ExecuteScalar());

                    //chi tiết hóa đơn 
                    foreach (DataGridViewRow row in dataGridView7.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string tenSP = row.Cells["TenSP"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal donGia = decimal.Parse(row.Cells["DonGia"].Value.ToString());
                        decimal thanhTien = decimal.Parse(row.Cells["ThanhTien"].Value.ToString());
                        string insertCT = @"INSERT INTO ChiTietHoaDon (IDHoaDon, TenSP, SoLuong, DonGia, ThanhTien) VALUES (@IDHoaDon, @TenSP, @SoLuong, @DonGia, @ThanhTien);";
                        SqlCommand cmdCT = new SqlCommand(insertCT, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@IDHoaDon", idHoaDon);
                        cmdCT.Parameters.AddWithValue("@TenSP", tenSP);
                        cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                        cmdCT.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdCT.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    InHoaDon(idHoaDon); // in hóa đơn sau khi tt thành công 
                    MessageBox.Show("Thanh toán thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView7.Rows.Clear(); // xóa hóa đơn sau khi TT 
                    txtTongHoaDonBH.Text = "";
                    txtTienKhachTraBH.Text = "";
                    txtTienThuaBH.Text = "";
                    txtKHName.Text = "";
                    txtKHsdt.Text = "";

                }
                catch (Exception ex)
                {
                    try
                    {
                        if (transaction.Connection != null) // rollback transaction
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Lỗi khi rollback: " + rollbackEx.Message);
                    }

                    MessageBox.Show("Lỗi khi thực hiện giao dịch: " + ex.Message);
                }
            }
        }
        private void txtTienKhachTraBH_TextChanged(object sender, EventArgs e) // tính tiền thừa
        {
            if (string.IsNullOrEmpty(txtTienKhachTraBH.Text))
            {
                txtTienThuaBH.Text = "0";
                return;
            }
            TinhTienThua(); 
        }
        private void TinhTienThua() // tính tiền thừa 
        {
            if (decimal.TryParse(txtTienKhachTraBH.Text, out decimal tienKhachTra) &&
        decimal.TryParse(txtTongHoaDonBH.Text, out decimal tongTien))
            {
                decimal tienThua = tienKhachTra - tongTien;
                txtTienThuaBH.Text = tienThua >= 0 ? tienThua.ToString("N0") : "0";
            }
            else
            {
                txtTienThuaBH.Text = "0";
            }
        }
        private string noiDungHoaDon;

        private void InHoaDon(int idHoaDon) // in hóa đơn bằng control PrintDocument 
        {
            StringBuilder hoaDonText = new StringBuilder();

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                // Lấy thông tin hóa đơn
                SqlCommand cmdHoaDon = new SqlCommand("SELECT * FROM HoaDon WHERE IDHoaDon = @ID", conn);
                cmdHoaDon.Parameters.AddWithValue("@ID", idHoaDon);
                SqlDataReader reader = cmdHoaDon.ExecuteReader();
                if (reader.Read())
                {
                    hoaDonText.AppendLine("====== September Flower ======");
                    hoaDonText.AppendLine("====== HÓA ĐƠN THANH TOÁN ======");
                    hoaDonText.AppendLine($"Mã hóa đơn: {reader["IDHoaDon"]}");
                    hoaDonText.AppendLine($"Ngày lập: {Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy HH:mm")}");
                    hoaDonText.AppendLine($"Khách hàng: {reader["TenKH"]}");
                    hoaDonText.AppendLine($"SĐT: {reader["SDT"]}");
                    hoaDonText.AppendLine($"Phương thức thanh toán: {reader["PhuongThucThanhToan"]}");
                    hoaDonText.AppendLine("-----------------------------------");
                }
                reader.Close();

                SqlCommand cmdCT = new SqlCommand("SELECT * FROM ChiTietHoaDon WHERE IDHoaDon = @ID", conn);
                cmdCT.Parameters.AddWithValue("@ID", idHoaDon);
                SqlDataReader ctReader = cmdCT.ExecuteReader();
                while (ctReader.Read())
                {
                    hoaDonText.AppendLine($"{ctReader["TenSP"]} x{ctReader["SoLuong"]} - {Convert.ToDecimal(ctReader["ThanhTien"]).ToString("N0")} VNĐ");
                }
                ctReader.Close();

                SqlCommand tongCmd = new SqlCommand("SELECT TongTien, TienKhachTra, TienThua FROM HoaDon WHERE IDHoaDon = @ID", conn);
                tongCmd.Parameters.AddWithValue("@ID", idHoaDon);
                SqlDataReader tongReader = tongCmd.ExecuteReader();
                if (tongReader.Read())
                {
                    hoaDonText.AppendLine("-----------------------------------");
                    hoaDonText.AppendLine($"Tổng tiền: {Convert.ToDecimal(tongReader["TongTien"]).ToString("N0")} VNĐ");
                    hoaDonText.AppendLine($"Khách trả: {Convert.ToDecimal(tongReader["TienKhachTra"]).ToString("N0")} VNĐ");
                    hoaDonText.AppendLine($"Tiền thừa: {Convert.ToDecimal(tongReader["TienThua"]).ToString("N0")} VNĐ");
                    hoaDonText.AppendLine("Cảm ơn quý khách, hẹn gặp lại!");
                }
                tongReader.Close();
            }
            noiDungHoaDon = hoaDonText.ToString();
            PrintDocument pd = new PrintDocument(); // in hóa đơn
            pd.PrintPage += new PrintPageEventHandler(PrintHoaDon);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
        private void PrintHoaDon(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Consolas", 10);
            float yPos = 10;
            int leftMargin = 10;

            using (StringReader reader = new StringReader(noiDungHoaDon))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos);
                    yPos += font.GetHeight(e.Graphics);
                }
            }
        }
        private void btnHuyBH_Click(object sender, EventArgs e)
        {
            dataGridView7.Rows.Clear();
            txtKHName.Text = "";
            txtKHsdt.Text = "";
            txtTongHoaDonBH.Text = "";
            txtTienKhachTraBH.Text = "";
            txtTienThuaBH.Text = "";
            cbPTTT.SelectedIndex = -1;
            MessageBox.Show("Đã hủy hóa đơn", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnTimKiemBH_Click(object sender, EventArgs e)
        {
            // bỏ
        }

    }
}

