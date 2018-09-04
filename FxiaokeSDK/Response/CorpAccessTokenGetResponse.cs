using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CorpAccessTokenGetResponse : BaseResponse
    {
        /// <summary>
        /// 企业应用访问公司合法性凭证
        /// </summary>
        public string corpAccessToken { get; set; }

        /// <summary>
        /// 开放平台派发的公司帐号
        /// </summary>
        public string corpId { get; set; }

        /// <summary>
        /// 企业应用访问公司合法性凭证的过期时间，单位为秒，取值在0~7200之间
        /// </summary>
        public int expiresIn { get; set; }
    }
}
