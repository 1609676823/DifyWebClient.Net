using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 创建空知识响应类，包含创建空知识后的相关信息。
    /// Create an empty knowledge response class, containing relevant information after creating empty knowledge.
    /// </summary>
    public class CreateEmptyKnowledgeResponse
    {
        /// <summary>
        /// 知识的唯一标识符。
        /// The unique identifier of the knowledge.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 知识的名称。
        /// The name of the knowledge.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 知识的描述信息。
        /// The description information of the knowledge.
        /// </summary>
        public string? description { get; set; }

        /// <summary>
        /// 知识的提供者。
        /// The provider of the knowledge.
        /// </summary>
        public string? provider { get; set; }

        /// <summary>
        /// 知识的访问权限。
        /// The access permission of the knowledge.
        /// </summary>
        public string? permission { get; set; }

        /// <summary>
        /// 知识的数据源类型。
        /// The data source type of the knowledge.
        /// </summary>
        public object? data_source_type { get; set; }

        /// <summary>
        /// 知识的索引技术。
        /// The indexing technique of the knowledge.
        /// </summary>
        public string? indexing_technique { get; set; }

        /// <summary>
        /// 关联的应用数量。
        /// The number of associated applications.
        /// </summary>
        public int? app_count { get; set; }

        /// <summary>
        /// 文档的数量。
        /// The number of documents.
        /// </summary>
        public int? document_count { get; set; }

        /// <summary>
        /// 知识的总字数。
        /// The total number of words in the knowledge.
        /// </summary>
        public int? word_count { get; set; }

        /// <summary>
        /// 创建知识的用户的唯一标识符。
        /// The unique identifier of the user who created the knowledge.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 知识的创建时间戳。
        /// The creation timestamp of the knowledge.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 更新知识的用户的唯一标识符。
        /// The unique identifier of the user who updated the knowledge.
        /// </summary>
        public string? updated_by { get; set; }

        /// <summary>
        /// 知识的更新时间戳。
        /// The update timestamp of the knowledge.
        /// </summary>
        public long? updated_at { get; set; }

        /// <summary>
        /// 用于生成知识嵌入的模型。
        /// The model used to generate knowledge embeddings.
        /// </summary>
        public string? embedding_model { get; set; }

        /// <summary>
        /// 嵌入模型的提供者。
        /// The provider of the embedding model.
        /// </summary>
        public string? embedding_model_provider { get; set; }

        /// <summary>
        /// 嵌入是否可用的信息。
        /// Information about whether the embedding is available.
        /// </summary>
        public object? embedding_available { get; set; }

        /// <summary>
        /// 知识检索模型的相关配置。
        /// The relevant configuration of the knowledge retrieval model.
        /// </summary>
        public RetrievalModelDict? retrieval_model_dict { get; set; }

        /// <summary>
        /// 知识的标签列表。
        /// The list of tags for the knowledge.
        /// </summary>
        public System.Collections.Generic.List<object>? tags { get; set; }

        /// <summary>
        /// 文档的格式。
        /// The format of the document.
        /// </summary>
        public object? doc_form { get; set; }

        /// <summary>
        /// 外部知识的相关信息。
        /// The relevant information of external knowledge.
        /// </summary>
        public ExternalKnowledgeInfo? external_knowledge_info { get; set; }

        /// <summary>
        /// 外部检索模型的相关配置。
        /// The relevant configuration of the external retrieval model.
        /// </summary>
        public ExternalRetrievalModel? external_retrieval_model { get; set; }

        /// <summary>
        /// 文档的元数据列表。
        /// The list of document metadata.
        /// </summary>
        public System.Collections.Generic.List<object>? doc_metadata { get; set; }

        /// <summary>
        /// 是否启用内置字段。
        /// Whether to enable built-in fields.
        /// </summary>
        public bool? built_in_field_enabled { get; set; }


        [JsonIgnore]
        private string? realJsonstring = string.Empty;

        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        public string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value;
                try
                {
                   DeserializeCreateEmptyKnowledgeResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// 解析json
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeCreateEmptyKnowledgeResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode is not null)
            {
                try
                {
                    this.id = jsonNode["id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.name = jsonNode["name"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.description = jsonNode["description"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.provider = jsonNode["provider"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.permission = jsonNode["permission"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.data_source_type = jsonNode["data_source_type"];
                }
                catch { }

                try
                {
                    this.indexing_technique = jsonNode["indexing_technique"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.app_count = jsonNode["app_count"]?.GetValue<int>();
                }
                catch { }

                try
                {
                    this.document_count = jsonNode["document_count"]?.GetValue<int>();
                }
                catch { }

                try
                {
                    this.word_count = jsonNode["word_count"]?.GetValue<int>();
                }
                catch { }

                try
                {
                    this.created_by = jsonNode["created_by"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.created_at = jsonNode["created_at"]?.GetValue<long>();
                }
                catch { }

                try
                {
                    this.updated_by = jsonNode["updated_by"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.updated_at = jsonNode["updated_at"]?.GetValue<long>();
                }
                catch { }

                try
                {
                    this.embedding_model = jsonNode["embedding_model"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.embedding_model_provider = jsonNode["embedding_model_provider"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.embedding_available = jsonNode["embedding_available"];
                }
                catch { }

                var retrievalModelNode = jsonNode["retrieval_model_dict"];
                if (retrievalModelNode is not null)
                {
                    this.retrieval_model_dict = new RetrievalModelDict();

                    try
                    {
                        this.retrieval_model_dict.search_method = retrievalModelNode["search_method"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.retrieval_model_dict.reranking_enable = retrievalModelNode["reranking_enable"]?.GetValue<bool>();
                    }
                    catch { }

                    try
                    {
                        this.retrieval_model_dict.reranking_mode = retrievalModelNode["reranking_mode"];
                    }
                    catch { }

                    var rerankingModelNode = retrievalModelNode["reranking_model"];
                    if (rerankingModelNode is not null)
                    {
                        this.retrieval_model_dict.reranking_model = new RerankingModel();

                        if (this.retrieval_model_dict.reranking_model != null)
                        {
                            try
                            {
                                this.retrieval_model_dict.reranking_model.reranking_provider_name = rerankingModelNode["reranking_provider_name"]!.GetValue<string>();
                            }
                            catch { }

                            try
                            {
                                this.retrieval_model_dict.reranking_model.reranking_model_name = rerankingModelNode["reranking_model_name"]!.GetValue<string>();
                            }
                            catch { }
                        }
                    }

                    try
                    {
                        this.retrieval_model_dict.weights = retrievalModelNode["weights"];
                    }
                    catch { }

                    try
                    {
                        this.retrieval_model_dict.top_k = retrievalModelNode["top_k"]?.GetValue<int>();
                    }
                    catch { }

                    try
                    {
                        this.retrieval_model_dict.score_threshold_enabled = retrievalModelNode["score_threshold_enabled"]?.GetValue<bool>();
                    }
                    catch { }

                    try
                    {
                        this.retrieval_model_dict.score_threshold = retrievalModelNode["score_threshold"];
                    }
                    catch { }
                }

                this.tags = new System.Collections.Generic.List<object>();
                var tagsNode = jsonNode["tags"];
                if (tagsNode is not null)
                {
                    try
                    {
                        foreach (var tag in tagsNode.AsArray())
                        {
                            this.tags.Add(tag!);
                        }
                    }
                    catch { }
                }

                try
                {
                    this.doc_form = jsonNode["doc_form"];
                }
                catch { }

                var externalKnowledgeInfoNode = jsonNode["external_knowledge_info"];
                if (externalKnowledgeInfoNode is not null)
                {
                    this.external_knowledge_info = new ExternalKnowledgeInfo();

                    try
                    {
                        this.external_knowledge_info.external_knowledge_id = externalKnowledgeInfoNode["external_knowledge_id"];
                    }
                    catch { }

                    try
                    {
                        this.external_knowledge_info.external_knowledge_api_id = externalKnowledgeInfoNode["external_knowledge_api_id"];
                    }
                    catch { }

                    try
                    {
                        this.external_knowledge_info.external_knowledge_api_name = externalKnowledgeInfoNode["external_knowledge_api_name"];
                    }
                    catch { }

                    try
                    {
                        this.external_knowledge_info.external_knowledge_api_endpoint = externalKnowledgeInfoNode["external_knowledge_api_endpoint"];
                    }
                    catch { }
                }

                var externalRetrievalModelNode = jsonNode["external_retrieval_model"];
                if (externalRetrievalModelNode is not null)
                {
                    this.external_retrieval_model = new ExternalRetrievalModel();

                    try
                    {
                        this.external_retrieval_model.top_k = externalRetrievalModelNode["top_k"]?.GetValue<int>();
                    }
                    catch { }

                    try
                    {
                        this.external_retrieval_model.score_threshold = externalRetrievalModelNode["score_threshold"]?.GetValue<int>();
                    }
                    catch { }

                    try
                    {
                        this.external_retrieval_model.score_threshold_enabled = externalRetrievalModelNode["score_threshold_enabled"];
                    }
                    catch { }
                }

                this.doc_metadata = new System.Collections.Generic.List<object>();
                var docMetadataNode = jsonNode["doc_metadata"];
                if (docMetadataNode is not null)
                {
                    try
                    {
                        foreach (var metadata in docMetadataNode.AsArray())
                        {
                            this.doc_metadata.Add(metadata!);
                        }
                    }
                    catch { }
                }

                try
                {
                    this.built_in_field_enabled = jsonNode["built_in_field_enabled"]?.GetValue<bool>();
                }
                catch { }
            }
        }
    }

    /// <summary>
    /// 检索模型的配置信息类。
    /// Retrieval model configuration information class.
    /// </summary>
    public class RetrievalModelDict
    {
        /// <summary>
        /// 搜索方法，如语义搜索。
        /// The search method, such as semantic search.
        /// </summary>
        public string? search_method { get; set; }

        /// <summary>
        /// 是否启用重排序功能。
        /// Whether to enable the re-ranking function.
        /// </summary>
        public bool? reranking_enable { get; set; }

        /// <summary>
        /// 重排序模式。
        /// The re-ranking mode.
        /// </summary>
        public object? reranking_mode { get; set; }

        /// <summary>
        /// 重排序模型的相关信息。
        /// The relevant information of the re-ranking model.
        /// </summary>
        public RerankingModel? reranking_model { get; set; }

        /// <summary>
        /// 搜索权重。
        /// Search weights.
        /// </summary>
        public object? weights { get; set; }

        /// <summary>
        /// 返回的结果数量。
        /// The number of results to return.
        /// </summary>
        public int? top_k { get; set; }

        /// <summary>
        /// 是否启用分数阈值过滤。
        /// Whether to enable score threshold filtering.
        /// </summary>
        public bool? score_threshold_enabled { get; set; }

        /// <summary>
        /// 分数阈值。
        /// The score threshold.
        /// </summary>
        public object? score_threshold { get; set; }
    }

    /// <summary>
    /// 外部知识信息类。
    /// External knowledge information class.
    /// </summary>
    public class ExternalKnowledgeInfo
    {
        /// <summary>
        /// 外部知识的唯一标识符。
        /// The unique identifier of external knowledge.
        /// </summary>
        public object? external_knowledge_id { get; set; }

        /// <summary>
        /// 外部知识 API 的唯一标识符。
        /// The unique identifier of the external knowledge API.
        /// </summary>
        public object? external_knowledge_api_id { get; set; }

        /// <summary>
        /// 外部知识 API 的名称。
        /// The name of the external knowledge API.
        /// </summary>
        public object? external_knowledge_api_name { get; set; }

        /// <summary>
        /// 外部知识 API 的端点。
        /// The endpoint of the external knowledge API.
        /// </summary>
        public object? external_knowledge_api_endpoint { get; set; }
    }

    /// <summary>
    /// 外部检索模型配置类。
    /// External retrieval model configuration class.
    /// </summary>
    public class ExternalRetrievalModel
    {
        /// <summary>
        /// 外部检索返回的结果数量。
        /// The number of results returned by external retrieval.
        /// </summary>
        public int? top_k { get; set; }

        /// <summary>
        /// 外部检索的分数阈值。
        /// The score threshold for external retrieval.
        /// </summary>
        public int? score_threshold { get; set; }

        /// <summary>
        /// 是否启用外部检索的分数阈值过滤。
        /// Whether to enable score threshold filtering for external retrieval.
        /// </summary>
        public object? score_threshold_enabled { get; set; }
    }
}
