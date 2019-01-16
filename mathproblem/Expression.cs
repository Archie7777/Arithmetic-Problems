//------------------------------------------
//表达式类
//公有方法：
//  1.SetPrintType() 静态设置要生成的表达式打印乘方运算的类型
//  2.SetPowerOp() 静态设置要生成的表达式是否带乘方运算
//  3.SetDifficulty() 静态设置要生成的表达式的难度
//  4.PrintExpression() 
//  5.PrintAnswer()
//  6.PrintExpressionWithAnswer()
//  7.PrintExpressionWithAnswerToFile()
//  8.IsInvalid() 返回该表达式是否有效，即有无除零
//------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mathproblem
{
    class Expression
    {
        public enum PowerOpPrintType { caret, doubleStar }
        public enum Difficulty { easy, hard }
        public enum IsPowerOp { yes, no }
        public Expression()
        {
            node = new NODE[16];
            if (ipo == IsPowerOp.yes)
                randomOperationType = RandomOperationType.withPower;
            else randomOperationType = RandomOperationType.Basic;
            expression = "";
            GenExpression();
            finalValue = Solve();
            if (finalValue == null) invalid = 1;
        }
        public void PrintExpression()
        {
            if (invalid == 1)
            {
                Console.WriteLine("Expression is Invalid");
                return;
            }
            Console.Write(expression);
            Console.WriteLine("= ?");
        }
        public void PrintAnswer()
        {
            if (invalid == 1)
            {
                Console.WriteLine("Expression is Invalid");
                return;
            }
            finalValue.Print();
            Console.WriteLine();
        }
        public void PrintExpressionWithAnswer()
        {
            if (invalid == 1)
            {
                Console.WriteLine("Expression is Invalid");
                return;
            }
            Console.Write(expression);
            Console.Write("= ");
            finalValue.Print();
            Console.WriteLine();
        }
        public void PrintExpressionWithAnswerToFile(StreamWriter file)
        {
            if (invalid == 1)
            {
                Console.WriteLine("Expression is Invalid");
                return;
            }
            file.Write(expression);
            file.Write("= ");
            file.Write(finalValue.GetString());
            file.WriteLine();
        }
        public bool IsInvalid()
        {
            return invalid == 1;
        }
        public static void SetPrintType(PowerOpPrintType popt)
        {
            powerOpPrintType = popt;
        }
        public static void SetPowerOp(IsPowerOp i)
        {
            ipo = i;
        }
        public static void SetDifficulty(Difficulty df)
        {
            difficulty = df;
        }



        //*****************************以下为私有部分*******************************************
        static private IsPowerOp ipo = IsPowerOp.no;
        static private PowerOpPrintType powerOpPrintType = PowerOpPrintType.caret;
        static private Difficulty difficulty = Difficulty.easy;
        private const int root = 1;
        private string expression;
        readonly private NODE[] node; //节点的结构体数据结构
        private struct NODE
        {
            public int leftchild, rightchild;
            public Operation o;
            public Number n;
        }
        private enum GenNodeType { onlyOperation, both, onlyNumber } //生成某一节点的方式
        private Number finalValue;        //生成表达式的最终答案
        readonly private int invalid = 0; //生成的表达式是否无效
        private enum RandomOperationType { Basic, withPower }
        private RandomOperationType randomOperationType;

        private void GenExpression()
        {
            switch (difficulty)
            {
                case Difficulty.easy:
                    GenEasyTree();
                    break;
                case Difficulty.hard:
                    GenHardTree();
                    break;
            }
            ChangeToString();
        }

        private void GenEasyTree()
        {
            int lc = node[root].leftchild = 2 * root;
            int rc = node[root].rightchild = 2 * root + 1;
            node[root].o = GenOperation();
            node[lc].n = GenInteger(20 + 1);
            if (node[root].o.Equals('^'))
                node[rc].n = GenInteger(3);
            else
                node[rc].n = GenInteger(20 + 1);
            node[lc].leftchild = node[lc].rightchild = 0;
            node[rc].leftchild = node[rc].rightchild = 0;
        }

        private void GenHardTree(int num = 1)
        {
            if (num == 0) return;
            if (num == 1)
            {
                node[num].o = GenOperation();
                node[num].leftchild = 2 * num;
                node[num].rightchild = 2 * num + 1;
            }
            else if (num < 8)
            {
                if (GenerateRandom(0, 2) == 1)
                {
                    node[num].o = GenOperation();
                    node[num].leftchild = 2 * num;
                    node[num].rightchild = 2 * num + 1;
                }
                else
                {
                    node[num].n = GenNumber(30 + 1, 10 + 1);
                    node[num].leftchild = node[num].rightchild = 0;
                }
            }
            else
            {
                node[num].n = GenNumber(30 + 1, 10 + 1);
                node[num].leftchild = node[num].rightchild = 0;
            }
            GenHardTree(node[num].leftchild);
            if (node[num].o != null && node[num].o.Equals('^'))
            {
                int rc = node[num].rightchild;
                node[rc].n = GenInteger(3 + 1);
                node[rc].leftchild = node[rc].rightchild;
                this.randomOperationType = RandomOperationType.Basic;
            }
            else
                GenHardTree(node[num].rightchild);
        }

        private void ChangeToString(int num = 1)
        {
            if (num == 0) return;
            if (num != 1 && node[num].leftchild != 0)
                expression += '(';
            ChangeToString(node[num].leftchild);
            if (node[num].leftchild == 0)
                expression += node[num].n.GetString() + " ";
            else
            {
                if (powerOpPrintType == PowerOpPrintType.doubleStar)
                    expression += node[num].o.GetString2() + " ";
                else
                    expression += node[num].o.GetString() + " ";
            }
            ChangeToString(node[num].rightchild);
            if (num != 1 && node[num].leftchild != 0)
                expression += ") ";
            return;
        }
        private Number Solve(int num = 1)
        {
            if (node[num].leftchild == 0)
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
        private Operation GenOperation()
        {
            int rdNum;
            Operation op = null;
            if (randomOperationType == RandomOperationType.Basic)
                rdNum = GenerateRandom(0, 4);
            else
                rdNum = GenerateRandom(0, 5);
            switch (rdNum)
            {
                case 0:
                    op = new Operation('+');
                    break;
                case 1:
                    op = new Operation('-');
                    break;
                case 2:
                    op = new Operation('*');
                    break;
                case 3:
                    op = new Operation('/');
                    break;
                case 4:
                    op = new Operation('^');
                    break;
            }
            return op;
        }
        private Number GenNumber(int rangeOfIndex, int rangeOfDenominator)
        {
            Number nb = null;
            int rdNum;
            int rI = GenerateRandom(0, rangeOfIndex);
            int rD = GenerateRandom(1, rangeOfDenominator);
            int rN = GenerateRandom(0, rangeOfDenominator);
            rdNum = GenerateRandom(0, 1);
            if (rdNum == 1)
                nb = new Number(rI);
            else nb = new Number(rN, rD);
            return nb;
        }
        private Number GenInteger(int rangeOfIndex)
        {
            Number nb = null;
            int rI = GenerateRandom(0, rangeOfIndex);
            nb = new Number(rI);
            return nb;
        }
        static readonly private Random randomNumber = new Random();
        private int GenerateRandom(int a, int b)
        {
            return randomNumber.Next(a, b);
        }
    }
}
