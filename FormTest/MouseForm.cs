using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FormTest
{
    public partial class MouseForm : Form
    {
        #region Fields

        private int hMouseHook = 0;

        //全局钩子常量
        private const int WH_MOUSE_LL = 14;

        //声明消息的常量,鼠标按下和释放
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        //保存任务栏的矩形区域
        private Rectangle taskBarRect;
        private Rectangle newTaskBarRect;

        //定义委托
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        private HookProc MouseHookProcedure;

        #endregion

        #region 声明Api函数，需要引入空间(System.Runtime.InteropServices)

        //寻找符合条件的窗口
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        //获取窗口的矩形区域
        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern int GetWindowRect(int hwnd, ref Rectangle lpRect);

        //安装钩子
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //卸载钩子
        [DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx")]
        public static extern bool UnhookWindowsHookEx(int hHook);

        //调用下一个钩子
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        //获取当前线程的标识符
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        //获取一个应用程序或动态链接库的模块句柄
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        //鼠标结构，保存了鼠标的信息
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEHOOKSTRUCT
        {
            public Point pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        #endregion

        public MouseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 安装钩子
        /// </summary>
        private void StartHook()
        {
            if (hMouseHook == 0)
            {
                hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

                if (hMouseHook == 0)
                {//如果设置钩子失败.

                    this.StopHook();
                    MessageBox.Show("Set windows hook failed!");
                }
            }
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        private void StopHook()
        {
            bool stop = true;

            if (hMouseHook != 0)
            {
                stop = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;

                if (!stop)
                {//卸载钩子失败

                    MessageBox.Show("Unhook failed!");
                }
            }
        }

        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                //把参数lParam在内存中指向的数据转换为MOUSEHOOKSTRUCT结构
                MOUSEHOOKSTRUCT mouse = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MOUSEHOOKSTRUCT));//鼠标

                //这句为了看鼠标的位置
                this.Text = "MousePosition:" + mouse.pt.ToString();

                if (wParam == WM_RBUTTONDOWN || wParam == WM_RBUTTONUP)
                { //鼠标按下或者释放时候截获

                    if (newTaskBarRect.Contains(mouse.pt))
                    { //当鼠标在任务栏的范围内

                        //如果返回1，则结束消息，这个消息到此为止，不再传递。
                        //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
                        return 1;
                    }
                }
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }


        #region Events

        private void MouseForm_Load(object sender, EventArgs e)
        {
            MouseHookProcedure = new HookProc(MouseHookProc);

            //taskBarHandle为返回的任务栏的句柄
            //Shell_TrayWnd为任务栏的类名
            int taskBarHandle = FindWindow("Shell_TrayWnd", null);

            //获得任务栏的区域
            //有一点要注意，函数返回时，taskBarRect包含的是窗口的左上角和右下角的屏幕坐标
            //就是说taskBarRect.Width和taskBarRect.Height是相对于屏幕左上角（0，0）的数值
            //这与c#的Rectangle结构是不同的
            GetWindowRect(taskBarHandle, ref taskBarRect);


            this.richTextBox1.Text = "taskBarRect.Location:" + taskBarRect.Location.ToString() + "\n";
            this.richTextBox1.Text += "taskBarRect.Size:" + taskBarRect.Size.ToString() + "\n\n";


            //构造一个c#中的Rectangle结构
            newTaskBarRect = new Rectangle(
            taskBarRect.X,
            taskBarRect.Y,
            taskBarRect.Width - taskBarRect.X,
            taskBarRect.Height - taskBarRect.Y
            );

            this.richTextBox1.Text += "newTaskBarRect.Location:" + newTaskBarRect.Location.ToString() + "\n";
            this.richTextBox1.Text += "newTaskBarRect.Size:" + newTaskBarRect.Size.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopHook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.StartHook();
            this.button1.Enabled = false;
            this.button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.StopHook();
            this.button1.Enabled = true;
            this.button2.Enabled = false;
        }



        #endregion


    }
}
