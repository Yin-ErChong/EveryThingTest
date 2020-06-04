using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class GenericsTest: TestBase, ITestBase
    {
        private static GenericsTest _Instance;
        public static GenericsTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GenericsTest();
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
            Generics<NormalClass> generics = new Generics<NormalClass>();
            CompareTest compareTest = new CompareTest();
            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
    public class CompareTest : IComparable
    {
        public bool Equals(CompareTest compareTest)
        {
            return true;
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public class NormalClass
    {
        public int x { get; set; }
        public NormalClass()
        {
            x = 6;
        }
    }
    public class Generics<T> where T : new()
    {
        public T instance { get; set; }
        /// <summary>
        /// 重载运算符
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator ==(Generics<T> t1, Generics<T> t2)
        {
            return true;
        }
        public static bool operator !=(Generics<T> t1, Generics<T> t2)
        {
            return true;
        }
        public static bool operator +(Generics<T> t1, Generics<T> t2)
        {
            return true;
        }
        public Generics()
        {
            instance = new T();
        }
    }
}
