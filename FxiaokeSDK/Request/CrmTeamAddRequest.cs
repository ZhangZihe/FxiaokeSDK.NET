using System.Collections.Generic;

namespace FxiaokeSDK.Request
{
    public class CrmTeamAddRequest:BaseCgiRequest
    {
        public string CurrentOpenUserId { get; set; }

        public string ApiName { get; set; }

        public CrmTeamAddData Data { get; set; }
    }

    public class CrmTeamAddData
    {
        public List<string> DataIDs { get; set; }

        public List<string> TeamMemberEmployee { get; set; }

        public string TeamMemberRole { get; set; }

        public string TeamMemberPermissionType { get; set; }
    }
}