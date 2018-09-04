using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK
{
    /// <summary>
    /// 纷享销客账号配置
    /// </summary>
    public class FxiaokeConfig
    {
        static FxiaokeConfig()
        {
            AppId = ConfigurationManager.AppSettings["fxiaoke_appid"];
            AppSecret = ConfigurationManager.AppSettings["fxiaoke_appsecret"];
            PermanentCode = ConfigurationManager.AppSettings["fxiaoke_apppermanentcode"];
        }

        /// <summary>
        /// 纷享销客域名
        /// </summary>
        public static readonly string BaseUrl = "https://open.fxiaoke.com";

        /// <summary>
        /// 企业应用ID
        /// </summary>
        public static string AppId;

        /// <summary>
        /// 企业应用凭证密钥
        /// </summary>
        public static string AppSecret;

        /// <summary>
        /// 企业应用获得的公司永久授权码
        /// </summary>
        public static string PermanentCode;
    }
}
