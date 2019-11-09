using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmCustomDataRecoverV2Request : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象数据map
        /// </summary>
        public CrmCustomDataRecoverV2Data Data { get; set; }

        public class CrmCustomDataRecoverV2Data
        {
            /// <summary>
            /// 对象的api_name
            /// </summary>
            public string DataObjectApiName { get; set; }

            /// <summary>
            /// 数据Id列表
            /// </summary>
            public List<string> IdList { get; set; }
        }

    }
}
