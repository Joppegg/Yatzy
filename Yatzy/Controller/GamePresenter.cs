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

        private DiceHolder _diceHolder;
        public IScoreParser ScoreParser { get; set; }
        public GameHelper GameHelper { get; set; }
        private ScoreParserFactory _scoreParserFactory;


        public GamePresenter(DiceHolder diceHolder, GameHelper gameHelper,ScoreParserFactory scoreParserFactory)
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



    }
}
