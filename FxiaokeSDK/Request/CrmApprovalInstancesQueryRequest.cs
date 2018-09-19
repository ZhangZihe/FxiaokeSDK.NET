using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 查询指定审批规则的审批实例列表
    /// </summary>
    public class CrmApprovalInstancesQueryRequest : BaseCgiRequest
    {
        /// <summary>
        /// 审批流程 apiName
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string FlowApiName { get; set; }

        /// <summary>
        /// 流程状态 流程实例状态 in_progress 进行中,pass 通过,error 异常,cancel 取消,reject 拒绝
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 开始时间(时间戳形式)
        /// </summary>
        public long StartTime { get; set; }

        /// <summary>
        /// 结束时间(时间戳形式)
        /// </summary>
        public long EndTime { get; set; }

        /// <summary>
        /// 数据对象apiName
        /// </summary>
        public string ObjectApiName { get; set; }

        /// <summary>
        /// 页码默认为 1
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// 分页大小默认 20
        /// </summary>
        public int PageSize { get; set; } = 20;
    }
}
