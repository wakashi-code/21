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
            PlayGame();
        }
        static void PlayGame()
        {
        int _playerBid = 0;
        bool _IsEnded = false;
            bool isEnoughCard = false;
        do
        {
            Croupier croupier = new Croupier();
            List<Card> playerArm = croupier.GiveTwoFirstCards();
            ShowGreeting();
            ShowPlayerBalance();
            AskPlayer("Сделайте ставку:");
            _playerBid = croupier.GetBidFromPlayer(CheckAndReturnPlayerInput(), _wallet.PlayerMoney);
            TakeBidFromWallet(_playerBid);

            while (_playerBid == 0) // так как метод на проверку хуйня и просто ретёрнит 0, здесь я буду сверять с нулём
                _playerBid = croupier.GetBidFromPlayer(CheckAndReturnPlayerInput(), _wallet.PlayerMoney);

            ShowPlayerBid(_playerBid);
            ShowPlayerArm(playerArm);
            ShowPlayerAmounts(croupier, playerArm);
            ShowCroupierCard(croupier);
            ShowConsoleCommands();

                do
                {
                    if (_menu.CheckUserInput(CheckAndReturnPlayerInput(), playerArm, croupier) == true)
                        isEnoughCard = true;
                    
                    else
                    {
                        ShowPlayerArm(playerArm);
                        ShowPlayerAmounts(croupier, playerArm);
                        if(int.Parse(croupier.CalculateHandsCost(playerArm)) < AMOUNTS_TO_LOSE || int.Parse(croupier.CalculateHandsCost(croupier.Arm)) < AMOUNTS_TO_LOSE)
                            ShowConsoleCommands();
                    }
                    
                } while (!isEnoughCard && !CompareAmountIfAbove21WithoutText(croupier, playerArm, croupier.Arm));



            while (!_IsEnded)
                {

                    if (CompareAmountIfAbove21(croupier, playerArm, croupier.Arm))
                    {
                        ShowPlayerArm(playerArm);
                        ShowCroupierHandFull(croupier);
                        ShowCroupierAmounts(croupier);
                        _IsEnded = true;

                        EndGame();
                    }

                    else
                    {
                        if (CompareAmountsBetweenPlayerAndCroupier(croupier, playerArm, croupier.Arm) == "Победа")
                        {
                            AddDoubleCashToWallet(_playerBid);
                            ShowPlayerArm(playerArm);
                            ShowCroupierHandFull(croupier);
                            ShowCroupierAmounts(croupier);
                            _IsEnded = true;

                            EndGame();
                            
                        }
                        else if (CompareAmountsBetweenPlayerAndCroupier(croupier, playerArm, croupier.Arm) == "Проигрыш")
                        {
                            ShowPlayerArm(playerArm);
                            ShowCroupierHandFull(croupier);
                            ShowCroupierAmounts(croupier);
                            _IsEnded = true;

                            EndGame();
                            

                        }
                        else if (CompareAmountsBetweenPlayerAndCroupier(croupier, playerArm, croupier.Arm) == "Ничья")
                        {
                            
                            ReturnBidToWalletIfDraw(_playerBid);
                            ShowPlayerArm(playerArm);
                            ShowCroupierHandFull(croupier);
                            ShowCroupierAmounts(croupier);
                            _IsEnded = true;

                            EndGame();
                            
                        }

                    }

                }

            } while (_wallet.PlayerMoney > 0);

        }

        static void EndGame()
        {   
            PrintColoredText("Игра окончена.\n", ConsoleColor.Red);
            PlayGame();
            
        }
        static void ReturnBidToWalletIfDraw(int playerBid) => _wallet.AddCashToWallet(playerBid);
        static void AddDoubleCashToWallet(int playerBid) => _wallet.AddCashToWallet(playerBid * 2);
        static void TakeBidFromWallet(int playerBid) => _wallet.TryTakeCashFromWallet(playerBid);
        static void ShowPlayerBid(int playerBid) => PrintColoredText($"Ваша ставка: {playerBid}", ConsoleColor.Cyan);
        static void ShowCroupierCard(Croupier croupier) => PrintColoredText($"\nКарты крупье: {croupier.Arm[0]}, ?", ConsoleColor.Red);
        static void ShowGreeting() => PrintColoredText("Добро пожаловать в игру '21 очко'.", ConsoleColor.Yellow);
        static void ShowPlayerBalance() => PrintColoredText($"Денег у вас в кошельке: {_wallet.PlayerMoney}", ConsoleColor.Cyan);
        static void AskPlayer(string text) => Console.WriteLine(text);
        static void ShowPlayerAmounts(Croupier croupier, List<Card> playerArm) => PrintColoredText($"Сумма ваших очков: {croupier.CalculateHandsCost(playerArm)}", ConsoleColor.Green);
        static void ShowConsoleCommands() => PrintColoredText("Введите 1,чтобы взять ещё одну карту.\nНажмите 2 чтобы спасовать.\nНажмите 0 если хотите закончить игру", ConsoleColor.White);
        static void ShowCroupierAmounts(Croupier croupier) => PrintColoredText($"Сумма очков крупье: {croupier.CalculateHandsCost(croupier.Arm)}", ConsoleColor.Cyan);

        static void ShowCroupierHandFull(Croupier croupier)
        {
            PrintColoredText("\nКарты крупье:", ConsoleColor.Cyan);
            foreach (Card card in croupier.Arm)
                PrintColoredText($"{card}", ConsoleColor.Cyan);
        }

        static void PrintColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        

        static string CompareAmountsBetweenPlayerAndCroupier(Croupier croupier, List<Card> playerArm, List<Card> croupierArm)
        {
            var userAmounts = croupier.CalculateHandsCost(playerArm);
            var croupierAmounts = croupier.CalculateHandsCost(croupierArm);
            PrintColoredText($"Ваши очки: {userAmounts}, очки крупье: {croupierAmounts}", ConsoleColor.Yellow);
            if (int.Parse(userAmounts) < int.Parse(croupierAmounts))
            {
                PrintColoredText("Вы проиграли :(.", ConsoleColor.Red);
                return "Проигрыш";
            }
            else if (int.Parse(userAmounts) > int.Parse(croupierAmounts))
            {
                PrintColoredText("Вы победили :)", ConsoleColor.Green);

                return "Победа";
            }
               
            else if (int.Parse(userAmounts) > int.Parse(croupierAmounts))
            {
                PrintColoredText("Ничья", ConsoleColor.Cyan);
                return "Ничья";
            }
            return "";
            
        }
        
        static bool CompareAmountIfAbove21WithoutText(Croupier croupier, List<Card> playerArm, List<Card> croupierArm)
        {
            var userAmounts = croupier.CalculateHandsCost(playerArm);
            var croupierAmounts = croupier.CalculateHandsCost(croupierArm);
            if (int.Parse(userAmounts) > AMOUNTS_TO_LOSE)
            {
                return true;
            }
            else if (int.Parse(croupierAmounts) > AMOUNTS_TO_LOSE)
            {
                return true;
            }
            return false;
        }

        static bool CompareAmountIfAbove21(Croupier croupier, List<Card> playerArm, List<Card> croupierArm)
        {
            var userAmounts = croupier.CalculateHandsCost(playerArm);
            var croupierAmounts = croupier.CalculateHandsCost(croupierArm);
            if (int.Parse(userAmounts) > AMOUNTS_TO_LOSE)
            {
                PrintColoredText($"Вы набрали больше 21 очков.Вы проиграли", ConsoleColor.Red);
                AddDoubleCashToWallet();
                return true;
            }
            else if (int.Parse(croupierAmounts) > AMOUNTS_TO_LOSE)
            {
                PrintColoredText($"У крупье больше 21 очков.Вы выиграли", ConsoleColor.Green);
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








