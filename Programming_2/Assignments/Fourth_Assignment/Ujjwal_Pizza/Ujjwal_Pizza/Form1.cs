using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ujjwal_Pizza
{
    public partial class left_panel : Form
    {
        // Creating field variables for storing coupon information
        private string SelectedCouponCode;
        private bool SelectedPreference;
        private string SelectedSize;
        private int SelectedQuantity;
        private double SelectedDiscount;
        private bool CurrentPreference;

        // Creating a list to store all the orders
        private static List<Order> orderList = new List<Order>();

        public enum PizzaSize
        {
            Small,
            Medium,
            Large,
            ExtraLarge
        }
        public left_panel()
        {
            Order order1 = new Order();
            InitializeComponent();
            this.leftValueSize.DataSource = Enum.GetNames(typeof(PizzaSize));
            this.leftValueSize.SelectedIndex = 1;
            this.leftNonVeg.Checked = true;
            this.leftQuantityValue.Text = "1";
            this.leftValueName.Text = "Go cool";
            this.leftValueContact.Text = "4375571889";

            // Resetting the right panel
            this.rightName.Text = "";
            this.rightContact.Text = "";
            this.rightPreference.Text = "";
            this.rightSize.Text = "";
            this.rightToppings.Text = "";
            this.rightQuantity.Text = "";
            this.rightCoupon.Text = "";
            this.rightDiscount.Text = "";
            this.rightTax.Text = "";
            this.rightTotal.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void leftOlives_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void leftValueName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        Order order1 = new Order();

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Creating a flag, to verify and calculate
            // If the fields are empty or not
            bool flag = false;

            int quantity = Convert.ToInt32(this.leftQuantityValue.Text);

            // Checking weather Coupon is Selected or Not
            if (this.couponSelector.Checked &&
                this.leftCouponValue.Text == this.SelectedCouponCode
                && this.CurrentPreference == this.SelectedPreference
                && this.leftValueSize.SelectedItem.ToString() == this.SelectedSize
                && quantity == this.SelectedQuantity)
            {
                // Assigning size
                order1.Size = this.leftValueSize.SelectedItem.ToString();
                this.rightSize.Text = this.leftValueSize.SelectedItem.ToString();

                // Assigning quantity
                order1.Quantity = quantity;
                this.rightQuantity.Text = quantity.ToString();

                // Assigning coupon
                order1.Coupon = this.leftCouponValue.Text;
                this.rightCoupon.Text = this.leftCouponValue.Text;

                // Assigning discount
                order1.Discount = this.SelectedDiscount;
                this.rightDiscount.Text = this.SelectedDiscount.ToString();

                // Assigning preference
                order1.Preference = this.CurrentPreference;
                if (this.CurrentPreference)
                {
                    this.rightPreference.Text = "Veg";
                }
                else
                {
                    this.rightPreference.Text = "Non-Veg";
                }
            }

            else
            {
                // Checking if veg is checked?
                if (this.leftVeg.Checked)
                {
                    order1.Preference = true;
                    this.rightPreference.Text = "Veg";
                }

                // Checking if non veg is checked?
                else if (this.leftNonVeg.Checked)
                {
                    order1.Preference = false;
                    this.rightPreference.Text = "Non-Veg";
                }

                // Assigning the Size to right panel
                this.rightSize.Text = this.leftValueSize.SelectedItem.ToString();
                order1.Size = this.leftValueSize.SelectedItem.ToString();

                // Assigning the Quantity to right panel
                this.rightQuantity.Text = this.leftQuantityValue.Text;
                order1.Quantity = Convert.ToInt32(this.leftQuantityValue.Text);

                // Assigning the Coupon to right panel
                this.rightCoupon.Text = "None";

                // Assigning the Discount to right panel
                order1.Discount = 0;
                this.rightDiscount.Text = "0";
            }

            // Assigning non empty Name to right panel
            if (String.IsNullOrEmpty(this.leftValueName.Text))
            {
                this.rightName.Text = "Required !";
                this.leftValueName.Text = "Required !";
                flag = true;
            }
            else
            {
                order1.Name = this.leftValueName.Text;
                this.rightName.Text = this.leftValueName.Text;
            }

            // Checking if contact is empty or not
            if (String.IsNullOrEmpty(leftValueContact.Text))
            {
                this.rightContact.Text = "Required !";
                this.leftValueContact.Text = "Required !";
                flag = true;
            }
            else
            {
                try
                {
                    if (!this.leftValueContact.Text.All(char.IsDigit))
                    {
                        flag = true;
                        throw new FormatException();
                    }

                    else if (this.leftValueContact.Text.Length != 10)
                    {
                        flag = true;
                        this.leftValueContact.Text = "10 Digit Req!";
                    }
                    else
                    {
                        this.rightContact.Text = leftValueContact.Text;
                        order1.Contact = Convert.ToInt64(this.leftValueContact.Text);
                    }
                }

                catch (FormatException)
                {
                    this.leftValueContact.Text = "Digit Required!";
                }
            }

            //// Assigning non empty Contact to right panel
            //if (CheckEmpty(this.leftValueContact.Text))
            //{
            //    try
            //    {
            //        if (!this.leftValueContact.Text.All(char.IsDigit)) // Gokul's Idea for digit checking
            //        {
            //            throw new FormatException();
            //        }
            //        if (this.leftValueContact.Text.Length > 10 || this.leftValueContact.Text.Length < 10)
            //        {
            //            this.leftValueContact.Text = "10 Digit Req!";
            //        }
            //        else
            //        {
            //            this.leftValueContact.Text = rightContact.Text;
            //            order1.Contact = Convert.ToInt32(this.leftValueContact.Text);
            //        }
            //    }

            //    catch (FormatException)
            //    {
            //        this.leftValueContact.Text = "Digit Required!";
            //    }
            //}

            // Checking if the toppings are selected or not
            if (this.leftOlives.Checked)
            {
                order1.Toppings.Add("Olives");
                this.rightToppings.Text += "Olives, ";
            }

            if (this.leftOnions.Checked)
            {
                order1.Toppings.Add("Onions");
                this.rightToppings.Text += "Onions, ";
            }

            if (this.leftPepper.Checked)
            {
                order1.Toppings.Add("Pepper");
                this.rightToppings.Text += "Pepper, ";
            }

            if (this.leftCheese.Checked)
            {
                order1.Toppings.Add("Cheese");
                this.rightToppings.Text += "Cheese, ";
            }

            if (this.leftSausage.Checked)
            {
                order1.Toppings.Add("Sausage");
                this.rightToppings.Text += "Sausage, ";
            }

            if (this.leftMushroom.Checked)
            {
                order1.Toppings.Add("Mushroom");
                this.rightToppings.Text += "Mushroom, ";
            }

            if (flag == true)
            {
                this.rightDiscount.Text = "Fill all the required!";
                this.rightTax.Text = "Fill all the required!";
                this.rightTotal.Text = "Fill all the required!";
            }
            else
            {
                // Finally Price is calculated
                CalculateFinalPrice();

                // Adding the order to the list
                orderList.Add(order1);
            }
        }

        private bool ConvertToint32(string text)
        {
            throw new NotImplementedException();
        }

        //// Creating a method to check if the values are empty or not
        //private bool CheckEmpty(string text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //    {
        //        this.rightName.Text = "Required !";
        //        flag = true;
        //        return false;
        //    }
        //    else
        //    {
        //        flag = false;
        //        return true;
        //    }
        //}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void leftQuantityIncrease_Click(object sender, EventArgs e)
        {
            int increament = Convert.ToInt32(this.leftQuantityValue.Text);
            if (increament < 5)
            {
                increament++;
            }
            this.leftQuantityValue.Text = increament.ToString();
        }

        private void leftQuantityDecrease_Click(object sender, EventArgs e)
        {
            int decreament = Convert.ToInt32(this.leftQuantityValue.Text);
            if (decreament > 1)
            {
                decreament--;
            }
            this.leftQuantityValue.Text = decreament.ToString();
        }

        private void couponSelector_CheckedChanged(object sender, EventArgs e)
        {
            // If the coupon is selected
            if (this.couponSelector.Checked)
            {
                // Checking if the coupon is selected or not
                using (StreamReader reader = new StreamReader("OfferCoupons.txt"))
                {
                    string dataLine;
                    bool CouponFound = false;

                    while ((dataLine = reader.ReadLine()) != null)
                    {
                        string[] data = dataLine.Split(',');
                        if (data[0] == this.leftCouponValue.Text.Trim())
                        {
                            CouponFound = true;

                            this.SelectedCouponCode = data[0];

                            bool couponPreference = Convert.ToBoolean(data[1]);
                            if (couponPreference)
                            {
                                this.leftVeg.Checked = true;
                                order1.Preference = true;
                                this.SelectedPreference = true;
                            }
                            else
                            {
                                this.leftNonVeg.Checked = true;
                                order1.Preference = false;
                                this.SelectedPreference = false;
                            }

                            this.leftValueSize.Text = data[2];
                            order1.Size = data[2];
                            this.SelectedSize = data[2];

                            this.leftQuantityValue.Text = data[3];
                            order1.Quantity = Convert.ToInt32(data[3]);
                            this.SelectedQuantity = Convert.ToInt32(data[3]);

                            order1.Discount = Convert.ToDouble(data[4]);
                            this.SelectedDiscount = Convert.ToDouble(data[4]);
                        }

                        //else
                        //{
                        //    this.leftCouponValue.Text = "Invalid Coupon!";
                        //    this.couponSelector.Checked = false;
                        //}

                        ////reader.Close();
                    }

                    if (!CouponFound)
                    {
                        this.leftCouponValue.Text = "Invalid Coupon!";
                        this.couponSelector.Checked = false;
                    }
                }
            }

            else
            {
                FieldResseter();
            }
        }

        public void FieldResseter()
        {
            // Resetting the coupon field
            this.SelectedCouponCode = null;
            this.SelectedPreference = false;
            this.SelectedSize = null;
            this.SelectedQuantity = 0;
            this.SelectedDiscount = 0;
        }

        private void leftNonVeg_CheckedChanged(object sender, EventArgs e)
        {
            if (this.leftNonVeg.Checked)
            {
                this.leftVeg.Checked = false;
                this.leftNonVeg.Checked = true;
                this.CurrentPreference = false;
            }
        }

        private void leftVeg_CheckedChanged(object sender, EventArgs e)
        {
            if (this.leftVeg.Checked)
            {
                this.leftNonVeg.Checked = false;
                this.leftVeg.Checked = true;
                this.CurrentPreference = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Resetting the left panel
            this.leftValueSize.DataSource = Enum.GetNames(typeof(PizzaSize));
            this.leftValueSize.SelectedIndex = 1;
            this.leftNonVeg.Checked = true;
            this.leftQuantityValue.Text = "1";
            this.leftValueName.Text = "Go cool";
            this.leftValueContact.Text = "4375571889";
            // Resetting the toppings
            this.leftOlives.Checked = false;
            this.leftOnions.Checked = false;
            this.leftPepper.Checked = false;
            this.leftCheese.Checked = false;
            this.leftSausage.Checked = false;
            this.leftMushroom.Checked = false;
            // Resetting the coupon
            this.couponSelector.Checked = false;
            this.leftCouponValue.Text = "";

            // Resetting the right panel
            this.rightName.Text = "";
            this.rightContact.Text = "";
            this.rightPreference.Text = "";
            this.rightSize.Text = "";
            this.rightToppings.Text = "";
            this.rightQuantity.Text = "";
            this.rightCoupon.Text = "";
            this.rightDiscount.Text = "";
            this.rightTax.Text = "";
            this.rightTotal.Text = "";

            // Resetting the coupon field
            FieldResseter();
        }

        public void CalculateFinalPrice() 
        {
            double priceWithoutTax = order1.CalculatePrice();

            double salesTax = priceWithoutTax * 0.13;
            
            double finalPrice = priceWithoutTax + salesTax;

            // Assigning the final price to the right panel
            if (salesTax < 0)
            {
                salesTax = 0;
            }
            else
            {
                salesTax = Math.Round(salesTax, 2);
            }

            if (finalPrice < 0)
            {
                finalPrice = 0;
            }
            else
            {
                finalPrice = Math.Round(finalPrice, 2);
            }

            // Assigning the tax amount to the right panel
            this.rightTax.Text = salesTax.ToString();
            this.rightTotal.Text = finalPrice.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
