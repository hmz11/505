using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Cal
    {
        double vol = 0;
        double M1 = 0;
        double M2 = 0;
        double M3 = 0;
        double M4 = 0;
        double I = 0;
        bool Check = true;
        //主面板需要引用的函数
        public double Calculate(double v, double r1, double r2, double r3, double r4, bool check)
        {
            M1 = r1;
            M2 = r2;
            M3 = r3;
            M4 = r4;
            vol = v;
            Check = check;
            if (Check == true)
            {
                I = Current(vol, Calculate1(M1, M2, M3, M4));
                return I;
            }
            else
            {
                I = Current(vol, Calculate2(M1, M2, M3, M4));
                return I;
            }
        }
        //电流算法
        public double Current(double V, double R)
        {
           // double I, V, R;
            I = V / R;
            return I;
        }

        //并联算法
        public double Parallel(double R1, double R2)
        {
            double sumR, mulR, R;
            sumR = R1 + R2;
            mulR = R1 * R2;
            R = mulR / sumR;
            return R;
        }

        //计算"delta"型到"Y"型的等效转换
        public double Equ1(double R1, double R2, double R3)
        {
            double R;
            return R = R1 * R2 * R3 / (R1 + R2 + R3);
        }

        //计算"Y"型到"delta"型的等效转换
        public double Equ2(double R1, double R2, double R3)
        {
            double R;
            return R = R1 * R2 + R2 * R3 + R3 * R1;
        }

        //计算电路一的总电阻，使用Y到delta的计算方法
        public double Calculate1(double R1, double R2, double R3, double R4)
        {
            double equR1, equR2, r;
            equR1 = Equ2(M1, M2, M3) / M2;
            equR2 = Equ2(M1, M2, M3) / M1;
            r = Parallel(Parallel(equR2, equR2), R4);
            return r;
        }
        //计算电路二的总电阻，使用delta到Y的计算方法
        public double Calculate2(double R1, double R2, double R3, double R4)
        {
            double equR1, equR2, equR3, r;
            equR1 = Equ1(M1, M2, M3) / M2;
            equR2 = Equ1(M1, M2, M3) / M1;
            equR3 = Equ1(M1, M2, M3) / M3;
            r = equR1 + Parallel(equR2, equR3 + M4);
            return r;
        }

    }
}
