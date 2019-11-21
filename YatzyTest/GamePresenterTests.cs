using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;
using Yatzy.Controller;
using Yatzy.Interfaces;
using Yatzy.Model;

namespace YatzyTest
{

    [TestFixture]
    public class GamePresenterTests
    {

        /*
        *This test should assert that when a new game is started all required variables are 
        * setup correctly and reset.
        *
        */
        [Test]
        public void NewGame_ShouldResetAndNotHaveScoreParser()
        {
           
            //Arrange
            GameHelper gamehelper = new GameHelper();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            DiceHolder diceHolder = new DiceHolder();

       
            //Act
            GamePresenter gamePresenter = new GamePresenter(diceHolder, gamehelper, scoreParserFactory);
            Assert.AreEqual(gamehelper, gamePresenter.GameHelper);
         
      
            //Assert
            gamePresenter.NewGame();
            Assert.AreNotEqual(gamehelper, gamePresenter.GameHelper);
            Assert.IsNull(gamePresenter.ScoreParser);
      

        }

        [Test]
        public void ChooseScoreParser_ShouldSetScoreParserOrThrowIfInvalidInput()
        {
            //Arrange
            GameHelper gamehelper = new GameHelper();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            DiceHolder diceHolder = new DiceHolder();
            string funInput = "Fun";
            string boringInput = "Boring";

            GamePresenter gamePresenter = new GamePresenter(diceHolder, gamehelper, scoreParserFactory);

            Assert.IsNull(gamePresenter.ScoreParser);

            gamePresenter.ChooseScoreParser("Fun");

            Assert.IsTrue(gamePresenter.ScoreParser is IScoreParser);

            gamePresenter = new GamePresenter(diceHolder, gamehelper, scoreParserFactory);


            Assert.Throws<InvalidOperationException>(() => gamePresenter.ChooseScoreParser("NotValid"));




        }



        [Test]
        public void Roll_ShouldRollAndPresentDice()
        {

        }



    }
}
