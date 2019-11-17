using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Die : IDie
    {
        Random _random;
   
        public Die(){
            _random = new Random();
        }
        public Die(Random random)
        {
            _random = random;
        }

        public int Id { get; set; }

        public int Value { get; set; }

        //Roll method - returns a random value 1-6.

        public  int Roll()
        {
             Value = _random.Next(1, 7);
            return Value;
        }

        //This bool will be used to indicate whether the user has "saved" the dice during a round, lok

        public bool IsLocked { get; set; }



    }
}
