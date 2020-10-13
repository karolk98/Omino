using System;

namespace tetris_trial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                Console.WriteLine(321);
                var gen = new BlockGenerator(6, 321);
                var board = new Board();
                board.Blocks = gen.GenerateBlocks(6);
                board.Square();
        }
    }
}