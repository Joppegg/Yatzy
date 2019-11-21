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

        //Switch statement to save. should throw io exception if already saved.
        public void SaveScore(string chosenScoring)
        {
            int score = 0;
            string switchScoring = chosenScoring.ToLower();
            //later on, should probably throw error to view.
         
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

                case "triples":
                    score = ScoreParser.CalculateNOfAKind(3);
                    GameHelper.SaveScore("ThreeOfAKind", score);
                    break;

                case "quadruples":
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

            //try.
            


        }



    }
}
