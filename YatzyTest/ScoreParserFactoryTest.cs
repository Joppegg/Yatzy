using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;
using Yatzy.Interfaces;
using Yatzy.Model;

namespace YatzyTest
{
    [TestFixture]
    class ScoreParserFactoryTest
    {

        [Test]
        public void GetScoreParser_ShouldReturnScoreParser()
        {
            string typeOfParser = "FunScoreParser";

            ScoreParserFactory scoreParserFactory  = new ScoreParserFactory();

            //Create mockdice
            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            //Create a dicelist
            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,
            };

            Mock<DiceHolder> mockDiceHolder = new Mock<DiceHolder>();

            ScoreParser actual = scoreParserFactory.GetScoreParser(typeOfParser, mockDiceHolder.Object);

            Assert.IsNotNull(actual);
           

                

        }


    }
}
