using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CreateTwoLevelForGuideConsole
{
    class CreateTwoLevelForGuide
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(?<=\\)(\d{1,7})-\d{1,2}-\d\.(?:png|jpg|gif|wmf)");  //还有.bmp格式的图片

            int casRn_part1;
            string path_root, path_second, directory, destination;
            foreach (var item in Directory.GetDirectories(@"F:\guide_chem问题"))
            {
                foreach (var filePath in Directory.GetFiles(item))
                {
                    if (!regex.IsMatch(filePath))
                    {
                        continue;
                    }

                    Console.WriteLine(filePath);

                    casRn_part1 = int.Parse(regex.Match(filePath).Groups[1].Value);
                    path_root = (casRn_part1 / 1000).ToString().PadLeft(4, '0');
                    path_second = (casRn_part1 % 1000).ToString().PadLeft(3, '0');

                    directory = string.Format(@"F:\molbase_img\{0}\{1}\", path_root, path_second);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    destination = string.Format(@"{0}\{1}", directory, regex.Match(filePath).Groups[0].Value);

                    if (File.Exists(destination))
                    {
                        File.Delete(destination);
                    }

                    Directory.Move(filePath, destination);
                }
            }
        }
    }
}
