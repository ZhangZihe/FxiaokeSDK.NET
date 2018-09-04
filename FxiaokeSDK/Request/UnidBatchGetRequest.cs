using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    public class UnidBatchGetRequest
    {
        public string AppAccessToken { get; set; }

        public string CorpId { get; set; }

        public List<string> OpenUserIds { get; set; }
    }
}
