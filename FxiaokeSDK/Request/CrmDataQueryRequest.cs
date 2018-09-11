using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class CrmDataQueryRequest
    {
        /// <summary>
        /// 开放平台公司账号
        /// </summary>
        public string CorpId { get; set; }


        public string CorpAccessToken { get; set; }
        /// <summary>
        /// 当前操作人的openUserId
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 对象的api_name
        /// </summary>
        public string ApiName { get; set; }

        public CrmDataSearchQuery SearchQuery { get; set; }
               

        public class CrmDataSearchQuery
        {
            /// <summary>
            /// 获取数据条数,默认20,最大值为1000(自定义对象最大值为100)
            /// </summary>
            public int Limit { get; set; }

            /// <summary>
            /// 偏移量，从0开始、数值必须为limit的整数倍
            /// </summary>
            public int Offset { get; set; }
            /// <summary>
            /// 过滤条件列表
            /// </summary>
            public List<CrmDataCondition> Conditions { get; set; }

            /// <summary>
            /// 返回字段信息
            /// </summary>
            public CrmDataProjection DataProjection { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public List<CrmDataOrder> Orders { get; set; }

            /// <summary>
            /// 范围条件列表
            /// </summary>
            public List<object> RangeConditions { get; set; }
        }

        public class CrmDataCondition
        {
            /// <summary>
            /// term_condition:表示精确匹配(目前只支持这种)
            /// </summary>
            public string ConditionType { get; } = "term_condition";

            public object Conditions { get; set; }
        }

        public class CrmDataProjection
        {
            public List<string> FieldNames { get; set; }
        }

        public class CrmDataOrder
        {
            /// <summary>
            /// true 表示正序 false 表示倒序
            /// </summary>
            public bool Ascending { get; set; }

            public string Field { get; set; }
        }
    }
}
