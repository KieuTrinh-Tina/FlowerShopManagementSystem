using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace FlowerShopManagementSystem
{
    internal class AddPromotionData
    {
        public int ID { get; set; }
        public string PromotionID { get; set; }
        public string PromotionName { get; set; }
        public string PromotionPercent { get; set; }
        public string PromotionImage { get; set; }
        public string PromotionStartDate { get; set; }
        public string PromotionEndDate { get; set; }

        private static SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public static List<AddPromotionData> GetPromotionsList()
        {
            List<AddPromotionData> promotionsListData = new List<AddPromotionData>();

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string selectData = "SELECT * FROM promotions";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddPromotionData apd = new AddPromotionData();
                        {
                            apd.ID = (int)reader["id"];
                            apd.PromotionID = reader["promo_id"].ToString();
                            apd.PromotionName = reader["promo_name"].ToString();
                            apd.PromotionImage = reader["promo_image"].ToString();
                            apd.PromotionPercent = reader["giamGia"].ToString();
                            apd.PromotionStartDate = Convert.ToDateTime(reader["startDate"]).ToShortDateString();
                            apd.PromotionEndDate = Convert.ToDateTime(reader["endDate"]).ToShortDateString();
                        };

                        promotionsListData.Add(apd);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

            return promotionsListData;
        }
    }
}
