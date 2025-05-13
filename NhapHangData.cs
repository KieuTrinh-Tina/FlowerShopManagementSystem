using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlowerShopManagementSystem
{
    internal class NhapHangData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");

        public int IDNhapHang { get; set; }
        public int IDSanPham { get; set; }
        public int SoLuongNhap { get; set; }
        public float GiaNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string Image { get; set; }
        public string TenSP { get; set; }
        public string Loai { get; set; }

        public List<NhapHangData> nhapHangListData()
        {
            List<NhapHangData> listData = new List<NhapHangData>();

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string selectData = "SELECT * FROM NhapHang";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhapHangData nhapHangData = new NhapHangData
                        {
                            IDNhapHang = Convert.ToInt32(reader["IDNhapHang"]),
                            IDSanPham = Convert.ToInt32(reader["IDSanPham"]),
                            SoLuongNhap = Convert.ToInt32(reader["SoLuongNhap"]),
                            GiaNhap = Convert.ToSingle(reader["GiaNhap"]),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            Image = reader["Image"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            Loai = reader["Loai"].ToString()
                        };

                        listData.Add(nhapHangData); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kết nối thất bại: " + ex.Message);
            }
            finally
            {
                    connect.Close();
            }

            return listData;
        }
    }
}
