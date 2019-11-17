using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy.Interfaces
{
   public interface IDiceHolder
    {
        public List<IDie> DiceList { get; set; }

        public void RollDice();
    }
}
