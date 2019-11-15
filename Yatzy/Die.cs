using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Die
    {
        Random _random;
        public Die(Random random)
        {
            _random = random;
        }

        public int Value { get; set; }

        public int Roll()
        {
            int roll = _random.Next(1, 7);
            return roll;
        }


        //This bool will be used to indicate whether the user has "saved" the dice during a round, lok
        public bool isLocked { get; set; }



    }
}
