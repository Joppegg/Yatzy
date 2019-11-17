using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTest
{

    [TestFixture]
    public class ScoreParserTest
    {

        //If ones can be scored, should return true.
        [Test]
        public void Calculate_ShouldReturnScoreForSelectingOnes()
        {
            //Create mockdice
            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            mockDie1.Setup(x => x.Value).Returns(1);
            mockDie2.Setup(x => x.Value).Returns(1);
            mockDie3.Setup(x => x.Value).Returns(1);
            mockDie4.Setup(x => x.Value).Returns(1);
            mockDie5.Setup(x => x.Value).Returns(1);

            int expected = 5;

            //Create a dicelist
            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,

            };

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(sut.CalculateOnes(), expected);
         


            //Pass MockDie into MockDiceHolder
            //Assert correct score


        }



    }
}
