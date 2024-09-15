using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace _21_ochko
{
    public class Game
    {
        private const int LENGTH_OF_CARDS_IN_CROUPIE_HAND = 2;
        private const int AMOUNTS_TO_LOSE = 21;
        static Wallet _wallet = new Wallet(1000);
        static Menu _menu = new Menu();

        static void Main(string[] args)
        {
            int _playerBid = 0;
            int _user_console_input = 0;
            do
            {
                Croupier croupier = new Croupier();
                List<Card> playerArm = croupier.GiveTwoFirstCards();
                ShowGreeting();
                ShowPlayerBalance();
                AskPlayer("Сделайте ставку:");
                _playerBid = croupier.GetBidFromPlayer(CheckAndReturnPlayerInput(), _wallet.PlayerMoney);
                while (_playerBid == 0) // так как метод на проверку хуйня и просто ретёрнит 0, здесь я буду сверять с нулём
                    _playerBid = croupier.GetBidFromPlayer(CheckAndReturnPlayerInput(), _wallet.PlayerMoney);
                ShowPlayerBid(_playerBid);
                ShowPlayerArm(playerArm);
                ShowPlayerAmounts(croupier, playerArm);
                ShowCroupierCard(croupier);
                ShowConsoleCommands();
                while (!_menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier))
                    _menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier);
                ShowPlayerArm(playerArm);
                ShowPlayerAmounts(croupier, playerArm);
                ShowCroupierCardAfterMove(croupier);
                CompareAmountIfAbove21(croupier, playerArm, croupier.Arm);
                
                _menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier);

                 ShowPlayerAmounts(croupier, playerArm);
                 ShowConsoleCommands();


                CompareAmountsBetweenPlayerAndCroupier(croupier, playerArm, croupier.Arm);

                ShowCroupierHandFull(croupier);

                // Переделать так,чтобы был цикл в котором ты набираешь карты и видишь свои очки,затем после выбора команды пасс крупье набирает карты и уже после того как крупье сделает пасс
                // сравнивать очки и выводить резульатт

                break;
                





            } while (_wallet.PlayerMoney > 0);

        }

        static void ShowPlayerBid(int playerBid) => PrintColoredText($"Ваша ставка: {playerBid}", ConsoleColor.Cyan);
        static void ShowCroupierCard(Croupier croupier) => PrintColoredText($"Карты крупье: {croupier.Arm[0]}, ?", ConsoleColor.Red);
        static void ShowCroupierCardAfterMove(Croupier croupier) => PrintColoredText($"Карты крупье: {croupier.Arm[0]}, ?, {croupier.Arm[croupier.Arm.Count - 1]}", ConsoleColor.Red);
        static void ShowGreeting() => PrintColoredText("Добро пожаловать в игру '21 очко'.", ConsoleColor.Yellow);
        static void ShowPlayerBalance() => PrintColoredText($"Денег у вас в кошельке: {_wallet.PlayerMoney}", ConsoleColor.Cyan);
        static void AskPlayer(string text) => Console.WriteLine(text);
        static void ShowPlayerAmounts(Croupier croupier, List<Card> playerArm) => PrintColoredText($"Сумма ваших очков: {croupier.CalculateHandsCost(playerArm)}", ConsoleColor.Green);
        static void ShowConsoleCommands() => PrintColoredText("Введите 1,чтобы взять ещё одну карту.\nНажмите 2 чтобы спасовать.\nНажмите 0 если хотите закончить игру", ConsoleColor.White);

        static void ShowCroupierHandFull(Croupier croupier)
        {
            foreach (Card card in croupier.Arm)
                PrintColoredText($"Карта крупье: {card}", ConsoleColor.Cyan);
        }

        static void PrintColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void CompareAmountsBetweenPlayerAndCroupier(Croupier croupier, List<Card> playerArm, List<Card> croupierArm)
        {
            var userAmounts = croupier.CalculateHandsCost(playerArm);
            var croupierAmounts = croupier.CalculateHandsCost(croupierArm);
            PrintColoredText($"Ваши очки: {userAmounts}, очки крупье: {croupierAmounts}", ConsoleColor.Yellow);
            if (int.Parse(userAmounts) < int.Parse(croupierAmounts))
                PrintColoredText("Вы проиграли :(.", ConsoleColor.Red);
            
            else if (int.Parse(userAmounts) > int.Parse(croupierAmounts))
                PrintColoredText("Вы победили :)", ConsoleColor.Green);
            else
                PrintColoredText("Ничья", ConsoleColor.Cyan);
        }
        
        static bool CompareAmountIfAbove21(Croupier croupier, List<Card> playerArm, List<Card> croupierArm)
        {
            var userAmounts = croupier.CalculateHandsCost(playerArm);
            var croupierAmounts = croupier.CalculateHandsCost(croupierArm);
            if (int.Parse(userAmounts) > AMOUNTS_TO_LOSE)
            {
                PrintColoredText($"Вы набрали больше 21 очков.Вы проиграли", ConsoleColor.Red);
                return true;
            }
            else if (int.Parse(croupierAmounts) > AMOUNTS_TO_LOSE)
            {
                PrintColoredText($"У крупье больше 21 очков.Вы выйграли", ConsoleColor.Green);
                return true;
            }
            return false;
             
        }

        static List<Card> ShowPlayerArm(List<Card> playerCards)
        {
            foreach (Card card in playerCards)
                PrintColoredText($"{card.ToString()}", ConsoleColor.Green);
            return playerCards;
        }

        static int CheckAndReturnPlayerInput()
        { 
            string? text = Console.ReadLine();
            int user_input = 0;
            while(!int.TryParse(text, out user_input))
            {
                string? try_input_text = Console.ReadLine();
                if (int.TryParse(try_input_text, out int res))
                {
                    user_input = int.Parse(try_input_text);
                    return user_input;
                }
            }
            return int.Parse(text);
         }
    }
}








