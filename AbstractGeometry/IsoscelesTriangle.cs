using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace AbstractGeometry
{
	internal class IsoscelesTriangle : Triangle
	{
		double @base;//'base'- ключевое слово обозначающее базовый класс, ключ.слова нельзя использовать для именования, но если перед ключевым словом поставить собаку, то его можно использовать для именования своих сущностей.
		double side;
		public double Base
		{
			get => @base; set => @base = FilterSize(value);
		}
		public double Side
		{

			get => side; set => side = FilterSize(value);
		}
		public IsoscelesTriangle(double @base, double side, int startx, int starty, int lineWidth, System.Drawing.Color color)
			: base(startx, starty, lineWidth, color)
		{
			Base = @base;
			Side = side;
		}
		public override double GetHeight()
		{
			return Math.Sqrt(Math.Pow(Side,2) - Math.Pow(Base/2,2));
			}
		public override double GetArea()
		{
			return Base * GetHeight()/2;
		}
		public override double GetPerimetr()
		{
			return 2 * Side + Base;
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			Point[]vertices = new Point[]
				{
					new Point(StartX, StartY+(int)GetHeight()),
					new Point(StartX+(int)Base, StartY+(int)GetHeight()),
					new Point((int)StartX+(int)Base/2, StartY)
				};
			e.Graphics.DrawPolygon(pen, vertices);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Основание: {Base}");
			Console.WriteLine($"Сторона: {Side}");
			base.Info(e);
		}
	}
}
