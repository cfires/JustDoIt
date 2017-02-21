using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JustDoIt.Controllers
{
    public class DistinctBySelfController : Controller
    {


        public ActionResult Index()
        {
            ISet<string> result = new HashSet<string>();

            var file = Request["file"];

            if (System.IO.File.Exists(file))
            {
                TextReader reader = System.IO.File.OpenText(file);
                string[] files = new string[2];
                files[0] = "不重复数据.txt";
                files[1] = "重复数据.txt";
                TextWriter writer1 = System.IO.File.CreateText(files[0]);
                TextWriter writer2 = System.IO.File.CreateText(files[1]);

            }

            return View();
        }






























        //// GET: DistinctBySelf
        //public ActionResult Index()
        //{
        //    var file = Request["file"];

        //    if (File.Exists(file))
        //    {
        //        List<string> list = new List<string>();
        //        using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("GBK")))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string temp = sr.ReadLine();
        //                if (!list.Contains(temp))
        //                {
        //                    list.Add(temp);
        //                }
        //            }
        //        }
        //    }

        //    return View();
        //}
    }
}