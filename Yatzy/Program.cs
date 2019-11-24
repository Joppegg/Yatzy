using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yatzy.View;

namespace Yatzy
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameView gameView = new GameView();
            gameView.StartGame();

        }
    }
}
