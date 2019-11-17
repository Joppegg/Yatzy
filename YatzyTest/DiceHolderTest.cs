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
         
            List<IDie> diceList = new List<IDie>();
            for (int i = 0; i<input; i++)
            {
                Mock<Die> mockDie = new Mock<Die>();
                diceList.Add(mockDie.Object);
            }
            var sut = new DiceHolder(diceList);
         

            Assert.AreEqual(expected, sut.DiceList.Count);

        }


        [Test]
        public void RollDice_ShouldCallDieRollMethodOnce()
        {
            
            List<IDie> diceList = new List<IDie>();
            Mock<IDie> mockDie = new Mock<IDie>();
     
            diceList.Add(mockDie.Object);

            var sut = new DiceHolder(diceList);
            sut.RollDice();

            mockDie.Verify(x=> x.Roll(), Times.Once());
        }

        [Test]
        public void RollDice_ShouldOnlyRollUnlockedDice()
        {
            List<IDie> diceList = new List<IDie>();
            Mock<IDie> mockDie = new Mock<IDie>();

            mockDie.Setup(x => x.IsLocked).Returns(true);
            diceList.Add(mockDie.Object);

            var sut = new DiceHolder(diceList);
            sut.RollDice();

            mockDie.Verify(x => x.Roll(), Times.Never());

        }

        [Test]
        public void SortDice_ShouldSortDescending() {
        }






    }
}
