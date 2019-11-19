using System;
using System.Collections.Generic;
using System.Text;
using Yatzy.Interfaces;

namespace Yatzy.Model
{
    public class ScoreParserFactory
    {
        public ScoreParser GetScoreParser(string scoreParserType, IDiceHolder diceHolder)
        {

            if (scoreParserType.Equals("FunScoreParser", StringComparison.InvariantCultureIgnoreCase)){
                return new ScoreParser(diceHolder);
            }
            return null;
        }


    }
}
