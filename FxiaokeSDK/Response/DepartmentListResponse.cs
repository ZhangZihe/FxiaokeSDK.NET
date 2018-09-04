using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class DepartmentListResponse : BaseResponse
    {
        public List<Department> Departments { get; set; }

        public class Department
        {
            /// <summary>
            /// 部门ID
            /// </summary>
            public long Id { get; set; }

            /// <summary>
            /// 部门名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 父部门ID，根部门ID为0，其它部门Id为非负整数
            /// </summary>
            public long ParentId { get; set; }

            /// <summary>
            /// 是否停用（true表示停用，false表示正常）
            /// </summary>
            public bool IsStop { get; set; }

            /// <summary>
            /// 部门排序，序号越小，排序越靠前。最小值为1
            /// </summary>
            public long Order { get; set; }
        }
    }
}
