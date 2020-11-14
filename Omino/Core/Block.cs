using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;

namespace Omino.Core
{
    public class Block
    {
        public List<Pixel> Pixels;
        public int Width;
        public int Height;

        public Block(List<Pixel> coords)
        {
            Pixels = Normalize(coords);
            Width = int.MinValue;
            Height = int.MinValue;
            foreach (var pixel in Pixels)
            {
                if (pixel.X > Width) Width = pixel.X;
                if (pixel.Y > Height) Height = pixel.Y;
            }

            Height++;
            Width++;
        }

        public static Block FromArray(bool[,] array)
        {
            List<Pixel> coords = new List<Pixel>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j])
                    {
                        coords.Add(new Pixel(i, j));
                    }
                }
            }

            return new Block(coords);
        }

        private static List<Pixel> Normalize(List<Pixel> input)
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            foreach (var pixel in input)
            {
                if (pixel.X < minX) minX = pixel.X;
                if (pixel.Y < minY) minY = pixel.Y;
            }

            List<Pixel> result = new List<Pixel>();

            foreach (var pixel in input)
            {
                result.Add(new Pixel(pixel.X - minX, pixel.Y - minY));
            }

            result.Sort((pixel1, pixel2) =>
            {
                if (pixel1.X == pixel2.X)
                {
                    return pixel1.Y - pixel2.Y;
                }

                return pixel1.X - pixel2.X;
            });

            return result;
        }

        public Block GetRotated()
        {
            List<Pixel> coords = new List<Pixel>();
            foreach (var pixel in this.Pixels)
            {
                coords.Add(new Pixel(pixel.Y, -pixel.X));
            }

            return new Block(coords);
        }

        private List<Block> rotations;
        public List<Block> GetRotations()
        {
            if (rotations != null) return rotations;
            rotations = new List<Block>(){this};
            Block temp = this;
            for (int i = 0; i < 3; i++)
            {
                temp = temp.GetRotated();
                if (rotations.Any(rotation =>
                {
                    return !rotation.Pixels.Where((t, j) => t != temp.Pixels[j]).Any();
                }))
                {
                    continue;
                }
                rotations.Add(temp);
            }

            return rotations;
        }

        private BlockHash _hash;
        public BlockHash GetHash()
        {
            return _hash ?? (_hash = new BlockHash(this));
        }

        public override string ToString()
        {
            bool[,] tab = new bool[Pixels.Count, Pixels.Count];
            foreach (var pixel in Pixels)
            {
                tab[pixel.X, pixel.Y] = true;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Pixels.Count; i++)
            {
                for (int j = 0; j < Pixels.Count; j++)
                {
                    stringBuilder.Append(tab[i, j] ? "x" : " ");
                }

                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

        public List<Block> Split(List<Cut> cuts)
        {
            var res = new List<Block>();
            int counter = 0;
            int[] taken = new int[Pixels.Count];

            while (counter < Pixels.Count)
            {
                List<Pixel> l = new List<Pixel>();
                for (int i = 0; i < taken.Length; i++)
                {
                    if (taken[i] == 0)
                    {
                        taken[i] = 1;
                        l.Add(Pixels[i]);
                        counter++;
                        break;
                    }
                }

                for (int i = 0; i < Pixels.Count; i++)
                {
                    foreach (var pixel in Pixels)
                    {
                        if (!l.Contains(pixel))
                        {
                            if (l.Any(pixel1 =>
                                {
                                    return pixel1.IsNeighbor(pixel) && cuts.All(cut => cut != new Cut(pixel, pixel1));
                                })
                            )
                            {
                                l.Add(pixel);
                                taken[Pixels.IndexOf(pixel)] = 1;
                                counter++;
                            }
                        }
                    }
                }


                res.Add(new Block(l));
            }

            return res;
        }

        public bool Split(List<Cut> cuts, out Block b1, out Block b2)
        {
            List<Pixel> l1 = new List<Pixel>();
            List<Pixel> l2 = new List<Pixel>();
            l1.Add(cuts.First().P1);
            l2.Add(cuts.First().P2);
            for (int i = 0; i < Pixels.Count; i++)
            {
                foreach (var pixel in Pixels)
                {
                    if (!l1.Contains(pixel))
                    {
                        if (l1.Any(pixel1 =>
                            {
                                return pixel1.IsNeighbor(pixel) && cuts.All(cut => cut != new Cut(pixel, pixel1));
                            })
                        )
                        {
                            l1.Add(pixel);
                        }
                    }

                    if (!l2.Contains(pixel))
                    {
                        if (l2.Any(pixel1 =>
                            {
                                return pixel1.IsNeighbor(pixel) && cuts.All(cut => cut != new Cut(pixel, pixel1));
                            })
                        )
                        {
                            l2.Add(pixel);
                        }
                    }
                }
            }

            b1 = null;
            b2 = null;
            if (l1.Count + l2.Count > Pixels.Count)
                return false;
            b1 = new Block(l1);
            b2 = new Block(l2);
            return true;


//            var visited = new List<Pixel> {p1};
//            var q = new Queue<Pixel>();
//            
//            q.Enqueue(p1);
//            while (q.Any())
//            {
//                var p = q.Dequeue();
//                pixel*pixel*cuts
//            }
        }

        public List<Cut> AllPossibleCuts()
        {
            List<Cut> cuts = new List<Cut>();
            foreach (var pixel1 in Pixels)
            {
                foreach (var pixel2 in Pixels)
                {
                    if (pixel1.IsNeighbor(pixel2) && !cuts.Contains(new Cut(pixel1, pixel2)))
                        cuts.Add(new Cut(pixel1, pixel2));
                }
            }

            return cuts;
        }

        public List<List<List<Block>>> cachedCuttedBlocks;

        public List<List<Block>> GetAllCombinationForNumberOfCuts(int cuts)
        {
            if(cachedCuttedBlocks == null) CalculateCutBlocks();
            if (cuts >= cachedCuttedBlocks.Count)
                return null;
            return cachedCuttedBlocks[cuts];
        }

        private void CalculateCutBlocks()
        {
            cachedCuttedBlocks = new List<List<List<Block>>>();
            List<Cut> possibleCuts = AllPossibleCuts();
            bool[] onOffCutList = new bool[possibleCuts.Count];

            for (int i = 0; i <= possibleCuts.Count; i++)
            {
                cachedCuttedBlocks.Add(new List<List<Block>>());
            }
            onOffRec(0);

            void onOffRec(int level)
            {
                List<Cut> cuts = new List<Cut>();
                for (int i = 0; i < onOffCutList.Length; i++)
                {
                    if (onOffCutList[i]) cuts.Add(possibleCuts[i]);
                }

                List<Block> blocks = Split(cuts);
                blocks.Sort((b1, b2) => b1.GetHash().CompareTo(b2.GetHash()));
                if (cachedCuttedBlocks[cuts.Count].All(list =>
                        {
                            if (blocks.Count != list.Count) return true;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (!list[i].GetHash().Equals(blocks[i].GetHash())) return true;
                            }

                            return false;
                        })
                    )
                {
                    cachedCuttedBlocks[cuts.Count].Add(blocks);
                }

                

                if (level == possibleCuts.Count) return;
                
                onOffCutList[level] = true;
                onOffRec(level + 1);
                onOffCutList[level] = false;
                onOffRec(level + 1);
            }
        }
    }
}