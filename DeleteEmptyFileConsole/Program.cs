using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteEmptyFileConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Directory.GetDirectories(@"F:\guide_img"))
            {
                if (Directory.GetDirectories(item).Length + Directory.GetFiles(item).Length == 0)
                {
                    Console.WriteLine(item);
                    Directory.Delete(item);
                }
            }
        }
    }
}
