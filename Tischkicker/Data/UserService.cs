namespace Tischkicker.Data
{
    using System.Data.SqlClient;
    public class UserService
    {
        private string connectionString = "Server = Dnold\\MSSQLSERVER01;Database=Tischkicker;Trusted_Connection=True;";
        public User GetUser(int id)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Users WHERE UserID = {id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    user.userID = reader.GetInt32(0);
                    user.username = reader.GetString(1);
                    user.email = reader.GetString(2);
                    user.passwort = reader.GetString(3);

                    //Todo: Admin Panel
                    user.admin = false;


                }
                reader.Close();
            }
            return user;

        }
        public void CreateUser(RegisterModel registerModel)
        {
            User user = ConvertRegisterIntoUser(registerModel);

            if (user != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Users (Username,Email,Password) VALUES ('{user.username}','{user.email}','{user.passwort}')", conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private User ConvertRegisterIntoUser(RegisterModel register)
        {
            User user = new User();
            user.username = register.Username;
            user.email = register.Email;
            user.passwort = register.Password;

            return user;
        }

        public User CheckLogin(SignInModel inModel)
        {
            User user = new User();
            user.userID = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Users WHERE Email = '{inModel.Email}'", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    user.userID = reader.GetInt32(0);
                    user.username = reader.GetString(1);
                    user.email = reader.GetString(2);
                    user.passwort = reader.GetString(3);


                }
                if (user.userID != -1)
                {
                    if (user.passwort == inModel.Password)
                    {


                        return user;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }



        }

        public void DeleteUser(User user)
        {
            using (SqlConnection sn = new SqlConnection(connectionString))
            {
                sn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Users WHERE UserID = {user.userID}", sn);
                cmd.ExecuteNonQuery();
                sn.Close();
            }
        }

        public void UpdateUser(User user)
        {

            User oldUser = GetUser(user.userID);
            using (SqlConnection sc = new SqlConnection(connectionString))
            {
                sc.Open();
                string sqlCommand = $"UPDATE dbo.Users SET Username='{user.username}', Password ='{user.passwort}', Email='{user.email}' WHERE UserID = {user.userID} ";
                SqlCommand cmd = new SqlCommand(sqlCommand, sc);
                cmd.ExecuteNonQuery();
                sc.Close();

            };
        }

    }
}

