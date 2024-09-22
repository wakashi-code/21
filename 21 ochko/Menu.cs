using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_ochko
{
    public class Menu
    {
        private int _userInput;

        public int UserInput
        {
            get
            {
                return _userInput;
            }
            set
            {
                _userInput = value;
            }
        }

        public Menu() { }

        public bool CheckUserInput(int playerInput, List<Card> playerHandle, Croupier croupier)
        {
            if(playerInput == 0)
            {
                Console.Clear();
                return false;
            }
            else if (playerInput == 1)
            {
                croupier.AddCardTo(playerHandle);
                croupier.ThinkAboutNextMove(croupier);
                return false;
            }
            else if (playerInput == 2)
            {
                croupier.ThinkAboutNextMove(croupier);
                return true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                return false;
                
            }
        }
    }
}
