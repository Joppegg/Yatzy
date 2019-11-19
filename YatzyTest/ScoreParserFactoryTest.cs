using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YatzyTest
{
    [TestFixture]
    class ScoreParserFactoryTest
    {

        [Test]
        public void GetScoreParser_ShouldReturnScoreParser()
        {
            string typeOfParser = "Boring";

            var ScoreParserFactory = new ScoreParserFactoryTest();

            var actual = ScoreParserFactory.createScoreParser(typeOfParser);

            Assert.IsNotNull(actual);
           

            

        }


    }
}
