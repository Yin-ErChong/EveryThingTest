using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class CommonTest : TestBase, ITestBase
    {
        private static CommonTest _Instance;
        public static CommonTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CommonTest();
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

            Console.WriteLine($"{time.ToString("yyyy/MM/d")}");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
