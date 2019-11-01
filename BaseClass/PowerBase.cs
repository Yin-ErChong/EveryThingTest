using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.BaseClass
{
    public class DataModel
    {
        public string id { get; set; }
        public string onlySignal { get; set; }
        public string power { get; set; }
    }
    public abstract class PowerBase
    {
        private List<DataModel> _dataModelDB { get; set; }
        private List<DataModel> _dataModelThis { get; set; }
        private string _onlySignal { get; set; }
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="power"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        //public  bool HavePowerEdit(string power,string id)
        //{
        //    _dataModelDB.ForEach(n=> {
        //        if (id.Contains(n.power))
        //        {

        //        }

        //    })
        //}
    }
}
