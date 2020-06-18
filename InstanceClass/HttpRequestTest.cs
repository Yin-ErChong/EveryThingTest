using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class HttpRequestTest : TestBase, ITestBase
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
        public override void Start()
        {
            Console.WriteLine("It'Start");
        }
    }
}
