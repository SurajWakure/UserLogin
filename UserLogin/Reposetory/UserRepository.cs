using System.Data.SqlClient;
using UserLogin.Models;

namespace UserLogin.Reposetory
{
    public class UserRepository:IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBCS");
        }

        public UserModel ValidateUser(string username, string password)
        {
            UserModel user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT UserId, Username, Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
