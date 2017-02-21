using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CreateTwoLevelConsole
{
    class CreateTwoLevel
    {
        //程序目的：将某文件夹下的文件按照cas的规则移动到两级目录下

        //为化学物质创建两级目录 注：cas:第一部分（2-7位数字）-第二部分（1-2位数字）-第三部分（1位数字）
        //Directory 目录  File 文件


        private static void Main(string[] args)
        {
            var regex = new Regex(@"(?<=\\)((\d{1,7})-\d{1,2}-\d).*(\.(?:png|jpg|gif|wmf|bmp))");

            int casRn_part1;
            string path_root;
            string path_second;
            string directory;
            string destination;
            var i = 0;

            foreach (var filePath in Directory.GetFiles(@"E:\work\macklin\化学物质\img_temp"))
            {
                if (!regex.IsMatch(filePath))
                {
                    continue;
                }

                Console.WriteLine(filePath);

                casRn_part1 = int.Parse(regex.Match(filePath).Groups[2].Value);
                path_root = (casRn_part1 / 1000).ToString().PadLeft(4, '0');
                path_second = (casRn_part1 % 1000).ToString().PadLeft(3, '0');

                directory = string.Format(@"E:\work\macklin\化学物质\img\{0}\{1}\", path_root, path_second);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                destination = string.Format(@"{0}\{1}{2}", directory, regex.Match(filePath).Groups[1].Value, regex.Match(filePath).Groups[3].Value);

                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }

                Directory.Move(filePath, destination);
                i++;
            }

            Console.WriteLine("成功移动" + i + "个文件");
            Console.ReadKey();






            //foreach (var filePath in Directory.GetFiles(@"F:\test\"))
            //{
            //    var cas = NextFile.Name;
            //    var first = cas.Split('-')[0];
            //    var _first = first.PadLeft(7, '0');
            //    var name1 = _first.Substring(0, 4);
            //    var name2 = _first.Substring(4, 3);

            //    File.Move(@"F:\test\353258-16-9.jpg", @"F:\test2\" + name1);
            //}

        }

        //static void Main(string[] args)
        //{
        //    var regex = new Regex(@"(?<=\\)(\d{1,7})-\d{1,2}-\d\.(?:png|jpg|gif|wmf|bmp)");

        //    int casRn_part1;
        //    string path_root, path_second, directory, destination;
        //    int i = 0;

        //    foreach (var filePath in Directory.GetFiles(@"F:\chemnet\img19"))
        //    {
        //        if (!regex.IsMatch(filePath))
        //        {
        //            continue;
        //        }

        //        Console.WriteLine(filePath);

        //        casRn_part1 = int.Parse(regex.Match(filePath).Groups[1].Value);
        //        path_root = (casRn_part1 / 1000).ToString().PadLeft(4, '0');
        //        path_second = (casRn_part1 % 1000).ToString().PadLeft(3, '0');

        //        directory = string.Format(@"F:\chemnet\img\{0}\{1}\", path_root, path_second);
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }

        //        destination = string.Format(@"{0}\{1}", directory, regex.Match(filePath).Groups[0].Value);

        //        if (File.Exists(destination))
        //        {
        //            File.Delete(destination);
        //        }

        //        Directory.Move(filePath, destination);
        //        i++;
        //    }

        //    Console.WriteLine("成功移动" + i + "个文件");
        //    Console.ReadKey();






        //    //foreach (var filePath in Directory.GetFiles(@"F:\test\"))
        //    //{
        //    //    var cas = NextFile.Name;
        //    //    var first = cas.Split('-')[0];
        //    //    var _first = first.PadLeft(7, '0');
        //    //    var name1 = _first.Substring(0, 4);
        //    //    var name2 = _first.Substring(4, 3);

        //    //    File.Move(@"F:\test\353258-16-9.jpg", @"F:\test2\" + name1);
        //    //}

        //}
    }
}
