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
            NullAbleModel nullAbleModel = new NullAbleModel();
            if (nullAbleModel.model?.num==0)
            {

            }
        }
    }
    public class NullAbleModel
    {
        public NullAbleModel2 model { get; set; }

    }
    public class NullAbleModel2
    {
        public int? num;

    }
}
