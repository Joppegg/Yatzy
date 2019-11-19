using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTest
{
    
    public abstract class ScoreParserTesting
    {

        //Helper method to set up Mock dies and Mock Diceholders, returning the preferred input.
        public Mock<IDiceHolder> GetMockDiceHolder(int inputDiceOne, int inputDiceTwo, int inputDiceThree, int inputDiceFour, int inputDiceFive)
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
            int totalSum = inputDiceOne + inputDiceTwo + inputDiceThree + inputDiceFour + inputDiceFive;

            Mock<IDiceHolder> mockDiceHolder = new Mock<IDiceHolder>();
            mockDiceHolder.Setup(x => x.DiceList).Returns(diceList);
            mockDiceHolder.Setup(x => x.GetSumOfAllDice()).Returns(totalSum);
            return mockDiceHolder;
        }

    }
}
