using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Monster : GameObject
    {
        public Monster(int x, int y) : base(x, y)
        {
            symbol = 'M';
        }
    }
}
