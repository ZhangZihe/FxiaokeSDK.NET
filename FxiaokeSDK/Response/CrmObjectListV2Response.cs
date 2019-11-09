using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmObjectListV2Response :BaseResponse
    {
        public ObjectsData Data { get; set; }

        /// <summary>
        /// 对象列表（对象类型数组）
        /// </summary>
        public class ObjectsData
        {
            public List<CrmObject> Objects { get; set; }
        }

        public class CrmObject
        {
            /// <summary>
            /// 对象api名称(自定义对象api_name以__c结尾)
            /// </summary>
            public string DescribeApiName { get; set; }

            /// <summary>
            /// 对象显示名称
            /// </summary>
            public string DescribeDisplayName { get; set; }

            /// <summary>
            /// 对象类型（package为预设对象，custom为自定义对象）
            /// </summary>
            public string DefineType { get; set; }

            /// <summary>
            /// 对象是否禁用
            /// </summary>
            public string IsActive { get; set; }
        }
    }
}
