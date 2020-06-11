using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.Model
{
    public  class BaseModel
    {
        private static Dictionary<string, Dictionary<string, PropertyInfo>> propertyInfoDic = new Dictionary<string, Dictionary<string, PropertyInfo>>();
        private static object locker = new object();
        private Type type ;
        public BaseModel()
        {
            type = this.GetType();
        }
        public void SetDefault()
        {
            InitPropertyInfo(type);
            foreach (var item in propertyInfoDic[type.ToString()])
            {
                Type itemType = item.Value.PropertyType;
                switch (itemType.Name)
                {
                    case "String": SetValue(item.Key, string.Empty); break;                   
                }
                if (item.Key=="")
                {

                }
            }
        }
        public static void InitPropertyInfo(Type type)
        {
            string typeName = type.ToString();
            if (!propertyInfoDic.ContainsKey(typeName))
            {
                lock (locker)
                {
                    propertyInfoDic.Add(typeName, new Dictionary<string, PropertyInfo>());
                    foreach (var item in type.GetProperties())
                    {
                        propertyInfoDic[typeName].Add(item.Name, item);
                    }
                }
            }
        }
        public void SetValue(string properName, object value)
        {
            InitPropertyInfo(type);
            string typeName = type.ToString();
            if (propertyInfoDic[typeName].ContainsKey(properName))
            {
                propertyInfoDic[typeName][properName].SetValue(this, value);
            }
        }
    }
}
