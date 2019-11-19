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
    public class FunScoreParser : IScoreParser
    {
        private int _currentScore;
 
        public IDiceHolder _diceHolder{ get; set; }


        public FunScoreParser(IDiceHolder diceHolder)
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
        *This method loops through the dicelist and checks if a number 1-6 is occuring n times.
        *Fun score is: 3 of a kind, 20  points. 4 of a kind, 25 points. Yatzy, 50 ppoints.
  
        *
        */
        public int CalculateNOfAKind(int numberOfAKind)
        {
            int score = 0;

            for (int i=1; i<=6; i++)
            {
                int count = 0;
                foreach (IDie d in _diceHolder.DiceList)
                {
                    if (d.Value == i)
                        count++;
                }
                if (count == 3)
                    score = 20;
                if (count == 4)
                    score = 25;
                if (count == 5)
                    score = 50;
    
            }
            return score;
        }

        public int CalculateFullHouse()
        {
          
            bool occursTwoTimes = false;
            bool occursThreeTimes = false;
            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                foreach (IDie d in _diceHolder.DiceList)
                {
                    if (d.Value == i)
                        count++;
                }
                if (count == 2)
                    occursTwoTimes = true;
                if (count == 3)
                    occursThreeTimes = true;
            }

            return occursThreeTimes && occursTwoTimes ? 25 : 0;
            
        }

        public int CalculateStraight()
        {
            int points = 0;
            int[] diceArray = new int[5];
            for (int i = 0; i < 5; i++)
            {
                diceArray[i] = _diceHolder.DiceList[i].Value;
            }
            Array.Sort(diceArray);
            if (diceArray[0] == 1 && diceArray[1] == 2 && diceArray[2] == 3 && diceArray[3] == 4 && diceArray[4] == 5)
                points = 25;

            else if (diceArray[0] == 2 && diceArray[1] == 3 && diceArray[2] == 4 && diceArray[3] == 5 && diceArray[4] == 6)
                points = 30;

            return points;

        }

        public int CalculateChance()
        {
            
            foreach (IDie d in _diceHolder.DiceList)
            {
                _currentScore += d.Value;
            }
            return _currentScore;
        }
        //Checks if there is a yatzy







    }
}
