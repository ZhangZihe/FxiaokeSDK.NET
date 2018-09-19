namespace FxiaokeSDK.Request
{
    public class CrmQueryAreaRequest
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
    }
}