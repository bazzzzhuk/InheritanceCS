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
			return base.ToString()+$"{Speciality.PadRight(16)}{Group.PadRight(8)}{Rating.ToString().PadRight(8)}{Attendance.ToString().PadRight(8)}";
		}
	}
}
