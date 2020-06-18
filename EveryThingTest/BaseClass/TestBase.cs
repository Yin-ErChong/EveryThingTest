using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.BaseClass
{
    public interface ITestBase
    {
         void Start();
         void End();
    }
    public abstract class TestBase
    {
        public abstract void Start();
        public virtual void End() {
            Console.WriteLine("It'End");
            Console.ReadLine();

        }

        public void Begin()
        {
            Start();
            End();
        }
    }
}
