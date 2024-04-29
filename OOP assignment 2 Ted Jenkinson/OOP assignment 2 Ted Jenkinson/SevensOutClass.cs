using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class SevensOutClass
    {
        public bool playing = true;
        static public int totalSO;
        public int dieNumS1;
        public int dieNumS2;
        static public int dieNumS1Stop;
        static public int dieNumS2Stop;
        static public int runningTotalSP1 = 0;
        static public int runningTotalSP2 = 0;
        int player = 1;

        StatisticsClass SP1 = new StatisticsClass();
        DieClass dr = new DieClass();
        TestingClass TS = new TestingClass();

        public static List<int> sevensTestList = new List<int>();

        public void SevensOut()//Called from GameClass
        {
            runningTotalSP1 = 0;
            runningTotalSP2 = 0;
            sevensTestList.Clear(); //Clears the tester list so that only the rolls from the most recent sevens out game

            while (playing == true) //Loop so that the game is repeated for multiple rolls per turn
            {
                Console.WriteLine(" ");
                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") Console.WriteLine("Player " + player + "'s turn"); //displayes the current players turn as without this multiplayer can be confusing

                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "single-player") //Gives control of the speed of the program to the user
                {
                    Console.WriteLine("Press a key to roll dice");
                    Console.ReadLine();
                }
                else if (GameClass.playerChoice == "AI" && player == 1)//Gives control of the speed of the program to the user and the AI when its there turn
                {
                    Console.WriteLine("Press a key to roll dice");
                    Console.ReadLine();
                }

                dr.diceRoll(); //calls the void called diceRoll in DieClass
                dieNumS1 = DieClass.dieNum;
                dr.diceRoll();//calls the void called diceRoll in DieClass
                dieNumS2 = DieClass.dieNum;

                if (player == 1) //adds only player ones rolls to the testing list
                {
                    sevensTestList.Add(dieNumS1);
                    sevensTestList.Add(dieNumS2);
                }

                Console.WriteLine($"Your numbers are: {dieNumS1} and: {dieNumS2}");
                totalSO = dieNumS1 + dieNumS2; //calculates the total for the rolls
                if (player == 1) runningTotalSP1 += totalSO; //adds the the current rolls total to player ones running total
                else if (player == 2) runningTotalSP2 += totalSO;//adds the the current rolls total to player twos running total

                if (totalSO == 7) //if the toatalSO is seven it stops the loop so game ends
                {
                    Console.WriteLine("Your total is: " + totalSO);
                    dieNumS1Stop = dieNumS1;
                    dieNumS2Stop = dieNumS2;
                    playing = false;
                }

                else if (dieNumS1 == dieNumS2) //doubles the total if diceNum1/2 are the same digit
                {
                    totalSO *= 2;
                    Console.WriteLine("Due to it being a double your total is: " + totalSO);
                }

                else Console.WriteLine("Your total is: " + totalSO);
                
                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") //switches the current player
                {
                    if (player == 1) player = 2;

                    else if (player == 2) player = 1;
                }

                if (GameClass.playerChoice == "single-player") Console.WriteLine("Your total score is: " + runningTotalSP1); //displays the total for the player if solo
                else if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") //displays the current total of both players
                {
                    Console.WriteLine("Player one's score is: " + runningTotalSP1);
                    Console.WriteLine("Player two's score is: " + runningTotalSP2);
                }
            }

            if (runningTotalSP1 > runningTotalSP2) Console.WriteLine("Player 1 wins");
            else if (runningTotalSP1 < runningTotalSP2) Console.WriteLine("Player 2 wins");
            SP1.SevenPlus1(); //Calls the void called SevePlus1 in the statistics class
            TS.TesterSaver(); //Calls the void called TesterSaver in the TestingClass
        }
    }
}
