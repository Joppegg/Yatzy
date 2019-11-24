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
        [TestCase("Sixes", 3, 3, 3, 4, 5, 0)]
        [TestCase("Straight", 1, 2, 3, 4, 5, 25)]
        [TestCase("Yatzy", 3, 3, 3, 3, 3, 50)]
        [TestCase("FullHouse", 3, 3, 3, 5, 5, 25)]
        [TestCase("Chance", 3, 3, 3, 4, 5, 18)]
        [TestCase("ThreeOfAKind", 3, 3, 3, 4, 5, 20)]


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

        //Asserts that the presenter correctly locks the specified dice and roll the unlocked ones. 
        [Test]
        public void Roll_ShouldLockAndRollUnlockedDice()
        {
            //Arrange
            int[] diceToRoll = new int[2];
            diceToRoll[0] = 1;
            diceToRoll[1] = 4;

            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,
            };
            mockDie1.Setup(x => x.IsLocked).Returns(true);
            mockDie4.Setup(x => x.IsLocked).Returns(true);


            IDiceHolder diceholder = new DiceHolder(diceList);
            Mock<GameHelper> mockGameHelper = new Mock<GameHelper>();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            GamePresenter gamePresenter = new GamePresenter(diceholder, mockGameHelper.Object, scoreParserFactory);
      

            //Act
            gamePresenter.Roll(diceToRoll);

            //assert
            mockDie1.Verify(x => x.Roll(), Times.Never());
            mockDie2.Verify(x => x.Roll(), Times.Once());
            mockDie3.Verify(x => x.Roll(), Times.Once());
            mockDie4.Verify(x => x.Roll(), Times.Never());
            mockDie5.Verify(x => x.Roll(), Times.Once());


        }

        [Test]
        [TestCase(1, 2, 3, 4, 5)]
        public void PrintDice_ShouldReturnDiceWithTheirScore(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive)
        {
            //Arrange
            string expected = "Dice1: ["+inputDiceOne+"] Dice2: ["+inputDiceTwo+"] Dice3: ["+inputDiceThree+"] Dice4: ["+inputDiceFour+"] Dice5: [" +inputDiceFive+"]";
            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(inputDiceOne, inputDiceTwo, inputDiceThree, inputDiceFour, inputDiceFive);
            Mock<GameHelper> mockGameHelper = new Mock<GameHelper>();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            GamePresenter gamePresenter = new GamePresenter(mockDiceHolder.Object, mockGameHelper.Object, scoreParserFactory);

            //Act & Assert
            Assert.AreEqual(expected, gamePresenter.PrintDice());
                
        }

        [Test]
        public void PrintListWithScore_ShouldReturnCorrectScore(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive)
        {
            //Arrange
            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(inputDiceOne, inputDiceTwo, inputDiceThree, inputDiceFour, inputDiceFive);
            Mock<GameHelper> mockGameHelper = new Mock<GameHelper>();
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            GamePresenter gamePresenter = new GamePresenter(mockDiceHolder.Object, mockGameHelper.Object, scoreParserFactory);

            Dictionary<string, int> scoreList = new Dictionary<string, int>();
            scoreList.Add("Ones", 4);
            scoreList.Add("Twos", 6);
            scoreList.Add("Threes", 3);
            scoreList.Add("Fours", 8);
            scoreList.Add("Fives", 15);
            scoreList.Add("Sixes", 6);
            scoreList.Add("ThreeOfAKind", 9);
            scoreList.Add("FourOfAKind", 12);
            scoreList.Add("FullHouse", 25);
            scoreList.Add("Straight", 20);
            scoreList.Add("Yatzy", 50);
            scoreList.Add("Chance", 10);
            mockGameHelper.Setup(x => x.GetScoreList()).Returns(scoreList);

            StringBuilder expectedListOutPut = new StringBuilder();
            foreach(KeyValuePair<string, int> score in scoreList)
            {
                expectedListOutPut.Append(score.Key + " " + score.Value + "\n");
            }

            Assert.AreEqual(expectedListOutPut, gamePresenter.PrintListWithScore());


            //Act && Assert:

            





        }




    }
}
