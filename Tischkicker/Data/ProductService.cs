using System.Data.SqlClient;
using System.Data;
namespace Tischkicker.Data
{
    public class ProductService
    {
        private string connectionString = "Server = Dnold\\MSSQLSERVER01;Database=Tischkicker;Trusted_Connection=True;";


        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Product product = new Product();

                    product.id = reader.GetInt32(0);
                    product.name = reader.GetString(1);
                    product.description = reader.GetString(2);

                    product.picUrls = reader.GetString(3).Split(";");
                    product.price = (float)reader.GetDouble(4);
                    product.categoryId = reader.GetInt32(5);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
        public List<Product> GetAllProductsFromCategory(Category category)
        {
            List<Product> productList = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlCmd = $"SELECT * FROM dbo.Products WHERE categoryID = {category.Id}";
                SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();

                    product.id = reader.GetInt32(0);
                    product.name = reader.GetString(1);
                    product.description = reader.GetString(2);

                    product.picUrls = reader.GetString(3).Split(";");
                    product.price = (float)reader.GetDouble(4);
                    product.categoryId = reader.GetInt32(5);
                    productList.Add(product);
                }
                reader.Close();
                conn.Close();

            }
            return productList;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Products WHERE productId = {id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    

                    product.id = reader.GetInt32(0);
                    product.name = reader.GetString(1);
                    product.description = reader.GetString(2);

                    product.picUrls = reader.GetString(3).Split(";");
                    product.price = (float)reader.GetDouble(4);
                    product.categoryId = reader.GetInt32(5);
                    
                }
                reader.Close();
            }
            return product;
        }
    }

}

