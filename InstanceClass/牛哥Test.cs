using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class 牛哥Test : TestBase, ITestBase
    {
        private static 牛哥Test _Instance;
        public static 牛哥Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 牛哥Test();
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

            Console.WriteLine("Hello！");
            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
