namespace FxiaokeSDK.Request
{
    public class DepartmentDetailRequest: BaseCgiRequest
    {
        /// <summary>
        /// 当前操作人OpenUserID
        /// </summary>
        public string CurrentOpenUserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentId { get; set; }
    }
}