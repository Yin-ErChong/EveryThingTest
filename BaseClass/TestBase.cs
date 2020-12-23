using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
        public virtual void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }

        public void Begin()
        {
            Start();
            End();
        }
    }
}
