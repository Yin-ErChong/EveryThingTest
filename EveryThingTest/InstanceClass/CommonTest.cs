using EveryThingTest.BaseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class CommonTest : TestBase, ITestBase
    {
        private static CommonTest _Instance;
        public static CommonTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CommonTest();
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
            DateTime dateTime = DateTime.Now;
            //List<ReduceMode> reduceModes = new List<ReduceMode>();
            //ReduceMode reduceModel = new ReduceMode();
            //reduceModel.MetaFieldName = "ReduceMode";
            //reduceModel.MetaFieldValue = "1";
            //SalaryMainType salaryMainType = new SalaryMainType();
            //salaryMainType.MetaFieldName = "SalaryMainType";
            //salaryMainType.MetaFieldValue = "1";
            //ReduceModel reduceModel1 = new ReduceModel();
            //DataRelation dataRelation = new DataRelation();
            //dataRelation.MetaFieldName = "ReduceReason";
            //dataRelation.key = "SXA031999999";
            //dataRelation.value = "其他";
            //DataRelation dataRelation2 = new DataRelation();
            //dataRelation2.MetaFieldName = "ReduceProof";
            //dataRelation2.key = "SXA031999999";
            //dataRelation2.value = "其他";
            //reduceModel1.ReduceReason = dataRelation;
            //reduceModel1.ReduceProof = dataRelation2;
            //salaryMainType.reduceModels.Add(reduceModel1) ;
            //reduceModel.salaryMainTypes.Add(salaryMainType);
            //reduceModes.Add(reduceModel);
            //string str= JsonConvert.SerializeObject(reduceModes);
            //double n = m.GetValueOrDefault() + 6;
            //DateTime time = DateTime.Now;
            //string str = string.Empty;
            //if (str=="")
            //{
            //    Console.WriteLine("相等");
            //}
            //Console.WriteLine($"{time.ToString("yyyy/MM/d")}");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
        
    }
    public class ReduceMode
    {
        public string MetaFieldName;
        public string MetaFieldValue;
        public List<SalaryMainType> salaryMainTypes=new List<SalaryMainType>();
    }
    public class SalaryMainType
    {
        public string MetaFieldName;
        public string MetaFieldValue;
        public List<ReduceModel> reduceModels=new List<ReduceModel>();
    }
    public class ReduceModel
    {
        public DataRelation ReduceReason =new DataRelation();
        public DataRelation ReduceProof=new DataRelation();
    }
    public class DataRelation
    {
        public string MetaFieldName;
        public string key;

        public string value;
    }
    
}
