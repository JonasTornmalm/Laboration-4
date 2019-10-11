using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Player : GameObject
    {
        public int movesMade { get; private set; } = 0;
        public bool hasKey { get; set; } = false;
        public Player(int x, int y) : base(x, y)
        {
            symbol = '@';
        }
        public override void PlayerUserInterface()
        {
            base.PlayerUserInterface();
            movesMade++;
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            Console.WriteLine($"Player has moved {movesMade} times.");
            if (!hasKey)
            {
                Console.WriteLine("Inventory: Empty");
            }
            else
            {
                Console.WriteLine("Inventory: Key");
            }
        }
    }
}
