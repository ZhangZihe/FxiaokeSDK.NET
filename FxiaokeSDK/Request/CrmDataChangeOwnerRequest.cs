using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataChangeOwnerRequest : BaseCgiRequest
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
        /// 数据Id
        /// </summary>
        public string DataId { get; set; }

        /// <summary>
        /// 负责人的openUserId(对于公海中未分配的客户,只能分配给公海管理员和公海成员)   
        /// </summary>
        public string OwnerOpenUserId { get; set; }
    }
}
