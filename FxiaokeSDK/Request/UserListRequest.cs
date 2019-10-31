namespace FxiaokeSDK.Request
{
    public class UserListRequest : BaseCgiRequest
    {
        public int DepartmentId { get; set; }

        public bool FetchChild { get; set; }

        public bool ShowDepartmentIdsDetail { get; set; }
    }
}