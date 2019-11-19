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

        [TestCase(1, 1, 1, 1, 1, 5)]
        [TestCase(2, 4, 6, 6, 6, 24)]
        public void GetScore_ShouldGetSumOfAllDice(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScore)
        {
            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            mockDie1.Setup(x => x.Value).Returns(inputDiceOne);
            mockDie2.Setup(x => x.Value).Returns(inputDiceTwo);
            mockDie3.Setup(x => x.Value).Returns(inputDiceThree);
            mockDie4.Setup(x => x.Value).Returns(inputDiceFour);
            mockDie5.Setup(x => x.Value).Returns(inputDiceFive);
            //Create a dicelist
            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,
            };

            var sut = new DiceHolder(diceList);

            Assert.AreEqual(expectedScore, sut.GetSumOfAllDice());

        }






    }
}
