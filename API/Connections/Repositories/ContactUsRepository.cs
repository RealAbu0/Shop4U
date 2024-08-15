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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly DapperConnections _connection;

        public ContactUsRepository(DapperConnections connections)
        {
            _connection = connections;
        }


        public async Task<ContactUs> CreateContactUs(ContactUs contactUs)
        {
            var query = "CreateContactUs_sp";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Username", contactUs.Username);
            dp.Add("@Email", contactUs.Email);
            dp.Add("@Category", contactUs.Category);
            dp.Add("@Message", contactUs.Message);
            dp.Add("@UserId", contactUs.UserId);

            using(var conn = _connection.GetConnectionString())
            {
                var result = await conn.QuerySingleOrDefaultAsync<ContactUs>(query, dp, commandType: CommandType.StoredProcedure);
                return result!;
            }
        }
    }
}
