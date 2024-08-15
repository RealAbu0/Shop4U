using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CardDetails
    {
        public string CardHolderName { get; set; } = string.Empty;
        public int CardNumber { get; set; }
        public int CardMM { get; set; }
        public int CardYY { get; set; }
        public int CardCVV { get; set; }
    }
}
