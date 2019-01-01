//------------------------------------------
//说明：四则运算表达式类
//方法：
//     1.默认构造函数：
//        功能：随机生成一个表达式，并求值
//     2.带参构造函数：
//        输入：字符串表达式
//        功能：将给定的表达式转化为数，并求值
//     3.PrintProblem:
//        输入：无
//        功能：输出表达式并在结尾加 “ = ? ”，若表达式无效则不打印
//     4.PrintAnswer:
//        输入：无
//        功能：打印表达式结果，若表达式无效则不打印
//     5.PrintProblemWithAnswer
//        输入：无
//        功能：打印表达式以及结果，若表达式无效则不打印
//     6.IsInvalue
//        输入：无
//        功能：判断该对象存储的表达式是否有效
//------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathproblem
{
    class Problem
    {
        public Problem()
        {
            node = new NODE[16];
            GenerateTree(1);
            finalValue = Solve(1);
            if (finalValue == null) invalue = 1;
        }
        public Problem(string por)
        {
            //将输入的表达式转化成树
        }
        public void PrintProblem()
        {
            if (invalue == 1) return;
            PrintTree(1);
            Console.Write("= ?");
            Console.WriteLine();
        }
        public void PrintAnswer()
        {
            if (invalue == 1) return;
            finalValue.Print();
            Console.WriteLine();
        }
        public void PrintProblemWithAnswer()
        {
            if (invalue == 1) return;
            PrintTree(1);
            Console.Write("= ");
            finalValue.Print();
            Console.WriteLine();
        }
        public int IsInvalue()
        {
            return invalue;
        }

        //*************************以下为私有部分**************************************************************

        readonly private NODE[] node; //节点的结构体数据结构
        private struct NODE
        {
            public int leftchild, rightchild;
            public Operation o;
            public Number n;
        }
        private enum GenType { onlyOperation, both, onlyNumber}; //生成某一节点的方式
        static readonly private Random randomNumber = new Random(); //生成表达式的随机数
        private Number finalValue;        //生成表达式的最终答案
        readonly private int invalue = 0; //生成的表达式是否无效

        private void PrintTree(int num)
        {
            if (num == -1) return;
            if (num != 1 && node[num].rightchild != -1) Console.Write("( ");
            PrintTree(node[num].leftchild);
            if (node[num].leftchild == -1) node[num].n.Print();
            else node[num].o.Print();
            PrintTree(node[num].rightchild);
            if (num != 1 && node[num].rightchild != -1) Console.Write(") ");
        }
        
        private Number Solve(int num)
        {
            if (node[num].leftchild == -1)
            {
                return node[num].n;
            }
            else
            {
                int l = node[num].leftchild;
                int r = node[num].rightchild;
                return node[num].o.Calculate(Solve(l), Solve(r));
            }
        }

        private void GenerateTree(int num)
        {
            if (num == -1) return;
            if (num == 1) GenerateNode(num, GenType.onlyOperation);
            else if (num > 7) GenerateNode(num, GenType.onlyNumber);
            else GenerateNode(num, GenType.both);
            GenerateTree(node[num].leftchild);
            GenerateTree(node[num].rightchild);
        }

        private void GenerateNode(int num, GenType GenType)
        {
            if (num == -1) return;
            node[num].leftchild = -1;
            node[num].rightchild = -1;
            switch (GenType)
            {
                case GenType.onlyOperation:
                    Operation o = null;
                    switch (GenerateRandom(0, 4))
                    {
                        case 0:
                            o = new Operation('+');
                            break;
                        case 1:
                            o = new Operation('-');
                            break;
                        case 2:
                            o = new Operation('*');
                            break;
                        case 3:
                            o = new Operation('/');
                            break;
                    }
                    node[num].o = o;
                    break;
                case GenType.both:
                    o = null;
                    Number n = null;
                    switch (GenerateRandom(0, 6))
                    {
                        case 0:
                            o = new Operation('+');
                            break;
                        case 1:
                            o = new Operation('-');
                            break;
                        case 2:
                            o = new Operation('*');
                            break;
                        case 3:
                            o = new Operation('/');
                            break;
                        case 4:
                            n = new Number(GenerateRandom(0, 20));
                            break;
                        case 5:
                            n = new Number(GenerateRandom(0, 10), GenerateRandom(1, 10));
                            break;
                    }
                    node[num].o = o;
                    node[num].n = n;
                    if (n != null) return;
                    break;
                case GenType.onlyNumber:
                    o = null;
                    n = null;
                    switch (GenerateRandom(0, 1))
                    {
                        case 0:
                            n = new Number(GenerateRandom(0, 20));
                            break;
                        case 1:
                            n = new Number(GenerateRandom(0, 10), GenerateRandom(1, 10));
                            break;
                    }
                    node[num].n = n;
                    return;
            }
            node[num].leftchild = 2 * num;
            node[num].rightchild = 2 * num + 1;
        }//GenerateNode
        
        private int GenerateRandom(int a, int b)
        {
            return randomNumber.Next(a, b);
        }
    }
}
