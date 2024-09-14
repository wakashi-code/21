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
        private const int START_AMOUNT_OF_POINTS = 0;
        private const int COST_TO_CROUPIE_TO_THINK_ABOUT_NEXT_MOVE = 17;
        private List<Card> _deck;
        private List<Card> _arm;

        public List<Card> Arm => _arm;

        public Croupier()
        {
            _deck = CreateDeck(); // Колода карт
            _arm = CreateCroupierArm(); // Рука крупье с двумя картами,отличающимися от карт игрока
            
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

        public List<Card> AddCardTo(List<Card> cardsDeck)
        {
            cardsDeck.Add(GiveCard());
            return cardsDeck;
        }
        
        //Приватный метод который создаёт руку крупье,т.е. выдаёт ему две карты
        private List<Card> CreateCroupierArm()
        {
            List<Card> croupireDeck = new List<Card>();
            croupireDeck.Add(GiveCard());
            croupireDeck.Add(GiveCard());

            return croupireDeck;
        }

        public int RaiseBid(int bidPrice, int moneyInWallet) //поднять ставку
        {
            int BidCost = 0;
            if (moneyInWallet >= bidPrice)
            {
                BidCost += bidPrice;
            }
            return BidCost;
        }

        public int GetBidFromPlayer(int bidPrice, int moneyInWallet)
        {
            if (bidPrice <= moneyInWallet)
                return bidPrice;
            else return 0;
        }
        // Метод, который считает количество очков,которые дают тебе карты в твоей руке
        public string CalculateHandsCost(List<Card> cards) 
        {
            int costCardsInHandle = START_AMOUNT_OF_POINTS;
            foreach (Card card in cards)
            {
                costCardsInHandle += (int)card.CardValue ;
            }
            return $"{costCardsInHandle}";
        }

        public List<Card> SkipMove(List<Card> croupierHand)
        {
            return croupierHand;
        }

        public void ThinkAboutNextMove(Croupier croupier)
        {
            if(int.Parse(croupier.CalculateHandsCost(croupier.Arm)) >= COST_TO_CROUPIE_TO_THINK_ABOUT_NEXT_MOVE)
            {
                SkipMove(croupier.Arm);
            }
            else if (int.Parse(croupier.CalculateHandsCost(croupier.Arm)) <= COST_TO_CROUPIE_TO_THINK_ABOUT_NEXT_MOVE)
            {
                croupier.AddCardTo(croupier.Arm);
            }
        }
        

    }
}
