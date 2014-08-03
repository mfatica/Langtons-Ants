using System;
using System.Windows.Forms;

namespace LangtonsAnts
{
    public partial class LangtonsAntForm
    {
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
        private void pickColor(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            ColorDialog.ShowHelp = true;
            ColorDialog.Color = c.BackColor;

            if (ColorDialog.ShowDialog() == DialogResult.OK)
                c.BackColor = ColorDialog.Color;
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
