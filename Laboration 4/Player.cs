using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Player : GameObject
    {
        private int movesMade { get; set; } = 0;

        public bool playGame = true;
        public bool hasKey = false;
        public bool hasUsedKey = false;
        public bool hasSword = false;
        public Player(int x, int y) : base(x, y)
        {
            symbol = '@';
        }
        public void PlayerUserInterface()
        {
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            string key = null;
            string sword = null;
            movesMade++;
            Console.WriteLine($"Player has moved {movesMade} times.");
            if (hasKey && !hasUsedKey)
            {
                key = "Key";
            }
            if (hasSword)
            {
                sword = "Sword";
            }
            Console.WriteLine($"Inventory: {key}{sword}");
        }
        public void DisplayScore()
        {
            Console.WriteLine($"You made it out!\n" +
                $"It took you {movesMade} moves.");
        }
    }
}
