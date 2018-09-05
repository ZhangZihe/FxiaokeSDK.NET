using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmDataQueryV2Response : BaseResponse
    {
        /// <summary>
        /// 查询结果
        /// </summary>
        public CrmDataQueryV2Data Data { get; set; }

        public class CrmDataQueryV2Data
        {
            /// <summary>
            /// 总记录数
            /// </summary>
            public int Total { get; set; }

            /// <summary>
            /// 获取数据条数,默认20,最大值为1000(自定义对象最大值为100)
            /// </summary>
            public int Offset { get; set; }

            /// <summary>
            /// 偏移量，从0开始、数值必须为limit的整数倍
            /// </summary>
            public int Limit { get; set; }

            /// <summary>
            /// 数据列表
            /// </summary>
            public List<JObject> DataList { get; set; }
        }
    }
}
