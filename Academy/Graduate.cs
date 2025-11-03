using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate:Student
	{
		public string  Subject { get; set; }	
		public Graduate
			(
			string lastName, string firstName, int age,
			string speciality, string group, double rating, double attendance,
			string subject
			):base(lastName, firstName, age, speciality, group, rating, attendance)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:\t{GetHashCode()}");
		}
		public Graduate(Student student, string subject):base(student)
		{
			Subject=subject;
			Console.WriteLine($"GConstructor:\t{GetHashCode()}");
		}
		~Graduate() 
		{
			Console.WriteLine($"GDestructor:\t{GetHashCode()}");
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine(Subject);
		}
	}
}
