using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmApprovalInstancesQueryResponse : BaseResponse
    {
        public ApprovalInstancesQueryResult QueryResult { get; set; }

        public class ApprovalInstancesQueryResult
        {
            /// <summary>
            /// 总记录数
            /// </summary>
            public int Total { get; set; }

            /// <summary>
            /// 流程实例列表
            /// </summary>
            public List<ApprovalInstance> InstanceList { get; set; }
        }

        public class ApprovalInstance
        {
            public string InstanceId { get; set; }

            public string InstanceName { get; set; }

            public string DataId { get; set; }

            public string TriggerType { get; set; }

            public string State { get; set; }

            public long CreateTime { get; set; }

            public long LastModifyTime { get; set; }

            public long EndTime { get; set; }

            public string FlowApiName { get; set; }

            public string ApplicantOpenUserId { get; set; }

            public long CancelTime { get; set; }

            public string ObjectApiName { get; set; }
        }
    }
}
