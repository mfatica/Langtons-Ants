using System.Drawing;
using System.Collections.Generic;

namespace inter.c173
{
    class GridRenderer
    {
        public List<Color> StateColors = new List<Color>();
        public Color AntColor = Color.FromArgb(256/2, 255,0,0);
        public int CellSize = 50;

        public bool GridLines = false;
        public Color GridLineColor = Color.Black;

        private Graphics _graphics;
        private Bitmap _bitmap;

        public Bitmap Render(int[,] grid, GridState gridState)
        {
            int width = grid.GetLength(0) * CellSize + 1;
            int height = grid.GetLength(1) * CellSize+1;

            if(_bitmap == null || (_bitmap.Width != width && _bitmap.Height != height))
                _bitmap = new Bitmap(width, height);

            _graphics = Graphics.FromImage(_bitmap);
            _graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed; 
            _graphics.Clear(StateColors[0]);
            
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] > 0)
                    {
                        int x = i * CellSize;
                        int y = j * CellSize;

                        _graphics.FillRectangle(new SolidBrush(StateColors[grid[i,j]]), x, y, CellSize, CellSize);
                    }
                }
            }

            foreach(Ant a in gridState.ants)
            {
                _graphics.FillRectangle(new SolidBrush(AntColor), a.Position.x * CellSize, a.Position.y * CellSize, CellSize, CellSize);
            }

            if(GridLines)
            {
                Pen line = new Pen(GridLineColor,0.25f);


                for (int i = 0; i < _bitmap.Width; i += CellSize)
                {
                    _graphics.DrawLine(line, i, 0, i, _bitmap.Height);
                }

                for(int i = 0; i < _bitmap.Height; i+= CellSize)
                {
                    _graphics.DrawLine(line, 0, i, _bitmap.Width, i);
                }
            }

            return _bitmap;
        }
    }
}
