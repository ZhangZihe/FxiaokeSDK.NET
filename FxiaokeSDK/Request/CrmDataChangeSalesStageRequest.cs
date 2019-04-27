using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataChangeSalesStageRequest : BaseCgiRequest
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
        /// 商机Id
        /// </summary>
        public string OpportunityId { get; set; }

        /// <summary>
        /// 当前销售阶段Id
        /// </summary>
        public string DataId { get; set; }

        /// <summary>
        /// 待变更的销售阶段ID
        /// </summary>
        public string NextSaleStageId { get; set; }
    }
}
