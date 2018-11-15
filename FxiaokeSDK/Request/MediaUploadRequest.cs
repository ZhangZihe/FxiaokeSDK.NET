using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 上传素材文件
    /// </summary>
    public class MediaUploadRequest : BaseCgiRequest
    {
        /// <summary>
        /// 素材文件类型，目前支持image（图文消息素材类型）, document（文档类型，支持审批素材, CRM素材）
        /// image类型，最大5M，支持jpg, png, gif, bmp, jpeg格式
        /// document类型，最大20M
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件扩展名, 当type=image时必传
        /// </summary>
        public string ExtName { get; set; }

        /// <summary>
        /// 二进制流
        /// </summary>
        public byte[] Media { get; set; }
    }
}
