namespace FxiaokeSDK.Request
{
    public class UserGetRequest:BaseCgiRequest
    {
        /// <summary>
        /// 开放平台员工帐号   
        /// </summary>
        public string OpenUserId { get; set; }

        /// <summary>
        /// 如果为true，则会返回员工主属部门(mainDepartmentId)与附属部门(attachingDepartmentIds); 默认值为false
        /// </summary>
        public bool ShowDepartmentIdsDetail { get; set; }
    }
}