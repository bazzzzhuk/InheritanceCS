using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;

namespace AbstractGeometry
{
	internal class IsoscelesTriangle : Triangle, IHaveHeight
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
			DrawHeight(e);
		}
		public void DrawHeight(System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.DarkRed);
			Font font = new Font("Arial", FilterFont((int)GetHeight()/20), FontStyle.Bold);
			TextFormatFlags flags = TextFormatFlags.NoPadding;
			string text = $"Высота: {GetHeight()}";
			Pen pen = new Pen(Color.Red, 1);
			//Thread.Sleep(1);
			Size textSize = TextRenderer.MeasureText(text, font);
			Matrix myMatrix = new Matrix();
			PointF rotatePoint = new PointF(StartX, StartY);
			myMatrix.RotateAt(-90, rotatePoint, MatrixOrder.Append);
			e.Graphics.Transform = myMatrix;
			e.Graphics.DrawString(text, font, brush, StartX - (int)GetHeight() + textSize.Height, StartY+(int)Base+50);
			e.Graphics.ResetTransform();
			e.Graphics.DrawLine(pen, (StartX+(int)Base/2), StartY, (StartX + (int)Base+50), StartY);
			e.Graphics.DrawLine(pen, (StartX+(int)Base), StartY+(int)GetHeight(), (StartX + (int)Base+50), StartY + (int)GetHeight());
			e.Graphics.DrawLine(pen, (StartX+(int)Base+25), StartY, (StartX + (int)Base+25), StartY + (int)GetHeight());
			e.Graphics.DrawLine(pen, (StartX+(int)Base+25), StartY, (StartX+(int)Base+15), StartY+10);
			e.Graphics.DrawLine(pen, (StartX+(int)Base+25), StartY, (StartX+(int)Base+35), StartY+10);
			e.Graphics.DrawLine(pen, (StartX+(int)Base+25), StartY + (int)GetHeight(), (StartX+(int)Base+15), StartY + (int)GetHeight() - 10);
			e.Graphics.DrawLine(pen, (StartX+(int)Base+25), StartY + (int)GetHeight(), (StartX+(int)Base+35), StartY + (int)GetHeight() - 10);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Основание: {Base}");
			Console.WriteLine($"Сторона: {Side}");
			base.Info(e);
		}
	}
}
