using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class AppAccessTokenGetResponse : BaseResponse
    {
        public string AppAccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }
}
