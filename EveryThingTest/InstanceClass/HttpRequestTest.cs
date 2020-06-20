using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestUtil.Helper;

namespace EveryThingTest.InstanceClass
{
    class HttpRequestTest: TestBase, ITestBase
    {
        private static HttpRequestTest _Instance;
        public static HttpRequestTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HttpRequestTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        List<long> timeConcurrentList1 = new List<long>();
        List<long> timeList1 = new List<long>();
        List<long> timeConcurrentList = new List<long>();
        List<long> timeList = new List<long>();
        public override void Start()
        {
            Console.WriteLine("It'Start");
            while (true)
            {
                Console.ReadLine();
                Stopwatch sw = new Stopwatch();

                var result3 = HttpHelper.GetInstance("https://www.baidu.com/");
                sw.Restart();
                单例并发测试();
                非单例并发测试();
                sw.Stop();
                Console.WriteLine($"单例耗时{sw.ElapsedMilliseconds}");
                
                //sw.Restart();
                //for (int i = 0; i < 50; i++)
                //{
                //    Thread thread = new Thread(GetTest);
                //    thread.Start();
                //}

                //sw.Stop();
                //Console.WriteLine($"非单例耗时{sw.ElapsedMilliseconds}");
            }           
        }
        public void 非单例并发测试()
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    timeList.Add(GetTest());
            //}
            for (int i = 0; i < 1000; i++)
            {
                Thread thread = new Thread(() => { timeConcurrentList.Add(GetTest()); });
                thread.Start();
            }
            Thread.Sleep(15000);
            Console.WriteLine($"非单例非并发平均耗时{(timeList.Count() > 0 ? timeList.Average() : 0)},并发平均耗时{(timeConcurrentList.Count() > 0 ? timeConcurrentList.Average() : 0)}");
        }
        public void 单例并发测试()
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    timeList.Add(GetTestInstance());
            //}
            for (int i = 0; i < 1000; i++)
            {
                Thread thread = new Thread(() => { timeConcurrentList1.Add(GetTestInstance()); });
                thread.Start();
            }
            Thread.Sleep(15000);
            Console.WriteLine($"单例非并发平均耗时{(timeList.Count()>0? timeList.Average():0)},并发平均耗时{(timeConcurrentList1.Count() > 0 ? timeConcurrentList1.Average() : 0)}");
        }
        public long GetTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            var result2 = HttpHelper.Get("https://g.alicdn.com/mui/bucket/3.0.4/??index.js,tool.js");
            //var result1 = HttpHelper.Get("https://pro.jd.com/");
            sw.Stop();
           // Console.WriteLine($"非单例耗时{sw.ElapsedMilliseconds}！！！！");
            return sw.ElapsedMilliseconds;
        }
        public long GetTestInstance()
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            var result2 = HttpHelper.GetInstance("https://g.alicdn.com/mui/bucket/3.0.4/??index.js,tool.js");

            //var result1 = HttpHelper.GetInstance("https://pro.jd.com/");
            sw.Stop();
            //Console.WriteLine($"单例耗时{sw.ElapsedMilliseconds}-----");
            return sw.ElapsedMilliseconds;
        }
    }
}
