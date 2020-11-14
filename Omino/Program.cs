using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Omino;
using Omino.Core;
using Omino.Drawing;

namespace Omino
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                var lines = File.ReadAllLines(args[0]);
                for (int i = 0; i < lines.Length; i+=3)
                {
                    List<Block> blocks = new List<Block>();
                    if(!int.TryParse(lines[i], out int size)) return 1;
                    string alg = lines[i + 1];
                    string input = lines[i + 2];
                    var numbers = input.Split(' ');
                    if (numbers.Length == 1)
                    {
                        if(!int.TryParse(input, out int count)) return 1;
                        blocks = new IncrementalBlockSetGenerator(size, CancellationToken.None, new Random().Next()).GenerateBlocks(count);
                    }
                    else
                    {
                        switch (size)
                        {
                            case 5:
                                for (var index = 0; index < numbers.Length; index++)
                                {
                                    var num = numbers[index];
                                    if(!int.TryParse(num, out int count)) return 1;
                                    for (int j = 0; j < count; j++)
                                    {
                                        blocks.Add(new PredefinedBlockSet(5).Get(index));
                                    }                                
                                }
                                break;
                            case 6:
                                for (var index = 0; index < numbers.Length; index++)
                                {
                                    var num = numbers[index];
                                    if(!int.TryParse(num, out int count)) return 1;
                                    for (int j = 0; j < count; j++)
                                    {
                                        blocks.Add(new PredefinedBlockSet(6).Get(index));
                                    }
                                }
                                break;
                            default:
                                return 1;
                        }
                    }
                    Board board = new Board();
                    board.Blocks = blocks;
                    switch (alg)
                    {
                        case "ok":
                        {
                            var result = board.Square();
                            CLISolutionPrinter.PrintSolution(result);
                            Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                            break;
                        }

                        case "hk":
                        {
                            var result = board.FastSquare();
                            CLISolutionPrinter.PrintSolution(result);
                            Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                            break;
                        }
                        case "op":
                        {
                            var result = board.Rectangle();
                            CLISolutionPrinter.PrintSolution(result.Item1);
                            Console.WriteLine($"Found rectangle, cuts: {result.Item2}");
                            break;
                        }
                        case "hp":
                        {
                            var result = board.FastRectangle();
                            CLISolutionPrinter.PrintSolution(result.Item1);
                            Console.WriteLine($"Found rectangle, cuts: {result.Item2}");
                            break;
                        }
                        default:
                            return 1;
                    }
                }
            }

            return 0;
        }
    }
}