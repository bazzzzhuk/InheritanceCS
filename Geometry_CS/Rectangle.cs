using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_CS
{
	internal class Rectangle : Shape
	{

		public double Width
		{
			get; set;
		}
		public double Height
		{
			get; set;
		}
		public Rectangle
			(double width, double height, int start_x, int start_y, int line_width)
			: base(start_x, start_y, line_width)
		{
			Width = width;
			Height = height;
		}		
		public override double get_area()
		{
			return Width * Height;
		}
		public override double get_perimetr()
		{
			return (Width + Height) * 2;
		}
		public override void draw(Graphics g, Color color)
		{
			Pen pen = new Pen(color, line_width);
			g.DrawRectangle(pen, start_x, start_y, Convert.ToInt32(Width), Convert.ToInt32(Height));
		}
		public override void info(Graphics g, Color color)
		{
			//Console.WriteLine($"{this.GetHashCode)}");
			Console.CursorLeft = start_x / 9 ;
			Console.CursorTop = start_y/10 -4;
			Console.WriteLine($"Стороны: {Width}x{Height}");
			Console.CursorLeft = start_x++ / 9;
			Console.CursorTop = start_y / 10 - 3;
			Console.WriteLine($"Площадь: {get_area()}");
			Console.CursorLeft = start_x++ / 9;
			Console.CursorTop = start_y / 10 - 2;
			Console.WriteLine($"Периметр: {get_perimetr()}");
			draw(g, color);
		}
	}
}