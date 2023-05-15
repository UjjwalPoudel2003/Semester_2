using System;

namespace firstClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an object of a class
            //object - is also an instance of a class

            Bird pegion = new Bird();

            Console.WriteLine($"Pegion : {pegion}");
            //dot operator or membership operator
            pegion.name = "jishan";
            pegion.age = 1;
            // Error: color is not public
            // pegion.color = "gray";
            Console.WriteLine($"Pegion : Name - {pegion.name}, Age - {pegion.age}");
            Console.WriteLine($"Pegion ToString : {pegion.ToString()}");
            Console.WriteLine($"Pegion : {pegion}");

            Bird sparrow = new Bird();
            sparrow.name = "winry";
            sparrow.age = 3;

            //will call parameterized constructor
            Bird parrot = new Bird("maverik", 1, "green");
            Console.WriteLine($"My parrot: {parrot}");
            //Console.WriteLine($"Color of my parrot : {parrot.color}");

            //initilizing the age of my parrot
            //assigning new value
            parrot.age = 4;
            parrot.name = "modified maverick";
            Console.WriteLine($"Age of my parrot : {parrot.age}, Name of my parrot : {parrot.name}");

            Bird crow = new Bird("chopper",4 , "white");
            Console.WriteLine(crow);

            Bird goose = new Bird("slicer", "gray");
            Console.WriteLine(goose);

            Console.WriteLine("This is before making friends");
            Console.WriteLine($"sparrow: {sparrow}");

            Console.WriteLine("This is after making friends");
            pegion.MakeFriends(sparrow);

        }
    }

    //class - user-defined data type
    public class Bird
    {
        //attributes
        public string name;
        public int age;
        string color;
        public Bird friend;

        //constructor - creates object of class by initilizing (default) values to attributes
        //same name as class name
        //called when the object is created
        public Bird()
        {
            //default constuctor
            Console.WriteLine("Constructor is called");
            this.name = "Unknown";
            this.age = 0;
            this.color = "Unknown";
            //this.friend = new Bird();
        }

        //constructor overloading
        public Bird(string nm, int ag, string clr)
        {
            //parameterized constructer
            Console.WriteLine("Constructor with 3 parameters called");
            this.name = nm;
            this.age = ag;
            this.color = clr;
            //this.friend = new Bird();
        }

        //constructor overloading
        public Bird(string name, string color)
        {
            //parameterized constructor but adding age 1 as default
            Console.WriteLine("Constructor with 2 parameters called");
            this.name = name;
            this.age = 1;
            this.color = color;
            //this.friend = new Bird();
        }

        //methods - it represents behavious

        public void MakeFriends(Bird newFriend)
        {
            this.friend = newFriend;
            Console.WriteLine($"{this.name} and {newFriend.name} are now friends");
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"Name - {this.name}, age - {this.age}, color - {this.color}, Friend = {(this.friend == null ? "None" : this.friend.name)}";
        }
    }
}
