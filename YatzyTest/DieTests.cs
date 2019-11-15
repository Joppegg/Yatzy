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
        public void Roll_ShouldReturnOneWhenRandomIsOne(int input, int expected)
        {
            //Sets up a Mockobject Random to use
            Mock<Random> mockRandom = new Mock<Random>();

            //Mock random should return the input
            mockRandom.Setup(x => x.Next()).Returns(input);
            var sut = new Die(mockRandom.Object);

            //Act
            int actual = sut.Roll();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}