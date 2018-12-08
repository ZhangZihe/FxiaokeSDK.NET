namespace FxiaokeSDK.Response
{
    public class JsApiTicketGetResponse:BaseResponse
    {
        /// <summary>
        /// 临时票据
        /// </summary>
        public string Ticket { get; set; }


        /// <summary>
        /// ticket有效时间，以秒为单位，正常情况下，有效期为7200秒
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}