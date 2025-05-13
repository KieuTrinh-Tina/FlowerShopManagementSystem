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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace FlowerShopManagementSystem
{
    public partial class AddUser : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public AddUser()
        {
            InitializeComponent();
            displayAddUsersData();
        }
        public void displayAddUsersData()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

            try
            {
                connect.Open();
                string query = "SELECT id, username, password, profile_image, role, status, date_signup FROM users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                dataGridView1.AutoGenerateColumns = true;
                if (dataGridView1.Columns.Contains("profile_image"))
                {
                    dataGridView1.Columns["profile_image"].Visible = true;
                    dataGridView1.Columns["profile_image"].HeaderText = "Đường dẫn ảnh";
                    dataGridView1.Columns["profile_image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            if (txtUsername_AddUser.Text == "" || txtPass_AddUser.Text == "" || role_AddUser.Text == "" || status_AddUser.Text == ""
                || imageView_AddUser.Image == null)
            { return true; }
            else
            { return false; }
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
                        //Kiểm tra tài khoản đã tồn tại chưa 
                        string selectUsern = "SELECT * FROM users WHERE username = @usern";
                        using (SqlCommand checkUsern = new SqlCommand(selectUsern, connect))
                        {
                            checkUsern.Parameters.AddWithValue("@usern", txtUsername_AddUser.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = checkUsern;
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count >= 1)
                            {
                                string usern = txtUsername_AddUser.Text.Substring(0, 1).ToUpper() + txtUsername_AddUser.Text.Substring(1);
                                MessageBox.Show(usern + " đã tồn tại", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string insertData = "INSERT INTO users (username, password, profile_image, role, status, date_signup) " +
                                                    "VALUES (@usern, @pass, @image, @role, @status, @date)";
                                DateTime today = DateTime.Today;
                                string folderPath = @"C:\Users\trinh\source\repos\FlowerShopManagementSystem\User Directory";
                                string fileName = txtUsername_AddUser.Text.Trim() + ".jpg";
                                string path = Path.Combine(folderPath, fileName);
                                string directoryPath = Path.GetDirectoryName(path);
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                File.Copy(imageView_AddUser.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@usern", txtUsername_AddUser.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", txtPass_AddUser.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@role", role_AddUser.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", status_AddUser.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date", today);
                                    cmd.ExecuteNonQuery();
                                    clearFields();
                                    MessageBox.Show("Thêm nhân viên thành công", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    displayAddUsersData();
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

        private void btnImportImage_AddUser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png|*.jpg;*.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageView_AddUser.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //userData.ID = (int)reader["id"];
            // userData.Username = reader["username"].ToString();
            //userData.Password = reader["password"].ToString();
            // userData.Role = reader["role"].ToString();
            //userData.Status = reader["status"].ToString();
            // userData.Image = reader["profile_image"].ToString();
            //userData.DateSignUp = reader["date_signup"].ToString();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            id = (int)row.Cells[0].Value;
            txtUsername_AddUser.Text = row.Cells[1].Value.ToString();
            txtPass_AddUser.Text = row.Cells[2].Value.ToString();
            string imagePath = row.Cells[3].Value.ToString();
            role_AddUser.Text = row.Cells[4].Value.ToString();
            status_AddUser.Text = row.Cells[5].Value.ToString();
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    imageView_AddUser.ImageLocation = imagePath;
                }
                else
                {
                    imageView_AddUser.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
    }

        private void btnUpdate_AddUser_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật nhân viên: " + txtUsername_AddUser.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) 
                    {
                        try
                        {
                            connect.Open();
                            string updateData = "UPDATE users SET username=@usern, password=@pass, role=@role, status=@status WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"usern", txtUsername_AddUser.Text.Trim());
                                cmd.Parameters.AddWithValue(@"pass", txtPass_AddUser.Text.Trim());
                                cmd.Parameters.AddWithValue(@"role", role_AddUser.Text.Trim());
                                cmd.Parameters.AddWithValue(@"status", status_AddUser.Text.Trim());
                                cmd.Parameters.AddWithValue(@"id", id);
                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Cập nhật thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayAddUsersData();
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
        public void clearFields()
        {
            txtUsername_AddUser.Text = "";
            txtPass_AddUser.Text = "";
            imageView_AddUser.Image = null;
            role_AddUser.SelectedIndex = -1;
            status_AddUser.SelectedIndex = -1;
        }
        private void btnClear_AddUser_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnXoa_AddUser_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên: " + txtUsername_AddUser.Text.Trim()
                    + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open) 
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE FROM users WHERE id=@id ";
                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue(@"id", id);
                                
                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Xóa thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayAddUsersData();
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

        private void txtSearchRoleUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimUser_Click(object sender, EventArgs e) // tìm nhân viên theo chức vụ 
        {
            string role = txtSearchRoleUser.Text.Trim();
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE role = @role";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@role", role);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void LoadAllUsers()
        {
            string connectionString = "Data Source=DESKTOP-G0M64VV\\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnResetTimKiemUser_Click(object sender, EventArgs e)
        {
            txtSearchRoleUser.Clear();
            LoadAllUsers();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
    }
}




