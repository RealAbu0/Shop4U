using Dapper;
using DapperContext;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DapperConnections _dapperContext;

        public CartRepository(DapperConnections dapperContext)
        {
            _dapperContext = dapperContext;
        }
        

        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            var query = "GetAllCart_sp";
            DynamicParameters dp = new DynamicParameters();

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryAsync<Cart>(query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Cart>> GetAllCartByUserID(int userId)
        {
            var query = "GetCartByUserId_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@UserId", userId);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryAsync<Cart>(query, dp, commandType: CommandType.StoredProcedure);
                return result!;
            }
        }

        public async Task AddCart(Item cart, int userId)
        {
            var query = "AddToCart_sp";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@UserId", userId);
            dp.Add("@RowId", cart.RowId);
            //dp.Add("@ProductId", cart.ItemId);
            //dp.Add("@ProductName", cart.ItemName);
            //dp.Add("@ProductImage", cart.ItemImage);
            //dp.Add("@ProductQuantity", cart.ItemQuantity);
            //dp.Add("@ProductPrice", cart.ItemPrice);
            //dp.Add("@UsernameId", usernameId);

            using (var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QuerySingleOrDefaultAsync<Task>(query, dp, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<Cart> DeleteCartByCartId(int cartId)
        {
            var query = "DeleteCartById_sp";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@CartID", cartId);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<Cart>(query, dp, commandType: CommandType.StoredProcedure);
                return result!;
            }

            
        }

        public async Task<Cart> DeleteAllCart(int userId)
        {
            var query = "DeleteAllCart_sp";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@UserId", userId);

            using(var conn = _dapperContext.GetConnectionString())
            {
                var result = await conn.QueryFirstOrDefaultAsync<Cart>(query, dp, commandType: CommandType.StoredProcedure);
                return result!;
            }

          
        }

        public Task PayItems()
        {
            throw new NotImplementedException();
        }
    }
}
