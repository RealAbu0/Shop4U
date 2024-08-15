using Dapper;
using DapperContext;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperConnections _dapperContext;

        public UserRepository(DapperConnections dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<User> AuthenticateLogin(User user)
        {
            var query = "AuthenticateUser_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Username", user.Username);
            dp.Add("@Password", user.Password);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> ChechEmailExist(string email)
        {
            var query = "CheckEmailExist_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Email", email);

            using (var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<bool>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> CheckUsernameExist(string username)
        {
            var query = "CheckUsernameExist_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Username", username);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<bool>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            var query = "CreateUser_sp";
            DynamicParameters dp = new DynamicParameters();
            
            dp.Add("@Username", user.Username);
            dp.Add("@Password", user.Password);
            dp.Add("@Firstname", user.Firstname);
            dp.Add("@Lastname", user.Lastname);
            dp.Add("@Email", user.Email);
            dp.Add("@Token", user.Token);
            dp.Add("@Role", user.Role);

            using (var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QuerySingleOrDefaultAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            var query = "DeleteUser_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@ID", id);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "GetAllUsers_sp";
            DynamicParameters dp = new DynamicParameters();

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }

        }

        public async Task<User> GetOneUser(int id)
        {
            var query = "GetOneUser_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@ID", id);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            var query = "UpdateUser_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@ID", user.ID);
            dp.Add("@Username", user.Username);
            dp.Add("@Password", user.Password);
            dp.Add("@Firstname", user.Firstname);
            dp.Add("@Lastname", user.Lastname);
            dp.Add("@Email", user.Email);
          

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QuerySingleOrDefaultAsync<User>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
