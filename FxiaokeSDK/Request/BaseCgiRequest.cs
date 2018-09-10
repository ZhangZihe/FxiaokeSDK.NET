using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public abstract class BaseCgiRequest
    {
        /// <summary>
        /// 企业应用访问公司合法性凭证
        /// </summary>
        public string CorpAccessToken { get; set; }

        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CorpId { get; set; }
    }
}
