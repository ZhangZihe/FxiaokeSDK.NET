using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class UnidBatchGetResponse : BaseResponse
    {
        /// <summary>
        /// 换取失败的openUserId列表
        /// </summary>
        public List<string> FailList { get; set; }

        /// <summary>
        /// 换取成功的openUserId->unid对应列表
        /// </summary>
        public List<string> UnidList { get; set; }
    }
}
