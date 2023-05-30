using System;

namespace Week4_Properties_Partial
{
    internal class Member1
    {
    }

    //work from member1

    public partial class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Student()
        {
            this.Name = "Unknown";
            this.Address = "Unknown";
            this.studentID = 00;
        }
    }
}
