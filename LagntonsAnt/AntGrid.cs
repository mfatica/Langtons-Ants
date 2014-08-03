using System;
using System.Collections.Generic;
using System.Drawing;

namespace LangtonsAnts
{
    class AntGrid
    {
        int[,] grid;
        GridState gridState;

        internal AntGrid Copy()
        {
            AntGrid copy = new AntGrid();

            copy.grid = new int[this.gridState.width, this.gridState.height];
            for (int i = 0; i < this.grid.GetLength(0); i++)
                for (int j = 0; j < this.grid.GetLength(1); j++)
                    copy.grid[i, j] = this.grid[i, j];

            copy.gridState = this.gridState;

            return copy;
        }

        public AntGrid() : this(new GridState()) { }

        public AntGrid(GridState gridState)
        {
            this.gridState = gridState;
            this.grid = new int[gridState.width, gridState.height];

            for (int i = 0; i < gridState.width; i++)
                for (int j = 0; j < gridState.height; j++)
                    grid[i, j] = 0;
        }

        public void AddAnt(int x, int y)
        {
            AddAnt(x, y, 3);
        }

        public void AddAnt(System.Drawing.Point pos)
        {
            AddAnt(pos.X, pos.Y, 3);
        }

        public void AddAnt(int x, int y, int dir)
        {
            if (x > 0 && y > 0 && x < gridState.width && y < gridState.height)
                gridState.ants.Add(new Ant(new Point(x, y), dir));
        }

        public void Step()
        {
            foreach (Ant a in gridState.ants)
            {
                Point from = a.Position;
                int state = grid[from.X, from.Y];

                if (gridState.turns[state] == 'R')
                    a.Direction++;
                else if (gridState.turns[state] == 'L')
                    a.Direction--;

                int nextState = ++state > gridState.turns.Count - 1 ? 0 : state;

                grid[from.X, from.Y] = nextState;

                Point to = a.Position.Add(Ant.directions[a.Direction]);

                if (to.Y < 0) to.Y = gridState.height - 1;
                if (to.Y > gridState.height - 1) to.Y = 0;

                if (to.X < 0) to.X = gridState.width - 1;
                if (to.X > gridState.width - 1) to.X = 0;

                a.Position = to;
            }
        }

        public Bitmap ToBitmap(GridRenderer gr)
        {
            return gr.Render(grid, gridState);
        }
    }

    public static class PointExtensions
    {
        public static string ToString(this Point p)
        {
            return String.Format("{0},{1}", p.X, p.Y);
        }

        public static Point Add(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }

    class GridState
    {
        public List<char> turns = new List<char>();
        public List<Ant> ants = new List<Ant>();

        public int width = 10;
        public int height = 10;

    }
}
