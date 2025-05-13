using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FlowerShopManagementSystem
{
    public partial class IventoryStaffMainFrm : Form
    {
        public IventoryStaffMainFrm()
        {
            InitializeComponent();
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

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            khoHang2.Visible = false;
            nhapHangFrm2.Visible = true;
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            khoHang2.Visible = true;
            nhapHangFrm2.Visible = false;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            khoHang2.Visible = false;
            nhapHangFrm2.Visible = false;

        }
        private NhapHangFrm nhapHangFrm1;
        private KhoHang khoHang1;
        private void khoHang1_Load(object sender, EventArgs e)
        {
            khoHang2 = new KhoHang();
            nhapHangFrm2 = new NhapHangFrm();
        }
        private void IventoryStaffMainFrm_Load(object sender, EventArgs e)
        {
            nhapHangFrm1 = new NhapHangFrm();
            khoHang1 = new KhoHang();
        }

        private void khoHang2_Load(object sender, EventArgs e)
        {

        }
    }
}


