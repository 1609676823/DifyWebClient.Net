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
    /// 图书 Book
    /// </summary>
    public class BookMetadata : DocMetadata
    {
        /// <summary>
        /// 书名
        /// Title of the book
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// Language of the book
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 作者
        /// Author of the book
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// 出版社
        /// Publisher of the book
        /// </summary>
        public string Publisher { get; set; } = string.Empty;

        /// <summary>
        /// 出版日期
        /// Publication date of the book
        /// </summary>
        public string PublicationDate { get; set; } = string.Empty;

        /// <summary>
        /// 国际标准书号
        /// ISBN of the book
        /// </summary>
        public string ISBN { get; set; } = string.Empty;

        /// <summary>
        /// 分类
        /// Category of the book
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public BookMetadata() { }
    }
}
