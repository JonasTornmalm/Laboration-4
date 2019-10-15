using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class Player : GameObject
    {
        public List<GameObject> inventory = new List<GameObject>();

        public bool playGame = true;
        public bool hasPickedUpKey = false;
        public bool hasUsedKey = false;
        public bool hasSword = false;
        public Player(int x, int y) : base(x, y)
        {
            symbol = '@';
        }
        //public GameObject AddToInventory(int x, int y)
        //{
        //
        //}
    }
}
