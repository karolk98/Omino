using System;
using System.Drawing;
using System.Windows.Forms;

namespace Omino
{
    public partial class BlockForm : Form
    {
        public BlockForm()
        {
            InitializeComponent();
            AddCheckboxes();
        }

        void AddCheckboxes()
        {
            for (int i = 0; i < checkboard.RowCount; i++)
            {
                for (int j = 0; j < checkboard.ColumnCount; j++)
                {
                    var button = new Button() {Dock = DockStyle.Fill, Margin = new Padding(0), BackColor = Color.MidnightBlue};
                    button.Click += btnEvent_click;
                    checkboard.Controls.Add(button, j, i);
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
            throw new System.NotImplementedException();
        }
    }
}