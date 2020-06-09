using EveryThingTest.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class ShuiYouTest : TestBase, ITestBase
    {
        private static ShuiYouTest _Instance;
        public static ShuiYouTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShuiYouTest();
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
            string str = "[{\"msg\":\"申报成功\"}]";

            Item[] Items = JsonConvert.DeserializeObject<Item[]>(str);
            foreach (var item in Items)
            {

                if (item.details == null || item.msg == "申报成功")
                {
                    Console.WriteLine(item.msg);
                    continue;
                }
                Console.WriteLine("--以下人员" + item.msg + ":");
                foreach (var detail in item.details)
                    {
                        Console.WriteLine(String.Join(",", detail));
                    }
                

            }
            Console.ReadLine();
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }

    }
    public class FeedBackMessage
    {
        public Item[] Items { get; set; }
    }

    public class Item
    {
        public string[][] details { get; set; }
        public string msg { get; set; }
    }


}
