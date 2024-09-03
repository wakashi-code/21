using System;
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
       // private cardValue _cardValue = cardValue.Ace;
         private CardValue cardValue;
         private CardSuit cardSuit;

         public CardSuit CardSuit => cardSuit;
         public CardValue Value => cardValue;




        
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
        AceLarge = 11,
        //туз может дать 1 или 11 очков в зависимости от ситуации


    }
    public enum CardSuit
    {
        Heart, //Сердце, Черви
        Diamond, // Бубны
        Spade, // Пики
        Club // Трефы, Крести
    }




}
