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
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    Console.Write(GetGameObject(row, column).symbol);
                }
                Console.WriteLine();
            }
        }
        public bool CheckIfWalkable(int x, int y)
        {
            
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is Wall)
                {
                    if(gameObject.x == x && gameObject.y == y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int MovePlayer()
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Player)
                {
                    var currentPlayerPositionX = gameObject.x;
                    var currentPlayerPositionY = gameObject.y;
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.W)
                    {
                        if(CheckIfWalkable(currentPlayerPositionX - 1, currentPlayerPositionY))
                        {
                            currentPlayerPositionX = gameObject.x--;
                            gameObject.PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        if (CheckIfWalkable(currentPlayerPositionX, currentPlayerPositionY - 1))
                        {
                            currentPlayerPositionY = gameObject.y--;
                            gameObject.PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        if (CheckIfWalkable(currentPlayerPositionX + 1, currentPlayerPositionY))
                        {
                            currentPlayerPositionX = gameObject.x++;
                            gameObject.PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        if (CheckIfWalkable(currentPlayerPositionX, currentPlayerPositionY + 1))
                        {
                            currentPlayerPositionY = gameObject.y++;
                            gameObject.PlayerUserInterface();
                        }
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
