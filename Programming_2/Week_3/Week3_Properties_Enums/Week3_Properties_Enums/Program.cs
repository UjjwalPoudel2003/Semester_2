using System;

namespace Week3_Properties_Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestAccount();
            TestEnum();
        }

        static void TestAccount()
        {
            Account ac1 = new Account();

            //change value for balance variable
            //restrict the change in balance directly
            //ac1.balance = 5000.00;
            /*Console.WriteLine($"ac1.balance : {ac1.balance}");*/ //field variable
            //Balance = 400;
            Console.WriteLine($"ac1.balance : {ac1.Balance}"); //property

            //ac1.AccountNumber = 159; //private setter
            Console.WriteLine($"ac1.AccountNumber : {ac1.AccountNumber}");

            Account ac2 = new Account();
            Console.WriteLine($"ac2.AccountNumber : {ac2.AccountNumber}");

            ac1.deposit(500);
            Console.WriteLine($"ac1 : {ac1}");

            ac2.deposit(3890.50);
            Console.WriteLine($"ac2 : {ac2}");

            Account.SetRate(0.015);
            Console.WriteLine("\nAccount information after interest rate hike");
            Console.WriteLine($"ac1: {ac1}");
            Console.WriteLine($"ac2: {ac2}");
        }

        public enum Days
        {

            //by default enum value starts from 0
            //assigned in increasing order to each name
            
            //custom numbers
            None = 15, Mon = 17, Tue, Wed, Thu = 34, Fri, Sat = 2, Sun

            //each enum name must be assigned to unique int number
        }

        static void TestEnum()
        {
            Console.WriteLine("Testing Enumerations");

            Days today = Days.Tue;
            Console.WriteLine($"today : {today}");

            //no information about what day it is
            today = Days.None;
            Console.WriteLine($"today : {today}\n");

            foreach (string nm in Enum.GetNames( typeof( Days ) ) )
            {
                Console.WriteLine($"enum name : {nm}");
            }
            Console.WriteLine();

            foreach (int vl in Enum.GetValues( typeof( Days ) ))
            {
                Console.WriteLine($"enum val : {vl}");
            }
            Console.WriteLine();

            Days tomorrow = (Days) 3;
            Console.WriteLine($"tomorrow : {tomorrow}");

            tomorrow = (Days) 15;
            Console.WriteLine($"tomorrow : {tomorrow}");

            string input = "Fri";

            //converts string into Enum name
            tomorrow = (Days) Enum.Parse( typeof( Days ), "Thu");
            Console.WriteLine($"tomorrow : {tomorrow}");

            tomorrow = (Days)Enum.Parse(typeof(Days), input);
            Console.WriteLine($"tomorrow : {tomorrow}");
        }
    }

    public class Account
    {
        //class variables
        private static int serialNumber = 100;
        private static double interestRate = 0.01;

        //field variable
        private double balance;

        //property - accompany or compliment the field variables
        public double Balance
        {
            //read-only property
            //allows to read information for field variable
            get 
            { 
                return balance + (balance * interestRate); 
            }
            //set 
            //{ 
            //    balance = value; 
            //}
        }


        //Auto-implemented properties
        public int AccountNumber { get; private set; }

        public Account()
        {
            this.AccountNumber = ++serialNumber;
        }

        public static void SetRate(double updatedRate)
        {
            //change the interestRate only if the updatedRate is not more than 5%
            interestRate = updatedRate;

            //balance = updatedRate; 
            //non-static members cannot be accessed in static method
        }

        public void deposit(double amount) 
        {
            if (amount > 0 ) 
            {
                this.balance += amount;
                Console.WriteLine($"{amount:c} deposited in the account");
            }
            else
            {
                Console.WriteLine($"cannot deposit negative amount in the balance");
            }
            Console.WriteLine($"Updated Balance : {this.balance}");
            
        }

        public override string ToString()
        {
            return $"Account Number : {this.AccountNumber}       Balance : {this.Balance:c}";
        }
    }
}
