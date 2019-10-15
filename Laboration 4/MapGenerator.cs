using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_4
{
    public class MapGenerator
    {
        public void CreateMap()
        {
            int levelHeight = 11;
            int levelWidth = 38;
            int playerStartRow = 2;
            int playerStartColumn = 2;

            GameSession gameSession = new GameSession(levelHeight, levelWidth);
            gameSession.Add(new Player(playerStartRow, playerStartColumn));

            char[,] charLayout =
            new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','E','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','.','.','.','.','#','#','#','#','#','#','.','M','.','.','M','.','M','.','.','.','.','M','.','.','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','#','#','#','.','#','#','#','#','#','#','.','.','.','M','.','.','M','.','.','M','.','.','.','.','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','#','#','#','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','M','.','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','#','#','#','.','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','M','M','#','#'},
                {'#','#','#','#','.','.','.','#','#','#','#','.','#','#','#','.','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','M','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','#','#','#','.','#','#','#','#','#','#','.','.','#','#','#','#','#','#','.','#','#','#','#','D','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','#','#','k','.','#','#','#','#','#','#','.','.','#','#','#','#','#','#','.','#','.','.','.','S','#','#'},
                {'#','#','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#','#','.','.','#','#','#','#','#','#','.','#','.','.','.','.','#','#'},
                {'#','#','.','.','.','.','.','.','.','#','#','.','D','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','#','.','D','.','.','.','.','#','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            };

            // Create objects
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
                    else if (charLayout[row, column] == 'k')
                    {
                        gameSession.Add(new Key(row, column));
                    }
                    else if (charLayout[row, column] == 'D')
                    {
                        gameSession.Add(new Door(row, column));
                    }
                    else if (charLayout[row, column] == 'M')
                    {
                        gameSession.Add(new Monster(row, column));
                    }
                    else if (charLayout[row, column] == 'S')
                    {
                        gameSession.Add(new Sword(row, column));
                    }
                    else if (charLayout[row, column] == 'E')
                    {
                        gameSession.Add(new DoorExit(row, column));
                    }
                }
            }

            while (gameSession.GetPlayer().playGame)
            {
                gameSession.PlayGame();
            }
            Console.Clear();
            gameSession.GetPlayer().DisplayScore();
        }
    }
}
