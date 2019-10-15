using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class DoorExit : GameObject, IInteractable
    {
        public DoorExit(int x, int y) : base(x, y)
        {
            symbol = 'E';
        }
        public bool InteractWithObject(Player player)
        {
            Console.Clear();
            Console.WriteLine("*You found the exit, let's get out of here!*\n" +
                "*Enter*");
            Console.ReadLine();
            player.playGame = false;
            return true;
        }
    }
}
