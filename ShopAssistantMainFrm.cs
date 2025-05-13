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
    public partial class ShopAssistantMainFrm : Form
    {
        public ShopAssistantMainFrm()
        {
            InitializeComponent();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_AdminHomeFrm_Click(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Check == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            shopAssistantKhachHang1.Visible = true;
            salesFrm1.Visible = false;

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            // bỏ
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            salesFrm1.Visible = true;
            shopAssistantKhachHang1.Visible = false;
        }
    }
}
