using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class TestingClass
    {
        int runningTotalSP1Test;
        int sevensTotalTest;
        int dieNumS1StopTest;
        int dieNumS2StopTest;
        int totalTester1;
        int totalTester2;
        int lastScore;
        List<int> sevensTestListTest = new List<int>();
        public void Tester()
        {
            Console.WriteLine("What would you like to test 1. Dice 2. Sevens out 3. Three or more 4. Return to menu");
            string whatTest = Console.ReadLine();
            if (whatTest == "1") Debug.Assert(DieClass.dieNum >= 1 && DieClass.dieNum <= 6, "The dice is rolling outside of the 1 to 6 bounds");//checks to see if the dice outputing numbers outside of the intended bounds
            if (whatTest == "2")
            {
                if (sevensTestListTest == null) Console.WriteLine("No games of sevens out have been played yet");
                else
                {
                    foreach (int i in sevensTestListTest)
                    {
                        sevensTotalTest += sevensTestListTest[i];
                    }
                    Debug.Assert(sevensTotalTest == runningTotalSP1Test, "Sevens out is not adding the total up correctly");//checks to see if the total taken from sevens out class is being added correctly
                    int dieNumS1StopTotal = dieNumS1StopTest + dieNumS2StopTest + 1;
                    Debug.Assert(dieNumS1StopTotal == 7, "The stop feature of sevens out is not adding the total correctly");//checks to see if the stop feature in the sevens out class is working correctly
                }
            }
            if(whatTest == "3")
            {
                if (totalTester1 == 0) Console.WriteLine("No games of three or more have been played yet");
                else
                {
                    totalTester1 += lastScore;
                    Debug.Assert(totalTester1 == totalTester2, "The scores for Three or more arent being added up correctly"); //checks to see if the scores are being added correctly to the total
                    Debug.Assert(totalTester2 >= 20, "Three or more has stopped before a player has reached 20 points"); //checks to see if the game has finished before a player reaches 20 points+
                }
            }
            if(whatTest == "4")
            {
                //nothing is needed here since the program loops regardless
            }
        }

        public void TesterSaver() //saves needed vairables form their respected classes under the same variable name which is local to this class
        {
            sevensTestListTest = SevensOutClass.sevensTestList;
            runningTotalSP1Test = SevensOutClass.runningTotalSP1;
            dieNumS1StopTest = SevensOutClass.dieNumS1Stop;
            dieNumS2StopTest = SevensOutClass.dieNumS2Stop;
            totalTester1 = ThreeOrMoreClass.totalTester1;
            totalTester2 = ThreeOrMoreClass.totalTester2;
            lastScore = ThreeOrMoreClass.lastScore;
        }
    }
}
