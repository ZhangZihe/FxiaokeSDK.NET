using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class OpenIdBatchGetResponse : BaseResponse
    {
        /// <summary>
        /// 换取失败的unid列表
        /// </summary>
        public List<string> FailList { get; set; }

        /// <summary>
        /// 换取成功的unid->openUserId对应列表
        /// </summary>
        public List<string> OpenIdList { get; set; }
    }
}
