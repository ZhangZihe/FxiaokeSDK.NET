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
        public async Task CorpAccessTokenGet()
        {
            var client = new FxiaokeClient();
            var result = await client.Execute(new CorpAccessTokenGetRequest());

            Assert.IsTrue(result.Success, result.Message);
        }
    }
}
