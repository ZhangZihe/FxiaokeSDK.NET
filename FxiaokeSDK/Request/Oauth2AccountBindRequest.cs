using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class Oauth2AccountBindRequest
    {
        /// <summary>
        /// 企业应用获取到的凭证
        /// </summary>
        public string AppAccessToken { get; set; }

        /// <summary>
        /// 企业应用系统里的员工帐号
        /// </summary>
        public string AppAcount { get; set; }

        /// <summary>
        /// 开放平台派发的用户账号
        /// </summary>
        public string OpenUserId { get; set; }
    }
}
