using EveryThingTest.BaseClass;
using EveryThingTest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    public class 序列化Test : TestBase, ITestBase
    {
        private static 序列化Test _Instance;
        public static 序列化Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 序列化Test();
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
            序列化ModelTest test = new 序列化ModelTest();
            test.SetDefault();
            var str = JsonConvert.SerializeObject(test);
            Console.WriteLine(str);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
