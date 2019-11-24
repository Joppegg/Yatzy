using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Interfaces;
using Yatzy.Model;

namespace Yatzy.Controller
{

    /*
    *This class acts as a controller for the console application. It controls the interaction
    * between the user and the system.
    * 
    */
    public class GamePresenter
    {

        private IDiceHolder _diceHolder;
        public IScoreParser ScoreParser { get; set; }
        public GameHelper GameHelper { get; set; }
        private ScoreParserFactory _scoreParserFactory;


        public GamePresenter(IDiceHolder diceHolder, GameHelper gameHelper,ScoreParserFactory scoreParserFactory)
        {
            _diceHolder = diceHolder;
            GameHelper = gameHelper;
            _scoreParserFactory = scoreParserFactory;
           
        }

        public void NewGame()
        {
            GameHelper = new GameHelper();
     
        }


        public void ChooseScoreParser(string nameOfParser)
        {
            if (nameOfParser.Equals("Fun", StringComparison.InvariantCultureIgnoreCase))
            {
               ScoreParser =  _scoreParserFactory.GetScoreParser("FunScoreParser", _diceHolder);
            }
            
            else if (nameOfParser.Equals("Boring", StringComparison.InvariantCultureIgnoreCase))
            {
                ScoreParser = _scoreParserFactory.GetScoreParser("BoringScoreParser", _diceHolder);
            }

            else
            {
                throw new InvalidOperationException();
            }


        }
     
        public void SaveScore(string chosenScoring) 
        {
            int score = 0;
            string switchScoring = chosenScoring.ToLower();
           

            switch (switchScoring)
            {
                case "ones":
                    score = ScoreParser.CalculateSingleNumbers(1);
                    GameHelper.SaveScore("Ones", score);
                    break;

                case "twos":
                    score = ScoreParser.CalculateSingleNumbers(2);
                    GameHelper.SaveScore("Twos", score);
                    break;

                case "threes":
                    score = ScoreParser.CalculateSingleNumbers(3);
                    GameHelper.SaveScore("Threes", score);
                    break;


                case "fours":
                    score = ScoreParser.CalculateSingleNumbers(4);
                    GameHelper.SaveScore("Fours", score);
                    break;

                case "fives":
                    score = ScoreParser.CalculateSingleNumbers(5);
                    GameHelper.SaveScore("Fives", score);
                    break;

                case "sixes":
                    score = ScoreParser.CalculateSingleNumbers(6);
                    GameHelper.SaveScore("Sixes", score);
                    break;

                case "threeofakind":
                    score = ScoreParser.CalculateNOfAKind(3);
                    GameHelper.SaveScore("ThreeOfAKind", score);
                    break;

                case "fourofakind":
                    score = ScoreParser.CalculateNOfAKind(4);
                    GameHelper.SaveScore("FourOfAKind", score);
                    break;

                case "fullhouse":
                    score = ScoreParser.CalculateFullHouse();
                    GameHelper.SaveScore("FullHouse", score);
                    break;

                case "straight":
                    score = ScoreParser.CalculateStraight();
                    GameHelper.SaveScore("Straight", score);
                    break;

                case "yatzy":
                    score = ScoreParser.CalculateNOfAKind(5);
                    GameHelper.SaveScore("Yatzy", score);
                    break;

                case "chance":
                    score = ScoreParser.CalculateChance();
                    GameHelper.SaveScore("Chance", score);
                    break;

            }

        }

        //Locks the dice TO BE SAVED, and rolls the rest of the dice.
        public void Roll(int[] diceToBeSaved)
        {
            for (int i = 0; i<diceToBeSaved.Length; i++)
            {
                _diceHolder.DiceList[diceToBeSaved[i]].IsLocked = true;
            }
            _diceHolder.RollDice();

        }
        
        //Graphically presents the dice and their values.
        public string PrintDice()
        {
            return "Dice1: [" + _diceHolder.DiceList[0].Value + "]" +
                " Dice2: [" + _diceHolder.DiceList[1].Value + "]" +
                " Dice3: [" + _diceHolder.DiceList[2].Value + "]" +
                " Dice4: [" + _diceHolder.DiceList[3].Value + "]" +
                " Dice5: [" + _diceHolder.DiceList[4].Value + "]";
        }

        public string PrintListWithScore()
        {
            StringBuilder scoreList = new StringBuilder();
            foreach (KeyValuePair<string, int> score in GameHelper.GetScoreList())
            {
                scoreList.Append(score.Key + " " + score.Value + "\n");
            }
            return scoreList.ToString();
        }


      


    }
}
