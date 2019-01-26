using FxiaokeSDK.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FxiaokeSDK.Response;
using Newtonsoft.Json;

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

        /// <summary>
        /// 业绩结算单自动核对功能
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        public static void Check()
        {
            var size = 100;
            for (var page = 1; page <= 10; page++)
            {
                Check((page - 1) * size, size);
            }
        }

        public static void Check(int offset, int limit)
        {
            //分页查出当月订单
            var orderResult = QueryOrderOfTheMonth(offset, limit);
            if (!orderResult.Success)
            {
                System.Console.WriteLine($"查询当月订单失败,errorMsg:{orderResult.Message}");
                return;
            }

            if (orderResult.Response.Datas.Count == 0)
            {
                System.Console.WriteLine("没有需要处理的订单数据");
                return;
            }

            var orderList = orderResult.Response.Datas;

            foreach (var order in orderList)
            {
                //var index = orderList.IndexOf(order) + 1;
                //if (index % 10 == 0)
                //    System.Console.WriteLine($"当前处理:{index}/{orderList.Count}"); 
                
                if(order["order_status"].ToString() != "7")
                {
                    //System.Console.WriteLine($"订单{order["name"].ToString()}不是已确认订单不创建业绩结算单");
                    continue;
                }

                var labels = JsonConvert.DeserializeObject<List<int>>(order["UDMSel1__c"].ToString());
                if (labels.Contains(3) && (labels.Contains(1) || labels.Contains(2)))
                {
                    //System.Console.WriteLine($"订单{order["name"].ToString()}不是已回款的多店订单不创建业绩结算单");
                    continue;
                }

                //计算出订单业绩结算金额
                var amount = CalculateAmount(order, out string msg);
                if (amount == decimal.Zero)
                {                    
                    //System.Console.WriteLine($"计算订单{order["name"].ToString()}金额为0不创建业绩结算单");
                    continue;
                }
                   
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    System.Console.WriteLine($"计算订单{order["name"].ToString()}业绩失败,errorMsg:{msg}");
                    continue;
                }
                //查出订单的业绩结算单

                var performanceResult = QueryPerformance(order);

                if (!performanceResult.Success)
                {
                    System.Console.WriteLine(
                        $"订单{order["name"].ToString()}查询业绩结算单失败,errorMsg:{performanceResult.Message}");
                    continue;
                }

                if (performanceResult.Response.Datas.Count == 0)
                {
                    System.Console.WriteLine($"订单{order["name"].ToString()}查询不到业绩结算单");
                    continue;
                }

                var performance = performanceResult.Response.Datas[0];
                if (amount != decimal.Parse(performance["field_24rnT__c"].ToString()))
                {
                    System.Console.WriteLine($"订单{order["name"].ToString()}业绩结算单金额和程序计算出的金额不同");
                    continue;
                }              
            }
        }

        /// <summary>
        /// 查出当月订单
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private static ApiResult<CrmDataQueryResponse> QueryOrderOfTheMonth(int offset,int limit)
        {
            var now = DateTime.Now;
            var firstDayOfTheMonth=new DateTime(DateTime.Now.Year,now.Month,1);
            var nextMonth = now.Month == 12
                ? new DateTime(DateTime.Now.Year + 1, 1, 1)
                : new DateTime(DateTime.Now.Year, now.Month + 1, 1);
            var lastDayOfTheMonth = nextMonth.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddMilliseconds(999);
            var result = Client.Execute(new CrmDataQueryRequest()
            {
                ApiName = "SalesOrderObj",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = DefaultOpenUserId,
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
                                ["order_status"] = "7"
                            }
                        }
                    },
                    RangeConditions = new List<object>()
                    {
                        new JObject()
                        {
                            ["fieldName"] = "create_time",
                            ["from"] = firstDayOfTheMonth.ToUnixStamp(),
                            ["to"] = lastDayOfTheMonth.ToUnixStamp()
                        }
                    }
                }
            });
            return result;
        }

        /// <summary>
        /// 计算业绩结算单金额
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static decimal CalculateAmount(JObject obj,out string msg)
        {
            decimal disAmount = 0;
            var salesOrdersProductResult = Client.Execute(new CrmDataQueryRequest()
            {
                ApiName = "SalesOrderProductObj",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = DefaultOpenUserId,
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 1000,
                    Conditions =new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject()
                            {
                                ["order_id"] = obj["_id"].ToString(),
                            }
                        }                      
                    }
                }
            });
            if (!salesOrdersProductResult.Success)
            {
                msg = $"订单{obj["name"].ToString()}查询订单产品失败";
                return 0;
            }

            var orderProductList = salesOrdersProductResult.Response.Datas;
            foreach (var orderProduct in orderProductList)
            {
                var productResult = Client.Execute(new CrmDataQueryRequest()
                {
                    ApiName = "ProductObj",
                    CorpAccessToken = CorpAccessToken,
                    CorpId = CorpId,
                    CurrentOpenUserId = DefaultOpenUserId,
                    SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                    {
                        Limit = 10,
                        Offset = 0,
                        Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                        {
                            new CrmDataQueryRequest.CrmDataCondition()
                            {
                                Conditions = new JObject()
                                {
                                    ["_id"] = orderProduct["product_id"].ToString()
                                }
                            }
                        }                               
                    }
                });
                if (!productResult.Success)
                {
                    msg = $"订单{obj["name"].ToString()}查询产品失败";
                    return 0;
                }

                if (productResult.Response.Datas.Count == 0)
                {
                    msg = $"订单{obj["name"].ToString()}查询产品失败";
                    return 0;
                }

                var product = productResult.Response.Datas[0];
                if (product["field_x99U7__c"] != null)
                {
                    decimal.TryParse(product["field_x99U7__c"]?.ToString() ?? "0", out decimal field_x99U7__c);
                    int.TryParse(orderProduct["quantity"].ToString().Split('.')[0], out int quantity);
                    disAmount += field_x99U7__c * quantity;
                }
            }

            var orderAmount = decimal.Parse(obj["order_amount"].ToString());
            decimal promotionCode = 0;
            if (obj["UDMoney1__c"] != null)
                promotionCode = decimal.Parse(obj["UDMoney1__c"].ToString());

            decimal amount = orderAmount - promotionCode - disAmount;
            if (amount <= 0)
            {
                msg = string.Empty;
                return decimal.Zero;

            }

            msg = string.Empty;
            return amount;
        }


        private static ApiResult<CrmDataQueryResponse> QueryPerformance(JObject obj)
        {
            var result = Client.Execute(new CrmDataQueryRequest()
            {
                ApiName = "object_112ft__c",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = DefaultOpenUserId,
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 10,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject()
                            {
                                ["field_jEU08__c"] = obj["_id"]
                            }
                        }
                    }
                }
            });
            return result;
        }

    }
}
