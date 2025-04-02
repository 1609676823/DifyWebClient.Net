using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 检索方法。
    /// hybrid_search 混合检索。
    /// semantic_search 语义检索。
    /// full_text_search 全文检索。
    /// Retrieval method.
    /// hybrid_search: Hybrid search.
    /// semantic_search: Semantic search.
    /// full_text_search: Full - text search.
    /// </summary>
    public static class SearchMethod
    {
        /// <summary>
        /// 混合检索
        /// Hybrid search
        /// </summary>
        public const string HybridSearch = "hybrid_search";

        /// <summary>
        /// 语义检索
        /// Semantic search
        /// </summary>
        public const string SemanticSearch = "semantic_search";

        /// <summary>
        /// 全文检索
        /// Full - text search
        /// </summary>
        public const string FullTextSearch = "full_text_search";

        /// <summary>
        /// 关键字检索，仅在检索的时候可用，上传文件等使用场景不可用
        /// Keyword search
        /// </summary>
        public const string KeywordSearch = "keyword_search";
    }
}
