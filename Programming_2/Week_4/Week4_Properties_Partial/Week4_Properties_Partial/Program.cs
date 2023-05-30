using System;

namespace Week4_Properties_Partial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestProperties();
            TestPartial();
        }//main ends

        static void TestProperties()
        {
            PropertiesDemo demo1 = new PropertiesDemo();

            //cannot access private field outside the class
            //demo1.distanceKm = 500;
            //Console.WriteLine($"distanceKm : {demo1.distanceKm}");

            demo1.KM = 500;
            Console.WriteLine($"KM: {demo1.KM}");
            Console.WriteLine($"Miles: {demo1.Miles}");

            demo1.Miles = 400;
            Console.WriteLine($"KM: {demo1.KM}");
            Console.WriteLine($"Miles: {demo1.Miles}");

            //demo1.month = 50;
            demo1.Month = 5;
            Console.WriteLine($"Month : {demo1.Month}");

            demo1.Month = 24;
            Console.WriteLine($"Month : {demo1.Month}");

            demo1.Article = "May Article";

            Console.WriteLine($"\nArticle access 1 : {demo1.Article}");
            Console.WriteLine($"Article access 2 : {demo1.Article}");
            Console.WriteLine($"Article access 3 : {demo1.Article}");
            Console.WriteLine($"Article access 4 : {demo1.Article}");
            Console.WriteLine($"Article access 5 : {demo1.Article}");

            //June Article
            demo1.Article = "";
            Console.WriteLine("\nAccessing for June Article-----------");
            Console.WriteLine($"Article access 1 : {demo1.Article}");
            Console.WriteLine($"Article access 2 : {demo1.Article}");

            demo1.Article = "June Article";
            Console.WriteLine($"Article access 3 : {demo1.Article}");
            Console.WriteLine($"Article access 4 : {demo1.Article}");
            Console.WriteLine($"Article access 5 : {demo1.Article}");
            Console.WriteLine($"Article access 6 : {demo1.Article}");


        }//test Properties ends

        static void TestPartial()
        {
            Student student1 = new Student();
            student1.studentID = 100;
            student1.Name = "John";
            student1.Address = "123 Main Street";
            Console.WriteLine($"Student 1 : \n{student1}");

            student1.participattion();
            student1.submitAssignment();

            Student student2 = new Student();
            student2.studentID = 200;
            student2.Name = "Mary";
            student2.Address = "456 Main Street";
            Console.WriteLine($"\nStudent 2 : \n{student2}");

            student2.participattion();
            student2.submitAssignment();

            Student student3 = new Student();
            Console.WriteLine($"\nStudent 3 : \n{student3}");

            student3.participattion();
            student3.submitAssignment();
        }//test partial ends
    }//program ends

    class PropertiesDemo
    {
        //field variables
        private double distanceKm;
        private const double KM_TO_MILES = 1.609;
        private int month;
        private string article;
        private int numOfAccess = 0;

        //property - provides read-write access to field variable distanceKm
        public double KM {
            get { return distanceKm; }
            set { distanceKm = value; }
        }

        //Property-conversion
        public double Miles
        {
            get { return distanceKm * KM_TO_MILES; }
            set { distanceKm = value / KM_TO_MILES; }
        }

        //Property - sanity check - set
        public int Month
        {
            set
            {
                if (value < 0 || value > 12)
                {
                    Console.WriteLine($"{value} is not acceptabel value for month." + $"Enter anything between 1 to 12. \n" +
                        $"SEtting month to january (1)");

                    month = 1;
                }

                else
                {
                    month = value;
                }
            }

            get
            {
                return month;
            }
        }

        //Property-sanity check - get
        public string Article
        {
            get {
                //if (article != "" || article != null)
                if (article != "NA")
                {
                    numOfAccess++;
                    if (numOfAccess <= 3)
                    {
                        return article;
                    }

                    else
                    {
                        Console.WriteLine($"Number of access : {numOfAccess}");
                        return "Your free access is over. Please create account to keep using article.";
                    }
                }

                else
                {
                    return "Sorry the article is not published yet, please wait";
                }

                
            }
            set
            {
                if (value == "")
                {
                    article = "NA";
                }
                else
                {
                    article = value;
                    //reset the numOfAccess to 0
                    //so that user an get 3 free access to article every month
                    numOfAccess = 0;
                }
            }      
        }
    }//propertiesDemo ends
}
