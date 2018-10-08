using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace clcok
{
    public class ClockEventArgs : EventArgs
    {
    }
    public delegate void ClockEventHandle(object obj, ClockEventArgs Args);//委托声明
    public class Clock
    {
        public event ClockEventHandle Clocking;//声明事件
        public void Response()
        {
            if (Clocking != null)
            {
                ClockEventArgs args = new ClockEventArgs();
                Clocking(this, args);//每触发一次事件，通知一次外界
            }
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入闹钟小时：");
            string h = Console.ReadLine();
            try
            {
                while (Int32.Parse(h) > 23 || Int32.Parse(h) < 0)
                {
                    Console.WriteLine("输入不合理，请重新输入小时：");
                    h = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("输入不合理，请重新输入小时：");
            }

            Console.WriteLine("请输入闹钟分钟: ");
            string m = Console.ReadLine();
            try
            {
                if (m.Length == 1)
                    m = "0" + m;
                while (Int32.Parse(m) > 59 || Int32.Parse(m) < 0)
                {
                    Console.WriteLine("输入不合理，请重新输入分钟：");
                    m = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("输入不合理，请重新输入分钟：");
            }

            Console.WriteLine("请输入闹钟秒钟: ");
            string s = Console.ReadLine();
            try
            {
                if (s.Length == 1)
                    s = "0" + s;
                while (Int32.Parse(s) > 59 || Int32.Parse(s) < 0)
                {
                    Console.WriteLine("输入不合理，请重新输入秒钟：");
                    s = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("输入不合理，请重新输入秒钟：");
            }

            string setTime = h + ":" + m+":"+s;


            var clock = new Clock();//注册一个闹钟
            string now_t = DateTime.Now.ToShortTimeString().ToString();
            Console.WriteLine("现在是：" + now_t);
            while (now_t != setTime)
            {
                Thread.Sleep(1000);//每一秒钟判断一次当前时间
                now_t = DateTime.Now.ToLongTimeString().ToString();
                Console.WriteLine("现在是：" + now_t);
            }
            clock.Clocking += Ring;
            clock.Response();
        }
        static void Ring(object sender, ClockEventArgs e)
        {
            Console.WriteLine("~~~时间到啦~~~");
        }
    }
}
