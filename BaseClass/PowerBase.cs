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
        public string pid { get; set; }
        public string onlySignal { get; set; }
        public string power { get; set; }
        public bool isMainData { get; set; }
        public bool isDeleted { get; set; }
    }
    public abstract class PowerBase
    {
        private List<DataModel> _dataModelDB { get; set; }
        private List<DataModel> _dataNeedUpdate { get; set; }
        private List<DataModel> _dataNeedInsert { get; set; }
        private List<DataModel> _dataModelThis { get; set; }
        private Dictionary<string,List<int>> _dicDB { get; set; }
        private string _onlySignal { get; set; }
        public PowerBase(List<DataModel> dataModelDB)
        {
            //初始化数据库字典
            _dataModelDB.ForEach(n=> {
                if (!_dicDB.ContainsKey(n.onlySignal))
                {
                    List<int> list = new List<int>();
                    list.Add(_dataModelDB.IndexOf(n));
                    _dicDB.Add(n.onlySignal, list);
                }
                else
                {
                    _dicDB[n.onlySignal].Add(_dataModelDB.IndexOf(n));
                }
            
            });
        }
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="power"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HavePowerEdit(string power, string onlySignal)
        {
            //不包含该唯一标识，说明无权限
            if (!_dicDB.ContainsKey(onlySignal))
            {
                return false;
            }
            List<int> seqList = _dicDB[onlySignal];
            foreach (var item in seqList)
            {
                //主数据或辅数据包含该权限
                if (power.Contains(_dataModelDB[item].power))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 根据新增的数据给指定唯一标识的数据增加一个权限
        /// </summary>
        /// <param name="power"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GrentPower(DataModel data, string onlySignal)
        {
            if (!_dicDB.ContainsKey(onlySignal))
            {
                _dataNeedInsert.Add(data);
            }
            else
            {
                int mainDataIndex =0;
                _dicDB[onlySignal].ForEach(
                    n =>
                    {
                        if (_dataModelDB[n].power == data.power)
                        {
                            return;
                        }
                        if (_dataModelDB[n].isMainData)
                        {
                            mainDataIndex = n;
                        }
                    }
                );
                DataModel dataModel = new DataModel();
                dataModel.power = data.power;
                dataModel.pid = _dataModelDB[mainDataIndex].id;
                dataModel.isMainData = false;
                _dataNeedInsert.Add(dataModel);
            }
        }
        /// <summary>
        /// 根据新增的数据给指定唯一标识的数据删除一个权限
        /// </summary>
        /// <param name="power"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void CancelPower(DataModel data, string onlySignal)
        {
            if (!_dicDB.ContainsKey(onlySignal))
            {
                return;
            }
            else
            {
                int mainDataIndex = 0;
                _dicDB[onlySignal].ForEach(
                    n =>
                    {
                        if (_dataModelDB[n].power == data.power)
                        {
                            if (_dataModelDB[n].isMainData)
                            {
                                _dataModelDB[n].power = string.Empty;
                            }
                            else
                            {
                                _dataModelDB[n].isDeleted = true;
                            }
                            _dataNeedUpdate.Add(_dataModelDB[n]);
                        }
                        if (_dataModelDB[n].isMainData)
                        {
                            mainDataIndex = n;
                        }
                    }
                );
            }
        }
    }
}
