using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class Asyn_AwaitTest : TestBase, ITestBase
    {
        private static Asyn_AwaitTest _Instance;
        public static Asyn_AwaitTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Asyn_AwaitTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        public override void Start()
        {
            DateTime time = DateTime.Now;

            var str = AsyncGet("");
            var str2 = str.Result;

            Console.WriteLine($"{time.ToString("yyyy/MM/d")}");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
        public async Task<string> AsyncGet(string param)
        {
            Console.WriteLine($"{Thread.CurrentThread.GetHashCode()}异步开始");
            return  await Task.Run(()=> {

                Thread.Sleep(5000);
                Console.WriteLine($"{Thread.CurrentThread.GetHashCode()}异步执行完毕");
                return "";
            });
        }
    }
}
