﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Omino.Core
{
    public class Board
    {
        public List<Block> Blocks;

        public int[,] FastSquare()
        {
            return FastSquare(CancellationToken.None);
        }

        public int[,] FastSquare(CancellationToken token)
        {
            if (Blocks is null || Blocks.Count == 0)
                return null;
            for (int i = (int) Math.Ceiling(Math.Sqrt(Blocks.Count * Blocks.First().Pixels.Count));
                i <= Blocks.Sum(b => b.Pixels.Count);
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
                                if(token.IsCancellationRequested)
                                    throw new TaskCanceledException();
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
                    return tab;
                }
            }

            return null;
        }
        public int[,] Square()
        {
            return Square(CancellationToken.None);
        }
        
        public int[,] Square(CancellationToken token)
        {
            if (Blocks is null || Blocks.Count == 0)
                return null;
            for (int i = (int) Math.Ceiling(Math.Sqrt(Blocks.Count * Blocks.First().Pixels.Count));
                i <= Blocks.Sum(b => b.Pixels.Count);
                i++)
            {
                var tab = new int[i, i];
                for (int a = 0; a < i; a++)
                for (int b = 0; b < i; b++)
                    tab[a, b] = -1;
                if (SquareRec(tab, 0, token))
                    return tab;
            }

            return null;
        }

        private bool SquareRec(int[,] tab, int level, CancellationToken token)
        {
            if (level == Blocks.Count)
            {
                return true;
            }

            foreach (var rotation in Blocks[level].GetRotations())
            {
                for (int i = 0; i < tab.GetLength(0) - rotation.Width + 1; i++)
                {
                    for (int j = 0; j < tab.GetLength(0) - rotation.Height + 1; j++)
                    {
                        if(token.IsCancellationRequested)
                            throw new TaskCanceledException();
                        if (!Insert(tab, rotation, i, j, level)) continue;

                        if (SquareRec(tab, level + 1, token))
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
            return Rectangle(CancellationToken.None);
        }

        public Tuple<int[,], int> Rectangle(CancellationToken token)
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
                if (RecRectangle(cutsDistribution, 0, cuts, tab, token))
                    return new Tuple<int[,], int>(tab, cuts);
                cuts++;
            }
        }

        public Tuple<int[,], int> FastRectangle()
        {
            return FastRectangle(CancellationToken.None);
        }

        public Tuple<int[,], int> FastRectangle(CancellationToken token)
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
                            if(token.IsCancellationRequested)
                                throw new TaskCanceledException();
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
            
            return new Tuple<int[,], int>(tab, cuts);
        }
        
        private bool RecRectangle(int[] cutsDistribution, int level, int cuts, int[,] tab, CancellationToken token)
        {
            if (cuts == 0)
            {
                var l = new List<Block>();
                return RecRecRectangle(l, 0, cutsDistribution,tab, token);
            }

            if (level >= cutsDistribution.Length) return false;
            for (int i = 0; i <= cuts; i++)
            {
                cutsDistribution[level] += i;
                if (RecRectangle(cutsDistribution, level + 1, cuts - i, tab, token))
                {
                    return true;
                }

                cutsDistribution[level] -= i;
            }

            return false;
        }

        private bool RecRecRectangle(List<Block> l, int level, int[] cutsDistribution, int[,] tab, CancellationToken token)
        {
            if (level == cutsDistribution.Length)
            {
                return RecRecRecRectangle(tab, l, 0, token);
            }

            bool found=false;

            var combinations = Blocks[level].GetAllCombinationForNumberOfCuts(cutsDistribution[level]);
            if (combinations is null) return false;
            foreach (var option in combinations)
            {
                l.AddRange(option);
                if (RecRecRectangle(l, level + 1, cutsDistribution, tab, token))
                    found = true;
                l.RemoveRange(l.Count-option.Count,option.Count);
            }

            return found;
        }

        private bool RecRecRecRectangle(int[,] tab, List<Block> Blocks, int level, CancellationToken token)
        {
            if (level == Blocks.Count)
            {
                return true;
            }

            foreach (var rotation in Blocks[level].GetRotations())
            {
                for (int i = 0; i < tab.GetLength(0) - rotation.Width + 1; i++)
                {
                    for (int j = 0; j < tab.GetLength(1) - rotation.Height + 1; j++)
                    {
                        if(token.IsCancellationRequested)
                            throw new TaskCanceledException();
                        if (tab[i, j] != -1)
                        {
                            continue;
                        }

                        if (!Insert(tab, rotation, i, j, level)) continue;

                        if (RecRecRecRectangle(tab, Blocks,level + 1, token))
                            return true;
                        Erase(tab, rotation, i, j);
                    }
                }
            }

            return false;
        }
    }
}