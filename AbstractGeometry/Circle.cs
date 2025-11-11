using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AbstractGeometry
{
	internal class Circle:Shape,IHaveDiameter
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
		public double GetDiameter()
		{
			return Radius*2;
		}
		public void DrawDiameter(System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.DarkRed);
			Font font = new Font("Arial", 16, FontStyle.Bold);
			TextFormatFlags flags = TextFormatFlags.NoPadding;
			string text = $"Диаметр: {radius}";
			Pen pen = new Pen(Color.Red, 1);
			Matrix myMatrix = new Matrix();
			PointF rotatePoint = new PointF(StartX+(int)(Radius), StartY + (int)(Radius));
			myMatrix.RotateAt(-45, rotatePoint, MatrixOrder.Append);
			//Thread.Sleep(1);
			Size textSize = TextRenderer.MeasureText(text, font);
			e.Graphics.Transform = myMatrix;
			e.Graphics.DrawLine(pen, StartX , StartY + (int)Radius, StartX + (int)Radius*2, StartY + (int)Radius);
			e.Graphics.DrawLine(pen, StartX + (int)Radius*2, StartY + (int)Radius, StartX + (int)Radius*2-10, StartY + (int)Radius+10 );
			e.Graphics.DrawLine(pen, StartX + (int)Radius*2, StartY + (int)Radius, StartX + (int)Radius*2-10, StartY + (int)Radius-10 );
			e.Graphics.DrawLine(pen, StartX , StartY + (int)Radius, StartX+10, StartY + (int)Radius + 10);
			e.Graphics.DrawLine(pen, StartX , StartY + (int)Radius, StartX+10, StartY + (int)Radius - 10);
			e.Graphics.DrawString(text, font, brush, StartX +(int)Radius - textSize.Width/2, StartY + (int)Radius-40);
			e.Graphics.ResetTransform();
		}
		public override double GetArea() => Math.PI * Math.Pow(Radius,2);
		public override double GetPerimetr()=>2*Math.PI*Radius;
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)(2 * Radius), (float)(2 * Radius));
			DrawDiameter(e);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"{this.GetType()}");
			Console.WriteLine($"Radius: {Radius}");
			base.Info(e);
		}
	}
}
