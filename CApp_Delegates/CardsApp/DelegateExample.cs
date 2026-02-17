using CApp_Delegates.CardsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Delegates
{
    public class DelegateExample
    {

        public static void Main1()
        {
            CardService cardService = new CardService();
                        var activeCards = cardService.GetCards(
                "C1",
                filterLogic: card => card.IsBlocked == false
            );

        }
    }
}
