using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Model;

namespace YatzyTest
{
    [TestFixture]
    class ScoreParserFactoryTest
    {

        [Test]
        public void GetScoreParser_ShouldReturnScoreParser()
        {
            string typeOfParser = "Boring";

            ScoreParserFactory scoreParserFactory  = new ScoreParserFactory();

            var actual = ScoreParserFactory.getScoreParser(typeOfParser) ;

            Assert.IsNotNull(actual);
           

            

        }


    }
}
