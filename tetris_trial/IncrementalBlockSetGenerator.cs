using System;
using System.Collections.Generic;
using System.Linq;

namespace tetris_trial
{
    public class IncrementalBlockSetGenerator
    {
        private static List<Block> INITIAL = new List<Block>()
        {
            new Block(new List<Pixel>()
                {
                    new Pixel()
                }
            )
        };
        
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
        
        public IncrementalBlockSetGenerator(int size, int seed=0)
        {
            _random = new Random(seed);
            List<Block> list = INITIAL;
            for (int i = 0; i < size - 1; i++)
            {
                var blockSet = new Dictionary<BlockHash, Block>();
                foreach (var block in list)
                {
                    foreach (var pixel in block.Pixels)
                    {
                        if (!block.Pixels.Contains(new Pixel(pixel.X+1, pixel.Y)))
                        {
                            var l = new List<Pixel>(block.Pixels)
                            {
                                new Pixel(pixel.X+1, pixel.Y)
                            };
                            Block b = new Block(l);
                            blockSet[b.GetHash()] = b;
                        }
                        if (!block.Pixels.Contains(new Pixel(pixel.X-1, pixel.Y)))
                        {
                            var l = new List<Pixel>(block.Pixels)
                            {
                                new Pixel(pixel.X-1, pixel.Y)
                            };
                            Block b = new Block(l);
                            blockSet[b.GetHash()] = b;
                        }
                        if (!block.Pixels.Contains(new Pixel(pixel.X, pixel.Y+1)))
                        {
                            var l = new List<Pixel>(block.Pixels)
                            {
                                new Pixel(pixel.X, pixel.Y+1)
                            };
                            Block b = new Block(l);
                            blockSet[b.GetHash()] = b;
                        }
                        if (!block.Pixels.Contains(new Pixel(pixel.X, pixel.Y-1)))
                        {
                            var l = new List<Pixel>(block.Pixels)
                            {
                                new Pixel(pixel.X, pixel.Y-1)
                            };
                            Block b = new Block(l);
                            blockSet[b.GetHash()] = b;
                        }
                    }
                }
                list = blockSet.Values.ToList();
            }

            this.blockSet = list;
            Console.WriteLine(list.Capacity);
        }
    }
}