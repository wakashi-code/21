using System.ComponentModel.Design;

namespace _21_ochko
{
    public class Game
    {
        private const int LENGTH_OF_CARDS_IN_CROUPIE_HAND = 2;
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
                PrintColoredText($"Сумма ваших очков: {croupier.CalculateHandsCost(playerArm)}", ConsoleColor.Green);
                ShowCroupierCard(croupier);
                PrintColoredText("Введите 1,чтобы взять ещё одну карту.\nНажмите 2 чтобы спасовать.\nНажмите 0 если хотите закончить игру", ConsoleColor.White);

                _user_console_input = _menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier);
               while(_user_console_input == 0)
                    _menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier);

                CompareAmountsBetweenPlayerAndCroupier(croupier, playerArm, croupier.Arm);
                break;
                





            } while (_wallet.PlayerMoney > 0);

        }

        static void ShowPlayerBid(int playerBid) => PrintColoredText($"Ваша ставка: {playerBid}", ConsoleColor.Cyan);
        static void ShowCroupierCard(Croupier croupier) => PrintColoredText($"Карта крупье: {croupier.Arm[0]}", ConsoleColor.Red);
        static void ShowGreeting() => PrintColoredText("Добро пожаловать в игру '21 очко'.", ConsoleColor.Yellow);
        static void ShowPlayerBalance() => PrintColoredText($"Денег у вас в кошельке: {_wallet.PlayerMoney}", ConsoleColor.Cyan);
        static void AskPlayer(string text) => Console.WriteLine(text);

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








