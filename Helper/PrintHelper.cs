using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveryThingTest.Helper
{
    class PrintHelper
    {
        PrintDocument printDocument = new PrintDocument();
        StreamReader lineReader;
        /// <summary>
        /// 打印纸设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            lineReader = new StreamReader(@"f:\新建文本文档.txt");
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
            lineReader = new StreamReader(@"f:\新建文本文档.txt");
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
    }
}
