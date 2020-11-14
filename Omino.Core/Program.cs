using System;
using System.Threading;

namespace Omino.Core
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IncrementalBlockSetGenerator blockSetGenerator = new IncrementalBlockSetGenerator(4, CancellationToken.None,5);
            Board board = new Board();
            board.Blocks = blockSetGenerator.GenerateBlocks(9);
            Console.WriteLine(board.Square());
        }
    }
}