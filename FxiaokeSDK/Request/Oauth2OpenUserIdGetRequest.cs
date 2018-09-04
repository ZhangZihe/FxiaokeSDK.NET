using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class Oauth2OpenUserIdGetRequest
    {
        /// <summary>
        /// 企业应用获取到的凭证
        /// </summary>
        public string AppAccessToken { get; set; }

        /// <summary>
        /// 员工身份临时票据，有效期为十分钟，有效期内使用一次后则会过期
        /// </summary>
        public string Code { get; set; }
    }
}
