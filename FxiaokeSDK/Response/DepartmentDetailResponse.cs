namespace FxiaokeSDK.Response
{
    public class DepartmentDetailResponse:BaseResponse
    {
        /// <summary>
        /// 负责人
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
       

    }
}