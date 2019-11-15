using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public interface IDie
    { 

        public int Roll();

        public bool IsLocked { get; set; }
    }
}
