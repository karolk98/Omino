using System;
using System.Collections.Generic;
using System.Linq;

namespace Omino.Core
{
    public class BlockGenerator
    {
        private List<Block> blockSet;
        private Random _random;

        public Block GenerateBlock()
        {
            return blockSet[_random.Next(blockSet.Count)];
        }
        
        public List<Block> GenerateBlocks(int count)
        {
            var blocks = new List<Block>();
            for (int i = 0; i < count; i++)
            {
                blocks.Add(blockSet[_random.Next(blockSet.Count)]);
            }

            return blocks;
        }
        
        public BlockGenerator(int size, int seed=0)
        {
            _random = new Random(seed);
            var tab = new bool[size, size];
            var blockSet = new Dictionary<BlockHash, Block>();
            tab[size/2, size/2] = true;
            GenerateBlockSetRec(tab, size,1, blockSet);
            this.blockSet = blockSet.Values.ToList();
//            foreach (var block in this.blockSet)
//            {
//                Console.WriteLine(block);
//            }
//
//            Console.WriteLine(this.blockSet.Count);
        }
        
        private void GenerateBlockSetRec(bool[,] tab,int size, int level, Dictionary<BlockHash, Block> blocks)
        {
            if (level == size)
            {
                Block block = Block.FromArray(tab);
                blocks[block.GetHash()] = block;
                return;
            }
            
            var availablePixels = new List<Tuple<int, int>>();
            for(int i = 0;i<size;i++)
            for (int j = 0; j < size; j++)
            {
                if(tab[i, j]) continue;
                if (i + 1 >= 0 && i + 1 < size)
                {
                    if (tab[i + 1, j])
                    {
                        availablePixels.Add(new Tuple<int, int>(i, j));
                        continue;
                    }
                }
                if (i - 1 >= 0 && i - 1 < size)
                {
                    if (tab[i - 1, j])
                    {
                        availablePixels.Add(new Tuple<int, int>(i, j));
                        continue;
                    }
                }
                if (j + 1 >= 0 && j + 1 < size)
                {
                    if (tab[i, j + 1])
                    {
                        availablePixels.Add(new Tuple<int, int>(i, j));
                        continue;
                    }
                }
                if (j - 1 >= 0 && i - 1 < size)
                {
                    if (tab[i, j - 1])
                    {
                        availablePixels.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            foreach (var tuple in availablePixels)
            {
                tab[tuple.Item1, tuple.Item2] = true;
                GenerateBlockSetRec(tab, size, level + 1, blocks);
                tab[tuple.Item1, tuple.Item2] = false;
            }
        }
    }
}