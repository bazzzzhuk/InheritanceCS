using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal interface IHaveHeight
	{
		double GetHeight();
		void DrawHeight(System.Windows.Forms.PaintEventArgs e);

	}
}
