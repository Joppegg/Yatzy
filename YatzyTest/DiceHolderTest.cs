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
        [TestCase(1, 1)]
        [TestCase(5, 5)]
        [TestCase(7, 7)]
        public void GetDiceList_ShouldReturnAllDice(int input, int expected)
        {
         
            List<Die> diceList = new List<Die>();
            for (int i = 0; i<input; i++)
            {
                Mock<Die> mockDie = new Mock<Die>();
                diceList.Add(mockDie.Object);
            }
            var sut = new DiceHolder(diceList);
         

            Assert.AreEqual(expected, sut.DiceList.Count);

        }


        [Test]
        [TestCase(5)]
        public void RollDice_ShouldCallRollDieOnEveryDie(int input)
        {
            List<Die> diceList = new List<Die>();

            Mock<Die> mockDie = new Mock<Die>();
            mockDie.Setup(x => x.Roll()).Returns(1);

            diceList.Add(mockDie.Object);

            var sut = new DiceHolder(diceList);
            sut.RollDice();

            mockDie.Verify(x=> x.Roll(), Times.Once));

            /**

            List<Die> diceList = new List<Die>();
            for (int i = 0; i < input; i++)
            {
                Mock<Die> mockDie = new Mock<Die>();
                mockDie.Setup(x=> x.Roll()).Returns(1);
                diceList.Add(mockDie.Object);
                
            }
            var sut = new DiceHolder(diceList);
            sut.RollDice();

            Mock.Get(diceList).Verify(x=> )
            
            foreach (Die die in sut.DiceList)
            {
                
                Assert.AreEqual(die.Value, 1);
            }
   **/












        }


    }
}
