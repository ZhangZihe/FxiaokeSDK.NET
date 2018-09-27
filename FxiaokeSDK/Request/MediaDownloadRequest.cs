using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 下载素材文件
    /// </summary>
    public class MediaDownloadRequest : BaseCgiRequest
    {
        public string MediaId { get; set; }
    }
}
