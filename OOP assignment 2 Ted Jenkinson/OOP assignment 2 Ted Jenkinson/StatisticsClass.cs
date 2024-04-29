using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class StatisticsClass
    {
        static public string sevensFilePath = "sevensScores.txt"; //sets the file name as a variable
        static public string threesFilePath = "threesScores.txt"; //sets the file name as a variable

        public void Stats() //Called from Program
        {
            string[] sLines = File.ReadAllLines(sevensFilePath); //reads all lines of txt from the file stored in the variable sevensFilePath
            int sNumber1 = int.Parse(sLines[0]); //converts the first line of txt to an integer
            int sNumber2 = int.Parse(sLines[1]); //converts the second line of txt to an integer
            Console.WriteLine($"The highest score gotten in seven's out is: {sNumber1} and seven's out has been played: {sNumber2} times");

            string[] tLines = File.ReadAllLines(threesFilePath); //reads all lines of txt from the file stored in the variable threesFilePath
            int tNumber = int.Parse(tLines[0]); //Converts the first line of txt to an integer
            Console.WriteLine($"Three or more has been played: {tNumber} times");
        }
        public void SevenPlus1() //called from SevensOutClass
        {
            string[] sLines = File.ReadAllLines(sevensFilePath); //reads all lines of txt from the file stored in the variable sevensFilePath
            int sNumber1 = int.Parse(sLines[0]); //converts the first line of txt to an integer
            int sNumber2 = int.Parse(sLines[1]); //converts the second line of txt to an integer
            sNumber2++; //incriments sNumber2 as this is the play counter for Sevens out
            if (SevensOutClass.runningTotalSP1 >= sNumber1 && SevensOutClass.runningTotalSP1 >= SevensOutClass.runningTotalSP2) sNumber1 = SevensOutClass.runningTotalSP1; //checks to see if player ones running total is larger then the current high score stored in sNumber1
            if (GameClass.playerChoice == "multi-player" || GameClass.playerChoice == "AI") if (SevensOutClass.runningTotalSP2 >= sNumber1 && SevensOutClass.runningTotalSP2 >= SevensOutClass.runningTotalSP1) sNumber1 = SevensOutClass.runningTotalSP2;//if the current game mode is set to multiplayer it check to see if player twos running total is larger then the current highscore

            File.WriteAllText(sevensFilePath, sNumber1 + "\n" + sNumber2); //replaces the two lines of txt with the values stored in sNumber1 and sNumber2
        }

        public void ThreePlus1() //caled from ThreeOrMoreClass
        {
            string[] tLines = File.ReadAllLines(threesFilePath);//reads all lines of txt from the file stored in the variable threesFilePath
            int tNumber = int.Parse(tLines[0]); //converts the first line of txt to an integer and stores it in tNumber
            tNumber++; //incriments tNumber as this is the play counter for Sevens out
            File.WriteAllText(sevensFilePath, tNumber + "\n"); // replaces the top line of txt with the value held in tNumber
        }
    }
}
