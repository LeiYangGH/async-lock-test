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
        static void WriteIncreasedNumber()
        {
            Console.WriteLine(n++);
            Thread.Sleep(1000);//模拟一些耗时操作
        }
        //目标：让输出的数字变得有序递增
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                //不要去掉Task.Run，是为了异步执行，不阻塞主线程
                Task.Run(() =>
                {
                    WriteIncreasedNumber();
                });
            }
            Console.ReadKey();
        }
    }
}
