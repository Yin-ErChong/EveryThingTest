using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class ReflectTest : TestBase, ITestBase
    {
        private static ReflectTest _Instance;
        public static ReflectTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReflectTest();
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
            ReflectModel reflectModel = new ReflectModel();
            reflectModel.SetValue("x",9);

            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
    public class ReflectModel : ReflectModelBase
    {
        public static Dictionary<string, PropertyInfo> propertyInfoDic;
        private static object locker=new object();
        public int x { get; set; }
        public void SetValue(string properName,object value)
        {
            if (propertyInfoDic == null)
            {
                lock (locker)
                {
                    if (propertyInfoDic == null)
                    {
                        Type type = typeof(ReflectModel);
                        propertyInfoDic = new Dictionary<string, PropertyInfo>();
                        foreach (var item in type.GetProperties())
                        {
                            propertyInfoDic.Add(item.Name,item);
                        }
                        
                    }
                }
            }
            if (propertyInfoDic.ContainsKey(properName))
            {
                propertyInfoDic[properName].SetValue(this, value);
            }
        }
    }
    public class ReflectModelBase
    {
        public int? num { get; set; }

    }
}
