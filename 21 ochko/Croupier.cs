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
        private List<Card> _deck;
        private List<Card> _arm;
        

        public Croupier()
        {
            _deck = CreateDeck();
            _arm = new List<Card>(); // Заполнить картами.Тут должны находится карты,которых
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

        public void RaiseBid() //поднять ставку
        {

        }
        // Метод, который считает количество очков,которые дают тебе карты в руке
        public void CalculateHandsCost(List<Card> cards) 
        {

        }


    }
}
