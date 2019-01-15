using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Console
{
    public static class Extenstions
    {
        public static long ToUnixStamp(this DateTime dt)
        {
            return (long)(dt.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static DateTime ToDateTime(this long unixStamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)).AddMilliseconds(unixStamp);
        }
    }
}
