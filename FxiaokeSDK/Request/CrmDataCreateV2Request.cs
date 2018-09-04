using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataCreateV2Request : BaseCgiRequest
    {
        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CorpId { get; set; }

        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象数据map
        /// </summary>
        public CrmDataCreateData Data { get; set; }

        public class CrmDataCreateData
        {
            /// <summary>
            /// 对象数据map(和对象描述中字段一一对应)
            /// </summary>
            public object Object_data { get; set; }

            /// <summary>
            /// 对象明细数据map(和对象描述中字段一一对应)
            /// </summary>
            public object Details { get; set; }
        }
    }
}
