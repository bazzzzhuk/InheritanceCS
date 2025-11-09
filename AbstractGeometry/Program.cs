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
			//e.Graphics.DrawRectangle(new Pen(Color.Plum,15), 300, 200, 500, 300);
			//Rectangle rectangle = new Rectangle(200, 200, 300, 300, 3, Color.DarkTurquoise);
			//rectangle.Info(e);
			// Set world transform of graphics object to rotate.
			Pen myPen = new Pen(Color.Blue, 10);
			//System.Drawing.Drawing2D.Matrix rotateMatrix = new System.Drawing.Drawing2D.Matrix();
			//Flip_cube(e);
			Flip_ellipse(e);
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
			// Create points that define polygon.
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
				for (float i = 0; i < 361; i = i + 2)
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
