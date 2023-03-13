using EveryThingTest.BaseClass;
using EveryThingTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    
    public class ADTest : TestBase ,ITestBase
    {
        private static ADTest _Instance;
        public static ADTest Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ADTest();                   
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
            string errResult = string.Empty;
            ADHelper.SetDomainMembership("","","",out errResult);
            //ADHelper.ChangeConputerName("YinComputer");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
