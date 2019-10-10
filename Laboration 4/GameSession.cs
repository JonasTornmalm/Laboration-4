using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    class GameSession
    {
        List<GameObject> gameObjects = new List<GameObject>();

        private int height;
        private int width;

        public GameSession(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Add(Wall wall)
        {
            gameObjects.Add(wall);
        }
        public void Add(Floor floor)
        {
            gameObjects.Add(floor);
        }
        public void Add(Door door)
        {
            gameObjects.Add(door);
        }
        public void Add(Key key)
        {
            gameObjects.Add(key);
        }
        public void Add(Player player)
        {
            gameObjects.Add(player);
        }

        public GameObject GetGameObject(int x, int y)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.x == x && gameObject.y == y)
                {
                    return gameObject;
                }
            }
            return null;
        }

        public void RenderGameObjects()
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    Console.Write(GetGameObject(row, column).symbol);
                }
                Console.WriteLine();
            }
        }
        public int MovePlayer()
        {
            foreach (var gameObject in gameObjects)
            {
                Console.CursorTop = 0;
                Console.CursorLeft = 0;
                if (gameObject is Player)
                {
                    var currentPlayerPositionX = gameObject.x;
                    var currentPlayerPositionY = gameObject.y;
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.W)
                    {
                        currentPlayerPositionX = gameObject.x--;
                        gameObject.PlayerMoves();
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        currentPlayerPositionY = gameObject.y--;
                        gameObject.PlayerMoves();
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        currentPlayerPositionX = gameObject.x++;
                        gameObject.PlayerMoves();
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        currentPlayerPositionY = gameObject.y++;
                        gameObject.PlayerMoves();
                    }
                }
            }
            return 0;
        }
        public void PlayGame()
        {
            RenderGameObjects();
            MovePlayer();
        }
    }
}
