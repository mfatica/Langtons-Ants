using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;

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

        bool mousedown = false;

        private async void pb_gridDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;

            List<System.Drawing.Point> added = new List<System.Drawing.Point>();

            while (mousedown)
            {
                await Task.Delay(2);
                System.Drawing.Point mpos = pb_gridDisplay.PointToClient(Cursor.Position);
                System.Drawing.Point antPos = new System.Drawing.Point(mpos.X / gr.CellSize, mpos.Y / gr.CellSize);

                if (!added.Any(p => p.X == antPos.X && p.Y == antPos.Y))
                {
                    added.Add(antPos);
                    grid.AddAnt(antPos);
                    pb_gridDisplay.Image = grid.ToBitmap(gr);
                }
            }
        }

        private void pb_gridDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
            
        }

        private void btn_runToStep_Click(object sender, EventArgs e)
        {
            long steps = long.Parse(txt_stepsToRun.Text);

            if(steps > 5000000)
            {
                if(MessageBox.Show("A large number of steps may take very long. Continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                System.Threading.Thread.Sleep(10);
            }

            Run(steps);
        }

        private async void btn_gif_create_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.DefaultExt = "gif";
            sfg.Filter = "GIF|*.gif";
            sfg.FileName = "ants.gif";

            if (sfg.ShowDialog() == DialogResult.OK)
            {
                btn_gif_create.Text = "Processing..";
                link_open_gif.Links.Add(0, link_open_gif.Text.Length, sfg.FileName);
                await Task.Run(() =>
                {
                    GridRenderer gifgr = gr.Copy();
                    AntGrid gifgrid = grid.Copy();

                    string path = sfg.FileName;

                    int steps = int.Parse(txt_gif_Steps.Text);
                    int frames = int.Parse(txt_gif_StepsPerFrame.Text);

                    List<Bitmap> gifFrames = new List<Bitmap>();

                    while (steps-- > 0)
                    {
                        gifgrid.Step();

                        if (steps % frames == 0)
                        {
                            gifFrames.Add((Bitmap)gifgrid.ToBitmap(gifgr).Clone());
                        }
                    }

                    using(MagickImageCollection collection = new MagickImageCollection())
                    {
                        for(int i = 0; i < gifFrames.Count; i++)
                        {
                            collection.Add(new MagickImage(gifFrames[i]));
                            collection[i].AnimationDelay = int.Parse(txt_gif_delay.Text);
                        }

                        collection.Write(path);
                    }
                    });

                btn_gif_create.Text = "Create";
                link_open_gif.Visible = true;
            }
        }

        private void OpenLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            linkLabel.Links[linkLabel.Links.IndexOf(e.Link)].Visited = true;
            string target = e.Link.LinkData as string;
            System.Diagnostics.Process.Start(target);
        }
    }
}
