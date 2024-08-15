using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public string UsernameId { get; set; } = string.Empty;

    }
}
