using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class Program
    {
        public static bool loop = true;
        public static void Main(string[] args)
        {
            while (loop == true) //loop so that you must enter one of the intended answers
            {
                Console.WriteLine("Would you like to: \n 1. Play a game \n 2. View the statistics of the games played \n 3. Test the games \n 4. Quit?");
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    GameClass G = new GameClass();
                    G.Game(); //calls the void Game in the GameClass
                }
                else if (userChoice == "2")
                {
                    StatisticsClass S = new StatisticsClass();
                    S.Stats(); //calls the void Stats in the StatisticsClass
                }
                else if (userChoice == "3")
                {
                    TestingClass T = new TestingClass();
                    T.Tester(); //calls the void Tester in the TestingClass
                }
                else if (userChoice == "4") loop = false; //Ends the program
                else Console.WriteLine("Please answer with either 1, 2, 3 or 4");
            }
        }
    }
}
