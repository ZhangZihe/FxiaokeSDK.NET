using System.Collections.Generic;

namespace FxiaokeSDK.Response
{
    public class DepartmentDetailResponse:BaseResponse
    {
        public Department Department { get; set; }
           
    }

    public class Department
    {
        public string Name { get; set; }


        public string PrincipalId { get; set; }
    }
}