namespace _21_ochko
{
    public class Game
    {
        static void Main(string[] args)
        {
            while(true)
            {
                ShowGreeting();
                InitializeWallet();
                ShowPlayerArm();
                
                break;
            }
            
        }
        //название хуета,переименовать
        static Wallet InitializeWallet()
        {
            Wallet playerWallet = new Wallet(1000);

            return playerWallet;
        }
        static Croupier InitializeCroupier()
        {
            Croupier croupier = new Croupier();

            return croupier;
        }
        
        static List<Card> InitializePlayerArm()
        {
            List<Card> playerArm = InitializeCroupier().GiveTwoFirstCards();

            return playerArm;
        }
        
        static void ShowPlayerArm()
        {
            Console.WriteLine("Ваши карты: ");
            foreach(Card card in InitializePlayerArm())
            {
                Console.Write($" {card} ");
            }

        }

        static void ShowGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Добро пожаловать в игру '21 очко'.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            
        }

        static List<Card> ShowPlayerArm(List<Card> playerCards)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("Ваши карты: ");
            foreach (Card card in playerCards)
                Console.Write($" {card} ");

            return playerCards;
            

            
        }
        
    }
}








/*
 * Croupier croup = new Croupier();
            
            Wallet wallet = new Wallet(1000);
            List<Card> challenge = croup.GiveTwoFirstCards();
            Console.Write("Карты в руке: ");
            foreach (Card card in challenge)
            {
                
                Console.Write(card);
                Console.WriteLine("");
            }
            string SumOfPoints = croup.CalculateHandsCost(challenge);
            Console.WriteLine(SumOfPoints);
*/
