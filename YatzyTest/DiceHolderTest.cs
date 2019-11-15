using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YatzyTest
{


    [TestFixture]
    class DiceHolderTest
    {

        [Test]
        public void AddDice_ShouldCreateSixDieObject()
        {
            int expected = 6;

            var sut = new DiceHolderTest();

            DiceHolderTest.AddDice();

            AssertEquals(6, DiceHolderTest.GetDice().Count);



        }
        


    }
}
