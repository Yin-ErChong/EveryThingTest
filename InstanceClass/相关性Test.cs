using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class 相关性Test:TestBase, ITestBase
    {
        public Dictionary<char, double> befordArrayDic = new Dictionary<char, double>()
        {
            { '1',0.301},
            { '2',0.176},
            { '3',0.125},
            { '4',0.097},
            { '5',0.079},
            { '6',0.067},
            { '7',0.058},
            { '8',0.051},
            { '9',0.046},
        };
        public Dictionary<char, double> befordArrayDic2 = new Dictionary<char, double>()
        {
            { '1',0.28},
            { '2',0.20},
            { '3',0.1},
            { '4',0.1},
            { '5',0.12},
            { '6',0.02},
            { '7',0.06},
            { '8',0.03},
            { '9',0.09},
        };
        private static 相关性Test _Instance;
        public static 相关性Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 相关性Test();
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
            Console.WriteLine(ComputeCoeff(befordArrayDic.Values.ToArray(), befordArrayDic2.Values.ToArray()));
        }
        public override void End()
        {
            Console.Read();
        }
        public double ComputeCoeff(double[] values1, double[] values2)
        {
            if (values1.Length != values2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = values1.Average();
            var avg2 = values2.Average();

            var sum1 = values1.Zip(values2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = values1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = values2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }
    }

}
