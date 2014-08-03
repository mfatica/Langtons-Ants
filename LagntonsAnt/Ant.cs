using System;
using System.Drawing;

namespace LangtonsAnts
{
    class Ant
    {
        private static long Count;

        private Point _pos = new Point(0, 0);
        private int _dir = 3;

        public Ant(Point pos, int dir)
        {
            Id = Count++;
            Position = pos;
            Direction = dir;
        }

        public long Id
        {
            get;
            set;
        }

        public int Direction
        {
            get
            {
                return _dir;
            }

            set
            {
                if (value < 0) value = directions.Length - 1;
                if (value > directions.Length - 1) value = 0;

                _dir = value;
            }
        }

        public Point Position
        {
            get;
            set;
        }

        public static Point[] directions = 
        { 
            new Point(0,-1),
            new Point(1,0),
            new Point(0,1),
            new Point(-1,0),
        };

        public override string ToString()
        {
            return String.Format("{0},{1}", Position.ToString(), Direction);
        }
    }
}
