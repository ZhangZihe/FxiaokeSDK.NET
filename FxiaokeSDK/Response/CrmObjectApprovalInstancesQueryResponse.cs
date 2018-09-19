using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmObjectApprovalInstancesQueryResponse : BaseResponse
    {
        /// <summary>
        /// 流程实例列表（instance数组）
        /// </summary>
        public List<ApprovalInstances> Instances { get; set; }

        public class ApprovalInstances
        {
            /// <summary>
            /// 流程实例id
            /// </summary>
            public string InstanceId { get; set; }

            /// <summary>
            /// 流程实例名称
            /// </summary>
            public string InstanceName { get; set; }

            /// <summary>
            /// 流程实例关联的数据id
            /// </summary>
            public string DataId { get; set; }

            /// <summary>
            /// 操作类型 Create新建，Update编辑，Invalid作废，Delete删除
            /// </summary>
            public string TriggerType { get; set; }

            /// <summary>
            /// 流程实例状态 in_progress 进行中,pass 通过,error 异常,cancel 取消,reject 拒绝
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// 流程实例创建时间
            /// </summary>
            public long CreateTime { get; set; }

            /// <summary>
            /// 流程实例最后更新时间
            /// </summary>
            public long LastModifyTime { get; set; }

            /// <summary>
            /// 流程实例结束时间
            /// </summary>
            public long EndTime { get; set; }

            /// <summary>
            /// 审批流程 apiName
            /// </summary>
            public string FlowApiName { get; set; }

            /// <summary>
            /// 流程实例发起人
            /// </summary>
            public string ApplicantOpenUserId { get; set; }

            /// <summary>
            /// 流程实例的取消时间
            /// </summary>
            public long CancelTime { get; set; }

            /// <summary>
            /// 数据对象的 apiName
            /// </summary>
            public string ObjectApiName { get; set; }
        }
    }
}
