using FxiaokeSDK.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            //PerformanceSettle.QueryAccount();
            //PerformanceSettle.Start(DateTime.Now);
            PerformanceSettle.Check(new DateTime(2019, 10, 1)); //业绩结算单自动核对功能
            //RepairUnit.Init();
            //RepairUnit.更新订单最后回款时间();

            System.Console.WriteLine("处理完成!");
            System.Console.ReadLine();
        }
    }
}
