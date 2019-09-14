using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.ExtensionFun
{
    public static class NormalExtension
    {
        //public static int GetDefaltOrValueInt(this int? nullObject)
        //{
        //    if (nullObject==null)
        //    {
        //        return 0;
        //    }
        //    return (int)nullObject;
        //}
        public static T GetDefaltOrValue<T>(this Nullable<T> nullObject)where T:struct
        {
            Type type = typeof(T);
            if (type.Name.ToString()=="int")
            {

            }
            return nullObject.Value;
        }

    }
}
