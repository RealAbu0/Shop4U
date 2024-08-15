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
    public class ItemRepository : IItemRepository
    {
        private readonly DapperConnections _connection;

        public ItemRepository(DapperConnections connections)
        {
            _connection = connections;
        }

        public async Task<IEnumerable<Item>> GetAllCandy()
        {
            var query = "GetAllCandy_sp";
            DynamicParameters dp = new DynamicParameters();

            using(var conn = _connection.GetConnectionString())
            {
                var result = await conn.QueryAsync<Item>(query, dp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var query = "GetAllRandomProducts_sp";

            DynamicParameters dp = new DynamicParameters();

            using(var conn = _connection.GetConnectionString())
            {
                var result = await conn.QueryAsync<Item>(query, dp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<Item>> GetAllSoftDrinks()
        {
            var query = "GetAllSoftDrinks_sp";
            DynamicParameters dp = new DynamicParameters();
         

            using( var conn = _connection.GetConnectionString())
            {
                var result = await conn.QueryAsync<Item>(query, dp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
