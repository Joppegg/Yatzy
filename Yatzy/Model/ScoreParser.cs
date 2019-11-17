using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Interfaces;

namespace Yatzy
{
    /*
    * This is a helper class supposed to simulate the scoring in the yatzy game.
    * This class should take the chosen score (e.g fives) and return the highest possible scoring from the 
    * provided DiceHolder.As such, if the score is invalid (no dice is 5 for fives..) it will return 0.
    *
    */
    public class ScoreParser
    {
        public IDiceHolder _diceHolder{ get; set; }

        public ScoreParser(IDiceHolder diceHolder)
        {
            _diceHolder = diceHolder;
        }

        public int CalculateOnes()
        {
            return 5;
        }

    }
}
