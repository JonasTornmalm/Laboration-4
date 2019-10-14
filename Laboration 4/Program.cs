using System;
using System.Collections.Generic;

namespace Laboration_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();           
            int levelHeight = 11;
            int levelWidth = 38;
            int playerStartRow = 4;
            int playerStartColumn = 5;
            int monsterCount = 5;


            GameSession gameSession = new GameSession(levelHeight, levelWidth);
            gameSession.Add(new Player(playerStartRow, playerStartColumn));

            for (int i = 0; i < monsterCount; i++)
            {
                int randomSpawnHeight = rnd.Next(1, 10);
                int randomSpawnWidth = rnd.Next(1, 37);
                gameSession.Add(new Monster(randomSpawnHeight, randomSpawnWidth));
            }           
            char[,] charLayout =
            new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','#','#','.','.','.','.','#','#','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','D','.','.','.','.','.','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            };

            for (int row = 0; row < charLayout.GetLength(0); row++)
            {
                for (int column = 0; column < charLayout.GetLength(1); column++)
                {
                    if (charLayout[row, column] == '#')
                    {
                        gameSession.Add(new Wall(row, column));
                    }
                    else if (charLayout[row, column] == '.')
                    {
                        gameSession.Add(new Floor(row, column));
                    }
                    else if(charLayout[row, column] == 'k')
                    {
                        gameSession.Add(new Key(row, column));
                    }
                    else if(charLayout[row, column] == 'D')
                    {
                        gameSession.Add(new Door(row, column));
                    }
                    else if(charLayout[row, column] == 'M')
                    {
                        gameSession.Add(new Monster(row, column));
                    }
                }
            }

            while (true)
            {
                gameSession.PlayGame();
            }
        }
    }
}
