using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class UnidGetRequest
    {
        /// <summary>
        /// 企业应用获取到的凭证
        /// </summary>
        public string AppAccessToken { get; set; }

        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CorpId { get; set; }

        /// <summary>
        /// 用户开平账号
        /// </summary>
        public string OpenUserId { get; set; }
    }
}
