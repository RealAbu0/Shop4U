using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICardDetailsRepository
    {
        void AddCard(CardDetails cardDetails);
        List<CardDetails> GetAllCards();
    }
}
