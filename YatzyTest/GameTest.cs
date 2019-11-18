using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YatzyTest
{
    [TestFixture]
    class GameTest
    {

        public void SaveScore_ShouldSaveScoreInList()
        {
            //Arrange
            string scoringOption = "Threes";
            int score = 25;
            var sut = new GameTest();

            //Act
            sut.SaveScore("Threes", 25);

            //Assert
            Assert.AreEqual(score, sut.GetScore(scoringOption));

        }


    }
}
