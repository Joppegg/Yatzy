using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public interface IDie
    { 

        public int Roll();
        public int Value { get; set; }
        public bool IsLocked { get; set; }

    }
}
