using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class UserSimpleListResponse : BaseResponse
    {
        public List<User> Userlist { get; set; }

        public class User
        {
            /// <summary>
            /// 开放平台员工账号
            /// </summary>
            public string OpenUserId { get; set; }

            /// <summary>
            /// 员工姓名
            /// </summary>
            public string Name { get; set; }
        }
    }
}
