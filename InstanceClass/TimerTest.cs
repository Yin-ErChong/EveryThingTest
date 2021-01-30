using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EveryThingTest.InstanceClass
{
    class TimerTest : TestBase, ITestBase
    {
        private static TimerTest _Instance;
        public static TimerTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TimerTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        public override void Start()
        {
            Console.WriteLine("It'Start");

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(writ1);

            timer2.Enabled = true;
            timer2.Interval = 5000;
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(writ2);
        }
        public event writ ev;
        public delegate void writ();
        public void writ1(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("哈哈哈");
        }
        public void writ2(object source, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            Console.WriteLine("停止");
        }

        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
