using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 父分段的召回模式（Parent Chunk Recall Mode）
    /// 可选值：full-doc 全文召回 / paragraph 段落召回
    /// </summary>
    public static class ParentMode
    {
        /// <summary>
        /// full-doc 全文召回
        /// </summary>
        public const string FullDoc = "full-doc";
        /// <summary>
        /// paragraph 段落召回
        /// </summary>
        public const string Paragraph = "paragraph";
    }
}
