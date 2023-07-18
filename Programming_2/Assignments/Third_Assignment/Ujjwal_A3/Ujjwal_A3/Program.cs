using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace Ujjwal_A3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestAccounts();
        } // end of Main method

        static void TestAccounts()
        {
            Bank.AccountList.Add(new SavingsAccount("S647", "Alex Du", 222290192, 4783.98));
            Bank.AccountList.Add(new ChequingAccount("C576", "Dale Stayne", 333312312, 12894.56));

            Bank.showAll();

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $500.00 from the following account");
            Console.WriteLine(Bank.AccountList[0].ToString());
            Bank.AccountList[0].withdraw(500.00);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $-250.00 to the following account");
            Console.WriteLine(Bank.AccountList[1].ToString());
            Bank.AccountList[1].deposit(-250.00);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $10000.00 to the following account");
            Console.WriteLine(Bank.AccountList[2].ToString());
            Bank.AccountList[2].withdraw(10000.00);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $5000.00 to the following account");
            Console.WriteLine(Bank.AccountList[2].ToString());
            Bank.AccountList[2].deposit(5000.00);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $7300.00 to the following account");
            Console.WriteLine(Bank.AccountList[3].ToString());
            Bank.AccountList[3].deposit(7300.90);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $45000.40 from the following account");
            Console.WriteLine(Bank.AccountList[4].ToString());
            Bank.AccountList[4].withdraw(45000.40);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $37000.00 from the following account");
            Console.WriteLine(Bank.AccountList[5].ToString());
            Bank.AccountList[5].withdraw(37000);
            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Bank.showAll(67676767);
            Console.WriteLine($"{new string('-', 90)}");

            Bank.showAll();
        }
    } // end of Program class

    class Consumer
    {
        public string ID { get; }
        public string Name { get; }

        public Consumer(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.Name}";
        }
    } // end of Consumer class

    abstract class Account : Consumer
    {
        public int AccountNum { get; }

        public Account(string id, string name, int accountNum) : base(id, name)
        {
            this.AccountNum = accountNum;
        }

        abstract public void withdraw(double amount);

        abstract public void deposit(double amount);

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.Name}, Account Number: {this.AccountNum}";
        }
    }// end of Account class

    class InsufficientBalanceException : Exception
    {
        public override string Message => "Account not having enough balance to withdraw";
    } // end of InsufficientBalanceException class

    class MinimumBalanceException : Exception
    {
        public override string Message => "You must maintain mininum $3000 balance in saving account";
    } // end of MinimumBalanceException class

    class IncorrectAmountException : Exception
    {
        public override string Message => "You must provide positive number for amount to be deposited";
    } // end of IncorrectAmountException class

    class OverdraftLimitException : Exception
    {
        public override string Message => "Overdraft limit exceeded. You can only use $2000 from overdraft";
    } // end of OverdraftLimitException class

    class AccountNotFoundException : Exception
    {
        public override string Message => "Account with given number does not exist";
    } // end of AccountNotFoundException class

    class SavingsAccount : Account
    {
        public double Balance { get; set; }

        public SavingsAccount(string id, string name, int accountNum, double balance = 0) : base(id, name, accountNum)
        {
            this.Balance = balance;
        }

        public override void withdraw(double amount)
        {
            if (amount > this.Balance)
            {
                throw new InsufficientBalanceException();
            }

            if (this.Balance - amount < 3000)
            {
                throw new MinimumBalanceException();
            }

            else
            {
                this.Balance -= amount;

                // displaying the upadated balance
                Console.WriteLine($"Updated balance: {this.Balance}");
            }
        }

        public override void deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new IncorrectAmountException();
            }

            else
            {
                this.Balance += amount;

                // displaying the upadated balance
                Console.WriteLine($"Updated balance: {this.Balance}");
            }
        }

        public override string ToString()
        {
            return $"Account Number: {this.AccountNum}, Balance: {this.Balance}";
        }
    } // end of SavingsAccount class

    class ChequingAccount : Account
    {
        public double Balance { get; set; }
        public double Overdraft = 2000;

        public ChequingAccount(string id, string name, int accountNum, double balance = 0) : base(id, name, accountNum)
        {
            this.Balance = balance;
        }

        public override void withdraw(double amount)
        {
            if (amount > (this.Balance + this.Overdraft))
            {
                throw new OverdraftLimitException();
            }

            if (amount < 0)
            {
                throw new IncorrectAmountException();
            }

            else
            {
                this.Balance -= amount;

                // displaying the upadated balance
                Console.WriteLine($"Updated balance: {this.Balance}");
            }
        }

        public override void deposit(double amount)
        {
            if (amount < 0)
            {
                throw new IncorrectAmountException();
            }

            else
            {
                this.Balance += amount;

                // displaying the upadated balance
                Console.WriteLine($"Updated balance: {this.Balance}");
            }
        }

        public override string ToString()
        {
            return $"Account Number: {this.AccountNum}, Balance: {this.Balance}";
        }
    } // end of ChequingAccount class

    class Bank
    {
        public static List<Account> AccountList;

        static Bank()
        {
            AccountList = new List<Account>
            {
                new SavingsAccount("S101", "James Finch", 222210212, 3400.90),
                new SavingsAccount("S102", "Kell Forest", 222214500, 42520.32),
                new SavingsAccount("S103", "Amy Stone", 222212000, 8273.45),
                new ChequingAccount("C104", "Kaitlin Ross", 333315002, 91230.45),
                new ChequingAccount("C105", "Adem First", 333303019, 43987.67),
                new ChequingAccount("C106", "John Doe", 333358927, 34829.76)
            };
        }

        public static void showAll()
        {
            // This is the static property that will iterate through the AccountList and display all the accounts
            foreach (Account account in AccountList)
            {
                Console.WriteLine(account);
            }
        }

        public static void showAll(int accountNum)
        {
            //This is the static method will accept account number as parameter and will display details for
            //the matching account.If the matching account does not find it must raise and catch the
            //AccountNotFoundException.
            Console.WriteLine("Consumer ID\t\tName\t\t");
            foreach (Account account in AccountList)
            {
                if (account.AccountNum == accountNum)
                {
                    Console.WriteLine(account);
                }

                else
                {
                    throw new AccountNotFoundException();
                }
            }
        }
    }
}
