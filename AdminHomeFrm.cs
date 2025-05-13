using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopManagementSystem
{
    public partial class AdminHomeFrm : Form
    {
        public AdminHomeFrm()
        {
            InitializeComponent();
        }

       

        private void AdminHomeFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void addUser1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_AdminHomeFrm_Click(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Check==DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            //bỏ
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            addPromotions1.Visible = false;
            addUser1.Visible = true;
            supplierFrm2.Visible = false;
            baoCaoDoanhThu1.Visible = false;

        }
        private void btnCTKM_Click(object sender, EventArgs e)
        {
            addPromotions1.Visible = true;
            addUser1.Visible = false;
            supplierFrm2.Visible = false;
            baoCaoDoanhThu1.Visible = false;
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            supplierFrm2.Visible = true;
            addPromotions1.Visible = false;
            addUser1.Visible = false;
            baoCaoDoanhThu1.Visible = false;
        }

        private void btnBCDT_Click(object sender, EventArgs e)
        {
            baoCaoDoanhThu1.Visible = true;
            supplierFrm2.Visible = false;
            addPromotions1.Visible = false;
            addUser1.Visible = false;

        }
        private void supplierFrm2_Load(object sender, EventArgs e)
        {

        }
    }
}
