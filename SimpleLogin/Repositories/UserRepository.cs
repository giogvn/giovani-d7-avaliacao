using System;
using SimpleLogin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SimpleLogin.Repositories
{
    public class UserRepository
    {
        static string ConnectionString = "Server=labsoft.pcs.usp.br; Initial Catalog=db_7; User id=''; pwd='';";

        public void Create(User newRecord)
        {
            string queryInsert = $"INSERT INTO Users (email, password) VALUES (@Email, @Password)";
            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", newRecord.Email);
                    cmd.Parameters.AddWithValue("@Password", newRecord.Password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<User> findUser(string email, string password)
        {
            List<User> list = new();
            string querySelect = "SELECT * FROM Users WHERE email = @Email AND password = @Password";
            using (SqlConnection con = new(ConnectionString))
            {
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        rdr = cmd.ExecuteReader();
                        rdr.Read();
                        User record = new User()
                        {
                            Email = rdr["email"].ToString(),
                            Password = rdr["password"].ToString()
                        };
                        list.Add(record);
                        return list;
                    }
                    catch (Exception e)
                    {
                        return list;
                    }
                }
            }
        }
    }
}
