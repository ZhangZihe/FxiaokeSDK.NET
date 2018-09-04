using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataGetRequest : BaseCgiRequest
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
        /// 对象的api_name; SalesOrderProductObj(订单关联产品)对象不支持该操作
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 数据Id
        /// </summary>
        public string DataId { get; set; }
    }
}
