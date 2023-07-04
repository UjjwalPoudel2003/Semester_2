using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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

            Employee emp1 = new Employee("Mary", "456 Main St", 1001, "Manager");
            Console.WriteLine($"emp1: {emp1}");

            PartTimeEmployee ptemp1 = new PartTimeEmployee("Tom", "789 Main St", 1002, "Clerk", 15.50, 40);
            Console.WriteLine($"ptemp1: {ptemp1}");
        }// TestInheritance ends
    }// Program ends

    public class Person 
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Person(string name, string address)
        {
            Console.WriteLine("Person constructor");
            this.Name = name;
            this.Address = address;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Address: {this.Address}";
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

    public class  Employee : Person
    {
        public int EmpID { get; set; }
        public string Designation { get; set; }

        public Employee(string nam, string address, int empID, string designation) : base(nam, address)
        {
            Console.WriteLine("Employee constructor");
            this.EmpID = empID;
            this.Designation = designation;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Emp ID : {this.EmpID}, Designation : {this.Designation}";
        }
    }// Employee ends

    public class  PartTimeEmployee : Employee
    {
        public double HourlyPay { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string nam, string address, int empID, string designation,double hourlyPay, double hoursWorked)
        : base(nam, address, empID, designation)
        {
            Console.WriteLine("PartTimeEmployee constructor");
            this.HourlyPay = hourlyPay;
            this.HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $" Hourly Pay : {this.HourlyPay}, Hours Worked : {this.HoursWorked}";
        }
    }
}
