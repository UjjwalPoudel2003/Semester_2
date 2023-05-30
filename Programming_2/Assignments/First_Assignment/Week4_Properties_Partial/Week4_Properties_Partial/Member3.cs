using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Properties_Partial
{
    internal class Member3
    {
    }

    //work from member3
    public partial class Student
    {
        public override string ToString()
        {
            return $"Student Details : \nStudent ID: {this.studentID}\nName: {this.Name}\nAddress: {this.Address}";
        }
    }
}
