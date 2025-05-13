using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FlowerShopManagementSystem
{
    public partial class DangNhap : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public DangNhap()
        {
            InitializeComponent();
        }

        private void chkShowPass_login_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau_login.PasswordChar = chkShowPass_login.Checked ? '\0' : '*';
        }
        public bool emptyFields()
        {
            if (txtUssername_login.Text == "" || txtMatKhau_login.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnDK_login_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.ShowDialog();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDN_login_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string query = "SELECT role FROM users WHERE username = @usern AND password = @pass AND status = 'Active'";
                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", txtUssername_login.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", txtMatKhau_login.Text.Trim());

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                string userRole = result.ToString();
                                MessageBox.Show("Đăng nhập thành công", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (userRole == "Admin") // admin thì chuyển đến frm các chức năng của admin
                                {
                                    AdminHomeFrm adminFrm = new AdminHomeFrm();
                                    adminFrm.Show();
                                    this.Hide();
                                }
                                else if (userRole == "Shop Assistant") // NVBH thì chuyển đến frm chức năng của NVBH 
                                {
                                    ShopAssistantMainFrm shopAssistantMainFrm = new ShopAssistantMainFrm();
                                    shopAssistantMainFrm.Show();
                                    this.Hide();
                                }
                                else if ((userRole == "Inventory Staff")) // NV kho thì chuyển đến frm các chức năng của NV kho 
                                {
                                    IventoryStaffMainFrm iventorystaffFrm = new IventoryStaffMainFrm();
                                    iventorystaffFrm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username/mật khẩu không đúng hoặc tài khoản chưa được kích hoạt!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối thất bại: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }


        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}


