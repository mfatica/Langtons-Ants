using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LangtonsAnts
{
    public partial class LangtonsAntForm
    {
        bool mousedown = false;

        private async void pb_gridDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;

            List<Point> added = new List<Point>();

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
            long steps;

            if (long.TryParse(txt_stepsToRun.Text, out steps))
            {
                if (steps > 5000000)
                {
                    if (MessageBox.Show("A large number of steps may take very long. Continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(10);
                }

                Run(steps);
            }
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

                    int steps, frames;

                    if (int.TryParse(txt_gif_Steps.Text, out steps) && int.TryParse(txt_gif_StepsPerFrame.Text, out frames))
                    {
                        List<Bitmap> gifFrames = new List<Bitmap>();

                        while (steps-- > 0)
                        {
                            gifgrid.Step();

                            if (steps % frames == 0)
                            {
                                gifFrames.Add((Bitmap)gifgrid.ToBitmap(gifgr).Clone());
                            }
                        }

                        using (MagickImageCollection collection = new MagickImageCollection())
                        {
                            for (int i = 0; i < gifFrames.Count; i++)
                            {
                                collection.Add(new MagickImage(gifFrames[i]));
                                collection[i].AnimationDelay = int.Parse(txt_gif_delay.Text);
                            }

                            collection.Write(path);
                        }
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

        private void btn_stop_Click(object sender, System.EventArgs e)
        {
            if (running)
            {
                running = false;
                btn_saveImage.Enabled = true;
            }
        }

        private void pb_gridLineColor_BackColorChanged(object sender, System.EventArgs e)
        {
            gr.GridLineColor = pb_gridLineColor.BackColor;
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }

        private void pb_antColor_BackColorChanged(object sender, System.EventArgs e)
        {
            gr.AntColor = pb_antColor.BackColor;
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }

        private void btn_restart_Click(object sender, System.EventArgs e)
        {
            Setup();
        }

        private void btn_addAnt_Click(object sender, System.EventArgs e)
        {
            int x, y;

            if (int.TryParse(txt_antX.Text, out x) && int.TryParse(txt_antY.Text, out y))
            {
                grid.AddAnt(x,y);
                pb_gridDisplay.Image = grid.ToBitmap(gr);
            }
        }

        private void btn_saveImage_Click(object sender, System.EventArgs e)
        {
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                string path = SaveDialog.FileName;
                pb_gridDisplay.Image.Save(path);
                link_open_save.Visible = true;
                link_open_save.Links.Add(0, link_open_save.Text.Length, path);
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                btn_saveImage.Enabled = false;
                running = true;
                Run();
            }
        } 
        private void pickColor(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            ColorDialog.ShowHelp = true;
            ColorDialog.Color = c.BackColor;

            if (ColorDialog.ShowDialog() == DialogResult.OK)
                c.BackColor = ColorDialog.Color;
        }

        private void btn_addColor_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = ColorDialog.Color;

                ListViewItem lvi = new ListViewItem(c.Name);
                lvi.Tag = c;
                lvi.SubItems.Add("L");
                list_ColorTurn.Items.Add(lvi);
            }

            SetupColors();
        }

        private void btn_delColor_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in list_ColorTurn.SelectedItems)
            {
                list_ColorTurn.Items.Remove(item);
            }

            SetupColors();
        }

        private void btn_swap_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in list_ColorTurn.SelectedItems)
            {
                string current = item.SubItems[1].Text;
                item.SubItems[1].Text = item.SubItems[1].Text.Equals("L") ? "R" : "L";
            }
            SetupColors();
        }

        private void tb_Speed_ValueChanged(object sender, EventArgs e)
        {
            lbl_speed.Text = String.Format("Speed ({0})", tb_Speed.Value);
            delay = tb_Speed.Value;
        }

        private void tb_cellSize_ValueChanged(object sender, EventArgs e)
        {
            lbl_cellSize.Text = String.Format("Cell Size ({0})", tb_cellSize.Value);
        }

        private void cb_gridLines_CheckedChanged(object sender, EventArgs e)
        {
            gr.GridLines = cb_gridLines.Checked;
            pb_gridDisplay.Image = grid.ToBitmap(gr);
        }
    }
}
