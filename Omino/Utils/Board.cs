using System;
using System.Collections.Generic;
using System.Linq;

namespace Omino.Utils
{
    public class Board
    {
        public List<Block> Blocks;

        public int[,] FastSquare()
        {
            for (int i = (int) Math.Ceiling(Math.Sqrt(Blocks.Count * Blocks.First().Pixels.Count));
                i < Blocks.Count * Blocks.First().Pixels.Count;
                i++)
            {
                var tab = new int[i, i];
                for (int a = 0; a < i; a++)
                for (int b = 0; b < i; b++)
                    tab[a, b] = -1;

                int placed = 0;
                for (var index = 0; index < Blocks.Count; index++)
                {
                    var block = Blocks[index];
                    foreach (var rotation in block.GetRotations())
                    {
                        for (int a = 0; a < tab.GetLength(0) - rotation.Width + 1; a++)
                        {
                            for (int b = 0; b < tab.GetLength(0) - rotation.Height + 1; b++)
                            {
                                if (Insert(tab, rotation, a, b, index))
                                {
                                    placed++;
                                    goto next_block;
                                }
                            }
                        }
                    }
                    break;
                    next_block: ;
                }

                if (placed == Blocks.Count)
                {
                    PrintSolution(tab, tab.GetLength(0));
                    return tab;
                }
            }

            return null;
        }
        
        public int[,] Square()
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
                    return tab;
            }

            return null;
        }

        public bool SquareRec(int[,] tab, int level)
        {
            if (level == Blocks.Count)
            {
                PrintSolution(tab, tab.GetLength(0));
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

        private bool Insert(int[,] tab, Block block, int i, int j, int level)
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

        private void Erase(int[,] tab, Block block, int i, int j)
        {
            foreach (var pixel in block.Pixels)
            {
                tab[pixel.X + i, pixel.Y + j] = -1;
            }
        }

        private void FindEdges(int area, out int x, out int y)
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

        public Tuple<int[,], int> Rectangle()
        {
            int x, y;
            if (Blocks is null || Blocks.Count == 0)
                return null;
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
                    return new Tuple<int[,], int>(tab, cuts);
                cuts++;
            }
        }
        
        public Tuple<int[,], int> FastRectangle()
        {
            if (Blocks is null || Blocks.Count == 0)
                return null;
            int area = Blocks.Sum(pp => pp.Pixels.Count);
            FindEdges(area, out var x, out var y);
            int[,] tab = new int[x,y];
            for (int a = 0; a < x; a++)
            for (int b = 0; b < y; b++)
                tab[a, b] = -1;
            int cuts = 0;
            int placed = 0;
            List<Block> notFitting = new List<Block>();
            foreach (var block in Blocks)
            {
                foreach (var rotation in block.GetRotations())
                {
                    for (int a = 0; a < tab.GetLength(0) - rotation.Width + 1; a++)
                    {
                        for (int b = 0; b < tab.GetLength(1) - rotation.Height + 1; b++)
                        {
                            if (Insert(tab, rotation, a, b, placed))
                            {
                                placed++;
                                goto next_block;
                            }
                        }
                    }
                }
                notFitting.Add(block);
                next_block: ;
            }

            foreach (var block in notFitting)
            {
                int localCuts = block.AllPossibleCuts().Count;
                cuts += localCuts;
                for (int i = 0; i < block.Pixels.Count; i++)
                {
                    for (int a = 0; a < tab.GetLength(0); a++)
                    {
                        for (int b = 0; b < tab.GetLength(1); b++)
                        {
                            if (tab[a, b] == -1)
                            {
                                tab[a, b] = placed;
                                goto next_piece;
                            }
                        }
                    }
                    next_piece: ;
                }

                placed++;
            }
            
            PrintSolution(tab, cuts);
            return new Tuple<int[,], int>(tab, cuts);
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
            if (combinations is null) return false;
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
                PrintSolution(tab, 0);
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
        public static void PrintSolution(int[,] board, int score) 
        {
            Console.WriteLine("Found solution! score:" + score);
            for (int a = 0; a < board.GetLength(0); a++)
            {
                for (int b = 0; b < board.GetLength(1); b++)
                    if (board[a, b] != -1)
                        Console.Write(board[a, b]);
                    else
                        Console.Write("x");
                
                Console.WriteLine();
            }
        }
    }
}