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
    ///社交媒体帖子 Social media post 
    /// </summary>
    public class SocialMediaPostMetadata : DocMetadata
    {
        /// <summary>
        /// 平台
        /// Platform of the social media post
        /// </summary>
        public string Platform { get; set; } = string.Empty;

        /// <summary>
        /// 作者/用户名
        /// Author or username of the social media post
        /// </summary>
        public string AuthorUsername { get; set; } = string.Empty;

        /// <summary>
        /// 发布日期
        /// Publish date of the social media post
        /// </summary>
        public string PublishDate { get; set; } = string.Empty;

        /// <summary>
        /// 帖子URL
        /// URL of the social media post
        /// </summary>
        public string PostUrl { get; set; } = string.Empty;

        /// <summary>
        /// 主题/标签
        /// Topic or tags of the social media post
        /// </summary>
        public string TopicTags { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public SocialMediaPostMetadata() { }
    }
}
