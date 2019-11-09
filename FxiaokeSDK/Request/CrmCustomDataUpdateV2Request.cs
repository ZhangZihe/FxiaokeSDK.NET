using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmCustomDataUpdateV2Request : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 是否需要触发工作流(默认不传时为true)
        /// </summary>
        public bool TriggerWorkFlow { get; set; }

        /// <summary>
        /// 对象数据map
        /// </summary>
        public CrmCustomDataUpdateData Data { get; set; }


        public class CrmCustomDataUpdateData
        {
            /// <summary>
            /// 对象数据map(和对象描述中字段一一对应)
            /// </summary>
            public object Object_data { get; set; }
        }
    }
}
