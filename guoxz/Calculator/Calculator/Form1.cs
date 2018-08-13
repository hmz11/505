using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;
        bool check = false;
        string sign;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(check==true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                textBox1.Text = "";
                check = false;
            }
            textBox1.Text += "0";
            if(sign=="/")
            {
                textBox1.Clear();
                MessageBox.Show("错误" );
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "x^2";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "sqrt";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            check = true;
            num2 = double.Parse(textBox1.Text);
            sign = "1/x";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            switch(sign)
            {
                case "+": num1 = num2 + double.Parse(textBox1.Text); break;
                case "-": num1 = num2 - double.Parse(textBox1.Text); break;
                case "*": num1 = num2 * double.Parse(textBox1.Text); break;
                case "/": num1 = num2 / double.Parse(textBox1.Text); break;
                case "1/x": num1 = 1 / num2; break;
                case "x^2": num1 = num2 * num2; break;
                case "sqrt": num1 = Math.Sqrt(num2);break;
            }
            textBox1.Text = num1 + "";
            check = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            num2 = 0;
        }
    }
}
