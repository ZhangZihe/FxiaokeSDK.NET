using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// 返回码 (0: 请求成功)
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 对返回码的文本描述内容(中文)
        /// </summary>
        public string ErrorDescription { get; set; }
    }
}
