using FxiaokeSDK.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FxiaokeSDK.Test
{
    [TestClass]
    public class FxiaokeClientTest
    {
        private string AppAccessToken { get; set; }

        private string CorpAccessToken { get; set; }

        private string CorpId { get; set; }

        [TestInitialize]
        public void Setup()
        {
            FxiaokeConfig.AppId = "FSAID_1317d08";
            FxiaokeConfig.AppSecret = "b2b75ca5885c47a18cc7724458b56c5c";
            FxiaokeConfig.PermanentCode = "1E1D1E3108E008A52EB7EBACB2779A28";

            var client = new FxiaokeClient();
            var result0 = client.Execute(new CorpAccessTokenGetRequest());
            Assert.IsTrue(result0.Success, result0.Message);

            var result1 = client.Execute(new AppAccessTokenGetRequest());
            Assert.IsTrue(result1.Success, result1.Message);

            AppAccessToken = result1.Response.AppAccessToken;
            CorpAccessToken = result0.Response.CorpAccessToken;
            CorpId = result0.Response.CorpId;
        }

        [TestMethod]
        public void ExecuteTest()
        {
            var jsonParam = new JObject
            {
                ["corpAccessToken"] = CorpAccessToken,
                ["corpId"] = CorpId,
            };
            jsonParam["fetchChild"] = false;
            jsonParam["departmentId"] = 999999;

            var client = new FxiaokeClient();
            var result = client.Execute("/cgi/user/simpleList", jsonParam.ToString());
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void CrmDataQueryV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataQueryV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_E52ABBD03C50251FC961C853B4A3C6A5",
                Data = new CrmDataQueryV2Request.CrmDataQueryData
                {
                    DataObjectApiName = "PriceBookObj",
                }
            });
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void DepartmentListTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new DepartmentListRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
            });
            Assert.IsTrue(result.Success, result.Message);
        }


        [TestMethod]
        public void UserSimpleListTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new UserSimpleListRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                DepartmentId = 999999,
            });
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void CrmDataQueryTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "SalesOrderObj",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 1000,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject
                            {
                                ["UDSText1__c"] = new JArray(){"12"}
                            }
                        }
                    }
                }

            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var client = new FxiaokeClient();
            var request = new UserGetRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                OpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void GetAccountObjTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "AccountObj",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 1000,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject
                            {
                                ["account_id"] = "cefa92170d6e49ad8321ce3997986a95"
                            }
                        }
                    }
                }

            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void GetSalesOrderObjTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "SalesOrderObj",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 1000,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject
                            {
                                ["name"] = "O20180906-0007"
                            }
                        }
                    }
                    //,Orders = new List<CrmDataQueryRequest.CrmDataOrder>()
                    //{
                    //    new CrmDataQueryRequest.CrmDataOrder()
                    //    {
                    //        Ascending = false,
                    //        Field = "create_time"
                    //    }
                    //}
                }

            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            long asd = 0;
            asd = long.Parse(result.Response.Datas[0]["order_time"].ToString());
            var time = new DateTime(asd);
            Assert.IsTrue(result.Success, result.Message);
        }



        [TestMethod]
        public void GetContractObjTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "ContractObj",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 1000,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
            {
                new CrmDataQueryRequest.CrmDataCondition()
                {
                    Conditions = new JObject
                    {
                        ["account_id"] = "O20180906-0007"
                    }
                }
            }
                    //,Orders = new List<CrmDataQueryRequest.CrmDataOrder>()
                    //{
                    //    new CrmDataQueryRequest.CrmDataOrder()
                    //    {
                    //        Ascending = false,
                    //        Field = "create_time"
                    //    }
                    //}
                }

            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }


        [TestMethod]
        public void GetMainObjTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "object_JyclH__c",
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = 0,
                    Limit = 10,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = new JObject
                            {
                                ["_id"] = "5b8f76b1494f6f37d87ea4ec"
                            }
                        }
                    }
                    //,Orders = new List<CrmDataQueryRequest.CrmDataOrder>()
                    //{
                    //    new CrmDataQueryRequest.CrmDataOrder()
                    //    {
                    //        Ascending = false,
                    //        Field = "create_time"
                    //    }
                    //}
                }

            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void JObjectTest()
        {
            //string jsonText = "[{'a':'aaa','b':'bbb','c':'ccc'},{'a':'aa','b':'bb,'c':'cc'}]";
            //JArray arrry = JArray.Parse(jsonText);
            var time = DateTime.Now.ToString("yyyy/MM/dd");
            Assert.IsNotNull(time);
        }

        [TestMethod]
        public void InsertLeadsObj()
        {
            var request = new CrmDataCreateRequest()
            {
                CorpAccessToken = CorpAccessToken,
                ApiName = "LeadsObj",
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                CorpId = CorpId,
                Data = new JObject
                {
                    ["source"] = "11",
                    ["marketing_event_id"] = "beac613ad90849c796f075753e9d033b",
                    ["name"] = "123",
                    ["mobile"] = "13712312312",
                    ["UDInt1__c"] = "93123123",
                    ["remark"] = "店铺链接:www.baidu.com\r\n旺旺:ww191239"
                }
            };
            var client = new FxiaokeClient();
            var response = client.Execute(request);
            if (response != null && response.Response.ErrorCode == 0 && !string.IsNullOrEmpty(response.Response.DataId))
            {
                var ss = response;
            }
                Assert.IsTrue(response.Response.ErrorCode == 0);
        }
    }
}
