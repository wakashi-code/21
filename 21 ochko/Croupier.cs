using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_ochko
{
    public class Croupier
    {
        private const int LENGTH_OF_CARD_VALUES = 10;
        private const int LENGTH_OF_CARD_SUITS = 4;
        private const int START_BID = 25;
        private const int START_AMOUNT_OF_POINTS = 0;
        private List<Card> _deck;
        private List<Card> _arm;

        public Croupier()
        {
            _deck = CreateDeck(); // Колода карт
            _arm = CreateCroupierHand(); // Рука крупье с двумя картами,отличающимися от карт игрока
            
        }

        private static List<Card> CreateDeck()
        {
            List<Card> cards = new List<Card>();
            for(int i = 1; i <= LENGTH_OF_CARD_VALUES; i++)
            {
                var value = (CardValue)i; 
                for(int j = 0; j < LENGTH_OF_CARD_SUITS; j++)
                {
                    var suit = (CardSuit)j;
                    cards.Add(new Card(value, suit));
                }
            }
            return cards;
        }

        public List<Card> GiveTwoFirstCards()
        {
            List<Card> twoCardDeck = new List<Card>();
            twoCardDeck.Add(GiveCard());
            twoCardDeck.Add(GiveCard());

            return twoCardDeck;

        }

        public Card GiveCard()
        {
            Random rnd = new Random();
            int index = rnd.Next(_deck.Count());
            
            Card card = _deck[index];

            _deck.RemoveAt(index);

            return card;
        }
        
        //Приватный метод который создаёт руку крупье,т.е. выдаёт ему две карты
        private List<Card> CreateCroupierHand()
        {
            List<Card> croupireDeck = new List<Card>();
            croupireDeck.Add(GiveCard());
            croupireDeck.Add(GiveCard());

            return croupireDeck;
        }

        public int RaiseBid(int bidPrice, int moneyInWallet) //поднять ставку
        {
            int BidCost = START_BID;
            if (moneyInWallet >= bidPrice)
            {
                BidCost += bidPrice;
            }
            return BidCost;
        }
        // Метод, который считает количество очков,которые дают тебе карты в твоей руке
        public string CalculateHandsCost(List<Card> cards) 
        {
            int costCardsInHandle = START_AMOUNT_OF_POINTS;
            foreach (Card card in cards)
            {
                costCardsInHandle += (int)card.CardValue ;
            }
            return $"Сумма очков в руке:{costCardsInHandle}";

           
        }


    }
}
