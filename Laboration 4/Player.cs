using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Player : GameObject
    {
        public Player(int x, int y) : base(x, y)
        {
            symbol = '@';
        }
    }
}
