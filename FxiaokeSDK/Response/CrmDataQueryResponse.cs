using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FxiaokeSDK.Response
{
    public class CrmDataQueryResponse : BaseResponse
    {
        public long TotalNumber { get; set; }

        public List<JObject> Datas { get; set; }
    }
}
