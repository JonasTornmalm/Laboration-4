using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Monster : GameObject, IInteractable
    {
        public Monster(int x, int y) : base(x, y)
        {
            symbol = 'M';
        }
        public bool InteractWithObject(Player player)
        {
            if (!player.hasSword)
            {
                Console.Clear();
                Console.CursorTop = 20;
                Console.WriteLine("*There are monsters in the way*");
                return false;
            }
            else if (symbol == 'M')
            {
                Console.Clear();
                Console.CursorTop = 20;
                Console.WriteLine("*You slice your sword on the monster!*");
                symbol = '.';
            }
            return true;
        }
    }
}
