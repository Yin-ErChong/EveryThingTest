using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class 打印机Test : TestBase, ITestBase
    {
        private static 打印机Test _Instance;
        public static 打印机Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 打印机Test();
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
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
