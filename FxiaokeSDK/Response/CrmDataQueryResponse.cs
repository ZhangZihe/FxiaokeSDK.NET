using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmDataQueryResponse : BaseResponse
    {
        public long TotalNumber { get; set; }

        public List<object> Datas { get; set; }
    }
}
