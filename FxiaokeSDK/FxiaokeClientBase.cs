using FxiaokeSDK.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                .SetTimeout(30 * 1000);

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
                var apiResult = new ApiResult<TResponse>
                {
                    Success = result.Success,
                    ErrorCode = result.ErrorCode,
                    Message = result.Message,
                    OriginalRequest = result.OriginalRequest,
                    OriginalResponse = result.OriginalResponse,
                }; ;

                if (string.IsNullOrWhiteSpace(result.Response))
                    return apiResult;

                var response = JsonConvert.DeserializeObject<TResponse>(result.Response);
                apiResult.Response = response;
                return apiResult;
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

        public async Task<ApiResult<TResponse>> Upload<TRequest, TResponse>(TRequest request) 
            where TRequest: Request.MediaUploadRequest 
            where TResponse : BaseResponse
        {
            HttpClient client = new HttpClient();
            var fileContent = new ByteArrayContent(request.Media);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            fileContent.Headers.ContentEncoding.Add("utf-8");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = $"\"media\"",
                FileName = $"\"media_{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{(request.ExtName != null && !request.ExtName.StartsWith(".") ? $".{request.ExtName}" : request.ExtName)}\"",
            };

            var content = new MultipartFormDataContent();
            content.Add(fileContent);

            var url = $"{FxiaokeConfig.BaseUrl}/media/upload?corpAccessToken={request.CorpAccessToken}&corpId={request.CorpId}&type={request.Type}";
            var responseMessage = await client.PostAsync(url, content).ConfigureAwait(false);
            var responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            try
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return new ApiResult<TResponse>
                {
                    Success = obj?.ErrorCode == 0,
                    Message = obj?.ErrorMessage ?? obj?.ErrorDescription ?? "发生未知异常",
                    ErrorCode = obj?.ErrorCode ?? 88888,
                    Response = obj,
                    OriginalRequest = url,
                    OriginalResponse = responseContent,
                };
            }
            catch (Exception e)
            {
                return new ApiResult<TResponse>
                {
                    Message = e.Message,
                    ErrorCode = 99999,
                    OriginalRequest = url,
                    OriginalResponse = e.ToString(),
                };
            }
        }

        public ApiResult<Stream> Download<TRequest>(string api, TRequest request)
            where TRequest : Request.MediaDownloadRequest
        {
            Request = null;
            Response = null;

            var jsonParam = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var url = string.Concat(FxiaokeConfig.BaseUrl, api);
            Request = WebRequest.Create(url).AsHttpWebRequest()
                .SetRequestObjWithJson(jsonParam)
                .SetTimeout(30 * 1000);

            try
            {
                Response = Request.GetResponse().AsHttpWebResponse();
                if (Response.StatusCode != HttpStatusCode.OK)
                {
                    return new ApiResult<Stream>
                    {
                        Message = Response.StatusDescription,
                        ErrorCode = (int)Response.StatusCode,
                    };
                }

                var stream = Response.AsHttpWebResponse().GetResponseStream();
                return new ApiResult<Stream>
                {
                    Success = true,
                    Response = stream,
                    OriginalRequest = jsonParam,
                };
            }
            catch (Exception e)
            {
                return new ApiResult<Stream>
                {
                    Message = e.Message,
                    ErrorCode = 99999,
                    OriginalRequest = jsonParam,
                    OriginalResponse = e.ToString(),
                };
            }
        }
    }
}
