using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class EquilateralTriangle:IsoscelesTriangle
	{
		public EquilateralTriangle(double side, int startx, int starty, int lineWigth, System.Drawing.Color color):
			base (side,side, startx, starty,lineWigth, color)
		{ }
	}
}
