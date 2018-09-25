using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 根据审批任务ID执行审批操作：同意、驳回
    /// </summary>
    public class CrmApprovalTaskActionRequest : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 操作类型 同意:agree ;拒绝:reject
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// 意见内容
        /// </summary>
        public string Opinion { get; set; }
    }
}
