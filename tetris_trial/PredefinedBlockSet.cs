using System;
using System.Collections.Generic;

namespace tetris_trial
{
    public class PredefinedBlockSet
    {
        private static readonly List<Block> PENTOMINO = new List<Block>()
        {
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(0,2), new Pixel(0,3), new Pixel(0,4)}),//I
            new Block(new List<Pixel>(){new Pixel(1,0), new Pixel(1,1), new Pixel(0,1), new Pixel(1,2), new Pixel(2,2)}),
            new Block(new List<Pixel>(){new Pixel(1,0), new Pixel(1,1), new Pixel(2,1), new Pixel(1,2), new Pixel(0,2)}),
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(1,0), new Pixel(1,1), new Pixel(1,2), new Pixel(1,3)}),
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(1,0), new Pixel(0,1), new Pixel(0,2), new Pixel(0,3)}),//L
            new Block(new List<Pixel>(){new Pixel(1,0), new Pixel(1,1), new Pixel(0,1), new Pixel(0,2), new Pixel(1,2)}),
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(1,1), new Pixel(0,2), new Pixel(1,2)}),
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(1,1), new Pixel(1,2), new Pixel(1,3)}),
            new Block(new List<Pixel>(){new Pixel(1,0), new Pixel(1,1), new Pixel(0,1), new Pixel(0,2), new Pixel(0,3)}),
            new Block(new List<Pixel>(){new Pixel(2,0), new Pixel(2,1), new Pixel(2,2), new Pixel(1,1), new Pixel(0,1)}),//T
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(0,2), new Pixel(1,0), new Pixel(1,2)}),//U
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(0,2), new Pixel(1,2), new Pixel(2,2)}),
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(1,1), new Pixel(1,2), new Pixel(2,2)}),//M
            new Block(new List<Pixel>(){new Pixel(0,1), new Pixel(1,0), new Pixel(1,1), new Pixel(2,1), new Pixel(1,2)}),//X
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(1,0), new Pixel(2,0), new Pixel(2,1), new Pixel(3,0)}),
            new Block(new List<Pixel>(){new Pixel(0,1), new Pixel(1,1), new Pixel(2,1), new Pixel(2,0), new Pixel(3,1)}),
            new Block(new List<Pixel>(){new Pixel(2,0), new Pixel(2,1), new Pixel(1,1), new Pixel(0,1), new Pixel(0,2)}),//S
            new Block(new List<Pixel>(){new Pixel(0,0), new Pixel(0,1), new Pixel(1,1), new Pixel(2,1), new Pixel(2,2)})//Z
        };
        private static readonly List<Block> HEXAMINO = new List<Block>()
        {
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(0, 4), new Pixel(0, 5)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(0, 4), new Pixel(1, 4)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(0, 4), new Pixel(1, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(0, 4), new Pixel(1, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 3), new Pixel(1, 4)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 3), new Pixel(1, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 3), new Pixel(1, 1)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 3), new Pixel(1, 0)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 1), new Pixel(1, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 3), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(0, 3), new Pixel(1, 2), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 3), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 2), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 1), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 0), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 1), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 2), new Pixel(2, 2)}),//cross
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 2), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 2), new Pixel(1, 0)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(0, 2), new Pixel(1, 4)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2)}),//O
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(2, 3), new Pixel(0, 2), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(2, 1), new Pixel(0, 2), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(1, 1), new Pixel(1, 2), new Pixel(2, 3), new Pixel(0, 1), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 2), new Pixel(2, 2), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 2), new Pixel(1, 3), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 2), new Pixel(2, 2), new Pixel(2, 1)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 1), new Pixel(2, 1), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(1, 0), new Pixel(0, 1), new Pixel(0, 2), new Pixel(1, 1), new Pixel(2, 1), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(1, 1), new Pixel(1, 2), new Pixel(1, 3), new Pixel(2, 3)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(1, 0), new Pixel(0, 1), new Pixel(2, 0), new Pixel(1, 1), new Pixel(0, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(1, 0), new Pixel(0, 1), new Pixel(1, 1), new Pixel(2, 1), new Pixel(1, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(1, 0), new Pixel(0, 1), new Pixel(1, 1), new Pixel(2, 1), new Pixel(2, 2)}),
            new Block(new List<Pixel>(){new Pixel(0, 0), new Pixel(0, 1), new Pixel(1, 1), new Pixel(1, 2), new Pixel(2, 2), new Pixel(2, 3)}),
        };

        private List<Block> blockSet;

        public PredefinedBlockSet(int size)
        {
            if (size == 5) blockSet = PENTOMINO.ConvertAll(block => new Block(block.Pixels));
            else if(size == 6) blockSet = HEXAMINO.ConvertAll(block => new Block(block.Pixels));
            else throw new ArgumentException("Unsupported predefined set");
        }

        public Block Get(int index)
        {
            if (index > blockSet.Count) throw new ArgumentException("Unsupported block");
            return blockSet[index];
        }
    }
}







































