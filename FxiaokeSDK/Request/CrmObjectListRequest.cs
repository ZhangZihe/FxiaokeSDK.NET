using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmObjectListRequest : BaseCgiRequest
    {
        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CorpId { get; set; }

        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }
    }
}
