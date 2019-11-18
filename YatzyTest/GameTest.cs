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
        public void SaveScore_ShouldSaveScoreInList()
        {
            //Arrange
            string scoringOption = "Threes";
            int score = 25;
            var sut = new Game();

            //Act
            sut.SaveScore("Threes", 25);

            //Assert
            Assert.AreEqual(score, sut.GetScoreList()[scoringOption]);

        }


    }
}
