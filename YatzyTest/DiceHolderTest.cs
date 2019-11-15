using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;

namespace YatzyTest
{


    [TestFixture]
    class DiceHolderTest
    {

        [Test]
        public void AddDice_ShouldCreateSixDieObject()
        {
            int expected = 6;

            var sut = new DiceHolder();

            DiceHolder.AddDice();

            Assert.AreEqual(6, DiceHolderTest.GetDice().Count);



        }
        


    }
}
