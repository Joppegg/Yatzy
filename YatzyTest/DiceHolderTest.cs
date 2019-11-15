using Moq;
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
        public void GetDice_ShouldReturnFiveDice()
        {
            int expected = 5;
            List<Die> diceList = new List<Die>();
            for (int i = 0; i<5; i++)
            {
                Mock<Die> mockDie = new Mock<Die>();
                diceList.Add(mockDie.Object);
            }
            var sut = new DiceHolder(diceList);
         

            Assert.AreEqual(expected, sut.DiceList.Count);



        }

    }
}
