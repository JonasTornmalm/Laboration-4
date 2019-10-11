﻿using System;
using System.Collections.Generic;

namespace Laboration_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int levelHeight = 11;
            int levelWidth = 30;
            int playerStartRow = 5;
            int playerStartColumn = 14;

            GameSession gameSession = new GameSession(levelHeight, levelWidth);
            gameSession.Add(new Player(playerStartRow, playerStartColumn));

            char[,] charLayout =
            new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','#','.','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
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
                }
            }

            while (true)
            {
                gameSession.PlayGame();
            }
        }
    }
}
