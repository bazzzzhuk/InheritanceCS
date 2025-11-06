using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Geometry_CS
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graphics g = Graphics.FromHwnd(IntPtr.Zero);
			g.Clear(Color.WhiteSmoke);
			Pen pen = new Pen(Color.Red,10);
			while (true) { g.DrawRectangle(pen, 10, 10, 100, 100); }
		}
	}
}
