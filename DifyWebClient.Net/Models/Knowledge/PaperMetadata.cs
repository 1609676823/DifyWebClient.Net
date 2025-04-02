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
    /// 学术论文/文章 Academic paper/article
    /// </summary>
    public class PaperMetadata : DocMetadata
    {
        /// <summary>
        /// 标题
        /// Title of the paper
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// Language of the paper
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 作者
        /// Author of the paper
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// 发布日期
        /// Publish date of the paper
        /// </summary>
        public string PublishDate { get; set; } = string.Empty;

        /// <summary>
        /// 期刊/会议名称
        /// Journal or conference name
        /// </summary>
        public string JournalConferenceName { get; set; } = string.Empty;

        /// <summary>
        /// 卷号/期号/页码
        /// Volume, issue, and page numbers
        /// </summary>
        public string VolumeIssuePageNumbers { get; set; } = string.Empty;

        /// <summary>
        /// 数字对象唯一标识符
        /// DOI of the paper
        /// </summary>
        public string DOI { get; set; } = string.Empty;

        /// <summary>
        /// 主题/关键词
        /// Topic or keywords of the paper
        /// </summary>
        public string TopicKeywords { get; set; } = string.Empty;

        /// <summary>
        /// 摘要
        /// Abstract of the paper
        /// </summary>
        public string Abstract { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public PaperMetadata() { }
    }
}
