//------------------------------------------
//命令行分析类
//作用：分析命令行
//  1.Has() 检查命令行中是否有给定string
//  2.NotHas() Has的取反，只是为了阅读方便
//  3.GetLength() 返回命令的参数数量
//  4.Get() 返回第n个参数
//  5.ToInt() 将第n个参数转化为int数字
//------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mathproblem
{
    class ArgumentParser
    {
        public ArgumentParser(string[] args)
        {
            arguments = new string[args.Length];
            for (int i = 0; i < args.Length; i++)
                arguments[i] = args[i];
        }
        public bool Has(string arg)
        {
            for (int i = 0; i < arguments.Length; i++)
                if (arg == arguments[i]) return true;
            return false;
        }
        public bool NotHas(string arg)
        {
            return !Has(arg);
        }
        public int GetLength()
        {
            return arguments.Length;
        }
        public string Get(int num)
        {
            return arguments[num - 1];
        }
        public int ToInt(int num)
        {
            return Convert.ToInt32(arguments[num - 1]);
        }
        private string[] arguments;
    }
}