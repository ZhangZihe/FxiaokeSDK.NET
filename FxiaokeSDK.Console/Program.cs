using FxiaokeSDK.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("开始处理......");
            PerformanceSettle.Init();
            PerformanceSettle.Start();

            System.Console.WriteLine("处理完成!");
            System.Console.ReadLine();
        }
    }
}
