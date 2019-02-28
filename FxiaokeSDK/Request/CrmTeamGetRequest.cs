namespace FxiaokeSDK.Request
{
    public class CrmTeamGetRequest:BaseCgiRequest
    {
        public string CurrentOpenUserId { get; set; }

        public string ApiName { get; set; }

        public DataModel Data { get; set; }
        public class DataModel
        {
            public string DataID { get; set; }
        }
    }
}