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

            FxiaokeConfig.AppId = "FSAID_1317cf4";
            FxiaokeConfig.AppSecret = "7faded1267ba492aa3eafe1aae12e86e";
            FxiaokeConfig.PermanentCode = "4EB0845137A6411E69850DFC5A94BB1E";

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
            var result = client.Execute(new CrmObjectDescribeV2Request
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
            //var client = new FxiaokeClient();
            //var request = new CrmDataQueryRequest()
            //{
            //    CorpAccessToken = CorpAccessToken,
            //    CorpId = CorpId,
            //    CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
            //    ApiName = "AccountObj",
            //    SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
            //    {
            //        Offset = 0,
            //        Limit = 1000,
            //        Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
            //        {
            //            new CrmDataQueryRequest.CrmDataCondition()
            //            {
            //                Conditions = new JObject
            //                {
            //                    ["name"] = "彤星旗舰店"
            //                }
            //            }
            //        }
            //    }
            //};

            //var result = client.Execute(request);
            //Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void CrmDataUpdateTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataUpdateV2Request()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                //ApiName = "AccountObj",
                //DataId = "433538f175e94e00ba9ec350bfc65fb6",
                //Data = new { owner = new List<string> { "FSUID_FACEAA83D4F0EE9591CDB911563EECBC" }, owner_department = "技术部" }
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
        public void SendMessage()
        {
            var client = new FxiaokeClient();
            var request = new AppMessageSendRequest
            {
                ServiceId = "FSAID_bec70df",
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                ToUser = new List<string>() { "FSUID_DEB7D1E884217C1868AC2128BF6F64FF" },
                MsgType = "text",
                Text = new MessageSendRequest.MessageText
                {
                    Content = "测试数据",
                },
            };
            var result = client.Execute(request);
        }

        [TestMethod]
        public void GetSalesOrderObjTest()
        {
            var client = new FxiaokeClient();
            var request = new CrmDataQueryV2Request()
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                Data = new CrmDataQueryV2Request.CrmDataQueryData
                {
                    DataObjectApiName = "SalesOrderObj",
                    Search_query_info = new CrmDataQueryV2Request.CrmDataSearchQueryInfo
                    {
                        Offset = 0,
                        Limit = 1000,
                        Filters = new List<CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter>
                            {
                                new CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter
                                {
                                    Field_name = "name",
                                    Field_values = new List<string>{ "O20180906-0007" },
                                    Operator = "EQ"
                                }
                            },
                        Orders = new List<CrmDataQueryV2Request.CrmDataSearchQueryInfoOrder>
                        {
                            new CrmDataQueryV2Request.CrmDataSearchQueryInfoOrder
                            {
                                IsAsc = false,
                                FieldName = "create_time"
                            }
                        }
                    }
                }
            };
            var json = JsonConvert.SerializeObject(request);
            var result = client.Execute(request);
            long asd = 0;
            asd = long.Parse(result.Response.Data.DataList[0]["order_time"].ToString());
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
                ActionType = "agree",
                Opinion = "同意"
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
            return new List<JObject>();
            //var client = new FxiaokeClient();
            //var result = client.Execute(new CrmDataQueryRequest()
            //{
            //    CorpAccessToken = CorpAccessToken,
            //    CorpId = CorpId,
            //    CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
            //    ApiName = apiName,
            //    SearchQuery = new CrmDataQueryRequest.CrmDataSearchQuery()
            //    {
            //        Offset = offset,
            //        Limit = limit,
            //        Conditions = new List<CrmDataQueryRequest.CrmDataCondition>()
            //        {
            //            new CrmDataQueryRequest.CrmDataCondition()
            //            {
            //                Conditions = param
            //            }
            //        }
            //    }
            //});
            //return result.Response.Datas;
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
            foreach (var item in accountIds)
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

        [TestMethod]
        public void ChangeSaleStageTest()
        {
            var client = new FxiaokeClient();

            var request = new CrmDataChangeSalesStageRequest
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                ApiName = "SaleActionObj",
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98",
                OpportunityId = "440a084a95774cc4bb81a6da73bbc647",
                DataId = "df79c3f84c66455c88cae58ecb8f8464",
                NextSaleStageId = "9e8bbec5b2284641aeaf5ec42b0ab2ed"
            };

            var reponse = client.Excute(request);
        }

        #region  CRM对象接口V2

        [TestMethod]
        public void CrmObjectListV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmObjectListV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_0642D2A6D0AC2FEDF2BF0930E9469F98"
            });

        }

        [TestMethod]
        public void CrmDataQueryV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataQueryV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataQueryV2Request.CrmDataQueryData
                {
                    DataObjectApiName = "LeadsObj",
                    Search_query_info = new CrmDataQueryV2Request.CrmDataSearchQueryInfo
                    {
                        Offset = 0,
                        Limit = 100,
                        Filters = new List<CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter>
                        {
                            new CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter
                            {
                                Field_name = "name",
                                Field_values = new List<string>{ "聚客通官网注册用户" },
                                Operator = "EQ"
                            },
                            new CrmDataQueryV2Request.CrmDataSearchQueryInfoFilter
                            {
                                Field_name = "company",
                                Field_values = new List<string>{ "富裕" },
                                Operator = "EQ"
                            }
                        }
                    }
                }
            });
            var department = result.Response.Data.DataList[0]["mobile"];
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void CrmDataCreateV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataCreateV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataCreateV2Request.CrmDataCreateData
                {
                    Object_data = new JObject
                    {
                        ["dataObjectApiName"] = "LeadsObj",
                        ["name"] = "测试数据勿删",
                        ["leads_pool_id"] = "7a22188ad3ec408a86526c6850034106",
                        ["mobile"] = "12346578900",
                        ["source"] = "11"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmDateGetV2Test()
        {
            var client = new FxiaokeClient();
            var response = client.Execute(new CrmDataGetV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataGetV2Request.CrmDataGetV2Data
                {
                    DataObjectApiName = "LeadsObj",
                    ObjectDataId = "5dc4cefa038eaa0001c0586f"
                }
            });
            var name = response.Response.Data["name"];
        }

        [TestMethod]
        public void CrmDataUpdateV2Test()
        {
            var client = new FxiaokeClient();
            var response = client.Execute(new CrmDataUpdateV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataUpdateV2Request.CrmDataUpdateV2Data
                {
                    Object_data = new JObject
                    {
                        ["dataObjectApiName"] = "LeadsObj",
                        ["_id"] = "5dc4cefa038eaa0001c0586f",
                        ["name"] = "测试数据测试勿删",
                        ["record_type"] = "record_V417w__c"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmDataInvalidV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataInvalidV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataInvalidV2Request.CrmDataInvalidV2Data
                {
                    DataObjectApiName = "LeadsObj",
                    Object_data_id = "5dc4cefa038eaa0001c0586f"
                }
            });
        }

        [TestMethod]
        public void CrmDataRecoverV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataRecoverV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataRecoverV2Request.CrmDataRecoverV2Data
                {
                    DataObjectApiName = "LeadsObj",
                    IdList = new List<string>
                    {
                        "5dc4cefa038eaa0001c0586f"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmDataChangeOwenrV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmDataChangeOwnerV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataChangeOwnerV2Request.CrmDataChangeOwnerV2Data
                {
                    DataObjectApiName = "LeadsObj",
                    Data = new List<CrmDataChangeOwnerV2Request.CrmDataChangeOwnerV2DataData>
                    {
                        new CrmDataChangeOwnerV2Request.CrmDataChangeOwnerV2DataData
                        {
                            ObjectDataId = "5dc4cefa038eaa0001c0586f",
                            OwnerId = new List<string>
                            {
                                "FSUID_FACEAA83D4F0EE9591CDB911563EECBC"
                            }
                        }
                    }
                }
            });
        }

        [TestMethod]
        public void CrmDataDeleteV2Test()
        {
            var client = new FxiaokeClient();
            var resule = client.Execute(new CrmDataDeleteV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmDataDeleteV2Request.CrmDataDeleteV2Data
                {
                    DataObjectApiName = "LeadsObj",
                    IdList = new List<string>
                    {
                        "5dc4cefa038eaa0001c0586f"
                    }
                }
            });
        }

        #endregion

        #region  自定义对象接口

        [TestMethod]
        public void CrmCustomDataQueryV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataQueryV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataQueryV2Request.CrmCustomDataQueryData
                {
                    DataObjectApiName = "object_ZBcAC__c",
                    Search_query_info = new CrmCustomDataQueryV2Request.CrmCustomDataSearchQueryInfo
                    {
                        Offset = 0,
                        Limit = 100,
                        Filters = new List<CrmCustomDataQueryV2Request.CrmCustomDataSearchQueryInfoFilter>
                        { }
                    }
                }
            });
            var a = result.Response.Data.Total;
            Assert.IsTrue(result.Success, result.Message);
        }

        //"5dc5316d706c7e0001ea2382"
        [TestMethod]
        public void CrmCustomDataCreateV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataCreateV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataCreateV2Request.CrmCustomDataCreateData
                {
                    Object_data = new JObject
                    {
                        ["dataObjectApiName"] = "object_0cpq5__c",
                        ["name"] = "测试",
                        ["owner"] = new JArray() { "FSUID_FACEAA83D4F0EE9591CDB911563EECBC" }
                    }
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataUpdateV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataUpdateV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataUpdateV2Request.CrmCustomDataUpdateData
                {
                    Object_data = new JObject
                    {
                        ["dataObjectApiName"] = "object_0cpq5__c",
                        ["_id"] = "5dc5316d706c7e0001ea2382",
                        ["name"] = "测试数据勿删"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataGetV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataGetV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataGetV2Request.CrmCustomDataGetV2Data
                {
                    DataObjectApiName = "object_0cpq5__c",
                    ObjectDataId = "5dc5316d706c7e0001ea2382"
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataInvalidV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataInvalidV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataInvalidV2Request.CrmCustomDataInvalidV2Data
                {
                    DataObjectApiName = "object_0cpq5__c",
                    IdList = new List<string>
                    {
                        "5dc5316d706c7e0001ea2382"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataRecoverV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataRecoverV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataRecoverV2Request.CrmCustomDataRecoverV2Data
                {
                    DataObjectApiName = "object_0cpq5__c",
                    IdList = new List<string>
                    {
                        "5dc5316d706c7e0001ea2382"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataDeleteV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataDeleteV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataDeleteV2Request.CrmCustomDataDeleteV2Data
                {
                    DataObjectApiName = "object_0cpq5__c",
                    IdList = new List<string>
                    {
                        "5dc5316d706c7e0001ea2382"
                    }
                }
            });
        }

        [TestMethod]
        public void CrmCustomDataChangeOwnerV2Test()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CrmCustomDataChangeOwnerV2Request
            {
                CorpAccessToken = CorpAccessToken,
                CorpId = CorpId,
                CurrentOpenUserId = "FSUID_FACEAA83D4F0EE9591CDB911563EECBC",
                Data = new CrmCustomDataChangeOwnerV2Request.CrmCustomDataChangeOwnerV2Data
                {
                    DataObjectApiName = "object_0cpq5__c",
                    DataList = new List<CrmCustomDataChangeOwnerV2Request.CrmCustomDataChangeOwnerV2DataData>
                    {
                        new CrmCustomDataChangeOwnerV2Request.CrmCustomDataChangeOwnerV2DataData
                        {
                            ObjectDataId = "5dc5316d706c7e0001ea2382",
                            OwnerId = new List<string>
                            {
                                "FSUID_FACEAA83D4F0EE9591CDB911563EECBC"
                            }
                        }
                    }
                }
            });
        }

        #endregion


    }
}
