using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LangtonsAnts
{
    public partial class LangtonsAntForm : Form
    {
        AntGrid grid;
        GridRenderer gr;
        GridState gs;

        bool running = false;
        int delay = 60;

        public LangtonsAntForm()
        {
            InitializeComponent();
            Setup();
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
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }

        private async void Run()
        {
            while(running)
            {
                await Task.Delay(1000 / delay);

                grid.Step();
                pb_gridDisplay.Image = grid.ToBitmap(gr);
            }
        }

        private void Run(long steps)
        {
            string title = this.Text;
            this.Text += " (Processing...)";
            while (steps-- > 0)
            {
                grid.Step();
            }
            this.Text = title;
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }
    }
}
