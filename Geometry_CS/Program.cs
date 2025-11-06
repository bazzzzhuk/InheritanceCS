using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Geometry_CS
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graphics g = Graphics.FromHwnd(IntPtr.Zero);
			g.Clear(Color.WhiteSmoke);
			//Pen pen = new Pen(Color.Red,10);
				Rectangle rect = new Rectangle(10, 10, 10, 10, 1);
			Random rand = new Random();
			for(int i=0; i<300; i++)
			{
				Color color = Color.FromArgb(rand.Next());
				rect.Width++;
				rect.Height++;
				//rect.start_x++;
				rect.start_y++;
				rect.info(g, color);
				Console.Clear();
				//Thread.Sleep(3);
			}
		}
	}
}
