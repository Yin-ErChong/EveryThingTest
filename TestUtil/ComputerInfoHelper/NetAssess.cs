using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtil.Helper;

namespace TestUtil.ComputerInfoHelper
{
    public class NetAssess
    {
        public static NetAssess Instance =new NetAssess();

        public  List<string> UrlList = new List<string>() {
            "https://www.taobao.com/",
            "https://www.jd.com/",
            "https://www.baidu.com/"
        };
        public void GoNetWork()
        {
            foreach (var item in UrlList)
            {
                HttpHelper.Get(item);
            }
        }
        public double GetWorkTime()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            GoNetWork();

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        //public int GetAssess()
        //{
        //    double time = GetWorkTime();

        //}

    }
}
