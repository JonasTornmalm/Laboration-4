using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    class GameSession
    {
        List<GameObject> GameObjects = new List<GameObject>();

        private int height;
        private int width;

        public GameSession(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Add(Wall wall)
        {
            GameObjects.Add(wall);
        }
        public void Add(Floor floor)
        {
            GameObjects.Add(floor);
        }
        public void Add(Door door)
        {
            GameObjects.Add(door);
        }
        public void Add(Key key)
        {
            GameObjects.Add(key);
        }
        public GameObject GetGameObject(int x, int y)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.x == x && gameObject.y == y)
                {
                    return gameObject;
                }
            }
            return null;
        }
        //public void PrintMap()
        //{
        //
        //}

        public void StructureCollections()
        {

        }
    }
}
