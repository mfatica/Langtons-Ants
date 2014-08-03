using System;
using System.Windows.Forms;
using System.Drawing;

namespace LangtonsAnts
{
    public partial class LangtonsAntForm
    {
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
            grid.AddAnt(int.Parse(txt_antX.Text), int.Parse(txt_antY.Text));
            pb_gridDisplay.Image = grid.ToBitmap(gr);
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
