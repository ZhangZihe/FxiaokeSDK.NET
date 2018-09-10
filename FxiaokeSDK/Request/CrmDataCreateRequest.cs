using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataCreateRequest : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象的api_name
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 是否触发工作流，默认false，只对回款计划以及自定义对象生效。注意，创建预设对象客户、联系人、销售订单、退货单、商机、合同、销售线索、开票申请、退款都会触发工作流并不受该参数的控制。
        /// </summary>
        public bool TriggerWorkFlow { get; set; }

        /// <summary>
        /// 对象数据Map（和对象描述中字段一一对应）
        /// </summary>
        public object Data { get; set; }
    }
}
