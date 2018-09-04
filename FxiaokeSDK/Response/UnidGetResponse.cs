using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class UnidGetResponse : BaseResponse
    {
        /// <summary>
        /// 开放平台派发的用户帐号
        /// </summary>
        public string Unid { get; set; }
    }
}
