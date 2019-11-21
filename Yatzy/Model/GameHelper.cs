using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class GameHelper
    {


        private Dictionary<string, int> _scoreList { get; set; }
        public bool IsGameFinished { get; set; }
        public int RoundNumber { get; set; }
        public GameHelper(Dictionary<string, int> scoreList)
        {
            _scoreList = scoreList;

        }
        //initialize with empty list
        public GameHelper() {
            _scoreList = new Dictionary<string, int>();
            _scoreList.Add("Ones", 0);
            _scoreList.Add("Twos", 0);
            _scoreList.Add("Threes", 0);
            _scoreList.Add("Fours", 0);
            _scoreList.Add("Fives", 0);
            _scoreList.Add("Sixes", 0);
            _scoreList.Add("ThreeOfAKind", 0);
            _scoreList.Add("FourOfAKind", 0);
            _scoreList.Add("FullHouse", 0);
            _scoreList.Add("SmallStraight", 0);
            _scoreList.Add("LargeStraight", 0);
            _scoreList.Add("Yatzy", 0);
            _scoreList.Add("Chance", 0);
        }

        public void SaveScore(string scoreName, int scoreValue)
        {
            if (!_scoreList.ContainsKey(scoreName))
                     throw new InvalidOperationException(); 

            _scoreList[scoreName] = scoreValue;
            RoundNumber++;
            if (RoundNumber >= 13)
            {
                IsGameFinished = true;
            }

        }

        public Dictionary<string, int> GetScoreList()
        {
            return _scoreList;
        }


    }   
}
