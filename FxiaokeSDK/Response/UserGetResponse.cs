using System;
using System.Collections.Generic;

namespace FxiaokeSDK.Response
{
    public class UserGetResponse : BaseResponse
    {
        public string OpenUserId { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool IsStop { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string ProfileImageUrl { get; set; }
        public List<int> DepartmentIds { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TartWorkDate { get; set; }
        public long CreateTime { get; set; }
        public string LeaderId { get; set; }
    }
}