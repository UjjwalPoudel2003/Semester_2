using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_10_GUI
{
    public partial class Form1 : Form
    {
        // responsible to identify the behaviour/events of GUI controls
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProvince_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Name.Text))
                {
                    this.lblName.Text = "Req Name";
                }
                else
                {
                    this.lblName.Text = this.Name.Text;
                }

                if (string.IsNullOrEmpty(this.Age.Text))
                {
                    this.lblAge.Text = "Req Age";
                }
                else
                {
                    int age = Convert.ToInt32(this.Age.Text);
                    if (age < 18)
                    {
                        this.lblAge.Text = "Uneligible";
                    }
                    else
                    {
                        this.lblAge.Text = this.Age.Text;
                    }
                }
            }

            catch (FormatException ex)
            {
                this.lblAge.Text = "Invalid Age";
                Console.WriteLine($"{ex}");
            }
            
            catch (Exception ex)
            {
                this.lblAge.Text = "Won't Process";
                Console.WriteLine($"{ex}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
