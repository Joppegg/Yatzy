using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTest
{

    [TestFixture]
    public class ScoreParserTest : ScoreParserTesting
    {

        [Test]
        [TestCase(6, 30)]
        [TestCase(4, 20)]
        [TestCase(2, 10)]
        public void Calculate_ShouldReturnScoreForSelectingOneToSix(int input, int expected)
        {
            //Create mockdice
            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            mockDie1.Setup(x => x.Value).Returns(input);
            mockDie2.Setup(x => x.Value).Returns(input);
            mockDie3.Setup(x => x.Value).Returns(input);
            mockDie4.Setup(x => x.Value).Returns(input);
            mockDie5.Setup(x => x.Value).Returns(input);

            //Create a dicelist
            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,
            };

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(sut.CalculateSingleNumbers(input), expected);
        }


        /*
        * The calculate method should only count the integer specified in the chosen score, eg the correct input (6 when choosing 6)
        *
        */
        [Test]
        [TestCase(6, 3, 18)]
        [TestCase(4, 1, 12)]
        [TestCase(2, 1, 6)]
        public void Calculate_ShouldOnlyCountChosenScore(int correctInput, int incorrectInput, int expected)
        {
            //Create mockdice
            Mock<IDie> mockDie1 = new Mock<IDie>();
            Mock<IDie> mockDie2 = new Mock<IDie>();
            Mock<IDie> mockDie3 = new Mock<IDie>();
            Mock<IDie> mockDie4 = new Mock<IDie>();
            Mock<IDie> mockDie5 = new Mock<IDie>();

            mockDie1.Setup(x => x.Value).Returns(correctInput);
            mockDie2.Setup(x => x.Value).Returns(correctInput);
            mockDie3.Setup(x => x.Value).Returns(correctInput);
            mockDie4.Setup(x => x.Value).Returns(incorrectInput);
            mockDie5.Setup(x => x.Value).Returns(incorrectInput);

            //Create a dicelist
            List<IDie> diceList = new List<IDie>
            {
                mockDie1.Object,
                mockDie2.Object,
                mockDie3.Object,
                mockDie4.Object,
                mockDie5.Object,
            };

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

          
            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(expected, sut.CalculateSingleNumbers(correctInput));
        }


        // The N of a kind method should detect how many times the chosen number is occurring and calculate the score accordingly.
        [Test]
        [TestCase(4, 2, 2, 2, 2, 1, 8)]
        [TestCase(4, 5, 5, 1, 5, 5, 20)]
        [TestCase(3, 2, 3, 4, 5, 1, 0)]
        [TestCase(3, 3, 3, 3, 5, 1, 9)]
        [TestCase(5, 3, 3, 3, 3, 3, 50)]
        public void Calculate_ShouldCalculateNOfAKind (int numberOfAkind, int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScoring)
        {

            Mock<IDiceHolder> mockDiceHolder = GetMockDiceHolder(inputDiceOne, inputDiceTwo, inputDiceThree, inputDiceFour, inputDiceFive);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(expectedScoring, sut.CalculateNOfAKind(numberOfAkind));

        }

        [TestCase(3, 3, 5, 5, 5, 25)]
        [TestCase(3, 2, 5, 5, 5, 0)]
        [Test]
        public void Calculate_ShouldCalculateFullHouse(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScoring)
        {        
            
            //Create mockdice
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


            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(expectedScoring, sut.CalculateFullHouse());
        }

        [TestCase(1, 2, 4, 5, 3, 25)]
        [TestCase(3, 2, 4, 5, 5, 0)]
        [TestCase(2, 3, 4, 5, 6, 30)]
        [TestCase(3, 5, 6, 2, 4, 30)]
        [Test]
        public void Calculate_ShouldCalculateStraight(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScoring)
        {
            //Create mockdice
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

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(expectedScoring, sut.CalculateStraight());

        }


        [TestCase(1, 2, 4, 5, 3, 15)]
        [TestCase(3, 2, 4, 5, 5, 19)]
        [TestCase(2, 3, 4, 5, 6, 20)]
        [TestCase(5, 5, 5, 5, 5, 25)]
        [Test]
        public void Calculate_ShouldCalculateBonus(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive, int expectedScoring)
        {

            //Create mockdice
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

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);

            var sut = new ScoreParser(mockDiceHolder.Object);
            Assert.AreEqual(expectedScoring, sut.CalculateChance());
        }
        











    }
}
