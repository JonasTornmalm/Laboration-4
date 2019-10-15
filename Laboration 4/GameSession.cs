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

        public GameSession(int height, int width)
        {
            this.height = height;
            this.width = width;
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
                            GetPlayer().PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        if (MovePlayer(currentPlayerPositionX, currentPlayerPositionY - 1))
                        {
                            currentPlayerPositionY = gameObject.y--;
                            GetPlayer().PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        if (MovePlayer(currentPlayerPositionX + 1, currentPlayerPositionY))
                        {
                            currentPlayerPositionX = gameObject.x++;
                            GetPlayer().PlayerUserInterface();
                        }
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        if (MovePlayer(currentPlayerPositionX, currentPlayerPositionY + 1))
                        {
                            currentPlayerPositionY = gameObject.y++;
                            GetPlayer().PlayerUserInterface();
                        }
                    }
                }
            }
            return 0;
        }
        public void PlayGame()
        {
            RenderGameObjects();
            PlayerController();
        }

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
    }
}
