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
    /// 个人文档 Personal document
    /// </summary>
    public class PersonalDocumentMetadata : DocMetadata
    {
        /// <summary>
        /// 标题
        /// Title of the personal document
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 作者
        /// Author of the personal document
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// 创建日期
        /// Creation date of the personal document
        /// </summary>
        public string CreationDate { get; set; } = string.Empty;

        /// <summary>
        /// 最后修改日期
        /// Last modified date of the personal document
        /// </summary>
        public string LastModifiedDate { get; set; } = string.Empty;

        /// <summary>
        /// 文档类型
        /// Type of the personal document
        /// </summary>
        public string DocumentType { get; set; } = string.Empty;

        /// <summary>
        /// 标签/分类
        /// Tags or category of the personal document
        /// </summary>
        public string TagsCategory { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public PersonalDocumentMetadata() { }
    }
}
