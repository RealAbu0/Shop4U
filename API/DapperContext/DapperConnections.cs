using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperContext
{
    public class DapperConnections
    {
        public IConfiguration _config;

        private readonly string _connectionString;

        public DapperConnections(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Default");
        }

        public IDbConnection GetConnectionString()
            => new SqlConnection(_connectionString);
    }
}
