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
            var arys = new int[] { 1,2,3,4,5,6,7,8,9,10};
            Console.WriteLine("It'Start");
            Console.WriteLine($"{GetResult(arys,5)}");
        }
        public int GetResult(int[] intArray,int number)
        {
            int seq = -1;
            int mid = intArray.Length/2;
            int left = 0;
            int right = intArray.Length - 1;
            int n = 1;
            while (true)
            {
                Console.WriteLine($"循环第{n}次");
                n++;
                if (intArray[left]== number)
                {
                    return left;
                }
                else if (intArray[right] == number)
                {
                    return right;
                }
                else if (intArray[mid] == number)
                {
                    return mid;
                }
                if (number > intArray[left]&& number< intArray[mid])
                {
                    right = mid;
                    mid = (mid + left) / 2;

                }
                else if(number < intArray[right] && number > intArray[mid])
                {
                    left = mid;
                    mid = (mid + right) / 2;
                }
                if (left==right)
                {
                    return seq;
                }
            }
        }
    }
}
