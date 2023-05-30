using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Ujjwal_A1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestRun();
        }

        public static void TestRun()
        {
            Purchase purchase1 = new Purchase();
            Console.WriteLine(purchase1);
        }

        public enum ProductCategory
        {
            Grocery, Electronics, Beverages, CleaningSupplies, Miscellaneous
        }

        public class Purchase
        {
            int PURCHASE_ID = 1;
            int Quantities = 1;
            ProductCategory Category;
            double Cost;

            public Purchase(ProductCategory category, int Quantities)
            {
                this.Category = category;
                this.Quantities = Quantities;
                this.Cost = 0;
                this.PURCHASE_ID++;
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
                return $"Purchase ID: {this.PURCHASE_ID}\tItem: {Category}\tQuantity: {this.Quantities}\tTotal: {this.Cost}";
            }
        }
    }
}
