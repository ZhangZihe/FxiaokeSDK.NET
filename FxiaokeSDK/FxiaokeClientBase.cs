using FxiaokeSDK.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK
{
    public class FxiaokeClientBase
    {
        public HttpWebRequest Request { get; private set; }

        public HttpWebResponse Response { get; private set; }

        public async Task<ApiResult<TResponse>> Execute<TRequest, TResponse>(string api, TRequest request) where TResponse : BaseResponse
        {
            Request = null;
            Response = null;

            var url = string.Concat(FxiaokeConfig.BaseUrl, api);
            var jsonParam = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            Request = WebRequest.Create(url).AsHttpWebRequest()
                .SetRequestObjWithJson(jsonParam)
                .SetTimeout(10 * 1000);

            try
            {
                Response = (await Request.GetResponseAsync()).AsHttpWebResponse();
                if (Response.StatusCode != HttpStatusCode.OK)
                {
                    return new ApiResult<TResponse>
                    {
                        Message = Response.StatusDescription,
                        ErrorCode = (int)Response.StatusCode,
                    };
                }

                var result = Response.GetString(encoding: Encoding.UTF8);
                var obj = JsonConvert.DeserializeObject<TResponse>(result);
                return new ApiResult<TResponse>
                {
                    Success = obj?.ErrorCode == 0,
                    Message = obj?.ErrorMessage ?? "发生未知异常",
                    ErrorCode = obj?.ErrorCode ?? 88888,
                    Response = obj,
                    OriginalResponse = result,
                };
            }
            catch (Exception e)
            {
                return new ApiResult<TResponse>
                {
                    Message = e.Message,
                    OriginalResponse = e.ToString(),
                    ErrorCode = 99999,
                };
            }
        }
    }
}
