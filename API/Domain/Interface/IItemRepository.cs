using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllSoftDrinks();
        Task<IEnumerable<Item>> GetAllCandy();

        Task<IEnumerable<Item>> GetAllItems();
    }
}
