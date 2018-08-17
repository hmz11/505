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

        bool choice = true; //判断电路类型
        double R1 = 0;
        double R2 = 0;
        double R3 = 0;
        double R4 = 0;
        double vol = 0;
        double res = 0;                                                                 //结果


        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("欢迎，请输入电阻电压值并选择电路");
        }


        public void Result(bool choice)                                                 //结果函数
        {
                                                                                        //flag判断是否为无效输入
            var flag = CheckInput();
            if (flag == false)
            {
                res = 0;
                return;                                                                 //如果出错结果保持为0
            }                                                                                            
            usecalculate(choice);                                                       //输入合法调用计算函数 
        }
                                                                                        //调用计算函数
        private void usecalculate(bool choice)
        {
            Cal result = new Cal();
            res = result.Calculate(vol, R1, R2, R3, R4, choice);
        }
                                                                                        //判断输入是否有效
        private bool CheckInput()
        {
            var flag = true;
            if (R1 <= 0 || R2 <= 0 || R3 <= 0 || R4 <= 0|| vol <= 0)
            {
                MessageBox.Show("输入无效，电阻与电压不可为0，请重新检查输入！");
                flag = false;
            }
            return flag;
        }

        private void button1_Click(object sender, EventArgs e)                              //选择电路1
        {
            choice= true;
            choose();
        }
                
        private void button2_Click(object sender, EventArgs e)                           //选择电路2
        {
            choice = false;
            choose();                                       
        }
        private void choose()
        {            
                Result(choice);
                textBox5.Text = res.ToString("f3");  //保留3位有效数字
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
 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox1.Text;
            InputOk(e, str);
        }
    
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox2.Text;
            InputOk(e, str);
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox3.Text;
            InputOk(e, str);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox4.Text;
            InputOk(e, str);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = this.textBox6.Text;
            InputOk(e, str);
        }

        private static void InputOk(KeyPressEventArgs e, string str)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';                                     //允许输入数字
            if (e.KeyChar == (char)8)                                                           //允许输入回退键
            {
                e.Handled = false;

            }
            if (e.KeyChar == (char)46)
            {
                if (str == "")                                                                  //第一个不允许输入小数点
                {
                    e.Handled = true;
                    return;
                }
                else
                {                                                                               //小数点不允许出现2次
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
