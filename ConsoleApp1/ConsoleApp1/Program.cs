using System.ComponentModel;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Info about the game
            Console.WriteLine("Hello and welcome to the combat simulator game!");
            Console.WriteLine("Here's what the game is about:");
            Console.WriteLine(" - The game is played on a four-square field of dimensions 11 by 11");
            Console.WriteLine(" - The object of the game is to kill your enemy");
            Console.WriteLine(" - You can move around the field, attack your enemy, heal yourself and increase speed and attack damage");
            Console.WriteLine(" - Each player has 3 life hearts, and each player has an attack trait that indicates the number of hearts taken");
            Console.WriteLine(" - The character can move according to the speed property, for example if it is speed 2, it will always move 2 shelves");
            Console.WriteLine(" - Each player can only take two actions at a time, then it's the next player's turn");
            Console.WriteLine(" - The game ends when one of the players dies");
            Console.WriteLine("Here's how the game is played:");
            Console.WriteLine(" - Movement: move up, move down, move left, move right");
            Console.WriteLine(" - Attack: attack");
            Console.WriteLine(" - Heal yourself: heal");
            Console.WriteLine(" - Increase speed yourself: increase speed");
            Console.WriteLine(" - Increase attack yourself: increase attack \n");

            //Info about fighters
            Console.WriteLine("Enter the name of the first fighter!");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second fighter!");
            string name2 = Console.ReadLine();
            Console.Write("\n");

            //Create fighters
            List<Fighter> list = new List<Fighter>();
            //Add fighters to the list 
            list.Add(new Fighter(name1, 3, 1, 1, 0, 5));
            list.Add(new Fighter(name2, 3, 1, 1, 10, 5));

            //Show info about fighters
            Console.WriteLine("Here's info about fighters:");
            showInfoAboutPlayers(list[0], list[1]);
            Console.Write("\n");

            // Number of rounds
            int numberOfRounds = 0;

            Console.WriteLine("Game starts!");
            while (true)
            {   
                // Who is next (kdo je na rade)
                int whoIsNext = numberOfRounds % 2;
                // If both players are alive
                if(list[0].Health > 0 && list[1].Health > 0)
                {
                    Console.WriteLine("Round: {0}", numberOfRounds + 1);
                    Console.WriteLine("It's {0}'s turn", list[whoIsNext].Name);
                }
                // Every player has 2 actions, dont have i++, i++ is in switch
                for (int i = 0; i <= 1;)
                {
                    // Invalid input
                    bool invalidInput = false;
                    // If both players are alive
                    if (list[0].Health > 0 && list[1].Health > 0)
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "move up":
                                list[whoIsNext].moveUp();
                                i++;
                                break;
                            case "move down":
                                list[whoIsNext].moveDown();
                                i++;
                                break;
                            case "move left":
                                list[whoIsNext].moveLeft();
                                i++;
                                break;
                            case "move right":
                                list[whoIsNext].moveRight();
                                i++;
                                break;
                            case "attack":
                                list[whoIsNext].attackPlayer(list[1 - whoIsNext]);
                                i++;
                                break;
                            case "heal":
                                list[whoIsNext].healPlayer();
                                i++;
                                break;
                            case "increase speed":
                                list[whoIsNext].increaseSpeed();
                                i++;
                                break;
                            case "increase attack":
                                list[whoIsNext].increaseAttack();
                                i++;
                                break;
                            case "exit":
                                return;
                            default:
                                // Dont have i++, because we dont want to change player
                                Console.WriteLine("Invalid input!");
                                invalidInput = true;
                                break;
                        }
                    }
                    else
                    {   
                        // Print who wins
                        if (list[0].Health > list[1].Health)
                        {
                            Console.WriteLine("{0} wins! Congratulation!", list[0].Name);
                        }
                        else
                        {
                            Console.WriteLine("{0} wins! Congratulation!", list[1].Name);
                        }
                        Console.WriteLine("Game is over!");
                        return;
                    }

                    // Show info about player, if we change anything
                    if (invalidInput == false)
                    {
                        // Show map
                        showMap(list[0], list[1]);
                        // Show info about players
                        showInfoAboutPlayers(list[0], list[1]);
                    }
                }
                Console.Write("\n");
                // Next round
                numberOfRounds++;
            }
        }

        // Show info about players
        public static void showInfoAboutPlayers(Fighter player1, Fighter player2)
        {
            Console.WriteLine("P1: {0}:", player1.Name);
            Console.WriteLine(" - Positon: [{0}][{1}]", player1.X, player1.Y);
            Console.WriteLine(" - Health: {0}", player1.Health);
            Console.WriteLine(" - Attack: {0}", player1.Attack);
            Console.WriteLine(" - Speed: {0} \n", player1.Speed);

            Console.WriteLine("P2: {0}:", player2.Name);
            Console.WriteLine(" - Positon: [{0}][{1}]", player2.X, player2.Y);
            Console.WriteLine(" - Health: {0}", player2.Health);
            Console.WriteLine(" - Attack: {0}", player2.Attack);
            Console.WriteLine(" - Speed: {0}", player2.Speed);
        }

        // Print map of the game
        public static void showMap(Fighter player1, Fighter player2)
        {
            // Create map
            string[,] map = new string[12, 12];
            // Fill the map
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    // First row and first column = X
                    if (i == 0 && j == 0)
                    {
                        map[i, j] = "X";
                    }
                    // First row = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                    else if (i == 0)
                    {
                        // Add . to the end of the number
                        map[i, j] = ((j - 1).ToString() + ".").ToString();
                    }
                    // First column = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                    else if (j == 0)
                    {
                        // Add . to the end of the number
                        map[i, j] = ((i - 1).ToString() + ".").ToString();
                    }
                    // Player 1
                    else if (i == (player1.Y + 1) && j == (player1.X + 1))
                    {
                        map[i, j] = "P1";
                    }
                    // Player 2
                    else if ((i == (player2.Y + 1) && j == (player2.X + 1)))
                    {
                        map[i, j] = "P2";
                    }
                    // Empty space
                    else
                    {
                        map[i, j] = "  ";
                    }
                }
            }

            // Print map
            Console.Write("\n");
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write("{0} ", map[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
