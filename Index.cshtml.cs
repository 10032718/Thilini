using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace PizzaPlanet.Pages.products
{


    public class IndexModel : PageModel
    {
        public List<productInfo> productInfos = new List<productInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=rs-mssql.database.windows.net;Initial Catalog=rs-mssql;Persist Security Info=True;User ID=rsuser;Password=***********";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString));
                {
                    SqlConnection.Open();
                    String sql = "SELECT * FROM app_product";
                    using (SqlCommand command = new SqlCommand(sql,connection));
                    {
                        using (SqlDataReader reader = command.ExecuteReader());
                        {
                            while (reader.Read())
                            {
                                productInfo info = new productInfo();
                                info.ProductId = "" + reader.GetInt(0);
                                info.Name = reader.GetString(1);
                                info.Description = reader.GetString(2);
                                info.Size = reader.GetString(3);
                                info.Kcal = reader.GetString(4);
                                info.Price = reader.GetString(5);
                                info.Status = reader.GetString(6);
                                info.Type = reader.GetString(7);

                                productInfos.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

Console.WriteLine("Exception: "+ ex.ToString());
            }
        }
    }

    public class productInfo
    {

        public string ProductId;
        public string Name;
        public string Description;
        public string Size;
        public string Kcal;
        public string Price;
        public string Status;
        public string Type;
    }
}
