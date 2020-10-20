using System;
using System.Collections.Generic;
using System.Linq;

namespace tetris_trial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                Console.WriteLine(321);
                var gen = new IncrementalBlockSetGenerator(8, 320);
                var b = gen.GenerateBlock();
                Block b1, b2;
                var c = new Cut(new Pixel(0,1), new Pixel(1,1) );
                var c2 = new Cut(new Pixel(1,1),new Pixel(0,1) );
                var l = new List<Cut>() {c};
                var sq = new Block(new List<Pixel>
                {
                    new Pixel(),
                    new Pixel(0,1),
                    new Pixel(1,0),
                    new Pixel(1,1),
                });
                b.Split(l, out b1, out b2);
                var l2 = b.Split(l);
                
                Console.WriteLine(sq);
                for (int i = 0; i <= 4; i++)
                {
                    Console.WriteLine(sq.GetAllCombinationForNumberOfCuts(i).Count);
                }
                
                var lista = new List<Block>{sq};
                var board = new Board();
                board.Blocks = gen.GenerateBlocks(3);;
                board.Rectangle();
        }
    }
}