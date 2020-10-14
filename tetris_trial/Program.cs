using System;
using System.Collections.Generic;

namespace tetris_trial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                Console.WriteLine(321);
                var gen = new BlockGenerator(6, 321);
//                var board = new Board();
//                board.Blocks = gen.GenerateBlocks(6);
//                board.Square();
                var b = gen.GenerateBlock();
                Block b1, b2;
                var c = new Cut(new Pixel(0,1), new Pixel(1,1) );
                var c2 = new Cut(new Pixel(1,1),new Pixel(0,1) );
                var l = new List<Cut>() {c};
                b.Split(l, out b1, out b2);
                Console.WriteLine(b);
                Console.WriteLine(b1);
                Console.WriteLine(b2);
                Console.WriteLine(c2!=c);
        }
    }
}