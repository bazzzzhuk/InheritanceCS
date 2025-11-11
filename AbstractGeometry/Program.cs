//#define ABSTRACT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices; //DLLImport
using System.Windows.Forms;
using System.Data;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;



namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle
				(Console.WindowLeft, Console.WindowTop,
				Console.WindowWidth, Console.WindowHeight
				);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
#if ABSTRACT
			//e.Graphics.DrawRectangle(new Pen(Color.Plum,15), 300, 200, 500, 300);
			// Set world transform of graphics object to rotate.
			Pen myPen = new Pen(Color.Blue, 10);
			//System.Drawing.Drawing2D.Matrix rotateMatrix = new System.Drawing.Drawing2D.Matrix();
			//Flip_cube(e);
			//Flip_ellipse(e);
			Rectangle rectangle = new Rectangle(600, 600, 400, 300, 3, Color.DarkTurquoise);
			rectangle.Info(e);
			Square square = new Square(350, 500,100,550,Color.Azure);
			square.Info(e);
			Circle circle = new Circle(100, 350, 350, 5, Color.Yellow);
			circle.Info(e);
			IsoscelesTriangle triange = new IsoscelesTriangle(130, 140, 300, 350, 5, Color.Ivory);
			triange.Info(e);
			EquilateralTriangle equ = new EquilateralTriangle(50,700,600, 4, Color.Green);
			equ.Info(e);
#endif
			Shape[] shapes =
				{
				new Rectangle(600, 600, 400, 300, 3, Color.DarkBlue),
				new Square(350, 500,100,550,Color.Azure),
				new Circle(150, 450, 450, 5, Color.Yellow),
				new IsoscelesTriangle(130, 140, 300, 350, 5, Color.Ivory),
				new EquilateralTriangle(50,700,600, 4, Color.Green)
			};
			for (int i = 0; i < shapes.Length; i++)
			{
				if ((shapes[i] is IHaveDiameter))
				shapes[i].Draw(e);
			}
		}
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		public static void Flip_cube(PaintEventArgs e)
		{
			Pen myPen = new Pen(Color.Blue, 10);
			float x = -100.0f;
			while (true)
			{
				for (float i = 10; i < 89; i = i + 1)
				{
					Matrix myMatrix = new Matrix();
					PointF rotatePoint = new PointF(x + 200, 700.0f);
					myMatrix.RotateAt(i, rotatePoint, MatrixOrder.Append);
					e.Graphics.DrawRectangle(myPen, x, 500, 200, 200);
					//Thread.Sleep(1);
					e.Graphics.Transform = myMatrix;
					Console.Clear();
				}
				x = x + 200;
			}
		}
		public static void Flip_ellipse(PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DarkOliveGreen, 1);
			PointF point1 = new PointF(325.0F, 2.5F);
			PointF point2 = new PointF(375.0F, 2.5F);
			PointF point3 = new PointF(375.0F, 125.0F);
			PointF point4 = new PointF(400.0F, 125.0F);
			PointF point5 = new PointF(350.0F, 175.0F);
			PointF point6 = new PointF(302.5F, 125.0F);
			PointF point7 = new PointF(325.0F, 125.0F);
			PointF[] curvePoints =
					 {
				 point1,
				 point2,
				 point3,
				 point4,
				 point5,
				 point6,
				 point7
			 };
			while (true)
			{
				for (float i = 0; i < 361; i = i + 1)
				{
					Random rand = new Random();
					Color color = new Color();
					color = Color.FromArgb(rand.Next());
					Brush brush = new SolidBrush(color);
					Matrix myMatrix = new Matrix();
					PointF rotatePoint = new PointF(350, 300.0f);
					myMatrix.RotateAt(i, rotatePoint, MatrixOrder.Append);
					//Thread.Sleep(1);
					e.Graphics.Transform = myMatrix;
					Console.Clear();
					e.Graphics.DrawPolygon(pen, curvePoints);
					e.Graphics.FillEllipse(brush, 250, 200, 200, 200);
				}
			}
		}
	}
}
