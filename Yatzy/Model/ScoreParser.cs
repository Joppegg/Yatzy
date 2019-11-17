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
        private int _currentScore;
 
        public IDiceHolder _diceHolder{ get; set; }


        public ScoreParser(IDiceHolder diceHolder)
        {
            _diceHolder = diceHolder;
            _currentScore = 0;
           
        }

        public int CalculateSingleNumbers(int chosenScore)
        {
            
           foreach (IDie d in _diceHolder.DiceList)
            {
                if (d.Value == chosenScore)
                    _currentScore += d.Value;
            }

            return _currentScore;
        }

        /*
        *This method loops through the dicelist and checks if a number 1-6 is occuring n
        *It then returns that number times n. If no number occurs n or more times it will multiply by 0, thus returning a zero to be scored.
        *
        */
        public int CalculateNOfAKind(int numberOfAKind)
        {
            int scoreToBeMultipliedByThree = 0;

            for (int i=1; i<=6; i++)
            {
                int count = 0;
                foreach (IDie d in _diceHolder.DiceList)
                {
                    if (d.Value == i)
                        count++;
                }
                if (count >= numberOfAKind)
                    scoreToBeMultipliedByThree = i;
            }
            return scoreToBeMultipliedByThree * numberOfAKind;
        }


    }
}
