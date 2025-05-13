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
    public partial class SupplierFrm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public SupplierFrm()
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
                string query = "SELECT id, NCC_name, NCC_diaChi, NCC_image, NCC_sdt, NCC_email FROM suppliers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView4.DataSource = table;

                dataGridView4.AutoGenerateColumns = true;
                if (dataGridView4.Columns.Contains("NCC_image"))
                {
                    dataGridView4.Columns["NCC_image"].Visible = true;
                    dataGridView4.Columns["NCC_image"].HeaderText = "Đường dẫn ảnh";
                    dataGridView4.Columns["NCC_image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            if (txtNameNCC.Text == "" || txtDiaChiNCC.Text == "" || txtsdtNCC.Text == "" || txtEmailNCC.Text == ""
                || imageView_NCC.Image == null)
            { return true; }
            else
            { return false; }
        }
        private int id = 0;
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                id = (int)row.Cells[0].Value;
               txtNameNCC.Text = row.Cells[1].Value.ToString();
                txtDiaChiNCC.Text = row.Cells[2].Value.ToString();
                string imagePath = row.Cells[3].Value.ToString();
               txtsdtNCC.Text = row.Cells[4].Value.ToString();
                txtEmailNCC.Text = row.Cells[5].Value.ToString();

                try
                {
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        imageView_NCC.ImageLocation = imagePath;
                    }
                    else
                    {
                        imageView_NCC.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNCC_Click(object sender, EventArgs e)
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
                        // Kiểm tra xem NCC đã tồn tại chưa (theo tên và số điện thoại)
                        string checkQuery = "SELECT * FROM suppliers WHERE NCC_Name = @ten AND NCC_sdt = @sdt";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                        {
                            checkCmd.Parameters.AddWithValue("@ten", txtNameNCC.Text.Trim());
                            checkCmd.Parameters.AddWithValue("@sdt", txtsdtNCC.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Nhà cung cấp đã tồn tại!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            else
                            {
                                string insertQuery = "INSERT INTO suppliers (NCC_Name,NCC_diaChi, NCC_image, NCC_sdt, NCC_email) " +
                                 "VALUES (@ten, @diachi, @image, @sdt, @email)";

                                string folderPath = @"C:\Users\trinh\source\repos\FlowerShopManagementSystem\User Directory";
                                string fileName = txtNameNCC.Text.Trim() + ".jpg";
                                string path = Path.Combine(folderPath, fileName);
                                string directoryPath = Path.GetDirectoryName(path);
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                File.Copy(imageView_NCC.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                                {
                                    cmd.Parameters.AddWithValue("@ten", txtNameNCC.Text.Trim());
                                    cmd.Parameters.AddWithValue("@diachi", txtDiaChiNCC.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@sdt", txtsdtNCC.Text.Trim());
                                    cmd.Parameters.AddWithValue("@email", txtEmailNCC.Text.Trim());

                                    cmd.ExecuteNonQuery();
                                    clearFields();
                                    MessageBox.Show("Thêm nhà cung cấp thành công", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtNameNCC.Text = "";
            txtDiaChiNCC.Text = "";
            imageView_NCC.Image = null;
            txtsdtNCC.Text = "";
            txtEmailNCC.Text = "";
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {

            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp: " + txtNameNCC.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) ;
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE FROM suppliers WHERE id=@id ";
                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"id", id);

                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Xóa nhà cung cấp thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClearNCC_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnUpdateNCC_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật nhà cung cấp: " + txtNameNCC.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) 
                    {
                        try
                        {
                            connect.Open();
                            string updateData = "UPDATE suppliers SET NCC_Name=@ten,NCC_diaChi=@diachi,NCC_sdt=@sdt, NCC_email=@email WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"ten", txtNameNCC.Text.Trim());
                                cmd.Parameters.AddWithValue(@"diachi", txtDiaChiNCC.Text.Trim());
                                cmd.Parameters.AddWithValue(@"sdt", txtsdtNCC.Text.Trim());
                                cmd.Parameters.AddWithValue(@"email", txtEmailNCC.Text.Trim());
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

        private void btnImportImageNCC_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png|*.jpg;*.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageView_NCC.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimNCC_Click(object sender, EventArgs e) // tìm NCC theo sdt 
        {
            string sdt = txtSearchPhoneNCC.Text.Trim();
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers WHERE NCC_sdt = @sdt";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView4.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void LoadAllSuppliers()
        {
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView4.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        

        private void btnResetTimKiemNCC_Click_1(object sender, EventArgs e)
        {
            txtSearchPhoneNCC.Clear();
            LoadAllSuppliers();
        }

        private void SupplierFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
