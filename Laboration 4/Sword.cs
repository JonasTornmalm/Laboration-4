using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Sword : GameObject, IInteractable
    {
        public Sword(int x, int y) : base(x, y)
        {
            symbol = 'S';
        }
        public bool InteractWithObject(Player player)
        {
            Console.Clear();
            Console.CursorTop = 20;
            Console.WriteLine("*You found a sword!*\n" +
                "*Adding to inventory*");
            player.hasSword = true;
            //GetPlayer().AddToInventory(gameObject);
            return true;
        }
    }
}
