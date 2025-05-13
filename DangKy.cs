using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FlowerShopManagementSystem
{
    public partial class DangKy : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public DangKy()
        {
            InitializeComponent();
        }

        private void txtMatKhau_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPass_signup_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau_signup.PasswordChar = chkShowPass_signup.Checked ? '\0' : '*';
            txtConfirmPass_signup.PasswordChar = chkShowPass_signup.Checked ? '\0' : '*';
        }
       public bool emptyFields()
        {
            if (txtUssername_signup.Text ==""||txtMatKhau_signup.Text==""||txtConfirmPass_signup.Text=="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnDN_signup_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.ShowDialog();
            this.Show();
        }

        private void Close_signup_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDK_signup_Click(object sender, EventArgs e)
        {
            if(emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if(connect.State==ConnectionState.Closed)
                try
                {
                    connect.Open();
                        string selectUsername = "SELECT*FROM users WHERE username =@usern";
                        using (SqlCommand checkUsername = new SqlCommand(selectUsername, connect))
                        {
                            checkUsername.Parameters.AddWithValue("@usern", txtUssername_signup.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsername);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count >= 1)
                            {
                                string usern = txtUssername_signup.Text.Substring(0, 1).ToUpper() + txtUssername_signup.Text.Substring(1);
                                MessageBox.Show(usern + " đã tồn tại", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (txtMatKhau_signup.Text != txtConfirmPass_signup.Text)
                            {
                                MessageBox.Show("Xác nhận mật khẩu không đúng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } else if (txtMatKhau_signup.Text.Length<8)
                            {
                                MessageBox.Show("Mật khẩu cần ít nhất 8 kí tự", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO users (username, [password], profile_image, role, status, date_signup)"+" VALUES (@usern, @pass, @image, @role, @status, @date )";
                                DateTime today = DateTime.Today;
                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@usern", txtUssername_signup.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", txtMatKhau_signup.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image","");
                                    cmd.Parameters.AddWithValue("@role", "Shop Assistant");
                                    cmd.Parameters.AddWithValue("@status", "Approval");
                                    cmd.Parameters.AddWithValue("@date", today);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Đăng ký thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Chuyển đến form đăng nhập
                                    DangNhap dnForm = new DangNhap();
                                    dnForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                catch (Exception ex)
                {
                        MessageBox.Show("Kết nối thất bại: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                {
                        connect.Close();
                    }
                
            }
        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
