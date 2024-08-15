using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Repositories
{
    public class CardDetailsRepository : ICardDetailsRepository
    {
        private List<CardDetails> _cards = new List<CardDetails>();
        //{
        //    new CardDetails
        //    {
        //        CardHolderName =  "abu",
        //        CardNumber = 483984938,
        //        CardMM = 44, CardYY = 00,
        //        CardCVV = 123
        //    }
        //};

       

        public void AddCard(CardDetails cardDetails)
        {
            

            _cards.Add(cardDetails);


           
        }

        public List<CardDetails> GetAllCards()
        {
            return _cards;
        }
    }
}
