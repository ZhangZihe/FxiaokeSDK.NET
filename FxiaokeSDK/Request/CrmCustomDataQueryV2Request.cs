using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmCustomDataQueryV2Request : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象数据map
        /// </summary>
        public CrmCustomDataQueryData Data { get; set; }

        public class CrmCustomDataQueryData
        {
            /// <summary>
            /// 对象的api_name
            /// </summary>
            public string DataObjectApiName { get; set; }

            public string Search_template_id { get; set; }

            /// <summary>
            /// 查询条件列表
            /// </summary>
            public CrmCustomDataSearchQueryInfo Search_query_info { get; set; }
        }

        public class CrmCustomDataSearchQueryInfo
        {
            /// <summary>
            /// 获取数据条数,默认20,最大值为1000(自定义对象最大值为100)
            /// </summary>
            public int Limit { get; set; } = 20;

            /// <summary>
            /// 偏移量，从0开始、数值必须为limit的整数倍
            /// </summary>
            public int Offset { get; set; }

            /// <summary>
            /// 过滤条件列表
            /// </summary>
            public List<CrmCustomDataSearchQueryInfoFilter> Filters { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public List<CrmCustomDataSearchQueryInfoOrder> Orders { get; set; }

            /// <summary>
            /// 返回字段列表
            /// </summary>
            public List<string> FieldProjection { get; set; }
        }

        public class CrmCustomDataSearchQueryInfoFilter
        {
            /// <summary>
            /// 字段名
            /// </summary>
            public string Field_name { get; set; }

            /// <summary>
            /// 取值范围
            /// </summary>
            public List<string> Field_values { get; set; }

            /// <summary>
            /// 支持操作
            /// </summary>
            public string Operator { get; set; }
        }

        public class CrmCustomDataSearchQueryInfoOrder
        {
            /// <summary>
            /// 字段名
            /// </summary>
            public string FieldName { get; set; }

            /// <summary>
            /// 如果是ture，按照升序排列，如果是false，则按照倒序排列
            /// </summary>
            public bool IsAsc { get; set; }
        }

    }
}
