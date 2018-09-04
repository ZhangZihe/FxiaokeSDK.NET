using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class OpenIdGetRequest
    {
        /// <summary>
        /// 企业应用获取到的凭证
        /// </summary>
        public string AppAccessToken { get; set; }

        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CropId { get; set; }

        /// <summary>
        /// 用户唯一id
        /// </summary>
        public string Unid { get; set; }
    }
}
