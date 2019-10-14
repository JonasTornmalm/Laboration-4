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

        public bool playGame = true;
        private bool doorUnlocked = false;
        private bool hasPickedUpKey = false;
        private bool hasUsedKey = false;
        private bool hasSword = false;

        public GameSession(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public void PlayerUserInterface()
        {
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            string key = null;
            string sword = null;
            movesMade++;
            Console.WriteLine($"HP: \n" +
            $"Player has moved {movesMade} times.");
            
            if (hasPickedUpKey && !hasUsedKey)
            {
                key = "Key";
            }
            if (hasSword)
            {
                sword = "Sword";
            }
            Console.WriteLine($"Inventory: {key}{sword}");
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
        public bool MovePlayer(int x, int y)
        {

            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Wall && gameObject.x == x && gameObject.y == y)
                {
                    return false;
                }
            }
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is Key && gameObject.x == x && gameObject.y == y)
                {
                    if (!hasPickedUpKey)
                    {
                        Console.Clear();
                        Console.CursorTop = 20;
                        Console.WriteLine("*You found a key!*\n" +
                            "*Adding to inventory*");
                        gameObject.AddToInventory(gameObject);
                        hasPickedUpKey = true;
                    }
                }
            }
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is Door && gameObject.x == x && gameObject.y == y)
                {
                    if(!hasPickedUpKey)
                    {
                        Console.CursorTop = 20;
                        Console.WriteLine("*Door is locked*");
                        return false;
                    }
                    else if(!doorUnlocked)
                    {
                        Console.Clear();
                        Console.WriteLine("*Using key to enter*");
                        Console.ReadLine();
                        gameObject.symbol = 'd';
                        doorUnlocked = true;
                        hasUsedKey = true;
                    }
                }
            }
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is Sword && gameObject.x == x && gameObject.y == y)
                {
                    Console.Clear();
                    Console.CursorTop = 20;
                    Console.WriteLine("*You found a sword!*\n" +
                        "*Adding to inventory*");
                    hasSword = true;
                    gameObject.AddToInventory(gameObject);
                }
            }
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is Monster && gameObject.x == x && gameObject.y == y)
                {
                    if (!hasSword)
                    {
                        Console.Clear();
                        Console.CursorTop = 20;
                        Console.WriteLine("*There are monsters in the way*");
                        return false;
                    }
                    else if(gameObject.symbol == 'M')
                    {
                        Console.Clear();
                        Console.CursorTop = 20;
                        Console.WriteLine("*You slice your sword on the monster!*");
                        gameObject.RemoveObject(gameObject);
                    }
                }
            }
            foreach(var gameObject in gameObjects)
            {
                if(gameObject is DoorExit && gameObject.x == x && gameObject.y == y)
                {
                    Console.Clear();
                    Console.WriteLine("*You found the exit, let's get out of here!*\n" +
                        "*Enter*");
                    Console.ReadLine();
                    playGame = false;
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
