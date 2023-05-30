using System;

namespace Week4_Properties_Partial
{
    class Member2
    {
    }

	//work from member2
	public partial class Student
	{
		public int studentID;
		public void submitAssignment()
		{
			Console.WriteLine($"Assignment  by {this.Name}");
		}

		public void participattion()
		{
			Console.WriteLine($"{this.Name} is participating in an event");
		}
	}
}
