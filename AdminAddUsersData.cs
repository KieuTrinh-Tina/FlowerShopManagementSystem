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
    internal class AdminAddUsersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G0M64VV\SQLEXPRESS;Initial Catalog=SFdemo;Integrated Security=True;Encrypt=False");
        public int ID { set; get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string DateSignUp { get; set; }
        public string Image { get; set; }
        public List<AdminAddUsersData> usersListData()
        {
            List<AdminAddUsersData> listData = new List<AdminAddUsersData>();
            if (connect.State!= ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT*FROM users";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            AdminAddUsersData userData = new AdminAddUsersData();
                            userData.ID = (int)reader["id"];
                            userData.Username = reader["username"].ToString();
                            userData.Password = reader["password"].ToString();
                            userData.Role = reader["role"].ToString();
                            userData.Status = reader["status"].ToString();
                            userData.Image = reader["profile_image"].ToString();
                            userData.DateSignUp = reader["date_signup"].ToString();

                            listData.Add(userData);

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
   
