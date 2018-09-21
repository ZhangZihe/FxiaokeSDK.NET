using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxiaokeSDK.Request
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public class MessageSendRequest : BaseCgiRequest
    {
        /// <summary>
        /// 开放平台员工ID列表（消息接收者，目前最多支持500人）
        /// </summary>
        public List<string> ToUser { get; set; }

        /// <summary>
        /// 消息类型，取值为：text/composite/articles
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 二级对象，文本内容详情
        /// </summary>
        public MessageText Text { get; set; }

        /// <summary>
        /// 二级对象，文本数据详情
        /// </summary>
        public MessageComposite Composite { get; set; }

        /// <summary>
        /// 图文条目列表 ，一次最多允许7条图文消息
        /// </summary>
        public List<MessageArticle> Articles { get; set; }

        /// <summary>
        /// 文本消息
        /// </summary>
        public class MessageText
        {
            /// <summary>
            /// 文本内容详情
            /// </summary>
            public string Content { get; set; }
        }

        /// <summary>
        /// 复合消息
        /// </summary>
        public class MessageComposite
        {
            public CompositeHead Head { get; set; }
            
            public CompositeFirst First { get; set; }

            public CompositeForm Form { get; set; }

            public CompositeRemark Remark { get; set; }

            public CompositeLink Link { get; set; }

            public class CompositeHead
            {
                /// <summary>
                /// 头部标题
                /// </summary>
                public string Title { get; set; }
            }

            public class CompositeFirst
            {
                /// <summary>
                /// 内容标题
                /// </summary>
                public string Content { get; set; }
            }

            public class CompositeForm
            {
                public string Label { get; set; }

                public string Value { get; set; }
            }

            public class CompositeRemark
            {
                /// <summary>
                /// 内容摘要
                /// </summary>
                public string Content { get; set; }
            }

            public class CompositeLink
            {
                /// <summary>
                /// 点击消息时跳转链接标题
                /// </summary>
                public string Title { get; set; }

                /// <summary>
                /// 点击消息时跳转链接地址
                /// </summary>
                public string Url { get; set; }
            }
        }

        /// <summary>
        /// 图文消息
        /// </summary>
        public class MessageArticle
        {
            /// <summary>
            /// 标题，最长45个字符
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 作者，最长8个字符
            /// </summary>
            public string Author { get; set; }

            /// <summary>
            /// 摘要，最长140字符。
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 封面图片对应的mediaId
            /// </summary>
            public string CoverImage { get; set; }

            /// <summary>
            /// 当articles.type为"TEXT"时，内容中是否显示图片(false不包含，true包含，默认false)
            /// </summary>
            public bool CoverImageInContent { get; set; }

            /// <summary>
            /// 图文消息内容类型（"TEXT","URL"）
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// 图文消息内容，当imageTextType为"URL"时表示链接地址。
            /// </summary>
            public string Content { get; set; }
        }
    }
}
