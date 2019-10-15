using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Door : GameObject, IInteractable
    {
        private bool doorUnlocked = false;
        public Door(int x, int y) : base(x, y)
        {
            symbol = 'D';
        }
        public bool InteractWithObject(Player player)
        {
            if (!player.hasKey)
            {
                Console.CursorTop = 20;
                Console.WriteLine("*Door is locked*");
                return false;
            }
            else if (!doorUnlocked)
            {
                Console.Clear();
                Console.WriteLine("*Using key to enter*");
                Console.ReadLine();
                symbol = ' ';
                doorUnlocked = true;
                player.hasUsedKey = true;
            }
            return true;
        }
    }
}
