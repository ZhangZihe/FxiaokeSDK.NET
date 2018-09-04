using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmObjectListResponse :BaseResponse
    {
        /// <summary>
        /// 对象列表（对象类型数组）
        /// </summary>
        public List<CrmObject> Objects { get; set; }

        public class CrmObject
        {
            /// <summary>
            /// 对象api名称(自定义对象api_name以__c结尾)
            /// </summary>
            public string Api_Name { get; set; }

            /// <summary>
            /// 对象显示名称
            /// </summary>
            public string Display_Name { get; set; }
        }
    }
}
