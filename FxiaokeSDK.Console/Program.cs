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
            var client = new FxiaokeClient();
            var result = client.Execute(new CorpAccessTokenGetRequest());

            System.Console.WriteLine(JsonConvert.SerializeObject(result));
            System.Console.ReadLine();
        }
    }
}
