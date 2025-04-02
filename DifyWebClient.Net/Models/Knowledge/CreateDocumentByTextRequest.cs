using DifyWebClient.Net.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 创建基于文本的请求
    /// Request Body for creating by text
    /// </summary>
    public class CreateDocumentByTextRequest
    {
        /// <summary>
        /// 创建基于文本的请求
        /// Request Body for creating by text
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public CreateDocumentByTextRequest(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        /// <summary>
        /// 文档名称
        /// Document name
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 文档内容
        /// Document content
        /// </summary>
        public string text { get; set; } = string.Empty;

        /// <summary>
        /// 索引方式
        /// Index mode:
        /// high_quality 高质量：使用 embedding 模型进行嵌入，构建为向量数据库索引
        /// economy 经济：使用 keyword table index 的倒排索引进行构建
        /// </summary>
        public string indexing_technique { get; set; } = IndexingTechnique.HighQuality;

        ///// <summary>
        ///// 文档类型（选填）
        ///// Type of document (optional):
        ///// </summary>
        //public string doc_type { get; set; } = string.Empty;

        ///// <summary>
        ///// 文档元数据（如提供文档类型则必填）。字段因文档类型而异
        ///// Document metadata (required if doc_type is provided). Fields vary by doc_type
        ///// </summary>
        //public DocMetadata doc_metadata { get; set; } = new DocMetadata();

        /// <summary>
        /// 索引内容的形式
        /// Format of indexed content
        /// </summary>
        public string doc_form { get; set; } = DocForm.TextModel;

        /// <summary>
        /// 在 QA 模式下，指定文档的语言，例如：English、Chinese
        /// In QA mode, specify the language of the document, for example: English, Chinese
        /// </summary>
        public string? doc_language { get; set; } =null;

        /// <summary>
        /// 处理规则
        /// Processing rules
        /// </summary>
        public ProcessRule process_rule { get; set; } = new ProcessRule();

        /// <summary>
        /// 检索模式
        /// Retrieval mode
        /// </summary>
        public RetrievalModel retrieval_model { get; set; } = new RetrievalModel();

        /// <summary>
        /// Embedding 模型名称
        /// Embedding model name
        /// </summary>
        public string embedding_model { get; set; } = string.Empty;

        /// <summary>
        /// Embedding 模型供应商
        /// Embedding model provider
        /// </summary>
        public string embedding_model_provider { get; set; } = string.Empty;
    }

    /// <summary>
    /// 检索模式类，包含检索方法、是否开启 rerank、Rerank 模型配置、召回条数、是否开启召回分数限制和召回分数限制。
    /// Retrieval mode class, containing retrieval method, whether to enable rerank, Rerank model configuration, number of recalls, whether to enable recall score limit, and recall score limit.
    /// </summary>
    public class RetrievalModel
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
        public string search_method { get; set; } = SearchMethod.HybridSearch;

        /// <summary>
        /// 是否开启 rerank。
        /// Whether to enable rerank.
        /// </summary>
        public bool reranking_enable { get; set; }=false;

        /// <summary>
        /// Rerank 模型配置。
        /// Rerank model configuration.
        /// </summary>
        public RerankingModel? reranking_model { get; set; }

        /// <summary>
        /// 召回条数。
        /// Number of recalls.
        /// </summary>
        public long top_k { get; set; } = 3;

        /// <summary>
        /// 是否开启召回分数限制。
        /// Whether to enable the recall score limit.
        /// </summary>
        public bool score_threshold_enabled { get; set; }=false ;

        /// <summary>
        /// 召回分数限制。
        /// Recall score limit.
        /// </summary>
        public double score_threshold { get; set; }
    }

    /// <summary>
    /// Rerank 模型配置类，包含 Rerank 模型的提供商和名称。
    /// Rerank model configuration class, containing the provider and name of the Rerank model.
    /// </summary>
    public class RerankingModel
    {
        /// <summary>
        /// Rerank 模型的提供商。
        /// Provider of the Rerank model.
        /// </summary>
        public string reranking_provider_name { get; set; } = string.Empty;

        /// <summary>
        /// Rerank 模型的名称。
        /// Name of the Rerank model.
        /// </summary>
        public string reranking_model_name { get; set; } = string.Empty;
    }

    /// <summary>
    /// 处理规则
    /// Processing rules
    /// </summary>
    public class ProcessRule
    {
       
        /// <summary>
        /// rules (object) 自定义规则（自动模式下，该字段为空）
        /// Custom rules (in automatic mode, this field is empty)
        /// </summary>
        //[JsonPropertyName("rules")]
        public Rules? rules { get; set; } = null;
        /// <summary>
        /// 处理模式：automatic 自动 / custom 自定义
        /// Cleaning, segmentation mode: automatic/custom
        /// </summary>
        public string mode { get; set; } = ProcessRuleMode.Automatic;

       
    }


    /*自定义规则*************************************************************************************/
    /// <summary>
    /// 自定义规则类（Custom Rules Class）
    /// </summary>
    public class Rules
    {
        /// <summary>
        /// 预处理规则（Pre-processing Rules）
        /// </summary>
       // [JsonPropertyName("pre_processing_rules")]
        public List<PreProcessingRule> pre_processing_rules { get; set; } = new List<PreProcessingRule>();

        /// <summary>
        /// 分段规则（Segmentation Rules）
        /// </summary>
        public Segmentation segmentation { get; set; } = new Segmentation();

        /// <summary>
        /// 子分段规则（Sub-chunk Segmentation Rules）
        /// </summary>
        public SubchunkSegmentation? subchunk_segmentation { get; set; } = null;
    }

    /// <summary>
    /// 预处理规则类（Pre-processing Rule Class）
    /// </summary>
    public class PreProcessingRule
    {
        /// <summary>
        /// 唯一标识符（Unique Identifier）
        /// 枚举值：
        /// remove_extra_spaces 替换连续空格、换行符、制表符
        /// remove_urls_emails 删除 URL、电子邮件地址
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用该规则（Is the Rule Enabled）
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 分段规则类（Segmentation Rules Class）
    /// </summary>
    public class Segmentation
    {
        /// <summary>
        /// 自定义分段标识符（Custom Separator）
        /// 默认为 \n
        /// </summary>
        public string separator { get; set; } = "\\n";

        /// <summary>
        /// 最大长度（Maximum Tokens）
        /// 默认为 1000
        /// </summary>
        public long max_tokens { get; set; } = 1000;

        /// <summary>
        /// 父分段的召回模式（Parent Chunk Recall Mode）
        /// 可选值：full-doc 全文召回 / paragraph 段落召回
        /// </summary>
        public string parent_mode { get; set; } = string.Empty;
    }

    /// <summary>
    /// 子分段规则类（Sub-chunk Segmentation Rules Class）
    /// </summary>
    public class SubchunkSegmentation
    {
        /// <summary>
        /// 子分段标识符（Sub-chunk Separator）
        /// 默认为 ***
        /// </summary>
        public string separator { get; set; } = "***";

        /// <summary>
        /// 最大长度（Maximum Tokens）
        /// 需要校验小于父级的长度
        /// </summary>
        public long? max_tokens { get; set; }

        /// <summary>
        /// 分段重叠部分（Chunk Overlap）
        /// 指段与段之间的重叠部分（选填）
        /// </summary>
        public long? chunk_overlap { get; set; }
    }


}
