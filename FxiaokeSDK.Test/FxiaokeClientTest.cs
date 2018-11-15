using FxiaokeSDK.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;

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
        public void CrmObjectDescribeTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmObjectDescribeRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                ApiName = "PaymentObj",
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98"
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
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
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
                                ["name"] = "彤星旗舰店"
                            }
                        }
                    }
                }
            };
            
            var result = client.Execute(request);
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
        public void CrmDataUpdateTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataUpdateRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                ApiName = "AccountObj",
                DataId = "433538f175e94e00ba9ec350bfc65fb6",
                Data = new { owner = new List<string> { "FSUID_FACEAA83D4F0EE9591CDB911563EECBC" }, owner_department = "技术部" }
            };

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
        public void MediaUploadTest()
        {
            var contractUrl = "http://imgcache.mysodao.com/img3/M05/C8/1A/CgAPD1vBwy6XH_vBAAICT-xHJwc187-793b94a8.PNG";
            var data = new HttpClient().GetByteArrayAsync(contractUrl).Result;

            var client = new FxiaokeClient();
            var result = client.Execute(new MediaUploadRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                Type = "image",
                Media = data,
                ExtName = "png",
            }).Result;
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void MediaDownloadTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new MediaDownloadRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                MediaId = "07e9312c-253a-4c5c-8915-b7e384ae6534", //07e9312c-253a-4c5c-8915-b7e384ae6534
            });
            byte[] data = new byte[client.Response.ContentLength];
            result.Response.Read(data, 0, data.Count());
            File.Create("F://a.png").Write(data, 0, data.Count());

            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void MediaDeleteTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new MediaDeleteRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                MediaId = "dd1b088b-f9ae-45ab-b2fd-3965a2a2ce1a",
            });
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void CrmApprovalTaskActionTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmApprovalTaskActionRequest
            {
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                TaskId = "5ba34e35cc9da3a0693d10fb",
                ActionType ="agree",
                Opinion ="同意"
            };
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void MessageSendTest()
        {
            var dt = DateTime.Parse("2018年1月1日");

            var client = new FxiaokeClient();
            var request = new AppMessageSendRequest
            {
                ServiceId = "FSAID_bec70df",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                ToUser = new List<string> { "FSUID_F3CFD1CDE9A5BCBA03D30CD150CDBFD7", "FSUID_0E31705CE1F0CF0D0F85DCE8FABD5D08" },
                MsgType = "text",
                Text = new MessageSendRequest.MessageText
                {
                    Content = "子何 邀请您参加会议 【内部系统需求对接】，会议时间：2018-11-8，请准时参加，会议内容：对接会议室预约系统需求",
                },
            };
            var result = client.Execute(request);
            Assert.IsTrue(result.Success, result.Message);
        }

        public List<JObject> QueryData(string apiName, JObject param, int limit, int offset = 0)
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataQueryRequest()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                ApiName = apiName,
                SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
                {
                    Offset = offset,
                    Limit = limit,
                    Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
                    {
                        new CrmDataQueryRequest.CrmDataCondition()
                        {
                            Conditions = param
                        }
                    }
                }
            });
            return result.Response.Datas;
        }

        [TestMethod]
        public void RemindTest()
        {
            //相同联系人的客户被签约增加CRM通知提醒, 避免业务员下的店铺被签约
            var orderId = "O20181114-9555";
            var orderResult = QueryData("SalesOrderObj", new JObject { ["name"] = orderId }, 1);

            var account_id = orderResult?.FirstOrDefault()?["account_id"]?.ToString();
            var record_type = orderResult?.FirstOrDefault()?["record_type"]?.ToString();//default__c//record_fo0Ke__c
            var contactResult = QueryData("ContactObj", new JObject { ["account_id"] = account_id }, 10);

            var accountIds = new List<string>();
            foreach (var item in contactResult)
            {
                var paramPair = new Dictionary<string, string>
                {
                    //{ "name", item["name"]?.ToString() },
                    { "UDInt1__c", item["UDInt1__c"]?.ToString() },
                    { "UDSText1__c", item["UDSText1__c"]?.ToString() },
                    { "mobile1", item["mobile1"]?.ToString() },
                    { "mobile2", item["mobile2"]?.ToString() },
                    { "mobile3", item["mobile3"]?.ToString() },
                }.Where(x => !string.IsNullOrWhiteSpace(x.Value)).ToList();
                
                foreach (var param in paramPair)
                {
                    var similarContactResult = QueryData("ContactObj", new JObject
                    {
                        [param.Key] = param.Value,
                        ["record_type"] = record_type == "default__c" ? "default__c" : "record_VKNvX__c"//default__c/record_VKNvX__c
                    }, 100);

                    var similarAccountIds = similarContactResult?.Where(x => x["owner"] != null && x["owner"]?.ToString() != "0").Select(x => x["account_id"]?.ToString());
                    accountIds.AddRange(similarAccountIds);
                }
            }
            accountIds = accountIds.Where(x => !string.IsNullOrWhiteSpace(x) && x != account_id).ToList();

            var accountNames = new List<string>();
            var owners = new List<string>();
            foreach(var item in accountIds)
            {
                var accountReuslt = QueryData("AccountObj", new JObject
                {
                    ["_id"] = item,
                    ["record_type"] = record_type == "default__c" ? "default__c" : "record_4sojg__c"//default__c/record_4sojg__c
                }, 1);
                var owner = accountReuslt?.FirstOrDefault()?["owner"]?.ToString();
                owners.Add(owner);

                accountNames.Add(accountReuslt?.FirstOrDefault()?["name"]?.ToString());
            }
            var names = string.Join(",", accountNames);
        }
    }
}
