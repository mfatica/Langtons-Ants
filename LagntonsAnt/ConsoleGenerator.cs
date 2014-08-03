using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LangtonsAnts
{
    class ConsoleGenerator
    {
        string[] args;
        int steps;
        string path;
        List<Point> ants;

        AntGrid grid;
        GridState gs;
        GridRenderer gr;

        public ConsoleGenerator(string[] args)
        {
            this.args = args;
            gs = new GridState();
            gr = new GridRenderer();
            ants = new List<Point>();

            PrintColorList();
        }

        private void PrintColorList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Available Colors:");

            KnownColor[] values = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor kc in values.OrderBy(v => v.ToString()))
                sb.AppendLine(kc.ToString());

            File.WriteAllText("./colors.txt", sb.ToString());
        }

        public void Generate()
        {
            try
            {
                ProcessArgs(args);

                grid = new AntGrid(gs);
                if(ants.Count > 0)
                {
                    foreach(Point pos in ants)
                    {
                        grid.AddAnt(pos);
                    }
                }

                Run();
            }
            catch
            {
                PrintUsage();
            }
        }

        private void SetDefaultOptions()
        {
            gr.CellSize = 5;
            gr.AntColor = Color.Red;

            gs.turns.Clear();
            gs.turns.Add('R');
            gs.turns.Add('L');

            gr.StateColors.Clear();
            gr.StateColors.Add(Color.White);
            gr.StateColors.Add(Color.Black);

            gr.GridLines = false;
            gr.GridLineColor = Color.Black;

            steps = -1;
            gs.width = -1;
            gs.height = -1;
        }

        private void ProcessArgs(string[] args)
        {
            SetDefaultOptions();

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg.ToLower().Contains("-w"))
                    gs.width = int.Parse(args[i+1]);

                if (arg.ToLower().Contains("-h"))
                    gs.height = int.Parse(args[i+1]);

                if (arg.ToLower().Contains("-turns"))
                {
                    string[] turns = args[i+1].Split(',');

                    gs.turns.Clear();

                    foreach (string t in turns)
                        gs.turns.Add(t[0]);
                }

                if (arg.ToLower().Contains("-colors"))
                {
                    string[] colors = args[i+1].Split(',');

                    gr.StateColors.Clear();

                    foreach (string name in colors)
                        gr.StateColors.Add(Color.FromName(name));
                }

                if (arg.ToLower().Contains("-gridlines"))
                    gr.GridLines = true;

                if (arg.ToLower().Contains("-gridcolor"))
                    gr.GridLineColor = Color.FromName(args[i+1]);

                if (arg.ToLower().Contains("-steps"))
                    steps = int.Parse(args[i+1]);

                if (arg.ToLower().Contains("-o"))
                    path = args[i+1];

                if(arg.ToLower().Contains("-ants"))
                {
                    string[] positions = args[i + 1].Split(';');

                    foreach(String pos in positions)
                    {
                        string[] split = pos.Split(',');
                        int X = int.Parse(split[0]);
                        int Y = int.Parse(split[1]);
                        ants.Add(new Point(X, Y));
                    }
                }
            }

            if(gs.width < 0 ||
                gs.height < 0 ||
                steps < 0 ||
                (gr.StateColors.Count != gs.turns.Count))
            {
                throw new Exception("Invalid arguments");
            }

            if (ants.Count < 1) ants.Add(new Point(gs.width / 2, gs.height / 2));
        }

        private void PrintUsage()
        {
            Console.WriteLine("\nusage: ants [options] -steps <num steps> -w <grid width> -h <grid height>\n" + 
                "\toptions:\n" +
                "\t\t-ants <x1,y1;x2,y2>\n\t\t\tSpecify ant start postition\n\t\t\tDefault is center\n" +
                "\t\t-turns <turns>\n\t\t\tRequires -colors\n\t\t\tSpecify turns\n" +
                "\t\t-colors <colors>\n\t\t\tRequres -turns\n\t\t\tSpecify tile colors\n" + 
                "\t\t-antcolor <color>\n\t\t\tSpecify ant color\n" +
                "\t\t-gridlines\n\t\t\tEnable grid lines\n" + 
                "\t\t-gridcolor <color>\n\t\t\tGrid line color\n" + 
                "\t\t-o <filename>\n\t\t\tOutput file name\n" + 
                "\tformat:\n" + 
                "\t\t<color>\tName of color, comma delimited\n" + 
                "\t\t<turn>\tL or R, comma delimited\n" + 
                "\t\t<x,y>\txy position, semicolon delimited");

            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }

        private void Run()
        {
            path = path == null ? String.Format("./{0}.bmp", steps) : path;

            while(steps-- > 0)
            {
                grid.Step();
            }
            grid.ToBitmap(gr).Save(path);
        }
    }
}
