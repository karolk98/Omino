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
            for (int i = (int) Math.Ceiling(Math.Sqrt(Blocks.Count * Blocks.First().Pixels.Count));
                i < Blocks.Count *
                Blocks.First().Pixels.Count;
                i++)
            {
                var tab = new int[i, i];
                for (int a = 0; a < i; a++)
                for (int b = 0; b < i; b++)
                    tab[a, b] = -1;
                if (SquareRec(tab, 0))
                    break;
            }

            return null;
        }

        public bool SquareRec(int[,] tab, int level)
        {
            if (level == Blocks.Count)
            {
                Console.WriteLine("Found solution! dim:" + tab.GetLength(0));
                for (int a = 0; a < tab.GetLength(0); a++)
                {
                    for (int b = 0; b < tab.GetLength(0); b++)
                        if (tab[a, b] != -1)
                            Console.Write(tab[a, b]);
                        else
                        {
                            Console.Write("x");
                        }

                    Console.WriteLine();
                }

                return true;
            }

            foreach (var rotation in Blocks[level].GetRotations())
            {
                for (int i = 0; i < tab.GetLength(0) - rotation.Width + 1; i++)
                {
                    for (int j = 0; j < tab.GetLength(0) - rotation.Height + 1; j++)
                    {
                        if (!Insert(tab, rotation, i, j, level)) continue;

                        if (SquareRec(tab, level + 1))
                            return true;
                        Erase(tab, rotation, i, j);
                    }
                }
            }

            return false;
        }

        public bool Insert(int[,] tab, Block block, int i, int j, int level)
        {
            foreach (var pixel in block.Pixels)
            {
                if (tab[pixel.X + i, pixel.Y + j] != -1)
                {
                    return false;
                }
            }

            foreach (var pixel in block.Pixels)
            {
                tab[pixel.X + i, pixel.Y + j] = level;
            }

            return true;
        }

        public void Erase(int[,] tab, Block block, int i, int j)
        {
            foreach (var pixel in block.Pixels)
            {
                tab[pixel.X + i, pixel.Y + j] = -1;
            }
        }

        public void FindEdges(int area, out int x, out int y)
        {
            for (int i = (int) Math.Sqrt(area); i > 0; i--)
            {
                if (area / (double) i - Math.Floor(area / (double) i) < 10 * Double.Epsilon)
                {
                    x = i;
                    y = area / i;
                    
                    return;
                }
            }

            x = -1;
            y = -1;
        }

        public void Rectangle()
        {
            int x, y;
            if (Blocks is null || Blocks.Count == 0)
                return;
            int area = Blocks.Sum(pp => pp.Pixels.Count);
            FindEdges(area, out x, out y);
            int[,] tab = new int[x,y];
            for (int a = 0; a < x; a++)
            for (int b = 0; b < y; b++)
                tab[a, b] = -1;
            int cuts = 0;
            while (true)
            {
                int[] cutsDistribution = new int[Blocks.Count];
                if (RecRectangle(cutsDistribution, 0, cuts, tab))
                    break;
                cuts++;
            }
        }
        
        private bool RecRectangle(int[] cutsDistribution, int level, int cuts, int[,] tab)
        {
            if (cuts == 0)
            {
                var l = new List<Block>();
                return RecRecRectangle(l, 0, cutsDistribution,tab);
            }

            if (level >= cutsDistribution.Length) return false;
            bool found = false;
            for (int i = 0; i <= cuts; i++)
            {
                cutsDistribution[level] += i;
                if (RecRectangle(cutsDistribution, level + 1, cuts - i, tab))
                {
                    found = true;
                    return true;
                }

                cutsDistribution[level] -= i;
            }

            return false;
        }

        private bool RecRecRectangle(List<Block> l, int level, int[] cutsDistribution, int[,] tab)
        {
            if (level == cutsDistribution.Length)
            {
                return RecRecRecRectangle(tab, l, 0);
            }

            bool found=false;

            var combinations = Blocks[level].GetAllCombinationForNumberOfCuts(cutsDistribution[level]);
            if(!(combinations is null))
                foreach (var option in combinations)
                {
                    l.AddRange(option);
                    if (RecRecRectangle(l, level + 1, cutsDistribution, tab))
                        found = true;
                    l.RemoveRange(l.Count-option.Count,option.Count);
                }

            return found;
        }

        private bool RecRecRecRectangle(int[,] tab, List<Block> Blocks, int level)
        {
            if (level == Blocks.Count)
            {
                Console.WriteLine("Found solution! dim:" + tab.GetLength(0));
                for (int a = 0; a < tab.GetLength(0); a++)
                {
                    for (int b = 0; b < tab.GetLength(1); b++)
                        if (tab[a, b] != -1)
                            Console.Write(tab[a, b]);
                        else
                        {
                            Console.Write("x");
                        }

                    Console.WriteLine();
                }
                
                for (int a = 0; a < tab.GetLength(0); a++)
                {
                    for (int b = 0; b < tab.GetLength(1); b++)
                        tab[a, b] = -1;
                }

                return true;
            }

            foreach (var rotation in Blocks[level].GetRotations())
            {
                for (int i = 0; i < tab.GetLength(0) - rotation.Width + 1; i++)
                {
                    for (int j = 0; j < tab.GetLength(1) - rotation.Height + 1; j++)
                    {
                        if (tab[i, j] != -1)
                        {
                            continue;
                        }

                        if (!Insert(tab, rotation, i, j, level)) continue;

                        if (RecRecRecRectangle(tab, Blocks,level + 1))
                            return true;
                        Erase(tab, rotation, i, j);
                    }
                }
            }

            return false;
        }
    }
}