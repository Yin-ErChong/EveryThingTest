﻿using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    public class ShuiYouTranserTest : TestBase, ITestBase
    {
        private static ShuiYouTranserTest _Instance;
        public static ShuiYouTranserTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShuiYouTranserTest();
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
        }
    }
}
