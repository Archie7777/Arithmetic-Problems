﻿//------------------------------------------
//说明：运算符类
//方法：
//      1.将两个参与运算的Number类进行运算
//
//------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathproblem
{
    class Operation : Component
    {
        public Operation(char op)
        {
            this.op = op;
        }
        public override void Print()
        {
            Console.Write("{0} ", op);
        }
        public bool Equals(char op)
        {
            if (this.op == op) return true;
            else return false;
        }
        public string GetString()
        {
            string s = "";
            s += op;
            return s;
        }
        public string GetString2()
        {
            string s = "";
            if (op != '^')
                s += op;
            else s += "**";
            return s;
        }
        public Number Calculate(Number a, Number b)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                case '^':
                    return a ^ b;
            }
            return null;
        }
        readonly private char op;
    }
}
