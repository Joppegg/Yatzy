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
    class ScoreParserFactoryTest : ScoreParserTesting
    {

        [Test]
        public void GetScoreParser_ShouldReturnScoreParser()
        {
            string typeOfParser = "FunScoreParser";

            ScoreParserFactory scoreParserFactory  = new ScoreParserFactory();



            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(1, 2, 3, 4, 5);

            ScoreParser actual = scoreParserFactory.GetScoreParser(typeOfParser, mockDiceHolder.Object);
            Assert.IsNotNull(actual);
           

                

        }


    }
}
