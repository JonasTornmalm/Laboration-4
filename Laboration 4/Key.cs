using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Key : GameObject, IInteractable
    {
        
        public Key(int x, int y) : base(x, y)
        {
            symbol = 'k';
        }

        public bool InteractWithObject(Player player)
        {
            if (!player.hasPickedUpKey)
            {
                Console.Clear();
                Console.CursorTop = 20;
                Console.WriteLine("*You found a key!*\n" +
                    "*Adding to inventory*");
                //player.AddToInventory(player);
                player.hasPickedUpKey = true;
            }
            return true;
        }
    }
}
