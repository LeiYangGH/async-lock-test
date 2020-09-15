using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asynclock
{
    class Program
    {
        static int n = 0;
        static object o = new object();

        //这里是模拟一些库函数，也就是不属于当前项目，无法修改
        static void WriteIncreasedNumber()
        {
            Task.Run(() =>
            {
                Console.WriteLine(n++);
                Thread.Sleep(1000);//模拟一些耗时操作
            });

        }
        //目标：让输出的数字变得有序递增
        static void Main(string[] args)
        {

            AutoResetEvent ev = new AutoResetEvent(false);
            for (int i = 0; i < 10; i++)
            {
                while (ev.WaitOne(1, false) == false)
                {
                    WriteIncreasedNumber();
                    ev.Set();
                }
            }
            Console.ReadKey();
        }
    }
}
