using System;

namespace Ujjwal_A1
{
    internal class Program
    {
        //calling test run in the main method
        static void Main(string[] args)
        {
            TestRun();
        }

        public static void TestRun()
        {
            Console.WriteLine("Name: Ujjwal Poudel");
            Console.WriteLine("Student ID: 301284284\n");
            // Create a Purchase object with ProductCategory.Grocery and quantity of 5
            Purchase purchase1 = new Purchase(ProductCategory.Grocery, 5);
            Console.WriteLine($"{purchase1}\n");

            // Create a Purchase object with ProductCategory.Electronics and quantity of 3
            Purchase purchase2 = new Purchase(ProductCategory.Electronics, 3);
            Console.WriteLine($"{purchase2}\n");

            // Calculate the cost of purchase2
            purchase2.CalculateCost();

            //Test case without the quantity
            Purchase purchase3 = new Purchase(ProductCategory.Beverages);
            Console.WriteLine($"{purchase3}\n");

            //Another Test case without the quantity
            Purchase purchase4 = new Purchase(ProductCategory.CleaningSupplies);
            Console.WriteLine($"{purchase4}\n");

            // Create a Purchase object with ProductCategory.Miscellaneous and quantity of 1
            Purchase purchase5 = new Purchase(ProductCategory.Miscellaneous, 1);
            Console.WriteLine($"{purchase5}\n");
        }

    }

    public enum ProductCategory
    {
        Grocery, Electronics, Beverages, CleaningSupplies, Miscellaneous
    }

    public class Purchase
    {
        private int PURCHASE_ID;
        public static int purchaseIdCounter = 1;
        private int Quantities;
        private ProductCategory Category;
        private double Cost;

        public Purchase(ProductCategory category, int quantities = 1)
        {
            this.Category = category; 
            this.Quantities = quantities;
            this.Cost = 0;
            this.PURCHASE_ID = purchaseIdCounter++;
            CalculateCost();
        }

        //creating a method to calculate the cost of the purchase
        public double Calculation(int price) 
        {
            this.Cost = price * this.Quantities;
            this.Cost = this.Cost - (this.Cost * 0.1);
            this.Cost = this.Cost + (this.Cost * 0.13);
            return this.Cost;
        }
        
        public void CalculateCost()
        {
            switch (Category)
            {
                case ProductCategory.Grocery:
                    int pricePerUnit = 1;
                    Calculation(pricePerUnit);
                    break;

                case ProductCategory.Electronics:
                    pricePerUnit = 15;
                    Calculation(pricePerUnit);
                    break;

                case ProductCategory.Beverages:
                    pricePerUnit = 10;
                    Calculation(pricePerUnit);
                    break;

                case ProductCategory.CleaningSupplies:
                    pricePerUnit = 5;
                    Calculation(pricePerUnit);
                    break;

                case ProductCategory.Miscellaneous:
                    pricePerUnit = 20;
                    Calculation(pricePerUnit);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Purchase ID: {PURCHASE_ID}\nItem: {Category}\nQuantity: {this.Quantities}\nTotal: {this.Cost}";
        }
    }
}
