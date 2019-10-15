using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    abstract public class GameObject
    {
        public char symbol { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
