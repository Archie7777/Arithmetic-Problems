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
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter an argument.");
                System.Console.WriteLine("Usage:\n" +
                    "generate 1000 problems: -g absolute_path_of_output_file\n" +
                    "play games: -p num_of_problem_you_want_to_play\n" +
                    "solve problems: -s absolute_path_of_problem_file");
                return ;
            }

            if (args[0] == "-g")
            {
                //====================================
                for(int i = 0; i < 10; i++)
                {
                    Problem p = new Problem();
                    while (p.IsInvalid() == 1)
                    {
                        p = new Problem();
                    }
                    p.PrintProblem();
                    p.PrintAnswer();
                }

                //====================================
                //Console.WriteLine("generate problem");
                return;
            }

            if (args[0] == "-p")
            {
                Console.WriteLine("play");
                return;
            }

            if (args[0] == "-s")
            {
                Console.WriteLine("solve problem");
                return;
            }

            System.Console.WriteLine("Please enter correct argument.");
            System.Console.WriteLine("Usage:\n" +
                "generate 1000 problems: -g absolute_path_of_output_file\n" +
                "play games: -p num_of_problem_you_want_to_play\n" +
                "solve problems: -s absolute_path_of_problem_file");
            return;
        }
    }
}
