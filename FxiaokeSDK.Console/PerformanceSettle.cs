using FxiaokeSDK.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Console
{
    public class PerformanceSettle
    {
        private static string AppAccessToken;
        private static string CorpAccessToken;
        private static string CorpId;
        private static string DefaultOpenUserId = System.Configuration.ConfigurationManager.AppSettings.Get("fxiaoke_defaultOpenUserId");
        private static FxiaokeClient Client = new FxiaokeClient();

        public static void Init()
        {
            var result0 = Client.Execute(new CorpAccessTokenGetRequest());
            var result1 = Client.Execute(new AppAccessTokenGetRequest());

            AppAccessToken = result1.Response.AppAccessToken;
            CorpAccessToken = result0.Response.CorpAccessToken;
            CorpId = result0.Response.CorpId;
        }

        public static void Start()
        {
            int size = 100;
            for(var page = 1; page < 10; page++)
                Start((page - 1) * size, size);
        }

        public static void Start(int offset, int limit)
        {
            var result = Client.Execute(new CrmDataQueryRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = DefaultOpenUserId,
                ApiName = "object_112ft__c",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = offset,
                    Limit = limit,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject
                            {
                                ["field_w7706__c"] = "jU4rV1qjg", //已确认: 否
                                ["field_8z4KD__c"] = 0, //待回款金额: 0
                            }
                        }
                    }
                }
            });

            if (!result.Success)
            {
                System.Console.WriteLine($"加载待处理数据失败:{result.Message}");
                return;
            }
            if (result.Response.Datas.Count == 0)
            {
                System.Console.WriteLine("没有需要处理的数据");
                return;
            }

            var resultMsg = new List<string>();
            foreach(var item in result.Response.Datas.Take(100))
            {
                var 业绩结算单 = item["name"].ToString();
                var 是否已确认 = item["field_w7706__c"].ToString(); //option1: 是, jU4rV1qjg: 否, other: 其他
                var 待回款 = decimal.Parse(item["field_8z4KD__c"].ToString());
                var 订单类型 = item["field_ioOM2__c"].ToString(); //1: 新签, 2: 续约, 3: 升级, 4: 断约新签, 5: 增值
                var 合同是否已上传 = item["field_83YtS__c"].ToString(); //是, 否

                if (订单类型 != "5" && 合同是否已上传 != "是") //不是增值, 需要上传合同
                    continue;

                if (待回款 != 0) //过滤未回款
                    continue;

                if (是否已确认 == "option1") //过滤已确认
                    continue;

                var 可结算日期 = DateTime.Now.Date.ToUnixStamp(); //field_dB02P__c
                var 业务管理确认时间 = DateTime.Now.ToUnixStamp(); //field_C46uu__c
                var 已确认 = "option1"; //field_w7706__c

                var updateResult = Client.Execute(new CrmDataUpdateRequest
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    ApiName = "object_112ft__c",
                    DataId = item["_id"].ToString(),
                    Data = new
                    {
                        field_dB02P__c = 可结算日期,
                        field_C46uu__c = 业务管理确认时间,
                        field_w7706__c = 已确认,
                    }
                });
                var line = $"{业绩结算单},{updateResult.Success},{updateResult.Message}";
                resultMsg.Add(line);
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine($"已处理完成数:{resultMsg.Count}/{result.Response.Datas.Count}");
        }
    }
}
