using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormTest
{
    public class ListViewNew
    {
        public DataTable dataTable = new DataTable();
        private ListView listView;
        public ListViewNew(ListView listView)
        {
            this.listView = listView;
        }
        public ListViewNew(ListView listView, DataTable dataTable)
        {
            this.listView = listView;
            this.dataTable = dataTable;
        }
        public void SetTable(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }
        public void BindTable()
        {
            listView.Clear();
            foreach (DataColumn item in dataTable.Columns)
            {
                listView.Columns.Add(item.ColumnName);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem();
                foreach (var item in row.ItemArray)
                {
                    listViewItem.SubItems.Add(item.ToString());
                }
                listView.Items.Add(listViewItem);
            }
        }
        public void UpdateData()
        {
            listView.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem();
                foreach (var item in row.ItemArray)
                {
                    listViewItem.SubItems.Add(item.ToString());
                }
            }
        }
        //private ListView listView;
        //public ListViewNew(ListView listView)
        //{
        //    this.listView = listView;
        //}
        //public void SetBtnCount(int count)
        //{
        //    btnCount = count;
        //}
        //public Dictionary<string,List<string> > btnSeqDic = new Dictionary<string, List<string>>();
        //public void SetBtnlocations(int[] seqs)
        //{
        //    btnLocations = seqs;
        //}
        //int[] btnLocations;
        //private int btnCount;
        ////ListViewItem必须要有Id这一列
        //public void AddItemWithBtn(ListViewItem listViewItem, Button[] btns,int[] locations)
        //{
        //    listView.Items.Add(listViewItem);
        //    string id = listViewItem.SubItems.where;
        //    for (int i = 0; i < btns.Length; i++)
        //    {
        //        btns[i].Location = new Point(listView.Items[seq].SubItems[locations[i]].Bounds.Left, listView.Items[seq].SubItems[locations[i]].Bounds.Top);
        //        if (btnSeqDic.ContainsKey(seq))
        //        {
        //            btnSeqDic[seq].Add(btns[i].Name);
        //        }              
        //    }            
        //}
        ////ListViewItem必须要有Id这一列
        //public void DeleteItemWithBtn(int i)
        //{
        //    listView.Items.RemoveAt(i);
        //    listView.Controls.RemoveAt(i* btnCount);
        //    btnSeqDic.Remove(i);
        //    for (int j = 0; i < listView.Controls.Count - btnCount; j+= btnCount)
        //    {
        //        for (int m = 0; m < btnCount; m++)
        //        {
        //            listView.Controls[j+m].Location= new Point(listView.Items[j].SubItems[btnLocations[m]].Bounds.Left, listView.Items[j].SubItems[btnLocations[m]].Bounds.Top);
        //        }
        //    }
        //}
    }
}
