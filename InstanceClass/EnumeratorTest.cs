using EveryThingTest.BaseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    public class EnumeratorTest : TestBase, ITestBase
    {
        private static EnumeratorTest _Instance;
        public static EnumeratorTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EnumeratorTest();
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
            List<string> strs = new List<string>() {"1","2","3" };
            CollectionTest collectionTest = new CollectionTest(strs);
            string se= strs[6];
            foreach (var item in collectionTest)
            {
                Console.WriteLine(item);
            }
        }

    }
    public class CollectionTest : IEnumerable
    {
        public List<string> strlist;
        public CollectionTest(List<string> strs)
        {
            strlist = strs;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in strlist)
            {
                yield return strlist[1];
            }
        }
    }
    public class Enumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();
        

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    public static class M
    {
        public static string Helper{ get;private set;}
        public static  void hehe()
        {

        }
    }

}
