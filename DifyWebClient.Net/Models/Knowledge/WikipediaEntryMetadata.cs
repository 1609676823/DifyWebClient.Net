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
    /// 维基百科条目 Wikipedia entry
    /// </summary>
    public class WikipediaEntryMetadata : DocMetadata
    {
        /// <summary>
        /// 标题
        /// Title of the Wikipedia entry
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// Language of the Wikipedia entry
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 网页URL
        /// Web page URL of the Wikipedia entry
        /// </summary>
        public string WebPageUrl { get; set; } = string.Empty;

        /// <summary>
        /// 最后编辑日期
        /// Last edit date of the Wikipedia entry
        /// </summary>
        public string LastEditDate { get; set; } = string.Empty;

        /// <summary>
        /// 编辑/贡献者
        /// Editor or contributor of the Wikipedia entry
        /// </summary>
        public string EditorContributor { get; set; } = string.Empty;

        /// <summary>
        /// 摘要/介绍
        /// Summary or introduction of the Wikipedia entry
        /// </summary>
        public string SummaryIntroduction { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public WikipediaEntryMetadata() { }
    }
}
