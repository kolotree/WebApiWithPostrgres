﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

                var command = new NpgsqlCommand("CreateUser", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(CreateStringParam(command, "username", userName));
                command.Parameters.Add(CreateStringParam(command, "PasswordHash", passwordHash));

                command.ExecuteReader();
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

                var command = new NpgsqlCommand("searchuser", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(CreateStringParam(command, "username", userName));

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    passwordHash = (string)dataReader["PasswordHash"];
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
