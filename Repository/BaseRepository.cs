using Npgsql;
using System.Configuration;
using System.Data;

namespace Repository
{
    public class BaseRepository
    {
        protected NpgsqlConnection GetNpgsqlConnection() => new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString);

        protected NpgsqlParameter CreateStringParam(NpgsqlCommand command, string name, string value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name.ToLower();
            parameter.DbType = DbType.AnsiString;
            parameter.Value = value;
            return parameter;
        }
    }
}
