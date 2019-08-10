using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                Operation.BeginInvoke(i * 10, result =>
                {
                    Console.WriteLine($"第{result.AsyncState}个结果为{Operation.EndInvoke(result)}");
                  
                }, i);
            
            }
            Console.Read();
        }


        private static Random random = new Random();

        private static Func<int, int> Operation = num =>
        {
            Thread.Sleep(random.Next(5) * 1000);
            return num * num;
        };
    }
}
