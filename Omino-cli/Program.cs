using System;
using System.Collections.Generic;
using System.IO;
using tetris_trial;

namespace Omino_cli
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Specify input:");
                Console.WriteLine("1) random blocks");
                Console.WriteLine("2) specific pentomino");
                Console.WriteLine("3) specific hexamino");
                if(!int.TryParse(Console.ReadLine(), out int action)) return 1;
                List<Block> blocks = new List<Block>();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Specify block size:");
                        if(!int.TryParse(Console.ReadLine(), out int size)) return 1;
                        Console.WriteLine("Specify block count:");
                        if(!int.TryParse(Console.ReadLine(), out int count)) return 1;
                        IncrementalBlockSetGenerator generator = new IncrementalBlockSetGenerator(size, new Random().Next());
                        blocks = generator.GenerateBlocks(count);
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("Specify pentomino block(0 to break):");
                            if(!int.TryParse(Console.ReadLine(), out int selected)) return 1;
                            if (selected == 0) break;
                            blocks.Add(new PredefinedBlockSet(5).Get(selected - 1));
                        } while (true);
                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Specify pentomino block(0 to break):");
                            if(!int.TryParse(Console.ReadLine(), out int selected)) return 1;
                            if (selected == 0) break;
                            blocks.Add(new PredefinedBlockSet(6).Get(selected - 1));
                        } while (true);
                        break;
                    default:
                        return 1;
                }

                Console.WriteLine("Specify algorithm:");
                Console.WriteLine("1) square optimal");
                Console.WriteLine("2) square heuristic");
                Console.WriteLine("3) rectangle optimal");
                Console.WriteLine("4) rectangle heuristic");
                if(!int.TryParse(Console.ReadLine(), out int alg)) return 1;

                Board board = new Board();
                board.Blocks = blocks;
                switch (alg)
                {
                    case 1:
                    {
                        var result = board.Square();
                        SolutionPrinter.PrintSolution(result);
                        Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                        break;
                    }

                    case 2:
                    {
                        var result = board.FastSquare();
                        SolutionPrinter.PrintSolution(result);
                        Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                        break;
                    }
                    case 3:
                    {
                        var result = board.Rectangle();
                        SolutionPrinter.PrintSolution(result.Item1);
                        Console.WriteLine($"Found rectangle, cuts: {result.Item2}");
                        break;
                    }
                    case 4:
                    {
                        var result = board.FastRectangle();
                        SolutionPrinter.PrintSolution(result.Item1);
                        Console.WriteLine($"Found rectangle, cuts: {result.Item2}");
                        break;
                    }
                    default:
                        return 1;
                }

                board.Blocks = blocks;
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
                        blocks = new IncrementalBlockSetGenerator(size, new Random().Next()).GenerateBlocks(count);
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
                            SolutionPrinter.PrintSolution(result);
                            Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                            break;
                        }

                        case "hk":
                        {
                            var result = board.FastSquare();
                            SolutionPrinter.PrintSolution(result);
                            Console.WriteLine($"Found square size: {result.GetLength(0)}x{result.GetLength(0)}");
                            break;
                        }
                        case "op":
                        {
                            var result = board.Rectangle();
                            SolutionPrinter.PrintSolution(result.Item1);
                            Console.WriteLine($"Found rectangle, cuts: {result.Item2}");
                            break;
                        }
                        case "hp":
                        {
                            var result = board.FastRectangle();
                            SolutionPrinter.PrintSolution(result.Item1);
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