using System;
using System.Collections.Generic;
using System.Linq;

namespace tetris_trial
{
    public class Board
    {
        public List<Block> Blocks;

        public List<Block> Square()
        {
            for (int i = (int)Math.Ceiling(Math.Sqrt(Blocks.Count * Blocks.First().Coords.Count)); i < Blocks.Count *
                                                                                      Blocks.First().Coords.Count;i++)
            {
                var tab = new int[i,i];
                for(int a=0;a<i;a++)
                for (int b = 0; b < i; b++)
                    tab[a, b] = -1;
                if(SquareRec(tab,0))
                    break;
            }

            return null;
        }

        public bool SquareRec(int[,] tab, int level)
        {
            if (level == Blocks.Count)
            {
                Console.WriteLine("Found solution! dim:"+tab.GetLength(0));
                for (int a = 0; a < tab.GetLength(0); a++)
                {
                    for (int b = 0; b < tab.GetLength(0); b++)
                        if(tab[a, b]!=-1)
                            Console.Write(tab[a, b]);
                        else
                        {
                            Console.Write("x");
                        }
                    Console.WriteLine();
                }

                return true;
            }
            Block block = Blocks[level];
            for (int r = 0; r < 4; r++)
            {
                for (int i = 0; i < tab.GetLength(0) - block.Width + 1; i++)
                {
                    for (int j = 0; j < tab.GetLength(0) - block.Height + 1; j++)
                    {
                        if (tab[i, j] != -1)
                        {
                            continue;
                        }

                        if (!Insert(tab, block, i,j, level)) continue;

                        if (SquareRec(tab, level + 1))
                            return true;
                        Erase(tab, block, i, j);
                    }
                }
                block = block.GetRotated();
            }

            return false;
        }

        public bool Insert(int[,] tab, Block block, int i, int j, int level)
        {
            foreach (var pixel in block.Coords)
            {
                if (tab[pixel.Item1+i, pixel.Item2+j] != -1)
                {
                    return false;
                }
            }

            foreach (var pixel in block.Coords)
            {
                tab[pixel.Item1+i, pixel.Item2+j] = level;
            }

            return true;
        }
        
        public void Erase(int[,] tab, Block block, int i, int j)
        {
            foreach (var pixel in block.Coords)
            {
                tab[pixel.Item1+i, pixel.Item2+j] = -1;
            }
        }

        public void FindEdges(int area, out int x, out int y)
        {
            for (int i = (int) Math.Sqrt(area); i > 0; i--)
            {
                if (area / (double) i - Math.Floor(area / (double) i) < 10 * Double.Epsilon)
                {
                    x=i;
                    y = area / i;
                }
            }

            x = -1;
            y = -1;
        }
    }
}