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


    }
}
