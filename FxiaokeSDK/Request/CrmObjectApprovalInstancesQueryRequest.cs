using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 查询CRM对象实例关联的审批实例
    /// </summary>
    public class CrmObjectApprovalInstancesQueryRequest : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// CRM数据Id
        /// </summary>
        public string DataId { get; set; }
    }
}
