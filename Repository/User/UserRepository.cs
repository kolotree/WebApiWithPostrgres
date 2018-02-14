using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public Task Create(string userName, string passwordHash)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "INSERT INTO User (UserName, PasswordHash) VALUES (@u, @p)";
                cmd.Parameters.AddWithValue("u", userName);
                cmd.Parameters.AddWithValue("p", passwordHash);
                cmd.ExecuteNonQuery();
            }
            catch (PostgresException ex)
            {
                return Task.FromException(ex);
            }
            finally
            {
                _connection.Close();
            }
            return Task.FromResult(true);
        }
    }
}
