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
                _connection.Open();

                var command = new NpgsqlCommand();
                command.Connection = _connection;
                command.CommandText = "INSERT INTO \"User\" (\"UserName\", \"PasswordHash\") VALUES (@u, @p)";
                command.Parameters.AddWithValue("u", userName);
                command.Parameters.AddWithValue("p", passwordHash);
                command.ExecuteNonQuery();
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

        public string GetPasswordHash(string userName)
        {
            string passwordHash = null;
            try
            {
                _connection.Open();

                var command = new NpgsqlCommand();
                command.Connection = _connection;
                command.CommandText = "SELECT \"PasswordHash\" FROM \"User\" WHERE \"UserName\" = @u";
                command.Parameters.AddWithValue("u", userName);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    passwordHash = dataReader.GetString(0);
                }
            }
            catch (PostgresException ex)
            {
                // log exception
                return null;
            }
            finally
            {
                _connection.Close();
            }
            return passwordHash;
        }
    }
}
