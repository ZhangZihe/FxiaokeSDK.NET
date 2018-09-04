using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK
{
    public static class HttpExtentions
    {
        public static HttpWebRequest AsHttpWebRequest(this WebRequest req)
        {
            return req as HttpWebRequest;
        }

        public static HttpWebRequest SetMethod(this HttpWebRequest req, HttpMethod method)
        {
            req.Method = method.Method;
            return req;
        }

        public static HttpWebRequest SetTimeout(this HttpWebRequest req, int timeout)
        {
            req.Timeout = timeout;
            return req;
        }

        public static HttpWebRequest SetRequestObjWithFormUrlEncoded<T>(this HttpWebRequest req, T obj)
        {
            req.SetMethod(HttpMethod.Post);
            req.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            req.KeepAlive = false;

            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                var param = obj.GetType().GetProperties().Select(x => new KeyValuePair<string, string>(x.Name, x.GetValue(obj)?.ToString()));
                var str = new System.Net.Http.FormUrlEncodedContent(param).ReadAsStringAsync().GetAwaiter().GetResult();
                writer.Write(str);
            }
            return req;
        }

        public static HttpWebRequest SetRequestObjWithJson(this HttpWebRequest req, string jsonContent)
        {
            req.SetMethod(HttpMethod.Post);
            req.ContentType = "application/json; charset=utf-8";
            req.KeepAlive = false;

            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(jsonContent);
            }
            return req;
        }

        public static HttpWebResponse AsHttpWebResponse(this WebResponse resp)
        {
            return resp as HttpWebResponse;
        }

        public static string GetString(this HttpWebResponse resp, Encoding encoding = default(Encoding))
        {
            using (var reader = new StreamReader(resp.GetResponseStream(), encoding ?? Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
