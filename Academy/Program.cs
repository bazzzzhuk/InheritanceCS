//#define INHERITANCE_1
//#define INHERITANCE_2
#define WRITE_TO_FILE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Program
	{
		static string path = @"L:\static new\Group_HW_1.txt";
		static readonly string delimiter = "─────────────────────────────";
		static void Main(string[] args)
		{
#if INHERITANCE_1
			Console.WriteLine("Academy");
			Human human = new Human("Montana", "Antonio", 25);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie",22,"Chemistry", "WW_220", 90, 95);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Info();	
			Console.WriteLine(delimiter);
#endif
#if INHERITANCE_2
			Human human = new Human("Pinkman", "Jessie", 22);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student(human, "Chemistry", "WW_220", 90, 95);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher(new Human("White", "Walter", 50), "Chemistry", 25);
			teacher.Info();
			Console.WriteLine(delimiter);

			Human h_Hank = new Human("Shreder", "Hank", 40);
			Student s_Hank = new Student(h_Hank, "Criminalistic", "OBN", 50, 60);
			Graduate graduate = new Graduate(s_Hank, "How to catch Heisenberg");
			graduate.Info();

#endif
			Streamer streamer = new Streamer();
#if WRITE_TO_FILE
			//Dictionary<string, string> academy_human = new Dictionary<string, string>();

			//base-class pointers: Generalisation (Upcast - приведение дочернего объекта к базовому типу)
			Human[] group =
			{
				new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 90, 95),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Shreder", "Hank", 40, "Criminalistic", "OBN", 50, 60, "How to catch Heisenberg"),
				new Student("Vercetty", "Tommy", 30, "Theft", "Vice", 90, 95),
				new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 25)
			};
			streamer.Print(group);
			streamer.Save(group, "group.txt");
			Human[]group2 = streamer.Load("group.txt");
			streamer.Print(group2);
#endif
			//Human[] group2 = streamer.Load("group.txt");
			//streamer.Print(group2);
		}
		//static Human[] Load(string filename)
		//{
		//	Human[] group = null;
		//	using (StreamReader sr = new StreamReader(path))
		//	{
		//		while (sr.EndOfStream)
		//		{
		//			string line = sr.ReadLine();
		//			if (line.Contains("│")) 
		//			{

		//			}
		//		}
		//	}
		//	return group;
		//}

		
	}
}