using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 网页 Web page
    /// </summary>
    public class WebPageMetadata : DocMetadata
    {
        /// <summary>
        /// 标题
        /// Title of the webpage
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// URL
        /// URL of the webpage
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// Language of the webpage
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 发布日期
        /// Publish date of the webpage
        /// </summary>
        public string PublishDate { get; set; } = string.Empty;

        /// <summary>
        /// 作者/出版者
        /// Author or publisher of the webpage
        /// </summary>
        public string AuthorPublisher { get; set; } = string.Empty;

        /// <summary>
        /// 主题/关键词
        /// Topic or keywords of the webpage
        /// </summary>
        public string TopicKeywords { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// Description of the webpage
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public WebPageMetadata() { }
    }
}
