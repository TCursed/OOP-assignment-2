using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class ThreeOrMoreClass
    {
        static public int runningTotalTP1 = 0;
        static public int runningTotalTP2 = 0;
        public string rerollQ;
        public bool twoOfAKind;
        public int saved;
        public int saved2;
        int player = 1;
        static public bool playing = true;
        public int tree = 0;
        public int AIChoice;
        public int AI1Or2;
        string keepNumS;
        int keepNumI;
        static public int lastScore;
        static public int totalTester1;
        static public int totalTester2;
        public string multiPScoreDisplay;

        Random rnd = new Random();
        List<int> numList = new List<int>();

        DieClass dr = new DieClass();
        StatisticsClass TP1 = new StatisticsClass();
        TestingClass TS = new TestingClass();

        public void ThreeOrMore() //calls from GameClass
        {
            while (playing == true)
            {
                numList.Clear(); //Clears the list so the other player can play
                saved = 0;
                saved2 = 0;
                Console.WriteLine(" ");
                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") Console.WriteLine("Player " + player + "'s turn");//displayes the current players turn as without this multiplayer can be confusing

                else if (GameClass.playerChoice == "single-player") Console.WriteLine("New turn"); //displays when it is a new turn for solo playing to split the two rounds
                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "single-player")//Gives control of the speed of the program to the user
                {
                    Console.WriteLine("Press enter to roll dice");
                    Console.ReadLine();
                }
                else if (GameClass.playerChoice == "AI" && player == 1)// Gives control of the speed of the program to the user and the AI when its there turn
                {
                    Console.WriteLine("Press enter to roll dice");
                    Console.ReadLine();
                }
                dr.diceRoll();//calls the void called diceRoll in DieClass
                numList.Add(DieClass.dieNum);
                dr.diceRoll();//calls the void called diceRoll in DieClass
                numList.Add(DieClass.dieNum);
                dr.diceRoll();//calls the void called diceRoll in DieClass
                numList.Add(DieClass.dieNum);
                dr.diceRoll();//calls the void called diceRoll in DieClass
                numList.Add(DieClass.dieNum);
                dr.diceRoll();//calls the void called diceRoll in DieClass
                numList.Add(DieClass.dieNum);

                Console.WriteLine("Your dice rolls are:");
                Console.WriteLine($"1. {numList[0]}    2. {numList[1]}    3. {numList[2]}    4. {numList[3]}    5. {numList[4]}");
                dupSearch(); //calls the dupSearch void

                if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") //switches the current player and displays the totals for each player
                {
                    if (player == 1) player = 2;
                    else if (player == 2) player = 1;
                    Console.WriteLine($"Player 1's score: {runningTotalTP1}    Player 2's score: {runningTotalTP2}");
                }
                else if (GameClass.playerChoice == "single-player") Console.WriteLine($"Your score: {runningTotalTP1}");//displays the total for the user if playing single-player

                if (runningTotalTP1 >= 20 || runningTotalTP2 >= 20) //finishes the game when one players total reaches 20
                {
                    if (runningTotalTP1 > runningTotalTP2) Console.WriteLine("Player one wins");
                    if (runningTotalTP1 < runningTotalTP2) Console.WriteLine("Player two wins");
                    TP1.ThreePlus1(); //calls the void ThreePlus1 in the StatisticsClass
                    playing = false; //stops the playing loop
                }
            }
        }
        public void dupSearch() //serches the list for duplicates called from the ThreeOrMore and twooo void's
        {
            var duplicates = numList //creates a variable called duplicates and stores the numList
               .GroupBy(x => x) //groups elements together based on their value
               .Where(g => g.Count() > 1) //filters the groups for groups which are larger then 1
               .ToDictionary(group => group.Key, group => group.Count()); //converts the filtered groups into a dictionary with a key(the value) and a count(the amout of values in each key)
            tree = 0;
            saved = 0;
            saved2 = 0;
            totalTester1 = runningTotalTP1;
            lastScore = 0;
            foreach (var dupCount in duplicates) //loops for every key in duplicate
            {
                Console.WriteLine($"Value: {dupCount.Key}, Count: {dupCount.Value}");
                if (dupCount.Value == 5) //if one key has a count of 5 add 12 to the current players total
                {
                    if (player == 1) runningTotalTP1 += 12;
                    else if (player == 2) runningTotalTP2 += 12;
                    totalTester2 = runningTotalTP1;
                    lastScore = 12;
                }
                else if (dupCount.Value == 4) //if one key has a count of 4 add 6 to the current players total
                {
                    if (player == 1) runningTotalTP1 += 6;
                    else if (player == 2) runningTotalTP2 += 6;
                    totalTester2 = runningTotalTP1;
                    lastScore = 6;
                }
                else if (dupCount.Value == 3)//if one key has a count of 3 add 3 to the current players total sets tree to 1
                {
                    if (player == 1) runningTotalTP1 += 3;
                    else if (player == 2) runningTotalTP2 += 3;
                    totalTester2 = runningTotalTP1;
                    tree = 1;
                    lastScore = 3;
                }
                else if (dupCount.Value == 2 && tree != 1)//if one key has a count of 2 and tree dosnt = 1
                {
                    twoOfAKind = true;
                    if (saved == 0) saved = dupCount.Key;
                    else if (saved != 0 && dupCount.Key != saved) saved2 = dupCount.Key;
                }
            }
            TS.TesterSaver(); //Calls the void called TesterSaver in the TestingClass
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            if (twoOfAKind == true && tree != 1) twooo(); //calls the twooo void
        }
        void twooo() //called in the dupSearch void
        {
            twoOfAKind = false;
            if (GameClass.playerChoice == "multi-player" || player == 1)
            {
                if (saved != 0 && saved2 == 0)
                {
                    Console.WriteLine("You have a two of a kind, would you like to reroll all the dice or keep two?");
                    rerollQ = Console.ReadLine();
                    if (rerollQ == "keep two")
                    {
                        for (int i = 0; i < numList.Count; i++)
                        {
                            if (numList[i] != saved) //if i dosnt = saved
                            {
                                dr.diceRoll();//calls the void called diceRoll in DieClass
                                numList[i] = DieClass.dieNum; //replaces i with a dice roll
                            }
                        }
                        Console.WriteLine("Your dice rolls are:");
                        Console.WriteLine($"1. {numList[0]}    2. {numList[1]}    3. {numList[2]}    4. {numList[3]}    5. {numList[4]}");
                        dupSearch(); //calls the dupSearch void
                    }
                    else if (rerollQ == "reroll all")
                    {
                        Console.WriteLine("Rerolling");
                        ThreeOrMore(); //calls the ThreeOrMore void as the player is wiping their list
                    }
                }
                else if (saved != 0 && saved2 != 0) //if there are 2 two of a kinds in the players list
                {
                    Console.WriteLine("There are 2 two of a kind rolls, would you like to reroll all the dice or keep two?");
                    rerollQ = Console.ReadLine();
                    if (rerollQ == "keep two")
                    {
                        Console.WriteLine("What number would you like to keep?");
                        keepNumS = Console.ReadLine();
                        keepNumI = int.Parse(keepNumS);
                        for (int i = 0; i < numList.Count; i++)
                        {
                            if (numList[i] != keepNumI) //searches the list and reroll the dice for those which dont = keepNumI
                            {
                                dr.diceRoll();//calls the void called diceRoll in DieClasss
                                numList[i] = DieClass.dieNum; //assigns the dice roll to the value in space i
                            }
                        }
                        Console.WriteLine("Your dice rolls are:");
                        Console.WriteLine($"1. {numList[0]}    2. {numList[1]}    3. {numList[2]}    4. {numList[3]}    5. {numList[4]}");
                        dupSearch();//calls the dupSearch void
                    }
                    else if (rerollQ == "reroll all")
                    {
                        Console.WriteLine("Rerolling");
                        ThreeOrMore(); //calls the ThreeOrMore void as the player is wiping their list
                    }
                }
            }
            if (GameClass.playerChoice == "AI" && player == 2) //if the user is playing with AI
            {
                if (saved != 0 && saved2 == 0)
                {
                    AIChoice = rnd.Next(1, 4);//randomises wether the AI will reroll all or keep the two of a kind rerolling the other three
                    if (AIChoice == 1 || AIChoice == 2)
                    {
                        for (int i = 0; i < numList.Count; i++)
                        {
                            if (numList[i] != saved)// searches the list and reroll the dice for those which dont = saved
                            {
                                dr.diceRoll();//calls the void called diceRoll in DieClass
                                numList[i] = DieClass.dieNum;//assigns the dice roll to the value in space i
                            }
                        }
                        Console.WriteLine("Your dice rolls are:");
                        Console.WriteLine($"1. {numList[0]}    2. {numList[1]}    3. {numList[2]}    4. {numList[3]}    5. {numList[4]}");
                        dupSearch();//calls the dupSearch void
                    }
                    else if (AIChoice == 3)
                    {
                        Console.WriteLine("Rerolling");
                        ThreeOrMore(); //calls the ThreeOrMore void as the AI is wiping their list
                    }
                }
                else if (saved != 0 && saved2 != 0)
                {
                    AI1Or2 = rnd.Next(1, 3); //Randomises which 2 of a kind the AI will choose to keep
                    AIChoice = rnd.Next(1, 4);//randomises wether the AI will reroll all or keep the two of a kind rerolling the other three
                    if (AIChoice == 1 || AIChoice == 2)
                    {
                        if (AI1Or2 == 1) keepNumI = saved;
                        else if (AI1Or2 == 2) keepNumI = saved2;
                        Console.WriteLine($"The AI has chosen to keep the two {keepNumI}'s for their next roll");
                        for (int i = 0; i < numList.Count; i++)
                        {
                            if (numList[i] != keepNumI)//searches the list and reroll the dice for those which dont = keepNumI
                            {
                                dr.diceRoll();//calls the void called diceRoll in DieClass
                                numList[i] = DieClass.dieNum;//assigns the dice roll to the value in space i
                            }
                        }
                        Console.WriteLine("Your dice rolls are:");
                        Console.WriteLine($"1. {numList[0]}    2. {numList[1]}    3. {numList[2]}    4. {numList[3]}    5. {numList[4]}");
                        dupSearch();//calls the dupSearch void
                    }
                    else if (AIChoice == 3)
                    {
                        Console.WriteLine("Rerolling");
                        ThreeOrMore();//calls the ThreeOrMore void as the AI is wiping their list
                    }
                }
            }
        }
    }
}
