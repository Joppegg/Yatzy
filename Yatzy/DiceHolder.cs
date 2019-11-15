using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class DiceHolder
    {
        public List<Die> DiceList { get; set; }

        public DiceHolder(List<Die> diceList)
        {
            DiceList = diceList;

        }

        public void RollDice()
        {
           foreach (Die d in DiceList)
            {
                d.Roll();
            }
        }




    }
}
