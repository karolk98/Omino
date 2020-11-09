using System;

namespace tetris_trial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IncrementalBlockSetGenerator blockSetGenerator = new IncrementalBlockSetGenerator(4, 5);
            Board board = new Board();
            board.Blocks = blockSetGenerator.GenerateBlocks(11);
            Console.WriteLine(board.Rectangle());
        }
    }
}