using CSharpFunctionalExtensions;
using Npgsql;
using System.Data;

namespace Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public Result Create(string userName, string passwordHash)
        {
            try
            {
                NpgsqlConnection _connection;
                using (_connection = GetNpgsqlConnection())
                {
                    _connection.Open();
                    NpgsqlCommand command;
                    using (command = new NpgsqlCommand("CreateUser", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(CreateStringParam(command, "username", userName));
                        command.Parameters.Add(CreateStringParam(command, "PasswordHash", passwordHash));

                        command.ExecuteReader();
                    }
                }
            }
            catch (PostgresException ex)
            {
                // log exception
                return Result.Fail(ex.Message);
            }
            return Result.Ok();
        }

        public Result<string> GetPasswordHash(string userName)
        {
            string passwordHash = null;
            try
            {
                NpgsqlConnection _connection;
                using (_connection = GetNpgsqlConnection())
                {
                    _connection.Open();
                    NpgsqlCommand command;
                    using (command = new NpgsqlCommand("searchuser", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(CreateStringParam(command, "username", userName));

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            passwordHash = (string)dataReader["PasswordHash"];
                        }
                    }
                }
            }
            catch (PostgresException ex)
            {
                // log exception
                return Result.Fail<string>(ex.Message);
            }
            return Result.Ok(passwordHash);
        }
    }
}
