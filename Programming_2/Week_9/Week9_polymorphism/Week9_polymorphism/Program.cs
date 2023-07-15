using System;

namespace Week9_polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TestDynamicPloymorphism();
            TestInterface();
        }

        static void TestDynamicPloymorphism()
        {
            Console.WriteLine("\nBill using plan class object---------");
            Plan p1 = new Plan();
            p1.CalculateBill(40);

            Console.WriteLine("\nBill using Individual plan class object ----------------");
            p1 = new CommercialPlan();
            p1.CalculateBill(40);

            // Parent class objects does not have access to childclass members
            // when performing dynamic binding, only the properties or methods of the parent class can be accessed directly
            // p1.CalculateCommercialTax(40);

            Console.WriteLine("\nBill using Commercial plan class object ----------------");
            p1 = new IndividualPlan();
            p1.CalculateBill(40);

            // p1.CalculateIndividualTax(40);

            // dynamic binding or late binding
            // dynamic or runtime polymorphism
            // child class instance will be allocated to parent class object at the runtime

            Console.WriteLine("\nBill using CommercialPlan class object---------");
            Plan p2 = new CommercialPlan();
            p2.CalculateBill(100);

            if (p2 is CommercialPlan)
            {
                // type cast / convert parent class object to child class object to access
                // child class members
                CommercialPlan cp1 = p2 as CommercialPlan;
                cp1.CalculateCommercialTax(100);
            }

            Console.WriteLine("\nBill using IndividualPlan class object---------");
            Plan p3 = new IndividualPlan();
            p3.CalculateBill(100);

            if(p3 is IndividualPlan)
            {
                IndividualPlan ip1 = p3 as IndividualPlan;
                ip1.CalculateIndividualTax(100);
            }

            // child class objects cannot hold reference to parent class instance
            // CommercialPlan cp2 =  new Plan();
            // IndividualPlan ip2 = new Plan();


            // Siblings classes objects cannot hold reference to eachother's instance
            // CommercialPlan cp3 = new IndividualPlan();
        }

        static void TestInterface()
        {
            // Interfaces cannot be instantiated
            // ICustomerServices ics1 = new ICustomerServices();
            Account a1 = new Account("Alex", 65);
            a1.Deposit(1000);
            a1.Withdraw(500);
            a1.WeekendServices();
            a1.SpecialHourServices();
            a1.OnlineServices();

            Account a2 = new Account("Bob", 45);
            if (a2 is ICustomerServices)
            {
                a2.SpecialHourServices();
            }

        }
    }

    public class Plan
    {
        public double Rate { get; set; }

        public void CalculateBill(int units)
        {
            Console.WriteLine($"Bill amount for {units} units is {this.Rate * units:c}" +
                $" at the rate of {this.Rate:c} per unit");
        }
    }

    public class CommercialPlan : Plan
    {
        public CommercialPlan()
        {
            this.Rate = 5.0;
        }

        public void CalculateCommercialTax(int units)
        {
            Console.WriteLine($"tax amount for {units} units is {(this.Rate * units * 0.18):c}" + 
                $" at 18% tax");
        }
    } 
    
    public class IndividualPlan : Plan
    {
        public IndividualPlan()
        {
            this.Rate = 2.0;

        }

        public void CalculateIndividualTax(int units)
        {
            Console.WriteLine($"tax amount for {units} units is {(this.Rate * units * 0.13):c}" +
                               $" at 13% tax");
        }
    } // IndividualPlan ends

    // Multiple inheritance - Inherit from two parent classes
    // not allowed in C#
    // public class CustomPlan : CommercialPlan, IndividualPlan
    // {
    //     // public CustomPlan()
    //     // {
    //     //    this.Rate = 3.0;
    //     // }
    // }

    public interface ICustomerServices
    {
        void WeekendServices();
        void SpecialHourServices();
        void OnlineServices();


        // Interface methods cannot have private access modifier
        //private void WeekendServices();

        // Interface methods cannot have a body / definition
        //void WeekendServices()
        //{

        //}
    } // ICustomerServices ends

    public interface ITransactionServices
    {
        void Withdraw(double amount);
        void Deposit(double amount);
    } // ITransactionServices ends

    public class Consumer
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Consumer(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age : {this.Age}";
        }
    } // Consumer ends

    // Account class inhertis Consumer class and implements ICustomerServices and ITransactionServices
    // Only one class can be inherited
    // Multiple interfaces can be implemented
    public class Account : Consumer, ICustomerServices, ITransactionServices
    {
        public double Balance { get; set; }

        public Account(string name, int age) : base(name, age)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $", Balance : {this.Balance:c}";
        }

        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                this.Balance -= amount;
                Console.WriteLine($"Amount {amount:c} withdrawn successfully from {this.Name}'s account. \n" + 
                    $"Updated balance : {this.Balance:c}");
            }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
                Console.WriteLine($"Amount {amount:c} deposited successfully to {this.Name}'s account. \n" +
                                       $"Updated balance : {this.Balance:c}");
            }
        }

        public void WeekendServices()
        {
            Console.WriteLine($"Weekend Services are availabe on saturday and sunday through 123-123-1234 or through chat on our website");
        }

        public void SpecialHourServices()
        {
            if (this.Age >= 60)
            {
                Console.WriteLine($"Special hour services are available from 8-9am on weekdays.");
            }
            else
            {
                Console.WriteLine($"Special hour services are only availabe to senior citizens.");
            }
        }

        public void OnlineServices()
        {
            Console.WriteLine($"Weekend Services are available 24x7 through" + 
                $"123-123-1234 or through chat on our website");
        }
    } // Account ends
} // namespace ends
