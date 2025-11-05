using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Student : Human
	{
		public string Speciality { get; set; }
		public string Group { get; set; }
		public double Rating { get; set; }
		public double Attendance { get; set; }
		public Student
			(
			string lastName, string firstName, int age,
			string speciality, string group, double rating, double attendance
			) : base(lastName, firstName, age)
		{
			Init(speciality, group, rating, attendance);
			Console.WriteLine($"SConstructor: \t{GetHashCode()}");
		}
		public Student
			(
			Human human, string speciality, string group, double rating, double attendance
			) : base(human)
		{
			Init(speciality, group, rating, attendance);
			Console.WriteLine($"SConstructor: \t{GetHashCode()}");
		}
		public Student(Student other) : base(other)
		{
			Init(other.Speciality, other.Group, other.Rating, other.Attendance);
			Console.WriteLine($"SConstructor: \t{GetHashCode()}");

		}
		~Student()
		{
			Console.WriteLine($"SConstructor: \t{GetHashCode()}");
		}
		void Init(string speciality, string group, double rating, double attendance)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine($"{Speciality} {Group} {Rating} {Attendance}");
		}
		public override string ToString()
		{

			return base.ToString()+
				$"{"Специальность│".PadLeft(14)}{Speciality}" + "\n" +
				$"{"Группа│".PadLeft(14)}{Group}" + "\n" +
				$"{"Рейтинг│".PadLeft(14)}{Rating.ToString()}" + "\n" +
				$"{"Посещаемость│".PadLeft(14)}{Attendance.ToString()}" + 
				$"{((base.GetType().ToString().Split('.').Last())!="Graduate"?"\n"+"─────┴─────".PadLeft(19):"")}";
		}
		public override string ToStringCSV()
		{
			return base.ToStringCSV()
				+$",{Speciality},{Group},{Rating},{Attendance}";
		}
		public override Human Init(string[] values)
		{
				base.Init(values);
			Speciality = values[4];
			Group = values[5];
			Rating = Convert.ToDouble(values[6]);
			Attendance = Convert.ToDouble(values[7]);
			return this; 
		}
	}
}
