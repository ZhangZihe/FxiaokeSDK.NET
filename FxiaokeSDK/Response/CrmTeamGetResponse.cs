using System.Collections.Generic;

namespace FxiaokeSDK.Response
{
    public class CrmTeamGetResponse : BaseResponse
    {
        public TeamObject Data { get; set; }
        public class TeamObject
        {
            public List<TeamMember> ObjectList { get; set; }
        }

        public class TeamMember
        {
            public List<string> TeamMemberEmployee { get; set; }

            public string TeamMemberRole { get; set; }

            public string TeamMemberPermissionType { get; set; }
        }
    }
}