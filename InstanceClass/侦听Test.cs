using EveryThingTest.BaseClass;
using EveryThingTest.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EveryThingTest.InstanceClass
{
    public class 侦听Test: TestBase, ITestBase
    {
        private static 侦听Test _Instance;
        public static 侦听Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 侦听Test();
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

            //WinCapHelper.WinCapInstance.Listen();
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }

}
