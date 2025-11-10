using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Rectangle : Shape
	{
		double width;
		double height;
		public double Width
		{
			get => width;
			set => width = FilterSize(value);
		}
		public double Height
		{
			get => height;
			set => height = FilterSize(value);
		}
		public Rectangle
			(
			double width, double height,
			int startx, int starty, int linewidth, Color color
			):base(startx, starty, linewidth, color)
		{
			Width = width;
			Height = height;
		}
		public override double GetArea() => Width*Height;
		public override double GetPerimetr() => 2*(Height+Width);
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color,LineWidth);
			SolidBrush brush = new SolidBrush(Color);
			e.Graphics.DrawRectangle(pen,StartX,StartY,(float)Width, (float)Height);
			e.Graphics.FillRectangle(brush, StartX, StartY, (float)Width, (float)Height);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine(this.GetType().ToString().Split('.').Last()+":");
			Console.WriteLine($"Ширина: {Width}");
			Console.WriteLine($"Высота: {Height}");
			base.Info(e);
		}
	}
}
