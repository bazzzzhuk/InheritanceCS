using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Policy;
using System.Drawing.Drawing2D;

namespace AbstractGeometry
{
	internal class Rectangle : Shape, IHaveDiagonale, IHaveHeight
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
		public double GetHeight()
		{
			return Height;
		}
		public Rectangle
			(
			double width, double height,
			int startx, int starty, int linewidth, Color color
			) : base(startx, starty, linewidth, color)
		{
			Width = width;
			Height = height;
		}
		public override double GetArea() => Width * Height;
		public override double GetPerimetr() => 2 * (Height + Width);
		public double GetDiagonale()
		{
			return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
		}
		public void DrawHeight(System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.DarkRed);
			Font font = new Font("Arial", FilterFont((int)GetHeight() / 20), FontStyle.Bold);
			TextFormatFlags flags = TextFormatFlags.NoPadding;
			string text = $"Высота: {GetHeight()}";
			Pen pen = new Pen(Color.Red, 1);
			//Thread.Sleep(1);
			Size textSize = TextRenderer.MeasureText(text, font);
			Matrix myMatrix = new Matrix();
			PointF rotatePoint = new PointF(StartX + (int)GetHeight()+50, StartY + (int)width / 2);
			myMatrix.RotateAt(-90, rotatePoint, MatrixOrder.Append);
			e.Graphics.Transform = myMatrix;
			e.Graphics.DrawString(text, font, brush, StartX + (int)GetHeight(), StartY + (int)width/2);
			e.Graphics.ResetTransform();
			e.Graphics.DrawLine(pen, (StartX + (int)width), StartY, (StartX + (int)width + 50), StartY);
			e.Graphics.DrawLine(pen, (StartX + (int)width), StartY + (int)GetHeight(), (StartX + (int)width + 50), StartY + (int)GetHeight());
			e.Graphics.DrawLine(pen, (StartX + (int)width + 25), StartY, (StartX + (int)width + 25), StartY + (int)GetHeight());
			e.Graphics.DrawLine(pen, (StartX + (int)width + 25), StartY, (StartX + (int)width + 15), StartY + 10);
			e.Graphics.DrawLine(pen, (StartX + (int)width + 25), StartY, (StartX + (int)width + 35), StartY + 10);
			e.Graphics.DrawLine(pen, (StartX + (int)width + 25), StartY + (int)GetHeight(), (StartX + (int)width + 15), StartY + (int)GetHeight() - 10);
			e.Graphics.DrawLine(pen, (StartX + (int)width + 25), StartY + (int)GetHeight(), (StartX + (int)width + 35), StartY + (int)GetHeight() - 10);
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			SolidBrush brush = new SolidBrush(Color);
			e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Width, (float)Height);
			//e.Graphics.FillRectangle(brush, StartX, StartY, (float)Width, (float)Height);
			DrawDiagonale(e);
			DrawHeight(e);
		}
		public void DrawDiagonale(System.Windows.Forms.PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Red, 3);
			SolidBrush brush = new SolidBrush(Color.DarkRed);
			e.Graphics.DrawLine(pen, StartX, StartY, StartX + (int)Width, StartY + (int)Height);
			e.Graphics.DrawLine(pen, StartX, StartY, StartX + 15, StartY+5);
			e.Graphics.DrawLine(pen, StartX, StartY, StartX + 5, StartY+15);
			e.Graphics.DrawLine(pen, StartX + (int)Width, StartY + (int)Height,StartX - 15 + (int)Width, StartY - 5 + (int)Height);
			e.Graphics.DrawLine(pen, StartX + (int)Width, StartY + (int)Height,StartX - 5 + (int)Width, StartY - 15 + (int)Height);
			Font font = new Font("Arial", 16, FontStyle.Bold);
			TextFormatFlags flags = TextFormatFlags.NoPadding;
			string text = $"Диагональ: {GetDiagonale()}";
			Size textSize = TextRenderer.MeasureText(text, font);
			Matrix myMatrix = new Matrix();
			PointF rotatePoint = new PointF(StartX + 20 + (int)width/2, StartY -20 + (int)height / 2);
			myMatrix.RotateAt(45, rotatePoint, MatrixOrder.Append);
			//Thread.Sleep(1);
			e.Graphics.Transform = myMatrix;
			e.Graphics.DrawString(text, font, brush, StartX + 30 + (int)width / 2 - textSize.Width / 2, StartY-20+(int)height/2);
			e.Graphics.ResetTransform();
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine(this.GetType().ToString().Split('.').Last() + ":");
			Console.WriteLine($"Ширина: {Width}");
			Console.WriteLine($"Высота: {Height}");
			Console.WriteLine($"Diagonal: {GetDiagonale()}");
			base.Info(e);
		}
	}
}
