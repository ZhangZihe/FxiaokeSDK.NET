using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmApprovalInstanceGetResponse : BaseResponse
    {
        public class ApprovalInstanceDetail
        {
            /// <summary>
            /// 流程实例详情
            /// </summary>
            public string Instance { get; set; }

            /// <summary>
            /// 流程实例详情
            /// </summary>
            public List<ApprovalInstanceDetailTask> Tasks { get; set; }
        }

        public class ApprovalInstanceDetailTask
        {
            /// <summary>
            /// 任务id
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// 任务类型 单人审批single 多人审批one_pass 会签all_pass
            /// 单人审批single:一个人过就过
            /// 多人审批one_pass:多个人当中一个人通过就过
            /// 会签 ll_pass:所有人都通过才过
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// 任务状态 进行中 in_progress ;通过 pass;自动通过 auto_pass;拒绝 reject;取消 cancel;回退 go_back;自动回退 auto_go_back;定时 schedule;异常 error
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// 审批流 apiName
            /// </summary>
            public string FlowApiName { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public long CreateTime { get; set; }

            /// <summary>
            /// 最后更新时间
            /// </summary>
            public long ModifyTime { get; set; }

            /// <summary>
            /// 审批意见
            /// </summary>
            public List<ApprovalInstanceDetailTaskOpinions> Opinions { get; set; }

            /// <summary>
            /// 未完成人员列表
            /// </summary>
            public List<string> UnCompletePersons { get; set; }

            /// <summary>
            /// 完成时间
            /// </summary>
            public long EndTime { get; set; }

            /// <summary>
            /// 已完成人员列表
            /// </summary>
            public List<string> CompleteOpenPersons { get; set; }
        }

        public class ApprovalInstanceDetailTaskOpinions
        {
            public string ActionType { get; set; }

            public string Opinion { get; set; }

            public long ReplyTime { get; set; }

            public string OpenUserId { get; set; }
        }
    }
}
