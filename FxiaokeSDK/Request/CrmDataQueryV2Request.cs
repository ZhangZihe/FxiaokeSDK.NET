using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 详细注释请参照官方文档: https://open.fxiaoke.com/wiki.html#artiId=218
    /// </summary>
    public class CrmDataQueryV2Request : BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象数据map
        /// </summary>
        public CrmDataQueryData Data { get; set; }

        public class CrmDataQueryData
        {
            /// <summary>
            /// 对象的api_name
            /// </summary>
            public string DataObjectApiName { get; set; }

            public string Search_template_id { get; set; }

            /// <summary>
            /// 查询条件列表
            /// </summary>
            public CrmDataSearchQueryInfo Search_query_info { get; set; }
        }

        public class CrmDataSearchQueryInfo
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
            public List<CrmDataSearchQueryInfoFilter> Filters { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public List<CrmDataSearchQueryInfoOrder> Orders { get; set; }
        }

        public class CrmDataSearchQueryInfoFilter
        {
            /// <summary>
            /// 字段名
            /// </summary>
            public string Field_name { get; set; }

            /// <summary>
            /// 取值范围
            /// </summary>
            public List<string> field_values { get; set; }

            /// <summary>
            /// 支持操作
            /// </summary>
            public string Operator { get; set;}
        }

        public class CrmDataSearchQueryInfoOrder
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
