using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //显示内容
            string text = "In document_PrintPage method.";
            //设置字体
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 35, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 0, 0);
        }





        protected void FileMenuItem_PageSet_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            pageSetupDialog.ShowDialog();
        }
        /// <summary>
        /// 打印机设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_PrintSet_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.ShowDialog();
        }
        /// <summary>
        /// 预览功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_PrintView_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog { Document = printDocument };
            var lineReader = new StreamReader(@"C:\Users\Administrator\Desktop\尹尔冲的小账本.txt");
            try
            { // 脚本学堂 www.jbxue.com
                printPreviewDialog.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog { Document = printDocument };
            var lineReader = new StreamReader(@"C:\Users\Administrator\Desktop\尹尔冲的小账本.txt");
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog { Document = printDocument };
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog { Document = printDocument };
            printPreviewDialog.ShowDialog();
           // printDocument.Print();
        }
    }
}
