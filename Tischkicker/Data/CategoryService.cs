using System.Data.SqlClient;
using System.Data;
namespace Tischkicker.Data
{
    public class CategoryService
    {
        private string connectionString = "Server = Dnold\\MSSQLSERVER01;Database=Tischkicker;Trusted_Connection=True;";

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlCmd = $"SELECT * FROM dbo.Categories";
                SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Category category = new Category();
                    category.Id = dr.GetInt32(0);
                    category.Name = dr.GetString(1);
                    category.imgUrl = dr.GetString(2);


                    categories.Add(category);
                }
                dr.Close();
                conn.Close();

            }
            return categories;
        }


    }
}
