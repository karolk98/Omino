using System;
using System.Collections.Generic;
using System.Text;

namespace tetris_trial
{
    public class Block
    {
        public List<Tuple<int, int>> Coords;
        public int Width;
        public int Height;

        public Block(List<Tuple<int, int>> coords)
        {
            Coords = Normalize(coords);
            Width = int.MinValue;
            Height = int.MinValue;
            foreach (var pixel in Coords)
            {
                if (pixel.Item1 > Width) Width = pixel.Item1;
                if (pixel.Item2 > Height) Height = pixel.Item2;
            }

            Height++;
            Width++;
        }

        public static Block FromArray(bool[,] array)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j])
                    {
                        coords.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            return new Block(coords);
        }

        private static List<Tuple<int, int>> Normalize(List<Tuple<int, int>> input)
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            foreach (var pixel in input)
            {
                if (pixel.Item1 < minX) minX = pixel.Item1;
                if (pixel.Item2 < minY) minY = pixel.Item2;
            }
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            
            foreach (var pixel in input)
            {
                result.Add(new Tuple<int, int>(pixel.Item1 - minX, pixel.Item2 - minY));
            }
            result.Sort((pixel1, pixel2) =>
            {
                if (pixel1.Item1 == pixel2.Item1)
                {
                    return pixel1.Item2 - pixel2.Item2;
                }
                return pixel1.Item1 - pixel2.Item1;
            });

            return result;
        }

        public Block GetRotated()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            foreach (var pixel in this.Coords)
            {
                coords.Add(new Tuple<int, int>(pixel.Item2, -pixel.Item1));
            }
            return new Block(coords);
        }

        public BlockHash GetHash()
        {
            return new BlockHash(this);
        }

        public override string ToString()
        {
            bool[,] tab = new bool[Coords.Count,Coords.Count];
            foreach (var pixel in Coords)
            {
                tab[pixel.Item1, pixel.Item2] = true;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Coords.Count; i++)
            {
                for (int j = 0; j < Coords.Count; j++)
                {
                    stringBuilder.Append(tab[i, j] ? "x" : " ");
                }

                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}