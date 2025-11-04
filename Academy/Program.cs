//#define INHERITANCE_1
//#define INHERITANCE_2
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
			Print(group);
			Save(group, path);
		}
		static void Print(Human[] group)
		{
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
				Console.WriteLine(delimiter);
			}
		}
		static void Save(Human[] group, string path)
		{
			using (StreamWriter sw = File.CreateText(path))
			{
				foreach (Human human in group)
				{
					sw.WriteLine(human);
				}
			}
		}
	}
}