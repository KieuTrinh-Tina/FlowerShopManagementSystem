using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace FlowerShopManagementSystem
{
    internal class CustomersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public int ID { get; set; }
        public string KH_name { get; set; }
        public string KH_diaChi { get; set; }
        public string KH_sdt { get; set; }
        public string KH_Email{ get; set; }
        public string Image { get; set; }
        public List<CustomersData> customersListData()
        {
            List<CustomersData> listData = new List<CustomersData>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT*FROM KhachHang";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CustomersData customerData = new CustomersData();
                            customerData.ID = (int)reader["id"];
                            customerData.KH_name = reader["KH_name"].ToString();
                            customerData.KH_diaChi = reader["KH_diaChi"].ToString();
                            customerData.Image = reader["KH_image"].ToString();
                            customerData.KH_sdt = reader["KH_sdt"].ToString();
                            customerData.KH_Email = reader["KH_email"].ToString();
                            listData.Add(customerData);

                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kết nối thất bại: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }
    }
}
    