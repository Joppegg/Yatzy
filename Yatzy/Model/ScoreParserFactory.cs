using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Interfaces;

namespace Yatzy.Model
{
    public class ScoreParserFactory
    {
        public IScoreParser GetScoreParser(string scoreParserType, IDiceHolder diceHolder)
        {

            if (scoreParserType.Equals("FunScoreParser", StringComparison.InvariantCultureIgnoreCase)){
                return new FunScoreParser(diceHolder);
            }

            if (scoreParserType.Equals("BoringScoreParser", StringComparison.InvariantCultureIgnoreCase))
            {
                return new BoringScoreParser(diceHolder);
            }
            return null;
        }


    }
}
