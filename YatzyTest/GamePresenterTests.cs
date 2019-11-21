using Moq;
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
    public class GamePresenterTests : ScoreParserTesting
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


            GamePresenter gamePresenter = new GamePresenter(diceHolder, gamehelper, scoreParserFactory);

            //Assert scoreparser is null before choosing
            Assert.IsNull(gamePresenter.ScoreParser);
            gamePresenter.ChooseScoreParser(funInput);

         
            //Assert scoreparser implements IScoreParser
            Assert.IsTrue(gamePresenter.ScoreParser is IScoreParser);
            gamePresenter = new GamePresenter(diceHolder, gamehelper, scoreParserFactory);

            //Assert throw if invalid input
            Assert.Throws<InvalidOperationException>(() => gamePresenter.ChooseScoreParser("NotValid"));

        }



        [Test]
        [TestCase("Ones",1,2,3,4,5, 1)]
        public void SaveScore_ShouldSaveScoreInGameHelper(string chosenScoring, int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScore)
        {
            //Arrange
            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(inputDiceOne, inputDiceTwo, inputDiceThree, inputDiceFour, inputDiceFive);
            Mock<GameHelper> mockGameHelper = new Mock<GameHelper>();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            GamePresenter gamePresenter = new GamePresenter(mockDiceHolder.Object, mockGameHelper.Object, scoreParserFactory);
            gamePresenter.ChooseScoreParser("Fun");

            //Act
            gamePresenter.SaveScore(chosenScoring);

            //Assert

            mockGameHelper.Verify(x => x.SaveScore(chosenScoring, expectedScore), Times.Once);






        }



    }
}
