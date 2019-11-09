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
            foreach (var orderno in orders)
            {
                var orderResult = Client.Execute(new CrmDataQueryV2Request
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    Data = new CrmDataQueryV2Request.CrmDataQueryData
                    {
                        DataObjectApiName = "SalesOrderObj",
                        Search_query_info = new CrmDataQueryV2Request.CrmDataSearchQueryInfo
                        {
                            Offset = 0,
                            Limit = 1,
                            Filters = new List<CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter>
                            {
                                new CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter
                                {
                                    Field_name = "name",
                                    Field_values = new List<string>{ orderno.ToString() },
                                    Operator = "EQ"
                                },
                            }
                        }
                    }
                });

                var orderId = orderResult.Response.Data.DataList.First()["_id"].ToString();
                var paymentResult = Client.Execute(new CrmDataQueryV2Request
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,                    
                    Data = new CrmDataQueryV2Request.CrmDataQueryData
                    {
                        DataObjectApiName = "OrderPaymentObj",
                        Search_query_info = new CrmDataQueryV2Request.CrmDataSearchQueryInfo
                        {
                            Offset = 0,
                            Limit = 1,
                            Filters = new List<CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter>
                            {
                                new CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter
                                {
                                    Field_name = "order_id",
                                    Field_values = new List<string>{ orderId.ToString() },
                                    Operator = "EQ"
                                }
                            }
                        }
                    }
                });

                if (paymentResult.Response.Data.Total == 0)
                    continue;

                var confirmTime = paymentResult.Response.Data.DataList.Select(x => long.Parse(x["finance_confirm_time"]?.ToString() ?? "0")).Max();
                if (confirmTime == 0)
                    confirmTime = paymentResult.Response.Data.DataList.Select(x => long.Parse(x["last_modified_time"].ToString())).Max();

                var updateResult = Client.Execute(new CrmDataUpdateV2Request
                {
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    Data = new CrmDataUpdateV2Request.CrmDataUpdateV2Data
                    {
                        Object_data = new JObject
                        {
                            ["dataObjectApiName"] = "SalesOrderObj",
                            ["_id"] = orderId,
                            ["UDDate2__c"] = confirmTime
                        }
                    }
                });
                System.Console.WriteLine(orderno + "|" + updateResult.Success + "|" + updateResult.Message);
            }

        }
    }
}
