using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class GameClass
    {

        public static string playerChoice;
        bool gameModeChecker = true;
        bool isMultiplayer = true;

        SevensOutClass SO = new SevensOutClass();
        ThreeOrMoreClass TOM = new ThreeOrMoreClass();

        public void Game() //called from program
        {
            while (gameModeChecker == true) //loop so that you must enter one of the intended answers
            {
                Console.WriteLine("What would you like to play?");
                Console.WriteLine("1. Sevens out");
                Console.WriteLine("2. Three or more");
                string gameChoice = Console.ReadLine();

                if (gameChoice == "1")
                {
                    gameModeChecker = false; //Ends the gameModeChecker loop
                    while (isMultiplayer == true) //loop so that you must enter one of the intended answers
                    {
                        Console.WriteLine("Would you like to play single-player, multi-player or against AI?");
                        playerChoice = Console.ReadLine();

                        if (playerChoice == "single-player" || playerChoice == "multi-player" || playerChoice == "AI")
                        {
                            isMultiplayer = false; //Ends the isMultiplayer loop
                            SO.SevensOut(); //calls the void SevensOut in the SevensOutClass
                        }
                        else
                        {
                            Console.WriteLine("Please write your answer as seen in the question");
                        }
                    }
                }

                else if (gameChoice == "2")
                {
                    gameModeChecker = false; //Ends the gameModeChecker loop
                    while (isMultiplayer == true) //loop so that you must enter one of the intended answers
                    {
                        Console.WriteLine("Would you like to play single-player, multi-player or against AI?");
                        playerChoice = Console.ReadLine();

                        if (playerChoice == "single-player" || playerChoice == "multi-player" || playerChoice == "AI")
                        {
                            isMultiplayer = false; //Ends the isMultiplayer loop
                            TOM.ThreeOrMore(); //Calls the void ThreeOrMore in the ThreeOrMoreClass
                        }
                        else
                        {
                            Console.WriteLine("Please write your answer as seen in the question");
                        }
                    }
                }
                else Console.WriteLine("Please write either 1 or 2");
            }
        }
    }
}
