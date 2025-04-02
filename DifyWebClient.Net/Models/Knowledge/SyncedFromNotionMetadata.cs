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
    /// Notion同步文档 Notion document
    /// </summary>
    public class SyncedFromNotionMetadata : DocMetadata
    {
        /// <summary>
        /// 标题
        /// Title of the synced document from Notion
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// Language of the synced document from Notion
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 作者/创建者
        /// Author or creator of the synced document from Notion
        /// </summary>
        public string AuthorCreator { get; set; } = string.Empty;

        /// <summary>
        /// 创建日期
        /// Creation date of the synced document from Notion
        /// </summary>
        public string CreationDate { get; set; } = string.Empty;

        /// <summary>
        /// 最后修改日期
        /// Last modified date of the synced document from Notion
        /// </summary>
        public string LastModifiedDate { get; set; } = string.Empty;

        /// <summary>
        /// Notion页面链接
        /// Notion page link
        /// </summary>
        public string NotionPageLink { get; set; } = string.Empty;

        /// <summary>
        /// 分类/标签
        /// Category or tags of the synced document from Notion
        /// </summary>
        public string CategoryTags { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// Description of the synced document from Notion
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public SyncedFromNotionMetadata() { }
    }
}
