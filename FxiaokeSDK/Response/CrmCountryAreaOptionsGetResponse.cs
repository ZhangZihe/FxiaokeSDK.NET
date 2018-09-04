using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Response
{
    public class CrmCountryAreaOptionsGetResponse : BaseResponse
    {
        public JObject CountryAreaOptions { get; set; }
    }
}
