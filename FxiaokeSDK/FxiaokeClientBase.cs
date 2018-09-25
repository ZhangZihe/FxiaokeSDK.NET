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

        public ApiResult<string> Execute(string api, string jsonParam)
        {
            Request = null;
            Response = null;

            var url = string.Concat(FxiaokeConfig.BaseUrl, api);
            Request = WebRequest.Create(url).AsHttpWebRequest()
                .SetRequestObjWithJson(jsonParam)
                .SetTimeout(10 * 1000);

            try
            {
                Response = Request.GetResponse().AsHttpWebResponse();
                if (Response.StatusCode != HttpStatusCode.OK)
                {
                    return new ApiResult<string>
                    {
                        Message = Response.StatusDescription,
                        ErrorCode = (int)Response.StatusCode,
                    };
                }

                var result = Response.GetString(encoding: Encoding.UTF8);
                var obj = JsonConvert.DeserializeObject<BaseResponse>(result);
                return new ApiResult<string>
                {
                    Success = obj?.ErrorCode == 0,
                    Message = obj?.ErrorMessage ?? obj?.ErrorDescription ?? "发生未知异常",
                    ErrorCode = obj?.ErrorCode ?? 88888,
                    Response = result,
                    OriginalRequest = jsonParam,
                    OriginalResponse = result,
                };
            }
            catch (Exception e)
            {
                return new ApiResult<string>
                {
                    Message = e.Message,
                    ErrorCode = 99999,
                    OriginalRequest = jsonParam,
                    OriginalResponse = e.ToString(),
                };
            }
        }

        public ApiResult<TResponse> Execute<TRequest, TResponse>(string api, TRequest request) where TResponse : BaseResponse
        {
            var jsonParam = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            
            var result = Execute(api, jsonParam);

            try
            {
                var response = JsonConvert.DeserializeObject<TResponse>(result.Response);
                return new ApiResult<TResponse>
                {
                    Success = result.Success,
                    ErrorCode = result.ErrorCode,
                    Message = result.Message,
                    OriginalRequest = result.OriginalRequest,
                    OriginalResponse = result.OriginalResponse,
                    Response = response,
                };
            }
            catch(Exception e)
            {
                return new ApiResult<TResponse>
                {
                    Message = e.Message,
                    ErrorCode = 99999,
                    OriginalRequest = jsonParam,
                    OriginalResponse = result?.Response ?? e.ToString(),
                };
            }
        }
    }
}
