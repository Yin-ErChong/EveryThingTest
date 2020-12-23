using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            NullAbleModelBase nullAbleModel2 = new NullAbleModelBase();
            StringBuilder stringBuilder = new StringBuilder("hi");
            object value = 9;
            ChangObject(value);

            
            nullAbleModel2 = null;
            NullAbleModel nullAbleModel3 = (NullAbleModel)nullAbleModel2;

            NullAbleModel nullAbleModel = new NullAbleModel();
            int? nullable = null;
            int notnull =2;
            notnull = nullable.GetValueOrDefault();

        }
        public void ChangObject(object strB)
        {
            strB=8;
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
    public class NullAbleModel: NullAbleModelBase
    {
        public int x;
    }
    public class NullAbleModelBase
    {
        public int? num;

    }
    
}
