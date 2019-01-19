using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathproblem
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentParser argument = new ArgumentParser(args);
            if (argument.GetLength() == 0)
            {
                System.Console.WriteLine("Please enter an argument.");
                System.Console.WriteLine("Usage:\n" +
                    "generate 1000 problems: -g absolute_path_of_output_file\n" +
                    "play games: -p num_of_problem_you_want_to_play\n" +
                    "solve problems: -s absolute_path_of_problem_file");
                return;
            }

            if (argument.Get(1) == "-g")
            {
                if (argument.Has("-d") && argument.Has("-c"))
                    Console.WriteLine("Please input correct argument");
                else if (argument.Has("-d"))
                {
                    Expression.SetPrintType(Expression.PowerOpPrintType.doubleStar);
                    Expression.SetPowerOp(Expression.IsPowerOp.yes);
                }
                else if (argument.Has("-c"))
                {
                    Expression.SetPrintType(Expression.PowerOpPrintType.caret);
                    Expression.SetPowerOp(Expression.IsPowerOp.yes);
                }
                else
                    Expression.SetPowerOp(Expression.IsPowerOp.no);
                if (argument.Has("-h"))
                    Expression.SetDifficulty(Expression.Difficulty.hard);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Expressions.txt", false))
                {
                    for (int i = 0; i < argument.ToInt(2); i++)
                        Generate(file);
                }
                return;
            }

            if (argument.Get(1) == "-p")
            {
                int correctNum = 0;
                int wrongNum = 0;
                Expression ep = new Expression();
                while (ep.IsInvalid())
                {
                    ep = new Expression();
                }
                ep.PrintExpression();
                string answer = Console.ReadLine();
                if (answer == "stop")
                    Console.WriteLine("正确数量：{0} 错误数量：{1}", correctNum, wrongNum);
                if (answer == ep.GetAnswerString())
                    correctNum++;
                else wrongNum++;
                return;
            }

            System.Console.WriteLine("Please enter correct argument.");
            return;
        }
        static void Generate(System.IO.StreamWriter file)
        {
            Expression ep = new Expression();
            while (ep.IsInvalid())
            {
                ep = new Expression();
            }
            ep.PrintExpressionWithAnswerToFile(file);
        }
    }
}
