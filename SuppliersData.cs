using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopManagementSystem
{
    internal class SuppliersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public int ID { get; set; }
        public string NCC_name { get; set; }
        public string NCC_diaChi { get; set; }
        public string NCC_sdt { get; set; }
        public string NCC_Email { get; set; }
        public string Image { get; set; }
        public List<SuppliersData> suppliersListData()
        {
            List<SuppliersData> listData = new List<SuppliersData>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT*FROM suppliers";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            SuppliersData suppliersData = new SuppliersData();
                            suppliersData.ID = (int)reader["id"];
                            suppliersData.NCC_name = reader["NCC_name"].ToString();
                            suppliersData.NCC_diaChi = reader["NCC_diaChi"].ToString();
                            suppliersData.Image = reader["NCC_image"].ToString();
                            suppliersData.NCC_sdt = reader["NCC_sdt"].ToString();
                            suppliersData.NCC_Email = reader["NCC_email"].ToString();
                            listData.Add(suppliersData);

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
