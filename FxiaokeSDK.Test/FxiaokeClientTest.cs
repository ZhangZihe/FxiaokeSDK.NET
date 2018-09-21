using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FxiaokeSDK.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public void CrmObjectDescribeTest()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmObjectDescribeRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                ApiName = "SalesOrderObj",
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
                                ["order_id"] = "987654321"
                            }
                        }
                    }
                }
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
        public void UpdateObj()
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
            var result = client.Execute(new CrmApprovalTaskActionRequest
            {
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                TaskId = "5ba34e35cc9da3a0693d10fb",
                ActionType = "agree",
                Opinion = "同意"
            });
            var json = JsonConvert.SerializeObject(request);
            Assert.IsTrue(result.Success, result.Message);
        }
    }
}
