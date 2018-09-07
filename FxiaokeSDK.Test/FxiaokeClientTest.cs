using System;
using System.Threading.Tasks;
using FxiaokeSDK.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxiaokeSDK.Test
{
    [TestClass]
    public class FxiaokeClientTest
    {
        [TestInitialize]
        public void Setup()
        {
            FxiaokeConfig.AppId = "FSAID_1317cde";
            FxiaokeConfig.AppSecret = "1909c5c548244d36bdc93c6d293e4f8b";
            FxiaokeConfig.PermanentCode = "6FE4EAB36C49B0D8EFD57B18261932D4";
        }

        [TestMethod]
        public void CrmDataQueryV2()
        {
            var client = new FxiaokeClient();
            var result = client.Execute(new CorpAccessTokenGetRequest());
            Assert.IsTrue(result.Success, result.Message);

            var result0 = client.Execute(new AppAccessTokenGetRequest());
            Assert.IsTrue(result0.Success, result0.Message);

            var result1 = client.Execute(new Oauth2OpenUserIdGetRequest
            {
                AppAccessToken = result0.Response.AppAccessToken,
                Code = "FSCOD_6FAC39BB21D80467AF4616740C867228",
            });
            Assert.IsTrue(result1.Success, result1.Message);

            var result2 = client.Execute(new CrmDataQueryV2Request
            {
                CorpAccessToken = result.Response.CorpAccessToken,
                CorpId = result.Response.CorpId,
                CurrentOpenUserId = result1.Response.OpenUserId,
                Data = new CrmDataQueryV2Request.CrmDataQueryData
                {
                    DataObjectApiName = "PriceBookObj",
                }
            });
            Assert.IsTrue(result2.Success, result2.Message);
        }
    }
}
