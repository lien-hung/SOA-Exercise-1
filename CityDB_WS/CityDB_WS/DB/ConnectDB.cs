using System.Data.SqlClient;

namespace CityDB_WS.DB
{
    public class ConnectDB
    {
        static readonly string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=world;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public static SqlConnection GetInstance()
        {
            return new SqlConnection(connStr);
        }
    }
}