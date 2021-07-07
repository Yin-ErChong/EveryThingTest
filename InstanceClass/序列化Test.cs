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
            UserInfo test = new UserInfo();

            test.SetDefault();
            List<UserInfo> userInfos = new List<UserInfo>();
            userInfos.Add(test);
            string str = @"[
  {
                'Url': '牛哥URL',
    'UserName': null,
    'PassWord': null,
    'IsLog': null,
    'Cookie': null,
    'Id': 0,
    'CreateTime': '0001-01-01T00:00:00',
    'ModifiedTime': '0001-01-01T00:00:00',
    'Enable': 0
  },
  {
                'Url': null,
    'UserName': null,
    'PassWord': null,
    'IsLog': null,
    'Cookie': null,
    'Id': 0,
    'CreateTime': '0001-01-01T00:00:00',
    'ModifiedTime': '0001-01-01T00:00:00',
    'Enable': 0
  }
]";
            userInfos = JsonConvert.DeserializeObject<List<UserInfo>>(str);//JsonConvert.SerializeObject(userInfos);
            Console.WriteLine(userInfos[1].CreateTime);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
