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
using System.IO;

namespace FlowerShopManagementSystem
{
    public partial class AddPromotions : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public AddPromotions()
        {
            InitializeComponent();
            displayData();
        }

        private void AddPromotions_Load(object sender, EventArgs e)
        {

        }
        public void displayData()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

            try
            {
                connect.Open();
                string query = "SELECT promo_id, promo_name, promo_image, giamGia, startDate, endDate FROM promotions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView2.DataSource = table;

                dataGridView2.AutoGenerateColumns = true;
                if (dataGridView2.Columns.Contains("promo_image"))
                {
                    dataGridView2.Columns["promo_image"].Visible = true;
                    dataGridView2.Columns["promo_image"].HeaderText = "Đường dẫn ảnh";
                    dataGridView2.Columns["promo_image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public bool emptyFields()
        {
            if (txtIDPromotion.Text == "" || txtNamePromotion.Text == "" || txtGiamPhanTramCTKM.Text == "" || imageView_Promo.Image == null)
            { return true; }
            else
            { return false; }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                txtIDPromotion.Text = row.Cells["promo_id"].Value?.ToString();
                txtNamePromotion.Text = row.Cells["promo_name"].Value?.ToString();
                imageView_Promo.ImageLocation = row.Cells["promo_image"].Value?.ToString();
                txtGiamPhanTramCTKM.Text = row.Cells["giamGia"].Value?.ToString();
                startPromotionDate.Value = Convert.ToDateTime(row.Cells["startDate"].Value);
                endPromotionDate.Value = Convert.ToDateTime(row.Cells["endDate"].Value);

            }
        }

        private void btnAddPromotion_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    // Kiểm tra ID chương trình khuyến mãi 
                    string selectPromoID = "SELECT * FROM promotions WHERE promo_id = @promoID";
                    using (SqlCommand selectPID = new SqlCommand(selectPromoID, connect))
                    {
                        selectPID.Parameters.AddWithValue("@promoID", txtIDPromotion.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(selectPID);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show("Mã chương trình đã tồn tại!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MemoryStream ms = new MemoryStream();
                    imageView_Promo.Image.Save(ms, imageView_Promo.Image.RawFormat);
                    byte[] promoImageBytes = ms.ToArray();
                    DateTime startDate = startPromotionDate.Value.Date;
                    DateTime endDate = endPromotionDate.Value.Date;

                    string insertData = "INSERT INTO promotions (promo_id, promo_name, promo_image, giamGia, startDate, endDate) " +
                                        "VALUES (@promoID, @promoName, @promoImage, @promoGiam, @ngayBD, @ngayKT)";
                    string path = Path.Combine(@"C:\Users\trinh\source\repos\FlowerShopManagementSystem\Promotion Directory\" + txtIDPromotion.Text.Trim() + ".jpg");
                    string directoryPath = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    File.Copy(imageView_Promo.ImageLocation, path, true);
                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@promoID", txtIDPromotion.Text.Trim());
                        cmd.Parameters.AddWithValue("@promoName", txtNamePromotion.Text.Trim());
                        cmd.Parameters.AddWithValue("@promoImage", path);
                        cmd.Parameters.AddWithValue("@promoGiam", txtGiamPhanTramCTKM.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayBD", startDate);
                        cmd.Parameters.AddWithValue("@ngayKT", endDate);
                        cmd.ExecuteNonQuery();
                        clearFields();
                        MessageBox.Show("Thêm chương trình thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayData();

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
        private void btnImportImage_Promo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    imageView_Promo.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearFields()
        {
            txtIDPromotion.Clear();
            txtNamePromotion.Clear();
            txtGiamPhanTramCTKM.Clear();
            imageView_Promo.Image = null;
            startPromotionDate.Value = DateTime.Now;
            endPromotionDate.Value = DateTime.Now;
        }

        private void btnClearPromotion_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnXoaPromotion_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chương trình: " + txtNamePromotion.Text.Trim()
                + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // xóa ct hợp lệ 
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    string deleteData = "DELETE FROM promotions WHERE promo_id = @promoID";
                    using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                    {
                        cmd.Parameters.AddWithValue("@promoID", txtIDPromotion.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            clearFields();
                            MessageBox.Show("Xóa thành công!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chương trình để xóa.", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnUpdatePromotion_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình cần cập nhật trong bảng!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowIndex];
            string currentPromoID = selectedRow.Cells["promo_id"].Value.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật chương trình: " + txtNamePromotion.Text.Trim()
                + " không?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // cập nhật ct hợp lệ 
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        string updateData = "UPDATE promotions SET promo_id=@newPromoID,promo_name=@promoName, promo_image=@promoImage, " + "giamGia=@promoGiam, startDate=@ngayBD, endDate=@ngayKT " + 
                            "WHERE promo_id=@promoID";

                        string path = Path.Combine(@"C:\Users\trinh\source\repos\FlowerShopManagementSystem\Promotion Directory\", txtIDPromotion.Text.Trim() + ".jpg");
                        string directoryPath = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }                     
                        File.Copy(imageView_Promo.ImageLocation, path, true);

                        using (SqlCommand updateD = new SqlCommand(updateData, connect))
                        {
                            updateD.Parameters.AddWithValue("@newPromoID", txtIDPromotion.Text.Trim());
                            updateD.Parameters.AddWithValue("@promoName", txtNamePromotion.Text.Trim());
                            updateD.Parameters.AddWithValue("@promoImage", path);
                            updateD.Parameters.AddWithValue("@promoGiam", txtGiamPhanTramCTKM.Text.Trim());
                            updateD.Parameters.AddWithValue("@ngayBD", startPromotionDate.Value.Date);
                            updateD.Parameters.AddWithValue("@ngayKT", endPromotionDate.Value.Date);
                            updateD.Parameters.AddWithValue("@promoID", currentPromoID);
                            updateD.ExecuteNonQuery();
                            clearFields();
                            MessageBox.Show("Cập nhật thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayData();

                        }                
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật thất bại: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}


   
