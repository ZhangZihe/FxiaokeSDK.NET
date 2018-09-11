using FxiaokeSDK.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK
{
    public class ApiResult<TResponse> where TResponse : BaseResponse
    {
        public bool Success { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string OriginalRequest { get; set; }

        public string OriginalResponse { get; set; }

        public TResponse Response { get; set; }
    }
}
