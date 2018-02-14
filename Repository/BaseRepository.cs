using Npgsql;
using System.Configuration;

namespace Repository
{
    public class BaseRepository
    {
        protected readonly NpgsqlConnection _connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString);
    }
}
