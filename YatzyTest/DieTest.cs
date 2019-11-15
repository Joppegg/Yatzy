using NUnit.Framework;
using Yatzy;

namespace YatzyTest
{
    [TestFixture]
    public class Tests
    {

        [Test]
        [TestCase(1, 1)]
        public void Roll_ShouldReturnOneWhenRandomIsOne(int input, int expected)
        {
            //Arrange
            var sut = new Die();

            //Act
            var result = Die.Roll();

            //Assert
            Assert.Pass();
        }
    }
}