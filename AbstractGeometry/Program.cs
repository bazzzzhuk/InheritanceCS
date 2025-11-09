using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices; //DLLImport
using System.Windows.Forms;
using System.Data;

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
			PaintEventArgs e = new PaintEventArgs( graphics, window_rect );
			//e.Graphics.DrawRectangle(new Pen(Color.Plum,15), 300, 200, 500, 300);
			Rectangle rectangle = new Rectangle(200, 200, 300, 300, 3, Color.DarkTurquoise);
			rectangle.Info(e);
			// Set world transform of graphics object to rotate.
			for (float i = 1; i < 360; i++)
			{
				e.Graphics.RotateTransform(i);

				// Then to scale, prepending to world transform.
				e.Graphics.ScaleTransform(3.0F, 2.0F);

				// Draw scaled, rotated rectangle to screen.
				e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), 150, 150, 100, 40);
				e.Dispose();
			}
		}
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
	}
}
