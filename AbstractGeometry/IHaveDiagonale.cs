using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal interface IHaveDiagonale
	{
		double GetDiagonale();
		void DrawDiagonale(System.Windows.Forms.PaintEventArgs e);
	}
}
