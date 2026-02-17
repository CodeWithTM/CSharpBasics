using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Delegates.CardsApp
{
    public class CardService
    {
        private readonly List<Card> _cards;

        public CardService()
        {
            // Dummy data (imagine this comes from DB)
            _cards = new List<Card>
        {
            new Card { CardNumber="1111222233334444", CustomerId="C1", IsBlocked=false, ExpiryDate=DateTime.Now.AddMonths(2), AvailableLimit=5000 },
            new Card { CardNumber="5555666677778888", CustomerId="C1", IsBlocked=true,  ExpiryDate=DateTime.Now.AddYears(1), AvailableLimit=0 },
            new Card { CardNumber="9999000011112222", CustomerId="C2", IsBlocked=false, ExpiryDate=DateTime.Now.AddDays(10), AvailableLimit=1000 },
        };
        }

        // Delegate-based method
        public List<CardDto> GetCards(
            string customerId,
            Func<Card, bool> filterLogic = null,
            Func<Card, CardDto> mapLogic = null)
        {
            IEnumerable<Card> query = _cards.Where(c => c.CustomerId == customerId);

            // Apply external filter logic
            if (filterLogic != null)
                query = query.Where(filterLogic);

            // Apply external mapping logic
            if (mapLogic != null)
                return query.Select(mapLogic).ToList();

            // Default mapping
            return query.Select(c => new CardDto
            {
                MaskedNumber = Mask(c.CardNumber),
                IsBlocked = c.IsBlocked,
                IsExpiringSoon = c.ExpiryDate <= DateTime.Now.AddDays(30)
            }).ToList();
        }

        private string Mask(string cardNumber)
        {
            return "XXXX-XXXX-XXXX-" + cardNumber.Substring(cardNumber.Length - 4);
        }
    }

    public class Card
    {
        public string CardNumber { get; set; } = "";
        public string CustomerId { get; set; } = "";
        public bool IsBlocked { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal AvailableLimit { get; set; }
    }


    public class CardDto
    {
        public string MaskedNumber { get; set; } = "";
        public bool IsBlocked { get; set; }
        public bool IsExpiringSoon { get; set; }
    }

}
