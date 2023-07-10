using System;
using System.Runtime.CompilerServices;

namespace Week8_Inheritance
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestInheritance();
		}// Main ends

		static void TestInheritance()
		{
			Person p1 = new Person("John", "123 Main St");
			Console.WriteLine($"p1: {p1}");

			//Employee emp1 = new Employee("Mary", "456 Main St", 1001, "Manager");
			//Console.WriteLine($"emp1: {emp1}");

			PartTimeEmployee ptemp1 = new PartTimeEmployee("Tom", "789 Main St", 1002, "Clerk", 15.50, 40);
			Console.WriteLine($"ptemp1: {ptemp1}");

			FullTimeEmployee ftemp1 = new FullTimeEmployee("Sue", "101 Main St", 1003, "Accountant", 50000);
			Console.WriteLine($"ftemp1: {ftemp1}");
		}// TestInheritance ends
	}// Program ends

	public class Person 
	{
		public string Name { get; set; }
		public string Address { get; set; }

		public Person(string name, string address)
		{
			this.Name = name;
			this.Address = address;
		}

		public override string ToString()
		{
			return $"Name: {this.Name}, Address: {this.Address}\n";
		}
	}// Person ends

	/*
	 * Employee inherits from the Person
	 * Employee IS-A Person
	 * Employee class can use/ have access to all the
	 * non-private members( fields, properties, methods, constructors) of the Person class
	 * Person - Parent, Base, Super class
	 * Employee - Child, Derived, Sub class
	*/

	// Sealed class cannot be inherited
	// doesn't allow modification of the class
	// sealed public class Employee : Person
	abstract public class  Employee : Person
	{
		// Protected members(fields, properties, methods, constructors) are accessible in the derived class
		protected int EmpID { get; set; }
		protected string Designation { get; set; }

		// Properties or method marked as virtual can be overridden in the derived class
		public virtual double BiWeeklyPay { get; }

		abstract public double getPay();

		public Employee(string nam, string address, int empID, string designation) : base(nam, address)
		{
			this.EmpID = empID;
			this.Designation = designation;
		}

		// sealed method cannot be overridden
		public override string ToString()
		{
			return $"{base.ToString()}, Emp ID : {this.EmpID}, Designation : {this.Designation}, Biweekly Pay : {this.BiWeeklyPay:C} - {this.getPay()}\n";
		}
	}// Employee ends

	public class  PartTimeEmployee : Employee
	{
		public double HourlyPay { get; set; }
		public double HoursWorked { get; set; }
		public override double BiWeeklyPay
		{
			get
			{
				return this.HourlyPay * this.HoursWorked;
			}
		}

		public PartTimeEmployee(string nam, string address, int empID, string designation,double hourlyPay, double hoursWorked)
		: base(nam, address, empID, designation)
		{
			this.HourlyPay = hourlyPay;
			this.HoursWorked = hoursWorked;
		}

		public override string ToString()
		{
			return $"{base.ToString()}" +
				$" Hourly Pay : {this.HourlyPay:C}, Hours Worked : {this.HoursWorked}\n";
		}

        public override double getPay()
        {
            return this.HourlyPay * this.HoursWorked;
        }
    }// PartTimeEmployee ends

	public class FullTimeEmployee : Employee
	{
		public double AnnualSalary { get; set; }

		public override double BiWeeklyPay
		{
            get
			{
                return this.AnnualSalary / 26;
            }
        }

		public FullTimeEmployee(string nam, string address, int empID, string designation, double annualSalary) : base(nam, address, empID, designation)
		{
			this.AnnualSalary = annualSalary;
		}

		public override string ToString()
		{
			return $"{base.ToString()}, Annual Salary : {this.AnnualSalary:C}";
		}

        public override double getPay()
        {
			return this.AnnualSalary / 26;
        }
    }
}
