using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class NullAbleTest : TestBase, ITestBase
    {
        private static NullAbleTest _Instance;
        public static NullAbleTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NullAbleTest();
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
