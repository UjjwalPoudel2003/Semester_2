using System;
using System.Diagnostics;
using System.Runtime.Remoting;

namespace xcptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestOperatorOverloading();
            TestException();
        }

        static void TestOperatorOverloading()
        {
            Time t1 = new Time(6, 34, 45);
            Time t2 = new Time(10, 29, 12);
            Time t3 = new Time(10, 29, 12);
            //referencing an existing object t2 under the name t4
            //both t2 and t4 are pointing to the same object and same memory location
            Time t4 = t2;

            Console.WriteLine($"t1 : {t1}");
            Console.WriteLine($"t2 : {t2}");
            Console.WriteLine($"t3 : {t3}");
            Console.WriteLine($"t4 : {t4}");


            Console.WriteLine($"\n--------------------------------");
            Console.WriteLine($"t1 == t2 : {t1 == t2} : {((t1 == t2) ? "same objects" : "different objects")}");
            Console.WriteLine($"t1 == t3 : {t1 == t3} : {((t1 == t3) ? "same objects" : "different objects")}");
            Console.WriteLine($"t2 == t3 : {t2 == t3} : {((t2 == t3) ? "same objects" : "different objects")}");

            Console.WriteLine($"\n--------------------------------");
            Console.WriteLine($"t2 == t4 : {t2 == t4} : {((t2 == t4) ? "same objects" : "different objects")}");
            Console.WriteLine($"t4 == t3 : {t4 == t3} : {((t4 == t3) ? "same objects" : "different objects")}");
            Console.WriteLine($"t1 == t4 : {t1 == t4} : {((t1 == t4) ? "same objects" : "different objects")}");

            Console.WriteLine($"\n--------------------------------");
            Console.WriteLine($"t2 : {t2}");
            Console.WriteLine($"t4 : {t4}");

            t4.Minutes = 55;
            t2.Seconds = 23;

            Console.WriteLine($"\n---------- After Change ------------");
            Console.WriteLine($"t2 : {t2}");
            Console.WriteLine($"t4 : {t4}");

            Console.WriteLine($"\n--------- After Changing + operator -----------");
            Time t5 = t1 + t2;
            Console.WriteLine($"t1 + t2 = t5 : {t5}");
            Time t6 = t1 + t3;
            Console.WriteLine($"t1 + t3 = t6 : {t6}");
            Time t7 = t2 + t3;
            Console.WriteLine($"t2 + t3 = t7 : {t7}");
            Time t8 = t7 + t6;
            Console.WriteLine($"t7 + t6 = t8 : {t8}");
        }

        static void TestException()
        {
            int a, b, c;
            a = 5;
            b = 0;

            //create array of integers below 10
            int[] ints = { 1, 2, 3, 4 };



            try //containts statement that will likely generate errors
            {

                Console.Write("Enter a number a: ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter a number b: ");
                b = Convert.ToInt32(Console.ReadLine());

                c = a / b;
                //ints[2] += c;
                //ints[7] += c;

                //foreach (int i in ints)
                //{
                //    Console.WriteLine(i);
                //}

                if (b % 2 != 0)
                {
                    //odd number, generate OddNumberException
                    throw new OddNumberException();
                }

                Console.WriteLine($" {a} / {b} = {c}");

            }
            //try cannot be used alone, must be used either with catch or finally

            catch (DivideByZeroException Dbze)
            {
                Console.WriteLine($"Cannot perform division by 0: {Dbze}");
            }

            catch (FormatException Fe)
            {
                Console.WriteLine($"Can only use integers: {Fe.Message}");
            }

            catch (OddNumberException one)
            {
                Console.WriteLine($"OddNumberException: {one.Message}");
            }

            //general exception class
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            finally //always executed
            {
                Console.WriteLine("\nFinally block executed, try and catch completed");
            }

            Console.WriteLine("\nDivision Completed");
        }

        static int PerformDivision(int x, int y)
        {
            int z = 0;

            try
            {
                z = x / y;
            }

            catch(DivideByZeroException Dbze)
            {
                Console.WriteLine($"Cannot perform division by 0: {Dbze}");
            }

            catch (FormatException Fe)
            {
                Console.WriteLine($"Can only use integers: {Fe.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            finally //always executed
            {
                Console.WriteLine("\nFinally block executed, try and catch completed");
            }   

            return z;
        }

    }

    //Inherit from Exception class
    //to define a custom exception class
    class OddNumberException : Exception
    {
        //must define message property to give description of Exception
        public override string Message =>
            "This scientific calculation doesn't accept odd numbers.";
    }

    class Time
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Time(int h, int m, int s)
        {
            this.Hour = h;
            this.Minutes = m;
            this.Seconds = s;
        }

        public override string ToString()
        {
            return $"{this.Hour} : {this.Minutes} : {this.Seconds}";
        }

        //overloading the == operator
        public static bool operator !=(Time firstObj, Time secondObj)
        {
            bool result = false;

            //if the Hour value and Minutes value for both the objects are same
            //objects are same
            if ((firstObj.Hour != secondObj.Hour && firstObj.Minutes != secondObj.Minutes))
            {
                return result;
            }
            //same object
            result = true;

            return result;
        }

        public static bool operator ==(Time firstObj, Time secondObj)
        {
            bool result = false;

            //if the Hour value and Minutes value for both the objects are same
            //objects are same
            if ((firstObj.Hour == secondObj.Hour && firstObj.Minutes == secondObj.Minutes))
            {
                return result;
            }
            //same object
            result = true;

            return result;
        }

        public static Time operator +(Time firstObj, Time secondObj)
        {
            int h = firstObj.Hour + secondObj.Hour;
            int m = firstObj.Minutes + secondObj.Minutes;
            int s = firstObj.Seconds + secondObj.Seconds;

            //perform necessary calculations for valid time
            if (s > 59)
            {
                m += 1;
                s -= 60;
            }

            if (m > 59)
            {
                h += 1;
                m -= 60;
            }

            if (h > 24)
            {
                h -= 24;
            }

            return new Time(h, m, s);
        }
    }
}
