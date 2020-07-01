using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass.LeetCode
{
    public class 二分法 : TestBase, ITestBase
    {
        private static 二分法 _Instance;
        public static 二分法 Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 二分法();
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
        public int GetResult(int[] intArray,int number)
        {
            int seq = -1;
            int mid = intArray.Length/2;
            int left = 0;
            int right = intArray.Length - 1;
            while (true)
            {
                if (left==right)
                {
                    return seq;
                }
                if (number> intArray[left])
                {

                }
            }
        }
    }
}
