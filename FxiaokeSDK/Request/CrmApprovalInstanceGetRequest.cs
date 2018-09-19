using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 根据审批实例ID获取审批详情
    /// </summary>
    public class CrmApprovalInstanceGetRequest : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string InstanceId { get; set; }
    }
}
