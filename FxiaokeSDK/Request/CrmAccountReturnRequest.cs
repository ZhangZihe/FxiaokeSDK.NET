namespace FxiaokeSDK.Request
{
    public class CrmAccountReturnRequest:BaseCgiRequest
    {
        public string CurrentOpenUserId { get; set; }

        public string ApiName { get; set; }

        public string DataId { get; set; }

        public string HighSealId { get; set; }
    }
}