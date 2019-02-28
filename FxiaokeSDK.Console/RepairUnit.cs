using FxiaokeSDK.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Console
{
    public class RepairUnit
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

        public static void 更新订单最后回款时间()
        {
            var orders = File.ReadAllLines("F://1.txt");
            foreach(var orderno in orders)
            {
                var orderResult = Client.Execute(new CrmDataQueryRequest
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    ApiName = "SalesOrderObj",
                    SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                    {
                        Offset = 0,
                        Limit = 1,
                        Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                        {
                            new CrmDataQueryRequest.CrmDataCondition()
                            {
                                Conditions = new JObject
                                {
                                    ["name"] = orderno,
                                }
                            }
                        }
                    }
                });

                var orderId = orderResult.Response.Datas.First()["_id"].ToString();
                var paymentResult = Client.Execute(new CrmDataQueryRequest
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    ApiName = "OrderPaymentObj",
                    SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                    {
                        Offset = 0,
                        Limit = 1,
                        Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                        {
                            new CrmDataQueryRequest.CrmDataCondition()
                            {
                                Conditions = new JObject
                                {
                                    ["order_id"] = orderId,
                                }
                            }
                        }
                    }
                });

                if (paymentResult.Response.Datas.Count == 0)
                    continue;

                var confirmTime = paymentResult.Response.Datas.Select(x => long.Parse(x["finance_confirm_time"]?.ToString() ?? "0")).Max();
                if (confirmTime == 0)
                    confirmTime = paymentResult.Response.Datas.Select(x => long.Parse(x["last_modified_time"].ToString())).Max();

                var updateResult = Client.Execute(new CrmDataUpdateRequest
                {
                    ApiName = "SalesOrderObj",
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    DataId = orderId,
                    Data = new JObject { ["UDDate2__c"] = confirmTime }
                });
                System.Console.WriteLine(orderno + "|" + updateResult.Success + "|" + updateResult.Message);
            }
            
        }
    }
}
