using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    class DoorExit : Door
    {
        public DoorExit(int x, int y) : base(x, y)
        {
            symbol = 'E';
        }
    }
}
