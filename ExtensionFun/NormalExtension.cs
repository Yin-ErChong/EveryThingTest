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
        /// <summary>
        /// 分割List
        /// </summary>
        /// <typeparam name="T">源数据类型</typeparam>
        /// <param name="source">源数据</param>
        /// <param name="capacity">容量（分割单位）</param>
        /// <returns></returns>
        public static List<List<T>> SplitList<T>(List<T> source, int capacity) where T : class
        {
            List<List<T>> target = new List<List<T>>();
            for (int i = 0; i <= (source.Count() - 1) / capacity; i++)
            {
                target.Add(new List<T>());
            }
            for (int i = 0; i < source.Count; i++)
            {
                target[i / capacity].Add(source[i]);
            }
            return target;
        }

    }
}
