using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ujjwal_Pizza
{
    internal class Order
    {
        public string Name { get; set; }
        public long Contact { get; set; }
        public bool Preference { get; set; } // true for veg, false for non-veg
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
        public int Quantity { get; set; }
        public string Coupon { get; set; }
        public double Discount { get; set; }

        public Dictionary<string, double> Prices { get; set; }

        public Order()
        {
            this.Name = "";
            this.Contact = 0;
            this.Preference = false;
            this.Size = "Medium";
            this.Toppings = new List<string>();
            this.Quantity = 1;
            this.Coupon = "";
        }

        public Order(string name, int contact,
            string coupon, List<string> toppings,
            bool preference = false,
            string size = "Medium",
            int quantity = 1)
        {
            this.Name = name;
            this.Contact = contact;
            this.Preference = preference;
            this.Size = size;
            this.Toppings = toppings;
            this.Quantity = quantity;
            this.Coupon = coupon;
        }

        // Creating a method to calulate the toppings price
        public double CalculateToppingsPrice()
        {
            const double TOPPING_PRICE = 0.33;
            // Calculating the total toppings present in that topping array
            int totalToppings = this.Toppings.Count;

            // Topping price is 0.33
            double toppingPrice = (totalToppings + 1) * TOPPING_PRICE;

            return toppingPrice;
        }

        public double CalculatePrice()
        {
            // Creating a nested dictonary for the prices of the pizza
            Dictionary<string, Dictionary<string, double>> prices = new Dictionary<string, Dictionary<string, double>>()
            {
               { "Veg", new Dictionary<string, double>() { 
                   { "Small", 5.99 },
                   { "Medium", 7.99 },
                   { "Large", 10.99},
                   { "ExtraLarge", 13.99}
                } 
               },
                { "Non-Veg", new Dictionary<string, double>() {
                    { "Small", 6.99 },
                    { "Medium", 8.99 },
                    { "Large", 12.99 },
                    { "ExtraLarge", 15.99 }
                 } 
                }
            };

            double basePrice = 0.0;

            try
            {
                // Calculating the price of the pizza
                if (this.Preference)
                {
                    switch (this.Size)
                    {
                        case "Small":
                            basePrice = prices["Veg"]["Small"];
                            break;
                        case "Medium":
                            basePrice = prices["Veg"]["Medium"];
                            break;
                        case "Large":
                            basePrice = prices["Veg"]["Large"];
                            break;
                        case "ExtraLarge":
                            basePrice = prices["Veg"]["ExtraLarge"];
                            break;
                        default:
                            throw new ArgumentException("Invalid size for Veg pizza.");
                    }
                }
                else
                {
                    switch (this.Size)
                    {
                        case "Small":
                            basePrice = prices["Non-Veg"]["Small"];
                            break;
                        case "Medium":
                            basePrice = prices["Non-Veg"]["Medium"];
                            break;
                        case "Large":
                            basePrice = prices["Non-Veg"]["Large"];
                            break;
                        case "ExtraLarge":
                            basePrice = prices["Non-Veg"]["ExtraLarge"];
                            break;
                        default:
                            throw new ArgumentException("Invalid size for Non Veg pizza.");
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            // Calculating the price
            double totalPrice = basePrice * this.Quantity;

            // Calculating the toppings price
            double toppingPrice = this.CalculateToppingsPrice();

            // Deducting discount from the total price
            totalPrice -= this.Discount;

            return totalPrice;
        }
    }
}
