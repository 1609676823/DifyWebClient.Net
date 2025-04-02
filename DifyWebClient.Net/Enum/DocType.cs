using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 文档类型
    /// Type of document
    /// </summary>
    public static class DocType
    {
        /// <summary>
        /// 图书
        /// Type of document (optional): Book
        /// </summary>
        public const string Book = "book";

        /// <summary>
        /// 网页
        /// Type of document (optional): Web page
        /// </summary>
        public const string WebPage = "web_page";

        /// <summary>
        /// 学术论文/文章
        /// Type of document (optional): Academic paper/article
        /// </summary>
        public const string Paper = "paper";

        /// <summary>
        /// 社交媒体帖子
        /// Type of document (optional): Social media post
        /// </summary>
        public const string SocialMediaPost = "social_media_post";

        /// <summary>
        /// 维基百科条目
        /// Type of document (optional): Wikipedia entry
        /// </summary>
        public const string WikipediaEntry = "wikipedia_entry";

        /// <summary>
        /// 个人文档
        /// Type of document (optional): Personal document
        /// </summary>
        public const string PersonalDocument = "personal_document";

        /// <summary>
        /// 商业文档
        /// Type of document (optional): Business document
        /// </summary>
        public const string BusinessDocument = "business_document";

        /// <summary>
        /// 即时通讯记录
        /// Type of document (optional): Chat log
        /// </summary>
        public const string IMChatLog = "im_chat_log";

        /// <summary>
        /// Notion 同步文档
        /// Type of document (optional): Notion document
        /// </summary>
        public const string SyncedFromNotion = "synced_from_notion";

        /// <summary>
        /// GitHub 同步文档
        /// Type of document (optional): GitHub document
        /// </summary>
        public const string SyncedFromGitHub = "synced_from_github";

        /// <summary>
        /// 其他文档类型
        /// Type of document (optional): Other document types
        /// </summary>
        public const string Others = "others";
    }

}
