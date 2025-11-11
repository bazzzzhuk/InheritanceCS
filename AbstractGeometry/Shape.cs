using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	abstract internal class Shape
	{
		public static readonly int MIN_START_X = 10;
		public static readonly int MIN_START_Y = 10;
		public static readonly int MAX_START_X = 800;
		public static readonly int MAX_START_Y = 600;
		public static readonly int MIN_LINE_WIDTH = 1;
		public static readonly int MAX_LINE_WIDTH = 50;
		public static readonly double MIN_SIZE = 20;
		public static readonly double MAX_SIZE = 800;
		public static readonly int MIN_FONT = 8;
		public static readonly int MAX_FONT = 20;


		int startx;
		int starty;
		int linewidth;

		public int StartX
		{
			get => startx;
			set => startx =
				value < MIN_START_X ? MIN_START_X :
				value > MAX_START_X ? MAX_START_X :
				value;
		}
		public int StartY
		{
			get => starty;
			set => starty =
				value < MIN_START_Y ? MIN_START_Y :
				value > MAX_START_Y ? MAX_START_Y :
				value;
		}
		public int LineWidth
		{
			get => linewidth;
			set => linewidth = 
				value < MIN_LINE_WIDTH ? MIN_LINE_WIDTH :
				value > MAX_LINE_WIDTH ? MAX_LINE_WIDTH :	
				value;
		}
		public double FilterSize(double value) =>
			value<MIN_SIZE?MIN_SIZE:
			value > MAX_SIZE?MAX_SIZE:	
			value;
		public int FilterFont(int value) =>
			value < MIN_FONT ? MIN_FONT :
			value > MAX_FONT ? MAX_FONT :
			value;
		public Color Color { get; set; }

		public Shape(int startx, int starty, int linewidth, Color color)
		{
			StartX = startx;
			StartY = starty;
			LineWidth = linewidth;			
			Color = color;
		}
		public abstract double GetArea();
		public abstract double GetPerimetr();
		public abstract void Draw(PaintEventArgs e);
		public virtual void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Площадь фигуры: {GetArea()}");
			Console.WriteLine($"Периметр фигуры: {GetPerimetr()}");
			Draw(e);
		}
	}
}
