using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Controller;
using Yatzy.Model;

namespace Yatzy.View
{

    //This class prints the game.

    public  class GameView
    {
        private GamePresenter _presenter;
        private GameHelper _gameHelper;
        private DiceHolder _diceHolder;
        private ScoreParserFactory _scoreParserFactory;
        public void StartGame(){

            _gameHelper = new GameHelper();
            _scoreParserFactory = new ScoreParserFactory();
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            Die die4 = new Die();
            Die die5 = new Die();

            List<IDie> diceList = new List<IDie>
            {
                die1,
                die2,
                die3,
                die4,
                die5
            };

            _diceHolder = new DiceHolder(diceList);
            _presenter = new GamePresenter(_diceHolder, _gameHelper, _scoreParserFactory);

            Console.WriteLine("Lets play some Yatzy! What rules do you want to play? write 'Fun' for the fun rules, and 'Boring' for the boring ones!");
            string scoreParserToUse = Console.ReadLine();
            _presenter.ChooseScoreParser(scoreParserToUse);

            int []initialDiceToSave = new int[0];
            while (!_gameHelper.IsGameFinished)
            {
                _presenter.Roll(initialDiceToSave);

                //Simulates one Round with two rethrows
                for (int i = 0; i<2; i++) { 
               Console.WriteLine("Rethrow "+(i+1)+" Save the die by typing the die-numbers separated by a comma. E.g '4,1' saves the first and fourth die.\n" +_presenter.PrintDice());
               string rerollDiceToSave = Console.ReadLine();
               int[] diceToSave = _presenter.ParseDieSelection(rerollDiceToSave);

                _presenter.Roll(diceToSave);
             
               }

                Console.WriteLine("Time to save the score: see the current list here, and type in what to save.");
                Console.WriteLine(_presenter.PrintDice());
                Console.WriteLine(_presenter.PrintListWithScore());

                string scoreToSave = Console.ReadLine();
                _presenter.SaveScore(scoreToSave);
                Console.WriteLine("Score saved: ");
                Console.WriteLine(_presenter.PrintListWithScore());

            }
            Console.WriteLine("Well done! Final score is: " + _gameHelper.Score);



        }
        


    }
}
