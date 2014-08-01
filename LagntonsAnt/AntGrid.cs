using System;
using System.Collections.Generic;
using System.Drawing;

namespace inter.c173
{
    class AntGrid
    {
        int[,] grid;
        GridState gridState;

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
            if(x < gridState.width && y < gridState.height)
                gridState.ants.Add(new Ant(new Point(x, y), 3));
        }

        public void Step()
        {
            foreach (Ant a in gridState.ants)
            {
                Point from = a.Position;
                int state = grid[from.x, from.y];

                if (gridState.turns[state] == 'R')
                    a.Direction++;
                else if (gridState.turns[state] == 'L')
                    a.Direction--;

                int nextState = ++state > gridState.turns.Count - 1 ? 0 : state;

                grid[from.x, from.y] = nextState;

                Point to = a.Position + Ant.directions[a.Direction];

                if (to.y < 0) to.y = gridState.height - 1;
                if (to.y > gridState.height - 1) to.y = 0;

                if (to.x < 0) to.x = gridState.width - 1;
                if (to.x > gridState.width - 1) to.x = 0;

                a.Position = to;
            }
        }

        public Bitmap ToBitmap(GridRenderer gr)
        {
            return gr.Render(grid, gridState);
        }
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public override string ToString()
        {
            return String.Format("{0},{1}",x,y);
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
