using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class DiceHolder
    {
        public List<IDie> DiceList { get; set; }

        public DiceHolder(List<IDie> diceList)
        {
            DiceList = diceList;

        }

        public void RollDice()
        {
           foreach (IDie d in DiceList)
            {
                d.Roll();
            }
        }




    }
}
