using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy.Interfaces
{
    public interface IScoreParser
    {
        public int CalculateNOfAKind(int nOfAKind);
        public int CalculateSingleNumbers(int chosenScore);
        public int CalculateFullHouse();
        public int CalculateStraight();

        public int CalculateChance();


    }
}
