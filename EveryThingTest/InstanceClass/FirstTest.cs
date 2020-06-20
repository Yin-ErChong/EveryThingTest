using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    
    public class FirstTest : TestBase ,ITestBase
    {
        private static FirstTest _Instance;
        public static FirstTest Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FirstTest();                   
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
