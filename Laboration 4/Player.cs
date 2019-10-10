﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Player : GameObject
    {
        public int movesMade { get; private set; } = 0;
        public Player(int x, int y) : base(x, y)
        {
            symbol = '@';
        }
        public override void PlayerMoves()
        {
            base.PlayerMoves();
            movesMade++;
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            Console.WriteLine($"Player has moved {movesMade} times.");
        }
    }
}