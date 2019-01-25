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
            //PerformanceSettle.Start();
            //业绩结算单自动核对功能
            PerformanceSettle.Check();
            System.Console.WriteLine("处理完成!");
            System.Console.ReadLine();
        }
    }
}
