using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Intro
{
    internal class Program
    {
        //static keyword allows to call Main method without creating object of the class
        public static void Main(string[] args)
        {
            //testClasses();
            testList();

        }//Main ends

        public static void testClasses()
        {
            //create an object of a class
            //object - instance of a class
            Bird pegion = new Bird();

            Console.WriteLine($"Pegion : {pegion}");

            //dot operator or membership operator
            pegion.name = "sudarshan";
            pegion.age = 4;
            //Error : color is not public
            //pegion.color = "gray";

            Console.WriteLine($"Pegion : Name - {pegion.name}, Age - {pegion.age}");
            Console.WriteLine($"Pegion.ToString() : {pegion.ToString()}");
            Console.WriteLine($"Pegion : {pegion}");

            //will call default constructor
            Bird sparrow = new Bird();
            sparrow.name = "Prashant";
            sparrow.age = 5;

            //will call parameterized constructor
            Bird myGoose = new Bird("Divya", 7, "Green and Purple");
            Console.WriteLine($"myGoose : {myGoose}");

            //Console.WriteLine($"color of Goose : {myGoose.color}");

            Console.WriteLine($"age of Goose : {myGoose.age}");

            myGoose.age = 2;
            Console.WriteLine($"age of Goose : {myGoose.age}");

            Bird crow = new Bird("Black", 3, "JuJu");
            Console.WriteLine($"crow : {crow}");

            Bird parrot = new Bird("Sally", "Green");
            Console.WriteLine($"parrot : {parrot}");

            Console.WriteLine("Before making friends--------------------");
            Console.WriteLine($"sparrow : {sparrow}");
            Console.WriteLine($"pegion : {pegion}");

            pegion.MakeFriends(sparrow);

            Console.WriteLine("After making friends--------------------");
            Console.WriteLine($"sparrow : {sparrow}");
            Console.WriteLine($"pegion : {pegion}");

            //Bird robin;

            //if (robin == null)
            //{
            //    Console.WriteLine("No memory initialized for robin");
            //}
            //else
            //{
            //    Console.WriteLine("Memory is initialized for robin");
            //}

            Console.WriteLine("---------------------Week 2 -------------------");

            Bird robin = new Bird("Robin", 3, "Red Orange");
            Console.WriteLine($"Robin : {robin}");

            robin.MakeFriends(sparrow);
            //sparrow.MakeFriends(robin);

            Console.WriteLine($"Robin : {robin}");
            Console.WriteLine($"Sparrow : {sparrow}");

            //Error - because color attribute is not marked as public
            //robin.color = "green";


            //pegion.MakeFriends(robin);

            //Error - cannot call static method with object name
            //pegion.Fight(sparrow);

            //use the class name to call the static method
            Bird.Fight(sparrow);

            //cannot use object name to access class variables (static attributes)
            //pegion.storeName = "PetStore";

            //use class name to access class variables (static attributes)
            Bird.storeName = "COMP123 Pet Store";

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Pegion : {pegion}");
            Console.WriteLine($"sparrow : {sparrow}");
            Console.WriteLine($"myGoose : {myGoose}");
            Console.WriteLine($"robin : {robin}");
            Console.WriteLine($"crow : {crow}");
            Console.WriteLine($"parrot : {parrot}");
            Console.WriteLine("--------------------------------");

            Bird.storeName = "Centennial Bird Store";

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Pegion : {pegion}");
            Console.WriteLine($"sparrow : {sparrow}");
            Console.WriteLine($"myGoose : {myGoose}");
            Console.WriteLine($"robin : {robin}");
            Console.WriteLine($"crow : {crow}");
            Console.WriteLine($"parrot : {parrot}");
            Console.WriteLine("--------------------------------");

            //pegion.gender = "";
            //sparrow.gender = "female";
            //myGoose.gender = "Male";
            //robin.gender = "Currently Unknown";
            pegion.gender = Gender.None;
            sparrow.gender = Gender.Female;
            myGoose.gender = Gender.Male;
            robin.gender = Gender.NoDisclosure;
            crow.gender = Gender.LGBTQ2;

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Pegion : {pegion.gender}");
            Console.WriteLine($"sparrow : {sparrow.gender}");
            Console.WriteLine($"myGoose : {myGoose.gender}");
            Console.WriteLine($"robin : {robin}");
            Console.WriteLine($"crow : {crow}");
            Console.WriteLine($"parrot : {parrot}");
            Console.WriteLine("--------------------------------");
        }

        public static void testList()
        {
            Console.WriteLine("Working with lists");
            //create a list
            List <int> numbers = new List<int>(); //creates an empty list
            numbers.Add(30);
            numbers.Add(35);

            Console.WriteLine($"numbers: {numbers}");

            List <int> primeNumbers = new List<int>() {1, 3, 5, 7, 9, 11, 13 };
            primeNumbers.Add(17);
            primeNumbers.Add(19);
            Console.WriteLine($"numbers: {string.Join(",", primeNumbers)}");
            Console.WriteLine($"primeNumbers");
            Console.WriteLine($"number of elements in primeNUMBERS: {primeNumbers}");

            List <Bird> allBirds = new List<Bird>();
            allBirds.Add(new Bird("Twinky", 4, "yellow"));

            Bird friday = new Bird("Friday", 2, "Green");
            friday.gender = Gender.Female;
            allBirds.Add(friday );

            Bird vic = new Bird("Vikstar123", 5, "Brown");
            vic.gender = Gender.Male;
            vic.MakeFriends(friday);
            allBirds.Add (vic );

            foreach(Bird eachBird in allBirds)
            {
                Console.WriteLine($"{eachBird}");
            }

            allBirds.Remove(friday);

            if (allBirds.Contains(vic))
            {
                Console.WriteLine($"{vic.name} is present in the list");
            }
            else
            {
                Console.WriteLine($"{vic.name} is NOT present in the list");
            }

        }
    }//Program ends

    public enum Gender
    {
          None ,Female, Male, LGBTQ2, NoDisclosure
    }

    //class - user-defined data type or custom data type
    //encapslation - grouping the attributes and behaviour under one block
    //reusability
    //security
    class Bird
    {
        //attributes represented using variable/properties

        // field variables - non-static atributes
        // have different values for different objects stored in different memory location

        public int birdID;
        public string name;
        public int age;
        //public string gender;
        public Gender gender; 

        //internal access by default if not access specifier is used
        string color;
        //private string color;

        //creating an object of a Bird class to represent the friend
        //so that all the properties of a Bird can be associated with friend
        public Bird friend;

        //public string friendName;
        //public int friendAge;

        // class variables - static attributes
        // have same values for all objects stored in shared memory location
        public static string storeName;
        public static int birdCounter = 50;


        //constructor - creates object of class by initializing (default) values to attributes
        //same name as class name
        //called when the object is created
        public Bird()
        {
            //default constructor
            //Console.WriteLine("Constructor called");
            this.name = "Unknown";
            this.age = 0;
            this.color = "Unknown";
            //will result into infinite call of constructor
            //this.friend = new Bird();

            //increase the birdCounter
            //birdCounter++;
            ////assign the current value of birdCounter as birdID for current object
            //this.birdID = birdCounter;

            this.birdID = ++birdCounter;
        }

        //constructor overloading
        public Bird(string nm, int ag, string clr)
        {
            //parameterized consructor
            //Console.WriteLine("Constructor with 3 parameters called");
            this.name = nm;
            this.age = ag;
            this.color = clr;
            //this.friend = new Bird();

            this.birdID = ++birdCounter;
        }

        public Bird(string name, string color)
        {
            //Console.WriteLine("Constructor with 2 parameters called");
            this.name = name;
            this.color = color;
            this.age = 1;
            //this.friend = new Bird();

            this.birdID = ++birdCounter;
        }

        //methods represents behavior
        //public static void MakeFriends(Bird newFriend)
        public void MakeFriends(Bird newFriend)
        {
            //this keyword represents the object using which the method is called

            //assign sparrow as friend to robin
            this.friend = newFriend;

            //assign robin as friend to sparrow
            newFriend.friend = this;

            Console.WriteLine($"{this.name} is now friends with {newFriend.name}");
            //recursive call
            //newFriend.MakeFriends(this);
        }


        //static method
        //it cannot use this keyword within method
        //it cannot be called with class object
        //have to call such a method with class name
        public static void Fight(Bird nemesis)
        {
            Console.WriteLine($"{nemesis.name} is fighting with another bird");
        }

        public override string ToString()
        {
            //return base.ToString();

            //cannot access static attribute (class variables) using this keyword

            return $"StoreName : {Bird.storeName} ----" +
                $" birdID = {this.birdID}" +
                $" birdCounter : {Bird.birdCounter}" +
                $" Name = {this.name}, " +
                $"Age = {this.age}, " +
                $"Gender = {this.gender}," + 
                $"Color = {this.color}, " +
                $"Friend = {(this.friend == null ? "None" : this.friend.name)}";
            //ternary operator ?:
        }

        //public int testMethod()
        //{
        //    return 4;
        //}
    }

}//namespace ends
