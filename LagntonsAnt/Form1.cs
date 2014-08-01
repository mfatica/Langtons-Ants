using inter.c173;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagntonsAnt
{
    public partial class Form1 : Form
    {
        AntGrid grid;
        GridRenderer gr;
        GridState gs;
        Bitmap displayImage;

        bool running = false;
        int delay = 60;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void UpdateForm()
        {
            pb_gridDisplay.Refresh();
        }

        private async void Run()
        {
            while(running)
            {
                await Task.Delay(1000 / delay);

                if (grid == null || gr == null)
                {
                    Setup();
                }

                grid.Step();
                displayImage = grid.ToBitmap(gr);
                UpdateForm();
            }
        }

        private void Setup()
        {
            int cells = pb_gridDisplay.Width / tb_cellSize.Value;

            gs = new GridState();
            gs.width = gs.height = cells;

            grid = new AntGrid(gs);
            delay = tb_Speed.Value;

            gr = new GridRenderer();
            gr.CellSize = tb_cellSize.Value;

            gr.AntColor = pb_antColor.BackColor;
            SetupColors();

            gr.GridLines = cb_gridLines.Checked;
            gr.GridLineColor = pb_gridLineColor.BackColor;
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }

        private void SetupColors()
        {
            gs.turns.Clear();
            gr.StateColors.Clear();

            foreach (ListViewItem item in list_ColorTurn.Items)
            {
                string turn = item.SubItems[1].Text;
                Color color = item.Tag == null ? Color.FromName(item.Text) : (Color)item.Tag;

                gs.turns.Add(turn[0]);
                gr.StateColors.Add(color);
            }
        }
    }
}
