using FluentAssertions;
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
        public void GetFunScoreParser_ShouldReturnFunScoreParser()
        {
            string typeOfParser = "FunScoreParser";
            ScoreParserFactory scoreParserFactory  = new ScoreParserFactory();
            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(1, 2, 3, 4, 5);

            IScoreParser actual = scoreParserFactory.GetScoreParser(typeOfParser, mockDiceHolder.Object);
            FunScoreParser expected = new FunScoreParser(mockDiceHolder.Object);

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
 

        }
        [Test]
        public void GetBoringScoreParser_ShouldReturnBoringScoreParser()
        {
            string typeOfParser = "BoringScoreParser";
            ScoreParserFactory scoreParserFactory = new ScoreParserFactory();
            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(1, 2, 3, 4, 5);

            IScoreParser actual = scoreParserFactory.GetScoreParser(typeOfParser, mockDiceHolder.Object);
            BoringScoreParser expected = new BoringScoreParser(mockDiceHolder.Object);


            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);

        }




    }
}
