using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egg
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for (i = 1; i <= 100000; i++)
            {
                if ((i % 2 == 1) && (i % 3 == 0) && (i % 4 == 1) && (i % 5 == 4) && (i % 6 == 3) && (i % 7 == 0) && (i % 8 == 1) && (i % 9 == 0))
                {
                    Console.WriteLine("最小鸡蛋为：" + i);
                    Console.ReadKey();
                }
            }
        }
    }
}
