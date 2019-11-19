using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Yatzy.Interfaces;

namespace Yatzy
{
    public class DiceHolder : IDiceHolder
    {
        public List<IDie> DiceList { get; set; }

        public DiceHolder()
        {

        }
        public DiceHolder(List<IDie> diceList)
        {
            DiceList = diceList;

        }

        public void RollDice()
        {
           foreach (IDie d in DiceList)
            {
                if (!d.IsLocked) { 
                d.Roll();
                }
            }
        }

        public int GetSumOfAllDice()
        {
            int sum = 0;
            foreach(IDie d in DiceList)
            {
                sum += d.Value;
            }
            return sum;
        }




    }
}
