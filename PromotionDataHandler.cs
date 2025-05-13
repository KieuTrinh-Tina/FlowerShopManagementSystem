using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopManagementSystem
{
    internal class PromotionDataHandler
    {
        private SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public List<AddPromotionData> GetPromotions()
        {
            List<AddPromotionData> list = new List<AddPromotionData>();

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM promotions", connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new AddPromotionData
                    {
                        PromotionID = reader["promo_id"].ToString(),
                        PromotionName = reader["promo_name"].ToString(),
                        PromotionImage = reader["promo_image"].ToString(),
                        PromotionPercent = reader["giamGia"].ToString(),
                        PromotionStartDate = Convert.ToDateTime(reader["startDate"]).ToShortDateString(),
                        PromotionEndDate = Convert.ToDateTime(reader["endDate"]).ToShortDateString()
                    });
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

            return list;
        }
    }
}
