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

        public int CheckUserInput(int playerInput, List<Card> playerHandle, Croupier croupier)
        {
            if(playerInput == 0)
            {
                Console.Clear();
                return 1;
            }
            else if (playerInput == 1)
            {
                croupier.AddCardTo(croupier.AddCardTo(playerHandle));
                return 1;
            }
            else if (playerInput == 2)
            {
                croupier.ThinkAboutNextMove(croupier);
                return 1;
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                return 0;
                
            }
        }
    }
}
