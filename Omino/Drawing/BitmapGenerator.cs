using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Omino.Core;

namespace Omino.Drawing
{
    static class BitmapGenerator
    {
        public static int PIXEL_SIZE = 40;
        public static int BORDER_WIDTH = 1;
        public static Bitmap DrawBlockList(List<Block> blocks)
        {
            int width = PIXEL_SIZE * (blocks.Sum(item => item.Width) + blocks.Count + 1);
            int height = PIXEL_SIZE * (blocks.Max(item => item.Height) + 2);
            var bitmap = new Bitmap(width, height);

            int currentPosition = 1;
            Random rnd = new Random();

            using (Graphics G = Graphics.FromImage(bitmap))
            {
                foreach (var block in blocks)
                {
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                    foreach (var pixel in block.Pixels)
                    {
                        int x = (currentPosition + pixel.X) * PIXEL_SIZE;
                        int y = (1 + pixel.Y) * PIXEL_SIZE;

                        var outer = new Rectangle(x, y, PIXEL_SIZE, PIXEL_SIZE);
                        G.DrawRectangle(new Pen(Color.LightSeaGreen), outer);

                        var inner = new Rectangle(x+BORDER_WIDTH, y + BORDER_WIDTH, PIXEL_SIZE -2*BORDER_WIDTH, PIXEL_SIZE- 2 * BORDER_WIDTH);
                        G.FillRectangle(new SolidBrush(randomColor), inner);
                    }

                    currentPosition += block.Width + 1;
                }
            }

            return bitmap;
        }

        public static Bitmap DrawSolution(int[,] solution)
        {
            int width = PIXEL_SIZE * (solution.GetLength(0)+2);
            int height = PIXEL_SIZE * (solution.GetLength(1) + 2);
            var bitmap = new Bitmap(width, height);

            Random rnd = new Random();

            int max = -1;
            for(int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    if (solution[i, j] > max) max = solution[i, j];
                }
            }
            List<Color> colors = new List<Color>();
            for (int i = 0; i < max + 1; i++)
            {
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            }

            using (Graphics G = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < solution.GetLength(0); i++)
                {
                    for (int j = 0; j < solution.GetLength(1); j++)
                    {
                        
                        int x = (1 + i) * PIXEL_SIZE;
                        int y = (1 + j) * PIXEL_SIZE;

                        var outer = new Rectangle(x, y, PIXEL_SIZE, PIXEL_SIZE);
                        G.DrawRectangle(new Pen(Color.LightSeaGreen), outer);

                        if (solution[i, j] == -1) continue;

                        var inner = new Rectangle(x + BORDER_WIDTH, y + BORDER_WIDTH, PIXEL_SIZE - 2 * BORDER_WIDTH, PIXEL_SIZE - 2 * BORDER_WIDTH);
                        G.FillRectangle(new SolidBrush(colors[solution[i, j]]), inner);
                    }
                }
            }

            return bitmap;
        }
    }
}
