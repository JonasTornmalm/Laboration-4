using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Wall : GameObject
    {
        public Wall(int x, int y) : base(x, y)
        {
            symbol = '#';
        }
    }
}
