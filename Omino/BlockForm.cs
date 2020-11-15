using Omino.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omino
{
    public partial class BlockForm : Form
    {
        Board _board;
        Button[,] buttons;
        public BlockForm(Board board)
        {
            InitializeComponent();
            AddCheckboxes();
            this._board = board;
        }

        void AddCheckboxes()
        {
            buttons = new Button[checkboard.RowCount, checkboard.ColumnCount];
            for (int i = 0; i < checkboard.RowCount; i++)
            {
                for (int j = 0; j < checkboard.ColumnCount; j++)
                {
                    var button = new Button() {Dock = DockStyle.Fill, Margin = new Padding(0), BackColor = Color.MidnightBlue};
                    button.Click += btnEvent_click;
                    checkboard.Controls.Add(button, j, i);
                    buttons[i, j] = button;
                }
            }
        }

        void btnEvent_click(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            switch (ctrl.BackColor.Name)
            {
                case "MidnightBlue":
                    ctrl.BackColor = Color.LightSeaGreen;
                    break;
                default:
                    ctrl.BackColor = Color.MidnightBlue;
                    break;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(_board.Blocks is null)
            {
                _board.Blocks = new List<Block>();
            }

            var block = ParseBlock();

            if (block.Split(new List<Cut>()).Count != 1)
            {
                errorLabel.Text = "Invalid block!";
                return;
            }

            _board.Blocks.Add(block);
            this.Close();
        }

        private Block ParseBlock()
        {
            var pixels = new List<Pixel>();
            for (int i = 0; i < checkboard.RowCount; i++)
            {
                for (int j = 0; j < checkboard.ColumnCount; j++)
                {
                    if (buttons[i, j].BackColor.Name == "LightSeaGreen")
                        pixels.Add(new Pixel { X = j, Y = i });
                }
            }
            return new Block(pixels);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}