using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Transactions;
using Omino.Core;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            Console.WriteLine("Specify block size:");
            if (!int.TryParse(Console.ReadLine(), out int size)) return;
            Console.WriteLine("Specify block count:");
            if (!int.TryParse(Console.ReadLine(), out int count)) return;
            Console.WriteLine("Specify tests count:");
            if (!int.TryParse(Console.ReadLine(), out int testCount)) return;
            Console.WriteLine("Specify result path:");
            var path = Console.ReadLine();

            var testMethods = new List<Function>
                {Function.Square, Function.FastSquare, Function.Rectangle, Function.FastRectangle};
            using var w = new StreamWriter(path);
            WriteHeaders(w, testMethods);
            for (int s = 1; s <= size; s++)
            {
                Console.WriteLine($"Starting tests for block size {s}");
                IncrementalBlockSetGenerator blockSetGenerator =
                    new IncrementalBlockSetGenerator(size, CancellationToken.None);
                for (int bc = 1; bc <= count; bc++)
                {
                    var tests = ConductTest(blockSetGenerator, s, bc, testCount,
                        testMethods);
                    
                    foreach (var test in tests)
                    {
                        WriteTest(w, test.blockSize, test.blockCount, test.results);
                    }
                }
            }
        }

        private static void WriteTest(StreamWriter writer, int blockSize, int blockCount,
            List<(Function, float time)> results)
        {
            var line = $"{blockSize},{blockCount}";
            foreach (var fun in results)
            {
                line += $",{fun.time}";
            }

            writer.WriteLine(line);
            writer.Flush();
        }

        private static void WriteHeaders(StreamWriter writer, List<Function> testMethods)
        {
            var headers = "BlockSize,BlockCount";
            foreach (var method in testMethods)
            {
                headers += $",{method.ToString()}";
            }

            writer.WriteLine(headers);
            writer.Flush();
        }

        private enum Function
        {
            Square,
            FastSquare,
            Rectangle,
            FastRectangle
        };

        private static List<(int blockSize, int blockCount, List<(Function method, float time)> results)> ConductTest(
            IncrementalBlockSetGenerator blockSetGenerator,
            int blockSize,
            int blockCount,
            int count, List<Function> methods)
        {
            var result = new List<(int, int, List<(Function, float)>)>();
            for (int c = 1; c <= count; c++)
            {
                Console.WriteLine($"Running test {c}/{count} - size: {blockSize}, blockCount: {blockCount}");
                var blocks = blockSetGenerator.GenerateBlocks(blockCount);
                var board = new Board();
                board.Blocks = blocks;

                var tmpResults = new List<(Function, float)>();

                foreach (var method in methods)
                {
                    var time = MeasureTime(board, method);
                    tmpResults.Add((method, time));
                }

                result.Add((blockSize, blockCount, tmpResults));
            }

            return result;
        }

        private static float MeasureTime(Board board, Function method)
        {
            var watch = new System.Diagnostics.Stopwatch();
            switch (method)
            {
                case Function.Square:
                    watch.Start();
                    board.Square();
                    watch.Stop();
                    break;
                case Function.FastSquare:
                    watch.Start();
                    board.FastSquare();
                    watch.Stop();
                    break;
                case Function.Rectangle:
                    watch.Start();
                    board.Rectangle();
                    watch.Stop();
                    break;
                case Function.FastRectangle:
                    watch.Start();
                    board.FastRectangle();
                    watch.Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (float) watch.Elapsed.TotalMilliseconds;
        }
    }
}