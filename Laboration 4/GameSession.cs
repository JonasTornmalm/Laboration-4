using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Laboration_4
{
    public class GameSession
    {
        List<GameObject> gameObjects = new List<GameObject>();

        private int height;
        private int width;
        private int movesMade { get; set; } = 0;

        public GameSession(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public void PlayerUserInterface()
        {
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            //string key = null;
            //string sword = null;
            movesMade++;
            Console.WriteLine($"Player has moved {movesMade} times.");
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
        public Player GetPlayer()
        {
            foreach(Player player in gameObjects)
            {
                if(player is Player)
                {
                    return player;
                }
            }
            return null;
        }
        public bool MovePlayer(int x, int y)
        {
            foreach(var gameObject in gameObjects)
            {
                if (gameObject is Wall && gameObject.x == x && gameObject.y == y)
                {
                    return false;
                }
                if (gameObject is IInteractable && gameObject.x == x && gameObject.y == y)
                {
                    return ((IInteractable)gameObject).InteractWithObject(GetPlayer());
                }

            }
            return true;
        }
        public void RenderGameObjects()
        {
            Console.CursorVisible = false;
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
        public int PlayerController()
        {
            Console.CursorTop = 27;
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Player)
                {
                    var currentPlayerPositionX = gameObject.x;
                    var currentPlayerPositionY = gameObject.y;
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.W)
                    {
                        if(MovePlayer(currentPlayerPositionX - 1, currentPlayerPositionY))
                        {
                            currentPlayerPositionX = gameObject.x--;
                        }
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        if (MovePlayer(currentPlayerPositionX, currentPlayerPositionY - 1))
                        {
                            currentPlayerPositionY = gameObject.y--;
                        }
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        if (MovePlayer(currentPlayerPositionX + 1, currentPlayerPositionY))
                        {
                            currentPlayerPositionX = gameObject.x++;
                        }
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        if (MovePlayer(currentPlayerPositionX, currentPlayerPositionY + 1))
                        {
                            currentPlayerPositionY = gameObject.y++;
                        }
                    }
                }
            }
            return 0;
        }
        public void PlayGame()
        {
            RenderGameObjects();
            PlayerUserInterface();
            PlayerController();
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
        public void Add(DoorExit doorExit)
        {
            gameObjects.Add(doorExit);
        }
        public void Add(Key key)
        {
            gameObjects.Add(key);
        }
        public void Add(Player player)
        {
            gameObjects.Add(player);
        }
        public void Add(Monster monster)
        {
            gameObjects.Add(monster);
        }
        public void Add(Sword sword)
        {
            gameObjects.Add(sword);
        }
    }
}
