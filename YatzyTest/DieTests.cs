using Moq;
using NUnit.Framework;
using System;
using Yatzy;

namespace YatzyTest
{
    [TestFixture]
    public class DieTests
    {

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 6)]
        public void Roll_ShouldReturnRandomNumber(int input, int expected)
        {
            //Sets up a Mockobject Random to use
            Mock<Random> mockRandom = new Mock<Random>();

            //Mock random should return the input
            mockRandom.Setup(x => x.Next(1,7)).Returns(input);
            Die die = new Die(mockRandom.Object);

            //Act
            int actual = die.Roll();

            //Assert
            Assert.AreEqual(expected, actual);
        }

       
        //Integration-testing, giving different seeds to random.
        [Test]
        [TestCase(15)]
        [TestCase(279)]
        [TestCase(4850)]
        public void Roll_WithSameSeedShouldReturnSameNumber(int inputSeed)
        {
            //Gets a random number and expects it. No mocking   
            Random testRandom = new Random(inputSeed);
            int expected = testRandom.Next(1, 7);

            Die die = new Die(new Random(inputSeed));
            int actual = die.Roll();

            Assert.AreEqual(expected, actual);

        }




    }
}