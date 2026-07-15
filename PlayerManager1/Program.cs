using System;
using System.Collections.Generic;

namespace PlayerManager1 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("=== PLAYER MANAGER ===");
            Console.WriteLine("1. Insert Player");
            Console.WriteLine("2. List All Players");
            Console.WriteLine("3. List Players with Score Greater Than...");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.WriteLine("\n--- INSERT NEW PLAYER ---");
            
            // Pede o nome
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            // Pede o score e converte para número em segurança
            Console.Write("Enter player score: ");
            if (int.TryParse(Console.ReadLine(), out int score))
            {
                // Cria o jogador e adiciona-o à lista!
                Player newPlayer = new Player(name, score);
                playerList.Add(newPlayer);
                Console.WriteLine($"Player '{name}' added successfully!");
            }
            else
            {
                Console.Error.WriteLine("Invalid score! Player not added.");
            }
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\n--- PLAYER LIST ---");
            foreach (Player p in playersToList)
            {
                Console.WriteLine($"Name: {p.Name} | Score: {p.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.WriteLine("\n--- FILTER PLAYERS BY SCORE ---");
            Console.Write("Enter minimum score: ");
            
            if (int.TryParse(Console.ReadLine(), out int minScore))
            {
                // 1. Obtém os jogadores filtrados
                IEnumerable<Player> filtered = GetPlayersWithScoreGreaterThan(minScore);
                
                // 2. Envia-os para o método que lista jogadores!
                ListPlayers(filtered);
            }
            else
            {
                Console.Error.WriteLine("Invalid score number!");
            }
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            List<Player> filteredList = new List<Player>();

            foreach (Player p in playerList)
            {
                if (p.Score > minScore)
                {
                    filteredList.Add(p);
                }
            }

            return filteredList;
        }
    }
}