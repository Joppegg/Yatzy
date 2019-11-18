using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;

namespace YatzyTest
{
    [TestFixture]
    class GameTest
    {

        [Test]
        [TestCase("Ones", 4, 4)]
        [TestCase("ThreeOfAKind", 9, 9)]
        [TestCase("Yatzy", 50, 50)]
        public void SaveScore_ShouldSaveScoreInList(string scoringOption, int scoringInput, int expected)
        {
            //Arrange
            var sut = new Game();

            //Act
            sut.SaveScore(scoringOption, scoringInput);

            //Assert
            Assert.AreEqual(expected, sut.GetScoreList()[scoringOption]);

        }

        [Test]
        public void SaveScore_ShouldThrowExceptionOnUnknownScoreName()
        {
       
            var sut = new Game();
            string scoringName = "This should not work";
            int score = 50;
            Assert.Throws<InvalidOperationException>(() => sut.SaveScore(scoringName, score));
        }

        [Test]
        public void IsGameFinished_ShouldReturnTrueIfThirteenScoresHaveBeenPlayed()
        {
            //Arrange
            var sut = new Game();

            //Act
            sut.SaveScore("Ones", 1);
            sut.SaveScore("Twos", 1);
            sut.SaveScore("Threes", 1);
            sut.SaveScore("Fours", 1);
            sut.SaveScore("Fives", 1);
            sut.SaveScore("Sixes", 1);
            sut.SaveScore("ThreeOfAKind", 1);
            sut.SaveScore("FourOfAKind", 1);
            sut.SaveScore("FullHouse", 1);
            sut.SaveScore("SmallStraight", 1);
            sut.SaveScore("LargeStraight", 1);
            sut.SaveScore("Yatzy", 1);
            sut.SaveScore("Chance", 1);

            //Assert
            Assert.IsTrue(sut.IsGameFinished);

        }

        


    }
}
