using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 获取部门下成员信息(简略)
    /// </summary>
    public class UserSimpleListRequest : BaseCgiRequest
    {
        /// <summary>
        /// 部门ID, 为非负整数
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 如果为true，则同时获取其所有子部门员工; 如果为false或者不传，则只获取当前部门员工
        /// </summary>
        public bool FetchChild { get; set; }
    }
}
