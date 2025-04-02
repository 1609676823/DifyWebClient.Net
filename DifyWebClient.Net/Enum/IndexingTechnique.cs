using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 索引方式
    /// Index mode
    /// </summary>
    public static class IndexingTechnique
    {
        /// <summary>
        /// 高质量: 使用 embedding 模型进行嵌入，构建为向量数据库索引
        /// Index mode: High quality - embedding using embedding model, built as vector database index
        /// </summary>
        public const string HighQuality = "high_quality";

        /// <summary>
        /// 经济: 使用 keyword table index 的倒排索引进行构建
        /// Index mode: Economy - Build using inverted index of keyword table index
        /// </summary>
        public const string Economy = "economy";
    }

}
