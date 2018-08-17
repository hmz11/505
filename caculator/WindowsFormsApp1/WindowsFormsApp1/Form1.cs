using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        bool check = true; //判断电路类型
        double R1 = 0;
        double R2 = 0;
        double R3 = 0;
        double R4 = 0;
        double vol = 0;
        double res = 0;                                                                 //结果
        

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("请输入电阻电压值并选择电路");
        }
     

        public void Result (bool check)                                                 //结果函数
        {
            bool flag = true;                                                           //flag判断是否为无效输入

            if(R1 <=0||R2<=0 || R3<=0 || R4 <= 0)
            {
                MessageBox.Show("输入无效，电阻不可为0或负数，请重新检查输入！");
                flag = false;
            }

            if(vol <= 0)
            {
                MessageBox.Show("输入无效，电压不可为0或负数，请重新检查输入！");
                flag = false;
                
            }
                                                                                     //如果输入合法
            if (check==true&&flag==true)
            {
                res = 0;
                                                                                     //调用计算函数得出结果I
                Cal result = new Cal();                                     
                res = result.Calculate(vol, R1, R2, R3, R4, check);           
            }

            if (check == false && flag == true)
            {
                Cal result = new Cal();
                res = result.Calculate(vol, R1, R2, R3, R4, check);
            }

            if(flag==false)
            {
                res = 0;                                                               //如果出错结果保持为0
            }
        }

        private void button1_Click(object sender, EventArgs e)                         //选择电路1
        {
            check = true;
            Result(check);
            textBox5.Text = res.ToString("f3"); 
        }

        private void button2_Click(object sender, EventArgs e)                           //选择电路2
        {
            
            check = false;
            Result(check);
            textBox5.Text = res.ToString("f3");                                           //保留3位有效数字
        }


        //************下为输入电阻和电压值以及键盘录入规则*************

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            R1 = double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            R2 = double.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            R3 = double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            R4 = double.Parse(textBox4.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            vol = double.Parse(textBox6.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox1.Text;
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)46)
            {
                if (str == "") //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                { //小数点不允许出现2次
                    foreach (char ch in str)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = false;
                }
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox2.Text;
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)46)
            {
                if (str == "") //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                { //小数点不允许出现2次
                    foreach (char ch in str)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = false;
                }
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox3.Text;
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)46)
            {
                if (str == "") //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                { //小数点不允许出现2次
                    foreach (char ch in str)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = false;
                }
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox4.Text;
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)46)
            {
                if (str == "") //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                { //小数点不允许出现2次
                    foreach (char ch in str)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = false;
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox6.Text;
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)46)
            {
                if (str == "") //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                { //小数点不允许出现2次
                    foreach (char ch in str)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = false;
                }
            }
        }

    }
}
