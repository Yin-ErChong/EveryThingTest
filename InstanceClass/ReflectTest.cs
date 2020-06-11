using EveryThingTest.BaseClass;
using EveryThingTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class ReflectTest : TestBase, ITestBase
    {
        private static ReflectTest _Instance;
        public static ReflectTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReflectTest();
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
            Guid guid = Guid.NewGuid();
            string str = "123";
            var ty= str.GetType();

            Stopwatch stopwatch = new Stopwatch();
            ReflectModel reflectModel = new ReflectModel();
            Type type = typeof(ReflectModel);
            var pro = type.GetProperty("x1");
            SetValueDelegate setter2 = DynamicMethodFactory.CreatePropertySetter(pro);
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                pro.SetValue(reflectModel, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"反射赋值耗时{stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                
                setter2(reflectModel, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"EmitSet赋值耗时{stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                reflectModel.x1=i;
            }
            stopwatch.Stop();
            Console.WriteLine($"正常赋值耗时{stopwatch.ElapsedMilliseconds}");
            //ReflectModel2 reflectModel2 = new ReflectModel2();
            //reflectModel2.SetValue("x1",5);
            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
    public class ReflectModel : ReflectModelBase<ReflectModel>
    {
        public int x1 { get; set; }
    }
    public class ReflectModel2 : ReflectModelBase<ReflectModel2>
    {
        public int x1 { get; set; }
    }
    public class ReflectModelBase<T>
    {

       
        public int? num { get; set; }

    }
    public delegate void SetValueDelegate(object target, object arg);
    /// <summary>
    /// 反射优化
    /// </summary>
    public static class DynamicMethodFactory
    {
        public static SetValueDelegate CreatePropertySetter(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            if (!property.CanWrite)
                return null;

            MethodInfo setMethod = property.GetSetMethod(true);

            DynamicMethod dm = new DynamicMethod("PropertySetter", null,
                new Type[] { typeof(object), typeof(object) }, property.DeclaringType, true);

            ILGenerator il = dm.GetILGenerator();

            if (!setMethod.IsStatic)
            {
                il.Emit(OpCodes.Ldarg_0);
            }
            il.Emit(OpCodes.Ldarg_1);

            EmitCastToReference(il, property.PropertyType);
            if (!setMethod.IsStatic && !property.DeclaringType.IsValueType)
            {
                il.EmitCall(OpCodes.Callvirt, setMethod, null);
            }
            else
                il.EmitCall(OpCodes.Call, setMethod, null);

            il.Emit(OpCodes.Ret);

            return (SetValueDelegate)dm.CreateDelegate(typeof(SetValueDelegate));
        }

        private static void EmitCastToReference(ILGenerator il, Type type)
        {
            if (type.IsValueType)
                il.Emit(OpCodes.Unbox_Any, type);
            else
                il.Emit(OpCodes.Castclass, type);
        }
    }


}
