using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		public string LastName {  get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }	
		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"HConstructor: \t{GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"HCopyConstructor: \t{GetHashCode()}");
		}
		~Human() 
		{
			Console.WriteLine($"HDestructor: \t{GetHashCode()}");
		}
		public virtual void Info()
		{
			Console.WriteLine($"{LastName} {FirstName} {Age}");
		}
		public override string ToString()
		{
			return 
				//split разделяет 'Academy.Type' на массив строк,
				//и из этого массива мы берем последний элемент
				$"{"─────┬─────\n".PadLeft(20)}" +
				$"{base.ToString().Split('.').Last()}│".PadLeft(14) +
				$"{LastName} " +
				$"{FirstName}" + "\n" +
				$"{"──────┼─────".PadLeft(19)}" + "\n" +
				$"{"Возраст│".PadLeft(14)}{Age.ToString().PadRight(5)}" + "\n";
			//PadRight() - выравнивает строку по левому борту. От Padding - наполнение. 
		}
		public virtual string ToStringCSV()
		{
			return 
				this.GetType().ToString().Split('.').Last()+","
				+$"{LastName},{FirstName},{Age}";	
		}
	}
}
