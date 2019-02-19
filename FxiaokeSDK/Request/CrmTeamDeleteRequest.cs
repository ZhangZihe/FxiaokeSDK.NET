using System.Collections.Generic;

namespace FxiaokeSDK.Request
{
    public class CrmTeamDeleteRequest : BaseCgiRequest
    {
        public string CurrentOpenUserId { get; set; }

        public string ApiName { get; set; }

        public DataModel Data { get; set; }

        public class DataModel
        {
            public List<string> DataIDs { get; set; }

            public List<string> TeamMemberEmployee { get; set; }
        }
    }
}