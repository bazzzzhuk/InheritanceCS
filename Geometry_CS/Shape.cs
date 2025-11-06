using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//#define SHAPE_TAKE_PARAMETERS int start_x, int start_y, int line_width,	Color color
//#define SHAPE_GIVE_PARAMETERS start_x, start_y, line_width, color

namespace Geometry_CS
{
	abstract internal class Shape
	{
		//protected

		int start_x;
		int start_y;
		int line_width;

		public static int MIN_START_X = 100;
		public static int MIN_START_Y = 100;
		public static int MAX_START_X = 1000;
		public static int MIN_LINE_WIDTH = 1;
		public static int MAX_LINE_WIDTH = 16;
		public static int MIN_SIZE = 32;
		public static int MAX_SIZE = 512;
		public static int MAX_START_Y = 600;

		public Shape(int start_x, int start_y, int line_width)
		{
			set_start_x(start_x);
			set_start_y(start_y);
			set_line_width(line_width);
		}
		public void set_start_x(int start_x)
		{
			this.start_x =
				start_x < MIN_START_X ? MIN_START_X :
				start_x > MAX_START_X ? MAX_START_X :
				start_x;
		}
		public void set_start_y(int start_y)
		{
			this.start_y =
				start_y < MIN_START_Y ? MIN_START_Y :
				start_y > MAX_START_Y ? MAX_START_Y :
				start_y;
		}
		public void set_line_width(int line_width)
		{
			this.line_width =
				line_width < MIN_LINE_WIDTH ? MIN_LINE_WIDTH :
				line_width > MAX_LINE_WIDTH ? MAX_LINE_WIDTH :
				line_width;
		}
		public double filter_size(int size)
		{
			return size < MIN_SIZE ? MIN_SIZE :
				size > MAX_SIZE ? MAX_SIZE :
				size;
		}

		public int get_start_x()
		{
			return start_x;
		}
		public int get_start_y()
		{
			return start_y;
		}
		public int get_line_width()
		{
			return line_width;
		}

		public abstract double get_area();
		public abstract double get_perimetr();
		public abstract void draw();


		public virtual void info()
		{
			Console.WriteLine($"Площадь квадрата: " + get_area());
			Console.WriteLine();
			Console.WriteLine($"Периметр квадрата: " + get_perimetr());
			Console.WriteLine();
			draw();
		}
	};
}
