using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Omino.Utils;
using Omino.Utils.Drawing;

namespace Omino
{
    public partial class MainForm : Form
    {
        Board board;
        IncrementalBlockSetGenerator blockSetGenerator;
        private CancellationTokenSource _tokenSource;
        private int currentSize;
        public MainForm()
        {
            InitializeComponent();

            BitmapGenerator.PIXEL_SIZE = 40;
            board = new Board();
            _tokenSource = new CancellationTokenSource();
            currentSize = -1;
        }

        public void DrawRectangle(PaintEventArgs e)
        {

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }

        private void generateButton_Click(object sender, System.EventArgs e)
        {
            CancelRunningTask();
            if (currentSize != (int) blockSizeBox.Value)
            {
                blockSetGenerator = new IncrementalBlockSetGenerator((int)blockSizeBox.Value, new Random().Next());
                currentSize = (int) blockSizeBox.Value;
            }
            board.Blocks = blockSetGenerator.GenerateBlocks((int)blockCountBox.Value);

            var bitmap = BitmapGenerator.DrawBlockList(board.Blocks);

            pictureBox.ClientSize = new Size(bitmap.Width, bitmap.Height);
            pictureBox.Image = bitmap;
        }

        private void optimalSquareButton_Click(object sender, System.EventArgs e)
        {
            CancelRunningTask();
            if (board.Blocks == null) return;
            var watch = new System.Diagnostics.Stopwatch();
            int[,] result = new int[0,0];
            Task task = Task.Factory.StartNew(() =>
            {
                watch.Start();
                result = board.Square();
                watch.Stop();
            }, _tokenSource.Token).ContinueWith(_ => {
                var bitmap = BitmapGenerator.DrawSolution(result);

                pictureBox.ClientSize = new Size(bitmap.Width, bitmap.Height);
                pictureBox.Image = bitmap;
                labelInfo1.Text = $"Time: {watch.ElapsedMilliseconds} ms";
                labelInfo2.Text = $"Square size: {result.GetLength(0)}x{result.GetLength(0)}";
            }, _tokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void heuristicSquareButton_Click(object sender, System.EventArgs e)
        {
            CancelRunningTask();
            if (board.Blocks == null) return;
            var watch = new System.Diagnostics.Stopwatch();
            int[,] result = new int[0, 0];
            Task task = Task.Factory.StartNew(() =>
            {
                watch.Start();
                result = board.FastSquare();
                watch.Stop();
            }, _tokenSource.Token).ContinueWith(_ => {
                var bitmap = BitmapGenerator.DrawSolution(result);

                pictureBox.ClientSize = new Size(bitmap.Width, bitmap.Height);
                pictureBox.Image = bitmap;
                labelInfo1.Text = $"Time: {watch.ElapsedMilliseconds} ms";
                labelInfo2.Text = $"Square size: {result.GetLength(0)}x{result.GetLength(0)}";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void optimalRectangleButton_Click(object sender, System.EventArgs e)
        {
            CancelRunningTask();
            if (board.Blocks == null) return;
            var watch = new System.Diagnostics.Stopwatch();
            Tuple<int[,], int> result = new Tuple<int[,], int>(new int[0, 0], 0);
            Task task = Task.Factory.StartNew(() =>
            {
                watch.Start();
                result = board.Rectangle();
                watch.Stop();
            }, _tokenSource.Token).ContinueWith(_ => {
                var bitmap = BitmapGenerator.DrawSolution(result.Item1);

                pictureBox.ClientSize = new Size(bitmap.Width, bitmap.Height);
                pictureBox.Image = bitmap;
                labelInfo1.Text = $"Time: {watch.ElapsedMilliseconds} ms";
                labelInfo2.Text = $"Cuts: {result.Item2}";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void heuristicRectangleButton_Click(object sender, System.EventArgs e)
        {
            CancelRunningTask();
            if (board.Blocks == null) return;
            var watch = new System.Diagnostics.Stopwatch();
            Tuple<int[,], int> result = new Tuple<int[,], int>(new int[0, 0], 0);
            Task task = Task.Factory.StartNew(() =>
            {
                watch.Start();
                result = board.FastRectangle();
                watch.Stop();
            }, _tokenSource.Token).ContinueWith(_ => {
                var bitmap = BitmapGenerator.DrawSolution(result.Item1);

                pictureBox.ClientSize = new Size(bitmap.Width, bitmap.Height);
                pictureBox.Image = bitmap;
                labelInfo1.Text = $"Time: {watch.ElapsedMilliseconds} ms";
                labelInfo2.Text = $"Cuts: {result.Item2}";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CancelRunningTask()
        {
            _tokenSource.Cancel();
            _tokenSource = new CancellationTokenSource();
            labelInfo1.Text = "";
            labelInfo2.Text = "";
        }
    }
}