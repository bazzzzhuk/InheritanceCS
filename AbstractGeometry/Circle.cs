using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Circle:Shape
	{
		double radius;
		public double Radius
		{
			get => radius;
			set => radius = FilterSize(value);
		}
		public Circle(double radius, int startx, int starty, int lineWidth, Color color):
			base(startx, starty, lineWidth, color)
		{
			Radius = radius;
		}
		public override double GetArea() => Math.PI * Math.Pow(Radius,2);
		public override double GetPerimetr()=>2*Math.PI*Radius;
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)(2 * Radius), (float)(2 * Radius));
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"{this.GetType()}");
			Console.WriteLine($"Radius: {Radius}");
			base.Info(e);
		}
	}
}
