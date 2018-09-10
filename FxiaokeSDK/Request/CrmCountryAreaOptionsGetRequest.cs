using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmCountryAreaOptionsGetRequest : BaseCgiRequest
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
        /// 是否获取已删除的省市区信息，默认为true返回已删除的，false不返回已删除的
        /// </summary>
        public bool IsIncludeDeleted { get; set; }
    }
}
