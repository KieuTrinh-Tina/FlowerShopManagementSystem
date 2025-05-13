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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace FlowerShopManagementSystem
{
    public partial class ShopAssistantKhachHang : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public ShopAssistantKhachHang()
        {
            InitializeComponent();
            displayData();
        }
        public void displayData()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

            try
            {
                connect.Open();
                string query = "SELECT id, KH_name, KH_diaChi, KH_image, KH_sdt, KH_email FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView3.DataSource = table;

                dataGridView3.AutoGenerateColumns = true;
                if (dataGridView3.Columns.Contains("KH_image"))
                {
                    dataGridView3.Columns["KH_image"].Visible = true;
                    dataGridView3.Columns["KH_image"].HeaderText = "Đường dẫn ảnh";
                    dataGridView3.Columns["KH_image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public bool emptyFields()
        {
            if (txtKHName.Text == "" || txtKHDiaChi.Text == "" || txtKHsdt.Text == "" || txtKHEmail.Text == ""
                || imageView_KH.Image == null)
            { return true; }
            else
            { return false; }
        }
        private int id = 0;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                id = (int)row.Cells[0].Value;
                txtKHName.Text = row.Cells[1].Value.ToString();
                txtKHDiaChi.Text = row.Cells[2].Value.ToString();  
                string imagePath = row.Cells[3].Value.ToString();  
                txtKHsdt.Text = row.Cells[4].Value.ToString();
                txtKHEmail.Text = row.Cells[5].Value.ToString();

                try
                {
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        imageView_KH.ImageLocation = imagePath;
                    }
                    else
                    {
                        imageView_KH.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnAdd_AddUser_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        // Kiểm tra xem khách hàng đã tồn tại chưa (theo tên và số điện thoại)
                        string checkQuery = "SELECT * FROM KhachHang WHERE KH_Name = @ten AND KH_sdt = @sdt";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                        {
                            checkCmd.Parameters.AddWithValue("@ten", txtKHName.Text.Trim());
                            checkCmd.Parameters.AddWithValue("@sdt", txtKHsdt.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Khách hàng đã tồn tại!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            else
                            {
                                string insertQuery = "INSERT INTO KhachHang (KH_Name,KH_diaChi, KH_image, KH_sdt, KH_email) " +
                                 "VALUES (@ten, @diachi, @image, @sdt, @email)";

                                string folderPath = @"C:\Users\trinh\source\repos\FlowerShopManagementSystem\User Directory";
                                string fileName = txtKHName.Text.Trim() + ".jpg";
                                string path = Path.Combine(folderPath, fileName);
                                string directoryPath = Path.GetDirectoryName(path);
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                File.Copy(imageView_KH.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                                {
                                    cmd.Parameters.AddWithValue("@ten", txtKHName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@diachi", txtKHDiaChi.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@sdt", txtKHsdt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@email", txtKHEmail.Text.Trim());

                                    cmd.ExecuteNonQuery();
                                    clearFields();
                                    MessageBox.Show("Thêm khách hàng thành công", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    displayData();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối thất bại" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
        public void clearFields()
        {
            txtKHName.Text = "";
            txtKHDiaChi.Text = "";
            imageView_KH.Image = null;
            txtKHsdt.Text = "";
            txtKHEmail.Text = "";
        }

        private void btnXoa_XoaKH_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng: " + txtKHName.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) ;
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE FROM KhachHang WHERE id=@id ";
                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"id", id);

                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Xóa thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kết nối thất bại:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }


        private void btnClear_KH_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnUpdate_KH_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật khách hàng: " + txtKHName.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) ;
                    {
                        try
                        {
                            connect.Open();
                            string updateData = "UPDATE KhachHang SET KH_Name=@ten,KH_diaChi=@diachi,KH_sdt=@sdt, KH_email=@email WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"ten", txtKHName.Text.Trim());
                                cmd.Parameters.AddWithValue(@"diachi", txtKHDiaChi.Text.Trim());
                                cmd.Parameters.AddWithValue(@"sdt", txtKHsdt.Text.Trim());
                                cmd.Parameters.AddWithValue(@"email", txtKHEmail.Text.Trim());
                                cmd.Parameters.AddWithValue(@"id", id);
                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Cập nhật thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayData();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kết nối thất bại:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }

            }
        }

        private void btnImportImage_KH_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png|*.jpg;*.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageView_KH.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e) // tìm kh theo sdt 
        {
            string sdt = txtSearchPhoneKH.Text.Trim();
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False"; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang WHERE KH_sdt = @sdt";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView3.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void LoadAllCustomers()
        {
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KhachHang";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView3.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnResetTimKiemKH_Click(object sender, EventArgs e)
        {
            txtSearchPhoneKH.Clear();      
            LoadAllCustomers();
        }

        private void ShopAssistantKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
    
    