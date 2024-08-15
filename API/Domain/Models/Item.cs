using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
        public int RowId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public int ItemQuantity { get; set; } 
        public int ItemPrice { get; set; }
        public string ItemImage { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public string ItemCategory { get; set; } = string.Empty;
    }
}
