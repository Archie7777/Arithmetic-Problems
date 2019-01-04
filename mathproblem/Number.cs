//------------------------------------------
//说明：数字类，整数分母为1
//方法：打印分数；分数与分数的运算符重载
//规则：
//      1.允许分子分母能够约分，但打印出的分数不允许分子分母能继续约分
//      2.允许分子为1，但打印时打印整数
//      3.允许参与运算的对象为空，若参与运算的对象有空对象，则返回值为空值
//      4.若存在除零现象发生，不抛出异常，但返回空值
//      5.不允许创建的对象的分母为0，若创建时输入的分母为0，则抛出异常
//------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathproblem
{
    class Number: Component
    {
        public Number(int numerator, int denominator = 1)
        {
            if (denominator == 0)
            {
                DivideByZeroException e = new DivideByZeroException();
                throw (e);
            }
            int gcd = Get_gcd(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            this.denominator = denominator;
            this.numerator = numerator;
        }

        public override void Print()
        {
            int gcd = Get_gcd(numerator, denominator);
            int nu = numerator / gcd;
            int de = denominator / gcd;
            if (de == 1) Console.Write("{0} ", nu);
            else Console.Write("{0}/{1} ", numerator, denominator);
        }

        public static Number operator +(Number a, Number b)
        {
            if (a == null || b == null) return null;
            int lcm = Get_lcm(a.denominator, b.denominator);
            int nu1 = a.numerator * (lcm / a.denominator);
            int nu2 = b.numerator * (lcm / b.denominator);
            Number c = new Number(nu1 + nu2, lcm);
            return c;
        }
        public static Number operator -(Number a, Number b)
        {
            if (a == null || b == null) return null;
            int lcm = Get_lcm(a.denominator, b.denominator);
            int nu1 = a.numerator * (lcm / a.denominator);
            int nu2 = b.numerator * (lcm / b.denominator);
            Number c = new Number(nu1 - nu2, lcm);
            return c;
        }
        public static Number operator *(Number a, Number b)
        {
            if (a == null || b == null) return null;
            int nu = a.numerator * b.numerator;
            int de = a.denominator * b.denominator;
            Number c = new Number(nu, de);
            return c;
        }
        public static Number operator /(Number a, Number b)
        {
            if (a == null || b == null) return null;
            if (b.numerator == 0)
            {
                return null;
            }
            int nu = a.numerator * b.denominator;
            int de = a.denominator * b.numerator;
            Number c = new Number(nu, de);
            return c;
        }
        public static Number operator ^(Number a, Number b)
        {
            if (a == null || b == null) return null;
            Number c = new Number(1);
            for (int i = 0; i < b.numerator / b.denominator; i++)
            {
                c *= a;
            }
            return c;
        }


        private int denominator;
        private int numerator;

        private static int Get_gcd(int a, int b)
        {
            return a % b != 0 ? Get_gcd(b, a % b) : b;
        }

        private static int Get_lcm(int a, int b)
        {
            return (a * b) / Get_gcd(a, b);
        }
    }
}
