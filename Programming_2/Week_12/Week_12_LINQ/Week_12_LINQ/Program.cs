using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_12_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestSelection();
            //TestFilter();
            //TestOrderBy();
            TestGroupBy();
        } //Main Ends

        static void TestFilter()
        {
            List<Student> students = Student.studentList;

            // show all the studnet shaving grade more than 60% using method syntax
            //IEnumerable<Student> result1 = students.Where(stud => stud.Grade > 60);

            // Using query syntax
            IEnumerable<Student> result1 = from stud in students where stud.Grade > 60 select stud;

            Console.WriteLine("All the students having grade more than 60% ---------------------------");
            Console.WriteLine($"{string.Join("\n", result1)}");

            // Showing all the students names having grade more than 90%
            var result2 = students.
                Where(stud => stud.Grade > 90).
                Select(stud => stud.Name);

            Console.WriteLine("\nAll the students having grade more than 90% ---------------------------");
            Console.WriteLine($"{string.Join("\n", result2)}");

            // Show all the student aes that starts with 'B' and having grade more than 90%
            var result3 = students.
                Where(stud => stud.Name.StartsWith("B") && stud.Grade > 90).
                Select(stud => stud.Name);

            Console.WriteLine("\nAll the students having grade more than 90% and name starts with 'B' ---------------------------");
            Console.WriteLine($"{string.Join("\n", result3)}");


            // Display all the students having grade more than 80% and name starts with 'A'
            var result4 = students.
                Where(stud => stud.Name.StartsWith("A") && stud.Grade > 90).
                Select(stud => stud.Name);

            Console.WriteLine("\nAll the students having grade more than 90% and name starts with 'A' ---------------------------");
            Console.WriteLine($"{string.Join("\n", result4)}");

            if (result4.Count() > 0)
            {
                Console.WriteLine($"{string.Join("\n", result4)}");
            }
            else
            {
                Console.WriteLine("No student found");
            }
        }

        static void TestSelection()
        {
            List<Student> students = Student.studentList;
            // show all the student names
            IEnumerable<string> result1 = students.Select(stud => stud.Name);

            Console.WriteLine("All the student names using Method Syntax---------------------------");
            Console.WriteLine($"result1 : {result1}");

            Console.WriteLine($"{string.Join("\n", result1)}");

            // query syntax
            IEnumerable<string> result2 = from stud in students select stud.Name;

            Console.WriteLine("All the student names using Query Syntax---------------------------");
            Console.WriteLine($"{string.Join("\n", result2)}");

            // show all the students' id
            IEnumerable<int> result3 = from stud in students select stud.Id;

            Console.WriteLine($"\nAl the IDs of students ---------------------------");
            Console.WriteLine($"{string.Join("\n", result3)}");

            // show all the students information
            IEnumerable<Student> result4 = students.Select(stud => stud);
            
            // In query syntax
            Console.WriteLine($"\nAll the students information ---------------------------");
            Console.WriteLine($"{string.Join("\n", result4)}");

        }

        static void TestOrderBy()
        {
            List<Student> students = Student.studentList;

            //// show all the students' names in ascending order
            //var result1 = students.OrderBy(stud => stud.Grade);

            //// In query syntax
            ////var result1 = from stud in students orderby stud.Grade select stud;

            //Console.WriteLine("All the students' names in ascending order ---------------------------");
            //Console.WriteLine($"{string.Join("\n", result1)}");

            //// show all the students' Id in descending order
            //var result2 = students.OrderByDescending(stud => stud.Id);

            //// In query syntax
            ////var result2 = from stud in students orderby stud.Id descending select stud;

            //Console.WriteLine("\nAll the students' Id in descending order ---------------------------");
            //Console.WriteLine($"{string.Join("\n", result2)}");

            //// Show all the students in increasing iorder of their grades
            //// and then decreasing oder of their id
            //var result3 = students.
            //    OrderBy(stud => stud.Grade).
            //    ThenByDescending(stud => stud.Id);

            //Console.WriteLine("\nAll the students in increasing iorder of their grades and then decreasing oder of their id ---------------------------");
            //Console.WriteLine($"{string.Join("\n", result3)}");


            // Show all the students in decreasing of their Name but should not display name starting with B
            var result4 = students.
                OrderByDescending(stud => stud.Name);

            Console.WriteLine("\nAll the students in decreasing of their Name but should not display name starting with B ---------------------------");
            foreach (var item in result4)
            {
                if (!item.Name.StartsWith("B"))
                {
                    Console.WriteLine(item.Name);
                }
            }

        }

        static void TestGroupBy()
        {
            List<Student> students = Student.studentList;

            // Show all the students grouped by program
            var result1 = students.GroupBy(stud => stud.Program);

            //var result1 = students.GroupBy(stud => stud.Program).
            //    Select(stud => stud.Name);

            Console.WriteLine("All the students grouped by program ---------------------------");
            //Console.WriteLine($"{string.Join("\n", result1)}");
            foreach (var group in result1)
            {
                Console.WriteLine($"\nGroup Count: {group.Count()}, Grouping Value: {group.Key}");
                //Console.WriteLine($"{string.Join("\n", group)}");

                foreach (var item in group)
                {
                    Console.WriteLine(item.Name);
                }
            }

            double sum = 0;
            Console.WriteLine("\nAverage grade for each program --------------------------");
            foreach (var item in result1)
            {
                Console.WriteLine($"\nProgram: {item.Key}, Total number of students : {item.Count()}");
                sum = 0;

                }
            }
        }
    }

    public class Student
    {
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public double Grade { get; set; }

        public string Program
        {
            get; set;
        }

        public static List<Student> studentList = new List<Student>
        {
            new Student(101, "Alex", 78.54, "NET"),
            new Student(102, "Ben", 89.54, "CP"),
            new Student(103, "Jane", 90.34, "CE"),
            new Student(105, "Charmaine", 43.74, "CE"),
            new Student(106, "Jessica", 25.65, "CP"),
            new Student(107, "Bapneet", 95.08, "CP"),
            new Student(108, "Henry", 54.34, "NET")
        };

        public Student(int id, string name, double grade, string program)
        {
            Id = id;
            Name = name;
            Grade = grade;
            Program = program;
        }

        // String override
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Grade: {Grade}, Program: {Program}";
        }
    }
}
