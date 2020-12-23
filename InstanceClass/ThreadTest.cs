using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EveryThingTest.InstanceClass
{
    public class ThreadTest: TestBase, ITestBase
    {
        private static ThreadTest _Instance;
        public static ThreadTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ThreadTest();
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
            Console.WriteLine("It'Start");
            try
            {
                Thread thread = new Thread(ExceptionTest);
                thread.Start();
            }
            catch (Exception ee)
            {

                throw;
            }
            
        }
        public override void End()
        {
            
        }
        private void TaskTest()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Thread thread = new Thread(test);
                thread.Start();
                //Task.Run(()=> {
                //    Console.WriteLine($"当前线程：{Thread.CurrentThread.ManagedThreadId}");
                //    Thread.Sleep(2000);               
                //});
            }
        }
        private void ExceptionTest()
        {
            Console.WriteLine("我要抛异常了");
            throw new Exception();
        }
        /// <summary>
        /// 前台线程完成了进程才结束，如果就剩下后台线程，则程序会直接结束
        /// </summary>
        private void BackgroundTest()
        {
            Te te = new Te();
            Thread thread = new Thread(test);
            thread.Start();
            Console.WriteLine($"当前线程是否后台线程：{thread.IsBackground}");
            //thread.IsBackground = true;
            
        }
        private void test()
        {
            Console.WriteLine($"当前线程：{Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }
        public class Te {

            public int a = 6;
        }
    }
}
