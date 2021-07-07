using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormTest
{
    public partial class ListViewTest : Form
    {
        public ListViewTest()
        {
            InitializeComponent();
        }

        private void ListViewTest_Load(object sender, EventArgs e)
        {
            string[] columnNames = new string[] { "文件名", "类型", "字数", "操作" };
            foreach (var item in columnNames)
            {
                this.listView1.Columns.Add(item);
            }
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewItem[] lvs = new ListViewItem[10];
            lvs[0] = new ListViewItem(new string[] { "1", "行1列2", "400", "", "" });
            lvs[1] = new ListViewItem(new string[] { "2", "行2列2", "300", "", "" });
            lvs[2] = new ListViewItem(new string[] { "3", "行3列2", "200", "", "" });
            return;
            ListViewNew listViewNew = new ListViewNew(this.listView1);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("文件名");
            dataTable.Columns.Add("文件地址");
            DataRow dataRow = dataTable.NewRow();
            dataRow["文件名"] = "测试";
            dataRow["文件地址"] = "测试2";
            dataTable.Rows.Add(dataRow);
            listViewNew.SetTable(dataTable);
            listViewNew.BindTable();

            //string[] columnNames = new string[] { "文件名", "类型", "字数", "操作" };
            //foreach (var item in columnNames)
            //{
            //    this.listView1.Columns.Add(item);
            //}
            //this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //ListViewItem[] lvs = new ListViewItem[10];
            //lvs[0] = new ListViewItem(new string[] { "1", "行1列2", "400", "", "" });
            //lvs[1] = new ListViewItem(new string[] { "2", "行2列2", "300", "", "" });
            //lvs[2] = new ListViewItem(new string[] { "3", "行3列2", "200", "", "" });
            //lvs[3] = new ListViewItem(new string[] { "4", "行3列2", "200", "", "" });
            //lvs[4] = new ListViewItem(new string[] { "5", "行3列2", "200", "", "" });
            //lvs[5] = new ListViewItem(new string[] { "6", "行3列2", "200", "", "" });
            //lvs[6] = new ListViewItem(new string[] { "7", "行3列2", "200", "", "" });
            //lvs[7] = new ListViewItem(new string[] { "8", "行3列2", "200", "", "" });
            //lvs[8] = new ListViewItem(new string[] { "9", "行3列2", "200", "", "" });
            //lvs[9] = new ListViewItem(new string[] { "10", "行3列2", "200", "", "" });
            //ListViewNew listViewNew = new ListViewNew(listView1);
            //foreach (ListViewItem item in lvs)
            //{
            //    Button btn = new Button();
            //    btn.Visible = true;
            //    btn.Text = "测试";
            //    btn.Size = new Size(100, 15);
            //    Button btndel = new Button();
            //    btndel.Visible = true;
            //    btndel.Text = "删除";
            //    btndel.Size = new Size(100, 15);
            //    Button[] buttons = new Button[] { btn , btndel };
            //    listViewNew.AddItemWithBtn(item, buttons,new int[] { 3,4});
            //}

            ////this.listView1.Items.AddRange(lvs);
            ////ImageList imageList = new ImageList();
            ////imageList.ImageSize = new Size(1, 20);
            ////listView1.SmallImageList = imageList;
            ////for (int i = 0; i < lvs.Length; i++)
            ////{
            ////    var d = this.listView1.Items[i].SubItems[0].Text;
            ////    Button btn = new Button(); 
            ////    btn.Visible = true;
            ////    btn.Text = "测试";
            ////    btn.Click += (a, b) => myButton_Click(d);
            ////    btn.Size = new Size(100, 15);
            ////    btn.Location = new Point(this.listView1.Items[i].SubItems[3].Bounds.Left, this.listView1.Items[i].SubItems[3].Bounds.Top); 
            ////    this.listView1.Controls.Add(btn); 
            ////    Button btndel = new Button();
            ////    btndel.Visible = true;
            ////    btndel.Text = "删除";
            ////    btndel.Name = i.ToString();
            ////    var j = i; btndel.Click += (p, o) => myDel_Click(j);
            ////    btndel.Size = new Size(100, 15);
            ////    btndel.Location = new Point(this.listView1.Items[i].SubItems[3].Bounds.Left + 100, this.listView1.Items[i].SubItems[4].Bounds.Top);
            ////    this.listView1.Controls.Add(btndel);
            ////}
        }

        private void myButton_Click(string c)
        {
            MessageBox.Show(c);
        }
        private void myDel_Click(int a)
        {
            this.listView1.Items.RemoveAt(a);
            //移除该行数据 this.listView1.Controls.RemoveAt(a * 2);//移除该行测试按钮 
            this.listView1.Controls.RemoveAt(a * 2);//移除该行删除按钮 
            var ad = this.listView1.Controls;
            for (int i = 0; i < this.listView1.Controls.Count; i++)
            {
                if (i >= a * 2)
                {
                    this.listView1.Controls[i].Location = new Point(this.listView1.Controls[i].Location.X, this.listView1.Controls[i].Location.Y - 20);
                }

            }
                    //if (this.listView1.Controls[i].Text.Equals("删除")) //{ // var itemIndex = Convert.ToInt32(this.listView1.Controls[i].Name) - 1; // this.listView1.Controls[i].Name = itemIndex.ToString();// this.listView1.Controls[i].Click += (p, o) => myDel_Click(itemIndex); //} 
        }
    }
}


