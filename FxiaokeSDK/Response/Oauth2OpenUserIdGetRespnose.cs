using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class Oauth2OpenUserIdGetRespnose : BaseResponse
    {
        /// <summary>
        /// 开放平台派发的用户帐号
        /// </summary>
        public string OpenUserId { get; set; }

        /// <summary>
        /// 开放平台派发的公司帐号
        /// </summary>
        public string CorpId { get; set; }
    }
}
