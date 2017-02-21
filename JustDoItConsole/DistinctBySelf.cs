using System;
using System.Collections.Generic;
using System.IO;

namespace DistinctBySelfConsole
{
    class DistinctBySelf
    {
        //去除自身文本中的重复行
        static void Main(string[] args)
        {
            ISet<string> result = new HashSet<string>();

            foreach (var item in File.ReadLines("./input.txt"))
            {
                if (result.Add(item))
                {
                    Console.WriteLine(item);
                }
            }

            File.WriteAllLines("./output.txt", result);

            Console.WriteLine("FINISH");

            Console.ReadKey();
        }
    }
}
