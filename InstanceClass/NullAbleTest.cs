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

            List<NullAbleModel2> nullAbleModel2s = new List<NullAbleModel2>();
            var a= nullAbleModel2s.Where(n => n.num == 2).ToList();
        }
    }
    public class NullAbleModel
    {
        public NullAbleModel2 model { get; set; }

    }
    public class NullAbleModel2
    {
        public int num;

    }
    
}
