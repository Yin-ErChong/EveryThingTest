using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class BaiduTest : TestBase, ITestBase
    {
        private static BaiduTest _Instance;
        public static BaiduTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BaiduTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        public int getValue(List<int> powerValueInt, int need)
        {
            int value = powerValueInt.Where(n=> Math.Abs(n - need)== powerValueInt.Min(l => Math.Abs(l - need))).First();
            powerValueInt.Remove(value);
            return value;
        }
        public int makeMin(List<int> intList,int cou)
        {
            int min= intList.FirstOrDefault(n=>n!=0);
            for (int i = 0; i < cou; i++)
            {
                if (intList[i]!=0)
                {
                    intList[i] = intList[i] - min;
                }
            }
            return min;
        }
        public override void Start()
        {
            string number = System.Console.ReadLine();
            string line = System.Console.ReadLine();
            string[] numStr = number.Split();
            string[] powerValueStr = line.Split();
            int count = int.Parse(numStr[0]);
            int num = int.Parse(numStr[1]);
            List<int> powerValueInt = new List<int>();
            for (int i = 0; i < count; i++)
            {
                powerValueInt.Add(int.Parse(powerValueStr[i]));
            }
            powerValueInt.Sort();
            for (int i = 0; i < num; i++)
            {
                System.Console.WriteLine(makeMin(powerValueInt, count));
            }



            //例3
            //string numstr = System.Console.ReadLine();
            //int T = int.Parse(numstr);
            //for (int j = 0; j < T; j++)
            //{
            //    string number = System.Console.ReadLine();
            //    string line = System.Console.ReadLine();
            //    int num = int.Parse(number);
            //    string[] powerValueStr = line.Split();
            //    List<int> powerValueInt = new List<int>();
            //    for (int i = 0; i < num; i++)
            //    {
            //        powerValueInt.Add(int.Parse(powerValueStr[i]));
            //    }
            //    List<int> GroupA = new List<int>();
            //    List<int> GroupB = new List<int>();
            //    GroupA.Add(getValue(powerValueInt, powerValueInt.Max()));
            //    GroupB.Add(getValue(powerValueInt, powerValueInt.Max()));
            //    int Asum = GroupA.Sum();
            //    int Bsum = GroupB.Sum();
            //    bool flag = true;
            //    if (Asum>= Bsum)
            //    {
            //        flag = false;
            //    }

            //    while (powerValueInt.Any())
            //    {
            //        if (flag)
            //        {
            //            int need = 0;
            //            if (Asum<=Bsum)
            //            {
            //                need= Bsum - Asum;
            //            }                        
            //            GroupA.Add(getValue(powerValueInt, need));
            //            Asum = GroupA.Sum();
            //            flag = false;
            //        }
            //        else
            //        {
            //            int need = 0;
            //            if (Bsum <= Asum)
            //            {
            //                need = Asum - Bsum;
            //            }
            //            GroupB.Add(getValue(powerValueInt, need));
            //            Bsum = GroupB.Sum();
            //            flag = true;
            //        }
            //    }
            //    if (Asum <= Bsum)
            //    {
            //        System.Console.WriteLine(Asum.ToString() + ' ' + Bsum.ToString());
            //    }
            //    else
            //    {
            //        System.Console.WriteLine(Bsum.ToString() + ' ' + Asum.ToString());
            //    }

            //}
            //例1
            //string numstr = System.Console.ReadLine();
            //int T = int.Parse(numstr);
            //for (int j = 0; j < T; j++)
            //{
            //    string number = System.Console.ReadLine();
            //    string line= System.Console.ReadLine();
            //    if (line.Contains('8') && line.Count() == 11)
            //    {
            //        System.Console.WriteLine("YES");
            //    }
            //    else {
            //        System.Console.WriteLine("NO");
            //    }

            //}
            //string numstr= System.Console.ReadLine();
            //int T = int.Parse(numstr);
            //for (int j = 0; j< T; j++)
            //{
            //    string line = System.Console.ReadLine();
            //    string[] tokens = new string[2];
            //    tokens = line.Split();
            //    int n = int.Parse(tokens[0]);
            //    int m = int.Parse(tokens[1]);
            //    int[] begin = new int[2];
            //    int[] end = new int[2];
            //    for (int i = 0; i < m; i++)
            //    {
            //        string linkstr = System.Console.ReadLine();
            //        string[] linkAry = new string[2];
            //        linkAry = linkstr.Split();
            //        if (int.Parse(linkAry[0]) == 1)
            //        {
            //            begin[0] = int.Parse(linkAry[0]);
            //            begin[1] = int.Parse(linkAry[1]);
            //        }
            //        if (int.Parse(linkAry[1]) == n)
            //        {
            //            end[0] = int.Parse(linkAry[0]);
            //            end[1] = int.Parse(linkAry[1]);
            //        }
            //    }
            //    if (begin[1]==end[0])
            //    {
            //        System.Console.WriteLine("POSSIBLE");
            //    }
            //    else
            //    {
            //        System.Console.WriteLine("IMPOSSIBLE");
            //    }
            //}

            //try
            //{
            //    string line;
            //    string[] tokens = new string[3];
            //    line = System.Console.ReadLine();
            //    tokens = line.Split();
            //    int n = int.Parse(tokens[0]);
            //    int m = int.Parse(tokens[1]);
            //    int a = n;
            //    int b = m;
            //    int k = int.Parse(tokens[2]);
            //    int X = a + b;
            //    for (int i = 0; i <= n; i++)
            //    {
            //        for (int j = 0; j <= m; j++)
            //        {
            //            if ((n - i) * (m - j) <= k && (i + j) < X)
            //            {
            //                a = i;
            //                b = j;
            //                X = a + b;
            //            }
            //        }
            //    }
            //    System.Console.WriteLine(X);
            //    Console.Read();
            //}
            //catch (Exception ee)
            //{

            //    throw;
            //}

        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
}
