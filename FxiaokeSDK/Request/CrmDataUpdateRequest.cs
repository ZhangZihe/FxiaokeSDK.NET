using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataUpdateRequest : BaseCgiRequest
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
        /// 对象的api_name
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 数据Id
        /// </summary>
        public string DataId { get; set; }

        /// <summary>
        /// 对象数据Map（和对象描述中字段一一对应）
        /// </summary>
        public object Data { get; set; }
    }
}
