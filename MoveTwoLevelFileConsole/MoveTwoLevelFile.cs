using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace MoveTwoLevelFileConsole
{
    class MoveTwoLevelFile
    {
        //目的 ：移动F:\guide_chem问题下的文件和后代目录中的文件到新文件夹F:\guide_chem_copy
        private static void Main(string[] args)
        {
            Move(@"F:\CasImage");
        }

        static void Move(string directory)
        {
            var files = Directory.GetFiles(directory);
            if (files != null)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("MOVINT FILE {0}", file);
                    File.Move(file, @"F:\CasImage2\" + file.Split('\\').Last());
                }
            }

            var directories = Directory.GetDirectories(directory);
            if (directories != null)
            {
                foreach (var dir in directories)
                {
                    Console.WriteLine("HANDLING DIRECTORY {0}", dir);
                    Move(dir);
                }
            }
        }

    }
}
