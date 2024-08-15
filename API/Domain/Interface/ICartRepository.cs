using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICartRepository
    {
        public Task AddCart(Item cart, int userId);
        Task<Cart> DeleteAllCart(int userId);
        
        Task<IEnumerable<Cart>> GetAllCart();
        Task<IEnumerable<Cart>> GetAllCartByUserID(int userId);

        public Task<Cart> DeleteCartByCartId(int cartId);

        Task PayItems();



    }
}
