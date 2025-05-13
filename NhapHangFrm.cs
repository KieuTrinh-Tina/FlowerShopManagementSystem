using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopManagementSystem
{
    public partial class NhapHangFrm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public NhapHangFrm()
        {
            InitializeComponent();
            displayData();
        }
        public void displayData()
        {
            string query = "SELECT IDNhapHang, IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai FROM NhapHang";
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView5.DataSource = table;

                    dataGridView5.AutoGenerateColumns = true;
                    if (dataGridView5.Columns.Contains("Image"))
                    {
                        dataGridView5.Columns["Image"].Visible = true;
                        dataGridView5.Columns["Image"].HeaderText = "Đường dẫn ảnh";
                        dataGridView5.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool emptyFields() // kiểm tra các ô nhập thông tin có bị để trống hay không 
        {
            if (txtIDSanPham.Text == "" || comboBoxTenSP.SelectedIndex == -1 || comboBoxLoaiSP.SelectedIndex == -1 || txtSLNhap.Text == ""
        || txtGiaNhap.Text == "" || ngayNhap.Text == "" || imageView_NhapHang.Image == null)
            { return true; }
            else
            { return false; }
        }
        private int id = 0;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
                txtIDNhapHang.Text = row.Cells["IDNhapHang"].Value.ToString();
                txtIDSanPham.Text = row.Cells["IDSanPham"].Value?.ToString();
                txtSLNhap.Text = row.Cells["SoLuongNhap"].Value?.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString();
                ngayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                imageView_NhapHang.ImageLocation = row.Cells["Image"].Value?.ToString();
                comboBoxTenSP.Text = row.Cells["TenSP"].Value.ToString();
                comboBoxLoaiSP.Text = row.Cells["Loai"].Value.ToString();
            }
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            int idSanPham;
            int soLuong;
            float giaNhap;
            DateTime ngayNhapValue = ngayNhap.Value;
            string tenSP = comboBoxTenSP.Text;
            string loaiSP = comboBoxLoaiSP.SelectedValue?.ToString();

            if (comboBoxTenSP.SelectedValue == null ||
         !int.TryParse(txtSLNhap.Text, out soLuong) ||
         !float.TryParse(txtGiaNhap.Text, out giaNhap))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin cần nhập", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(comboBoxTenSP.SelectedValue.ToString(), out idSanPham))
            {
                MessageBox.Show("ID sản phẩm không hợp lệ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertQuery = @"INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
                                   OUTPUT INSERTED.IDNhapHang
                                   VALUES (@IDSanPham, @SoLuongNhap, @GiaNhap, @NgayNhap, @Image, @TenSP, @Loai)";
                    int insertedIDNhapHang = 0;
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                        cmd.Parameters.AddWithValue("@SoLuongNhap", soLuong);
                        cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                        cmd.Parameters.AddWithValue("@NgayNhap", ngayNhapValue);
                        cmd.Parameters.AddWithValue("@Image", imageView_NhapHang.ImageLocation ?? "");
                        cmd.Parameters.AddWithValue("@TenSP", tenSP);
                        cmd.Parameters.AddWithValue("@Loai", loaiSP);
                        insertedIDNhapHang = (int)cmd.ExecuteScalar();
                    }
                    txtIDNhapHang.Text = insertedIDNhapHang.ToString();
                    string checkKho = "SELECT COUNT(*) FROM KhoHang WHERE IDSanPham = @IDSanPham";
                    int count = 0;
                    using (SqlCommand cmd = new SqlCommand(checkKho, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                        count = (int)cmd.ExecuteScalar();
                    }

                    if (count == 0)
                    {
                        string insertKho = "INSERT INTO KhoHang (IDSanPham, SoLuong) VALUES (@IDSanPham, @SoLuong)";
                        using (SqlCommand cmd = new SqlCommand(insertKho, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateKho = "UPDATE KhoHang SET SoLuong = SoLuong + @SoLuong WHERE IDSanPham = @IDSanPham";
                        using (SqlCommand cmd = new SqlCommand(updateKho, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Nhập hàng thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi nhập hàng: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            displayData();
        }

        private void btnImportImage_NhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png|*.jpg;*.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageView_NhapHang.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearFields()
        {
            txtIDNhapHang.Clear();
            txtIDSanPham.Clear();
            comboBoxTenSP.SelectedIndex = -1;
            imageView_NhapHang.Image = null;
            comboBoxLoaiSP.SelectedIndex = -1;
            txtSLNhap.Clear();
            txtGiaNhap.Clear();
            ngayNhap.Value = DateTime.Now;

        }
        private void btnUpdatNhapHang_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        private void btnXoaNhapHang_Click(object sender, EventArgs e)
        {
            int idSanPham;
            int soLuong;

            if (!int.TryParse(txtIDSanPham.Text, out idSanPham) ||
                !int.TryParse(txtSLNhap.Text, out soLuong))
            {
                MessageBox.Show("Vui lòng nhập đúng ID sản phẩm và số lượng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa sp trong NhapHang 
                    string deleteNhapHang = "DELETE FROM NhapHang WHERE IDSanPham = @IDSanPham AND SoLuongNhap = @SoLuongNhap";
                    using (SqlCommand cmd = new SqlCommand(deleteNhapHang, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                        cmd.Parameters.AddWithValue("@SoLuongNhap", soLuong);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("Không tìm thấy sản phẩm để xóa");
                        }
                    }
                    // Cập nhật lại kho hàng sau khi xóa
                    string updateKho = "UPDATE KhoHang SET SoLuong = SoLuong - @SoLuong WHERE IDSanPham = @IDSanPham";
                    using (SqlCommand cmd = new SqlCommand(updateKho, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    MessageBox.Show("Xóa sản phẩm thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                displayData();
            }
        }

        private void btnUpdateNhapHang_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong;
            float giaNhap;
            if (!int.TryParse(txtSLNhap.Text.Trim(), out soLuong))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(txtGiaNhap.Text.Trim(), out giaNhap))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật sản phẩm: " + comboBoxTenSP.Text.Trim()
                + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateData = @"UPDATE NhapHang SET SoLuongNhap=@SLNhap, GiaNhap=@giaNhap, NgayNhap=@ngayNhap, TenSP=@tenSP, Loai=@loai
                                      WHERE IDNhapHang = @IDNhapHang";

                    using (SqlCommand cmd = new SqlCommand(updateData, conn))
                    {
                        cmd.Parameters.AddWithValue("@SLNhap", soLuong);
                        cmd.Parameters.AddWithValue("@giaNhap", giaNhap);
                        cmd.Parameters.AddWithValue("@ngayNhap", ngayNhap.Value.Date);
                        cmd.Parameters.AddWithValue("@tenSP", comboBoxTenSP.Text.Trim()); // Hoặc SelectedItem
                        cmd.Parameters.AddWithValue("@loai", comboBoxLoaiSP.SelectedValue?.ToString()?.Trim() ?? comboBoxLoaiSP.Text.Trim()); // Tùy thuộc ValueMember
                        cmd.Parameters.AddWithValue("@IDNhapHang", txtIDNhapHang.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                        displayData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimUser_Click(object sender, EventArgs e)
        {
            string idSanPham = txtSearchIDSanPham.Text.Trim();
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NhapHang WHERE IDSanPham = @IDSanPham";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDSanPham",idSanPham);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView5.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void LoadAllProducts()
        {
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NhapHang";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView5.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnResetTimKiemUser_Click(object sender, EventArgs e)
        {
            txtSearchIDSanPham.Clear();
            LoadAllProducts();
        }
        private bool KiemTraIDSanPhamTonTai(int idSanPham)
        {
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM SanPham WHERE IDSanPham = @IDSanPham";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra ID sản phẩm: " + ex.Message);
                    return false; 
                }
            }
        }
        private void NhapHangFrm_Load(object sender, EventArgs e)
        {
            LoadDanhSachTenSanPham();
            LoadDanhSachLoaiSanPham();
            txtIDSanPham.ReadOnly = true;
        }

        private void LoadDanhSachTenSanPham()
        {
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IDSanPham, TenSP FROM SanPham";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxTenSP.DisplayMember = "TenSP";
                    comboBoxTenSP.ValueMember = "IDSanPham";
                    comboBoxTenSP.DataSource = dt;

                    if (comboBoxTenSP.SelectedItem != null) 
                    {
                        txtIDSanPham.Text = comboBoxTenSP.SelectedValue?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tên sản phẩm: " + ex.Message);
            }
        }
        private void LoadDanhSachLoaiSanPham()
        {
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // lấy danh sách loại sp từ tên sp 
                    string query = "SELECT DISTINCT LoaiSP FROM SanPham";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxLoaiSP.DisplayMember = "LoaiSP";
                    comboBoxLoaiSP.ValueMember = "LoaiSP"; 
                    comboBoxLoaiSP.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách loại sản phẩm: " + ex.Message);
            }
        }
        private void comboBoxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenSP.SelectedValue != null)
            {
                txtIDSanPham.Text = comboBoxTenSP.SelectedValue.ToString();
            }
        }
    }
}
    
    

