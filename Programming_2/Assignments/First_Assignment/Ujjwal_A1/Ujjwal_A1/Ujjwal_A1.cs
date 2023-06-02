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
            // Create a Purchase object with ProductCategory.Grocery and quantity of 5
            Purchase purchase1 = new Purchase(ProductCategory.Grocery, 5);
            Console.WriteLine($"{purchase1}\n");

            // Create a Purchase object with ProductCategory.Electronics and quantity of 3
            Purchase purchase2 = new Purchase(ProductCategory.Electronics, 3);
            Console.WriteLine($"{purchase2}\n");

            // Calculate the cost of purchase2
            purchase2.CalculateCost();

            // Test case without the quantity, test failed default constructor not working
            //Purchase purchase3 = new Purchase(ProductCategory.Beverages);
            //Console.WriteLine($"{purchase3}\n");

            // Another Test case without the quantity, test failed default constructor not working
            //Purchase purchase4 = new Purchase(ProductCategory.CleaningSupplies);
            //Console.WriteLine($"{purchase4}\n");

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
        private static int PURCHASE_ID = 1;
        private int Quantities;
        private ProductCategory Category;
        private double Cost;

        public Purchase(ProductCategory category, int quantities)
        {
            Category = category; 
            Quantities = quantities;
            Cost = 0;
            PURCHASE_ID++;
            CalculateCost();
        }
        
        public void CalculateCost()
        {
            switch (Category)
            {
                case ProductCategory.Grocery:
                    this.Cost = 1 * this.Quantities;
                    this.Cost =  this.Cost - (this.Cost * 0.2);
                    this.Cost = this.Cost + (this.Cost * 0.13);
                    break;

                case ProductCategory.Electronics:
                    this.Cost = 15 * this.Quantities;
                    this.Cost = this.Cost - (this.Cost * 0.1);
                    this.Cost = this.Cost + (this.Cost * 0.13);
                    break;

                case ProductCategory.Beverages:
                    this.Cost = 10 * this.Quantities;
                    this.Cost = this.Cost - (this.Cost * 0.05);
                    this.Cost = this.Cost + (this.Cost * 0.13);
                    break;

                case ProductCategory.CleaningSupplies:
                    this.Cost = 5 * this.Quantities;
                    this.Cost = this.Cost - (this.Cost * 0.15);
                    this.Cost = this.Cost + (this.Cost * 0.13);
                    break;

                case ProductCategory.Miscellaneous:
                    this.Cost = 20 * this.Quantities;
                    this.Cost = this.Cost + (this.Cost * 0.13);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Purchase ID: {PURCHASE_ID}\nItem: {Category}\nQuantity: {this.Quantities}\nTotal: {this.Cost}";
        }
    }
}
