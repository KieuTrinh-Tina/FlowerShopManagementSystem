using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopManagementSystem
{
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public event EventHandler onSelect = null;
        public int id { get; set; }
        public string price { get; set; }
        public string Category { get; set; }
        public string Qty { get; set; }
        public string Name
        {
            get { return blbHoaHongDo.Text; }
            set { blbHoaHongDo.Text = value; }
        }
        public Image Image
        {
            get { return txtImageHHD.Image; }
            set { txtImageHHD.Image = value; }
        }
        public int Quantity
        {
            get { return (int)numSL.Value; }
        }
        private void Item_Load(object sender, EventArgs e)
        {
        }
        private void txtImageHHD_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}

