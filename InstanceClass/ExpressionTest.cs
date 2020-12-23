using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    public class ExpressionTest: TestBase, ITestBase
    {
        private static ExpressionTest _Instance;
        public static ExpressionTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExpressionTest();
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
            Expression<Func<int, int, int, int, int>> expression = (x, y, m, n) => (x * y*m) + (m * n);
            //Expression<Func<string, string, bool>> expression2 = (x, y) => {return x.Contains(y)};
            Console.WriteLine(expression);
            Func<int, int, int, int, int> func = expression.Compile();
            Console.WriteLine(func(1,2,3,4));
        }
    }
}
