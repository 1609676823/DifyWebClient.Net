using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 索引内容的形式
    /// Format of indexed content
    /// </summary>
    public static class DocForm
    {
        /// <summary>
        /// 文本模型: 文档直接 embedding，经济模式默认为该模式
        /// Indexing content format: Text documents are directly embedded; economy mode defaults to using this form
        /// </summary>
        public const string TextModel = "text_model";

        /// <summary>
        /// 分层模型: parent-child 模式
        /// Indexing content format: Parent-child mode
        /// </summary>
        public const string HierarchicalModel = "hierarchical_model";

        /// <summary>
        /// 问答模型: 为分片文档生成 QA 对，然后对问题进行 embedding
        /// Indexing content format: QA Mode - Generates QA pairs for segmented documents and then embeds the questions
        /// </summary>
        public const string QAModel = "qa_model";
    }

}
