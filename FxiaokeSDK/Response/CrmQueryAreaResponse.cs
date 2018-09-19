using Newtonsoft.Json.Linq;

namespace FxiaokeSDK.Response
{
    public class CrmQueryAreaResponse: BaseResponse
    {
        public string errorMessage { get; set; }

        public string errorCode { get; set; }

        public JObject datas { get; set; }
    }
}
