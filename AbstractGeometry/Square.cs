using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AbstractGeometry
{
	internal class Square:Rectangle
	{
		public Square(double side, int startx, int starty, int lineWidth, Color color):
			base(side, side, startx, starty, lineWidth, color)
		{

		}
	}
}
