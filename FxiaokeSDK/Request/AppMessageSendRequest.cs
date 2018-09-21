using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 应用挂接服务号发消息
    /// </summary>
    public class AppMessageSendRequest : MessageSendRequest
    {
        /// <summary>
        /// 授权服务号Id
        /// </summary>
        public string ServiceId { get; set; }
    }
}
