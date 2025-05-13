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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace FlowerShopManagementSystem
{
    public partial class KhoHang : UserControl
    {
        public KhoHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
        private void LoadTonKho()
        {
            string query = @"SELECT sp.IDSanPham,
                           sp.TenSP,
                           sp.LoaiSP,
                           kh.SoLuong,
                           sp.GiaNhap
                    FROM KhoHang kh
                    JOIN SanPham sp ON kh.IDSanPham = sp.IDSanPham";

            SqlConnection conn = null;
            SqlDataAdapter adapter = null;
            DataTable dt = null;

            try
            {
                conn = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Lỗi kêt nối: {ex.ToString()}");
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView6.Rows[e.RowIndex];

                txtNameTonKho.Text = row.Cells["TenSP"].Value?.ToString();
                txtLoaiTonKho.Text = row.Cells["LoaiSP"].Value?.ToString();
                txtSLTonKho.Text = row.Cells["SoLuong"].Value?.ToString();
                txtGiaNhapTonKho.Text = row.Cells["GiaNhap"].Value?.ToString();
            }
        }
        private void btnUpdateTonKho_Click(object sender, EventArgs e) 
        {
            // bỏ
        }

        private void ResetForm()
        {
            txtNameTonKho.Clear();
            txtLoaiTonKho.Clear();
            txtSLTonKho.Clear();
            txtGiaNhapTonKho.Clear();
        }

        private void KhoHang_Load(object sender, EventArgs e)
        {
            LoadTonKho();
            dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView6.MultiSelect = false;
        }
        private void btnLuuTonKho_Click(object sender, EventArgs e) // btn cập nhật
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idSanPham = Convert.ToInt32(dataGridView6.SelectedRows[0].Cells["IDSanPham"].Value);
            string tenSP = txtNameTonKho.Text.Trim();
            string loaiSP = txtLoaiTonKho.Text.Trim();
            int soLuong;
            double giaNhap;
            // kiểm tra dữ liệu nhập vào 
            if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(loaiSP) || !int.TryParse(txtSLTonKho.Text, out soLuong) || !double.TryParse(txtGiaNhapTonKho.Text, out giaNhap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateSP = "UPDATE SanPham SET TenSP = @TenSP, LoaiSP = @LoaiSP, GiaNhap = @GiaNhap WHERE IDSanPham = @ID";
                string updateKho = "UPDATE KhoHang SET SoLuong = @SoLuong WHERE IDSanPham = @ID";
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Cập nhật sản phẩm 
                    SqlCommand cmdSP = new SqlCommand(updateSP, conn, trans);
                    cmdSP.Parameters.AddWithValue("@TenSP", tenSP);
                    cmdSP.Parameters.AddWithValue("@LoaiSP", loaiSP);
                    cmdSP.Parameters.AddWithValue("@GiaNhap", giaNhap);
                    cmdSP.Parameters.AddWithValue("@ID", idSanPham);
                    cmdSP.ExecuteNonQuery();
                    // Cập nhật kho
                    SqlCommand cmdKho = new SqlCommand(updateKho, conn, trans);
                    cmdKho.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdKho.Parameters.AddWithValue("@ID", idSanPham);
                    cmdKho.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Cập nhật không thành công: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    LoadTonKho();
                    ResetForm();
                }
            }
        }
        private void btnXoaTonKho_Click(object sender, EventArgs e) 
        {
            // bỏ 
        }
        private void btnClearTonKho_Click(object sender, EventArgs e)
        {
            txtNameTonKho.Clear();
            txtLoaiTonKho.Clear();
            txtSLTonKho.Clear();
            txtGiaNhapTonKho.Clear();
        }

        private void btnTimTonKho_Click(object sender, EventArgs e) // tìm ID Sản phẩm 
        {
            string idSanPham = txtSearchIDSanPham.Text.Trim();
            string connectionString = @"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                            sp.IDSanPham, 
                            sp.TenSP, 
                            sp.LoaiSP, 
                            kh.SoLuong, 
                            sp.GiaNhap
                        FROM KhoHang AS kh
                        JOIN SanPham AS sp ON kh.IDSanPham = sp.IDSanPham
                        WHERE kh.IDSanPham = @IDSanPham";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDSanPham", idSanPham);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView6.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = @"SELECT 
                            sp.IDSanPham, 
                            sp.TenSP, 
                            sp.LoaiSP, 
                            kh.SoLuong, 
                            sp.GiaNhap
                        FROM KhoHang AS kh
                        JOIN SanPham AS sp ON kh.IDSanPham = sp.IDSanPham";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView6.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetTimKiemTonKho_Click(object sender, EventArgs e) // reset tìm kiếm 
        {
            txtSearchIDSanPham.Clear(); 
            LoadAllProducts();          
        }
    }
}
