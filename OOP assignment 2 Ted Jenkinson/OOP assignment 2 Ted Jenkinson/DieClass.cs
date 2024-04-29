using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment_2_Ted_Jenkinson
{
    internal class DieClass
    {
        public static int dieNum;
        Random rnd = new Random(); //Instantiates a randomiser
        public void diceRoll() //called from both SevensOutClass and ThreeOrMoreClass
        {
            dieNum = rnd.Next(1, 7); //Randomises a number between 1 and 6 and assigns it to the variable dieNum
        }
    } 
}
