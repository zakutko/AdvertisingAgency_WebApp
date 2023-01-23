using System.Data;
using System.Data.SqlClient;

namespace AdvertisementsMicroservice.DAL.DataContext
{
    public class DapperContext
    {
        public IDbConnection CreateConnection()
            => new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
    }
}
