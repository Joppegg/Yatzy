using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy.Model
{
    public class ScoreParserFactory
    {
        public ScoreParser getScoreParser(string scoreParserType, DiceHolder diceHolder)
        {

            if (scoreParserType.Equals("FunScoreParser", StringComparison.InvariantCultureIgnoreCase)){
                return new ScoreParser(diceHolder);
            }
            return null;
        }


    }
}
