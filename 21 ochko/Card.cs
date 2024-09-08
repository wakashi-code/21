﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_ochko
{
    /// <summary>
    /// 
    /// </summary>
    public class Card //Должно быть 36 штук
    {
 
        private const string SUIT_CHARS = "♥♦♠♣";
         private CardValue _cardValue;
         private CardSuit _cardSuit;

         public CardSuit CardSuit => _cardSuit;
         public CardValue Value => _cardValue;

        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            _cardValue = cardValue;
            _cardSuit = cardSuit;
        }

        public override string ToString()
        {

            return $"{GetCharFromSuit()} : {GetStringFromValue()}";
        }

        private char GetCharFromSuit()
        {
            return SUIT_CHARS[(int)_cardSuit];
        }
        
        // сделать второй метод который выдаёт номинал карты
        public string GetStringFromValue()
        {
            if((int)_cardValue >= 6)
                return ((int)_cardValue).ToString();

            return _cardValue.ToString();
        }

    }
    public enum CardValue : int
    {
        Ace = 1,
        Jack = 2,
        Queen = 3,
        King = 4,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        // 
        //туз может дать 1 или 11 очков в зависимости от ситуации


    }
    public enum CardSuit : int
    {
        Heart = 0, // Сердце, Черви
        Diamond = 1, // Бубны
        Spade = 2,  // Пики
        Club = 3 // Трефы, Крести
    }




}
