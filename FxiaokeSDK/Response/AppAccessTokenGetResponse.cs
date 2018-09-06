using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class AppAccessTokenGetResponse : BaseResponse
    {
        /// <summary>
        /// 企业应用获取到的凭证
        /// </summary>
        public string AppAccessToken { get; set; }

        /// <summary>
        /// 企业应用获取到的凭证的过期时间，单位为秒，取值在0~2592000之间
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
