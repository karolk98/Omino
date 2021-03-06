﻿using System;

namespace Omino.Drawing
{
    public class CLISolutionPrinter
    {
        private const char TOP_LEFT = '╔';
        private const char BOTTOM_LEFT = '╚';
        private const char TOP_RIGHT = '╗';
        private const char BOTTOM_RIGHT = '╝';
        private const char LEFT_RIGHT = '║';
        private const char TOP_BOTTOM = '═';

        private static char[] CHARS => new char[]
        {
            '▒',
            '@',
            '&',
            '%',
            'G',
            '#',
            '$',
            'W'
        };

        private struct CharConfig
        {
            public char character;
            public ConsoleColor foreground;
            public ConsoleColor background;

            public void reverse()
            {
                ConsoleColor temp = foreground;
                foreground = background;
                background = temp;
            }

            public void print()
            {
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;
                Console.Write(character);
                Console.Write(character);
                Console.ResetColor();
            }
        }

        private static CharConfig GetCharConfig(int i)
        {
            Random random = new Random(i);
            bool reverse_colors = random.Next(2)==0;
            int foreground = random.Next(8);
            int background = random.Next(8);
            int character = random.Next(8);
            CharConfig config =
            new CharConfig {
                character = CHARS[character],
                foreground = LIGHT_COLORS[foreground],
                background = DARK_COLORS[background]
            };
            if (reverse_colors) config.reverse();
            return config;
        }

        private static ConsoleColor[] LIGHT_COLORS => new[]
        {
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Gray,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Red,
            ConsoleColor.White,
            ConsoleColor.Yellow
        };

        private static ConsoleColor[] DARK_COLORS => new[]
        {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkGray,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkYellow
        };

        public static void PrintSolution(int[,] board)
        {
            int board_width = board.GetLength(0);
            int board_height = board.GetLength(1);
            
            PrintBeginning(board_width);
            for (int i = 0; i < board_height; i++)
            {
                Console.Write(LEFT_RIGHT);
                for (int j = 0; j < board_width; j++)
                {
                    int id = board[j, i];
                    if (id == -1)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    CharConfig config = GetCharConfig(id);
                    config.print();
                }
                Console.WriteLine(LEFT_RIGHT);
            }
            PrintEnding(board_width);
        }

        private static void PrintBeginning(int board_width)
        {
            Console.Write(TOP_LEFT);
            for (int i = 0; i < 2 * board_width; i++)
            {
                Console.Write(TOP_BOTTOM);
            }
            Console.WriteLine(TOP_RIGHT);
        }
        
        private static void PrintEnding(int board_width)
        {
            Console.Write(BOTTOM_LEFT);
            for (int i = 0; i < 2 * board_width; i++)
            {
                Console.Write(TOP_BOTTOM);
            }
            Console.WriteLine(BOTTOM_RIGHT);
        }
    }
}