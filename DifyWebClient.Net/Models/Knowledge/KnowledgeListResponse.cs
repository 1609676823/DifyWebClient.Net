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
#pragma warning disable IDE1006 // Naming Styles

    /// <summary>
    /// Represents the response model for a list of knowledge data.
    /// 表示知识数据列表的响应模型。
    /// </summary>
    public class KnowledgeListResponse
    {
        /// <summary>
        /// Gets or sets the list of data items.
        /// 获取或设置数据项列表。
        /// </summary>
        public List<KnowledgeDataList>? data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there are more items.
        /// 获取或设置一个值，指示是否有更多项。
        /// </summary>
        public bool has_more { get; set; }

        /// <summary>
        /// Gets or sets the limit of items per request.
        /// 获取或设置每次请求的项限制。
        /// </summary>
        public long limit { get; set; }

        /// <summary>
        /// Gets or sets the total number of items.
        /// 获取或设置项的总数。
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// 获取或设置当前页码。
        /// </summary>
        public long page { get; set; }

        /// <summary>
        /// The real JSON string representation of the response.
        /// 响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        private string? realJsonstring = string.Empty;

        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        public string? RealJsonstring {
        get { return realJsonstring; } 
        set {
                realJsonstring = value;
                try
                {
                    DeserializeKnowledgeListResponse(value!);
                }
                catch (Exception)
                {

                   // throw;
                }
            }
        }

        /// <summary>
        /// Deserializes the JSON object to populate the properties of DataList.
        /// 反序列化 JSON 对象以填充 DataList 的属性。
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeKnowledgeListResponse(string json)
        {
            JsonNode jsonNode = JsonNode.Parse(json)!;

            // Parse main properties and assign to this instance
            try { this.has_more = jsonNode["has_more"]!.GetValue<bool>(); } catch (Exception) { }
            try { this.limit = jsonNode["limit"]!.GetValue<long>(); } catch (Exception) { }
            try { this.total = jsonNode["total"]!.GetValue<long>(); } catch (Exception) { }
            try { this.page = jsonNode["page"]!.GetValue<long>(); } catch (Exception) { }

            // Parse data array and assign to this instance
            this.data = new List<KnowledgeDataList>();
            try
            {
                JsonArray dataArray = jsonNode["data"]!.AsArray();
                
                foreach (JsonNode dataItem in dataArray!)
                {
                    KnowledgeDataList dataList = new KnowledgeDataList();
                    try { dataList.id = dataItem["id"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.name = dataItem["name"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.description = dataItem["description"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.provider = dataItem["provider"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.permission = dataItem["permission"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.data_source_type = dataItem["data_source_type"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.indexing_technique = dataItem["indexing_technique"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.app_count = dataItem["app_count"]!.GetValue<long>(); } catch (Exception) { }
                    try { dataList.document_count = dataItem["document_count"]!.GetValue<long>(); } catch (Exception) { }
                    try { dataList.word_count = dataItem["word_count"]!.GetValue<long>(); } catch (Exception) { }
                    try { dataList.created_by = dataItem["created_by"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.created_at = dataItem["created_at"]!.GetValue<long>(); } catch (Exception) { }
                    try { dataList.updated_by = dataItem["updated_by"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.updated_at = dataItem["updated_at"]!.GetValue<long>(); } catch (Exception) { }
                    try { dataList.embedding_model = dataItem["embedding_model"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.embedding_model_provider = dataItem["embedding_model_provider"]!.GetValue<string>(); } catch (Exception) { }
                    try { dataList.embedding_available = dataItem["embedding_available"]!.GetValue<bool>(); } catch (Exception) { }
                    try
                    {
                        dataList.retrieval_model_dict = dataItem["retrieval_model_dict"] != null ? new Retrieval_Model_Dict
                        {
                            search_method = dataItem["retrieval_model_dict"]!["search_method"]!.GetValue<string>(),
                            reranking_enable = dataItem["retrieval_model_dict"]!["reranking_enable"]!.GetValue<bool>(),
                            reranking_mode = dataItem["retrieval_model_dict"]!["reranking_mode"]?.GetValue<string>(),
                            reranking_model = dataItem["retrieval_model_dict"]!["reranking_model"] != null ? new Reranking_Model
                            {
                                reranking_provider_name = dataItem["retrieval_model_dict"]!["reranking_model"]!["reranking_provider_name"]!.GetValue<string>(),
                                reranking_model_name = dataItem["retrieval_model_dict"]!["reranking_model"]!["reranking_model_name"]!.GetValue<string>()
                            } : null,
                            weights = dataItem["retrieval_model_dict"]!["weights"] != null ? new Weights
                            {
                                keyword_setting = dataItem["retrieval_model_dict"]!["weights"]!["keyword_setting"] != null ? new Keyword_Setting
                                {
                                    keyword_weight = dataItem["retrieval_model_dict"]!["weights"]!["keyword_setting"]!["keyword_weight"]!.GetValue<double>()
                                } : null,
                                vector_setting = dataItem["retrieval_model_dict"]!["weights"]!["vector_setting"] != null ? new Vector_Setting
                                {
                                    vector_weight = dataItem["retrieval_model_dict"]!["weights"]!["vector_setting"]!["vector_weight"]!.GetValue<double>(),
                                    embedding_model_name = dataItem["retrieval_model_dict"]!["weights"]!["vector_setting"]!["embedding_model_name"]!.GetValue<string>(),
                                    embedding_provider_name = dataItem["retrieval_model_dict"]!["weights"]!["vector_setting"]!["embedding_provider_name"]!.GetValue<string>()
                                } : null
                            } : null,
                            top_k = dataItem["retrieval_model_dict"]!["top_k"]!.GetValue<long>(),
                            score_threshold_enabled = dataItem["retrieval_model_dict"]!["score_threshold_enabled"]!.GetValue<bool>(),
                            score_threshold = dataItem["retrieval_model_dict"]!["score_threshold"]!.GetValue<double>()
                        } : null;
                    }
                    catch (Exception) { }
                    try { dataList.tags = dataItem["tags"]?.AsArray().Select(tag => tag!.GetValue<string>()).ToList(); } catch (Exception) { }
                    try { dataList.doc_form = dataItem["doc_form"]?.GetValue<string>(); } catch (Exception) { }
                    try
                    {
                        dataList.external_knowledge_info = dataItem["external_knowledge_info"] != null ? new External_Knowledge_Info
                        {
                            external_knowledge_id = dataItem["external_knowledge_info"]!["external_knowledge_id"]?.GetValue<string>(),
                            external_knowledge_api_id = dataItem["external_knowledge_info"]!["external_knowledge_api_id"]?.GetValue<string>(),
                            external_knowledge_api_name = dataItem["external_knowledge_info"]!["external_knowledge_api_name"]?.GetValue<string>(),
                            external_knowledge_api_endpoint = dataItem["external_knowledge_info"]!["external_knowledge_api_endpoint"]?.GetValue<string>()
                        } : null;
                    }
                    catch (Exception) { }
                    try
                    {
                        dataList.external_retrieval_model = dataItem["external_retrieval_model"] != null ? new External_Retrieval_Model
                        {
                            top_k = dataItem["external_retrieval_model"]!["top_k"]!.GetValue<long>(),
                            score_threshold = dataItem["external_retrieval_model"]!["score_threshold"]!.GetValue<double>(),
                            score_threshold_enabled = dataItem["external_retrieval_model"]!["score_threshold_enabled"]!.GetValue<bool>()
                        } : null;
                    }
                    catch (Exception) { }

                    this.data.Add(dataList);
                }
            }
            catch (Exception) { }
        }
    
}

    /// <summary>
    /// Represents a single data item in the list.
    /// 表示列表中的单个数据项。
    /// </summary>
    public class KnowledgeDataList
    {
        /// <summary>
        /// Gets or sets the identifier of the data item.
        /// 获取或设置数据项的标识符。
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// Gets or sets the name of the data item.
        /// 获取或设置数据项的名称。
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// Gets or sets the description of the data item.
        /// 获取或设置数据项的描述。
        /// </summary>
        public string? description { get; set; }

        /// <summary>
        /// Gets or sets the provider of the data item.
        /// 获取或设置数据项的提供者。
        /// </summary>
        public string? provider { get; set; }

        /// <summary>
        /// Gets or sets the permission associated with the data item.
        /// 获取或设置与数据项关联的权限。
        /// </summary>
        public string? permission { get; set; }

        /// <summary>
        /// Gets or sets the type of data source.
        /// 获取或设置数据源类型。
        /// </summary>
        public string? data_source_type { get; set; }

        /// <summary>
        /// Gets or sets the technique used for indexing the data.
        /// 获取或设置用于索引数据的技术。
        /// </summary>
        public string? indexing_technique { get; set; }

        /// <summary>
        /// Gets or sets the count of applications associated with the data item.
        /// 获取或设置与数据项关联的应用程序数量。
        /// </summary>
        public long app_count { get; set; }

        /// <summary>
        /// Gets or sets the count of documents associated with the data item.
        /// 获取或设置与数据项关联的文档数量。
        /// </summary>
        public long document_count { get; set; }

        /// <summary>
        /// Gets or sets the count of words associated with the data item.
        /// 获取或设置与数据项关联的词汇数量。
        /// </summary>
        public long word_count { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the data item.
        /// 获取或设置创建数据项的用户标识符。
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the data item was created.
        /// 获取或设置数据项创建时的时间戳。
        /// </summary>
        public long created_at { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who updated the data item.
        /// 获取或设置更新数据项的用户标识符。
        /// </summary>
        public string? updated_by { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the data item was updated.
        /// 获取或设置数据项更新时的时间戳。
        /// </summary>
        public long updated_at { get; set; }

        /// <summary>
        /// Gets or sets the embedding model used for the data item.
        /// 获取或设置数据项使用的嵌入模型。
        /// </summary>
        public string? embedding_model { get; set; }

        /// <summary>
        /// Gets or sets the provider of the embedding model.
        /// 获取或设置嵌入模型的提供者。
        /// </summary>
        public string? embedding_model_provider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether embedding is available for the data item.
        /// 获取或设置一个值，指示数据项是否可用嵌入。
        /// </summary>
        public bool embedding_available { get; set; }

        /// <summary>
        /// Gets or sets the retrieval model dictionary associated with the data item.
        /// 获取或设置与数据项关联的检索模型字典。
        /// </summary>
        public Retrieval_Model_Dict? retrieval_model_dict { get; set; }

        /// <summary>
        /// Gets or sets the list of tags associated with the data item.
        /// 获取或设置与数据项关联的标签列表。
        /// </summary>
        public List<string>? tags { get; set; }

        /// <summary>
        /// Gets or sets the document form associated with the data item.
        /// 获取或设置与数据项关联的文档形式。
        /// </summary>
        public string? doc_form { get; set; }

        /// <summary>
        /// Gets or sets the external knowledge information associated with the data item.
        /// 获取或设置与数据项关联的外部知识信息。
        /// </summary>
        public External_Knowledge_Info? external_knowledge_info { get; set; }

        /// <summary>
        /// Gets or sets the external retrieval model associated with the data item.
        /// 获取或设置与数据项关联的外部检索模型。
        /// </summary>
        public External_Retrieval_Model? external_retrieval_model { get; set; }
    }

    /// <summary>
    /// Represents the retrieval model dictionary.
    /// 表示检索模型字典。
    /// </summary>
    public class Retrieval_Model_Dict
    {
        /// <summary>
        /// Gets or sets the search method.
        /// 获取或设置搜索方法。
        /// </summary>
        public string? search_method { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether reranking is enabled.
        /// 获取或设置一个值，指示是否启用重排序。
        /// </summary>
        public bool reranking_enable { get; set; }

        /// <summary>
        /// Gets or sets the reranking mode.
        /// 获取或设置重排序模式。
        /// </summary>
        public string? reranking_mode { get; set; }

        /// <summary>
        /// Gets or sets the reranking model.
        /// 获取或设置重排序模型。
        /// </summary>
        public Reranking_Model? reranking_model { get; set; }

        /// <summary>
        /// Gets or sets the weights associated with the retrieval model.
        /// 获取或设置与检索模型关联的权重。
        /// </summary>
        public Weights? weights { get; set; }

        /// <summary>
        /// Gets or sets the top K results to retrieve.
        /// 获取或设置要检索的前 K 结果。
        /// </summary>
        public long top_k { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether score threshold is enabled.
        /// 获取或设置一个值，指示是否启用分数阈值。
        /// </summary>
        public bool score_threshold_enabled { get; set; }

        /// <summary>
        /// Gets or sets the score threshold.
        /// 获取或设置分数阈值。
        /// </summary>
        public double score_threshold { get; set; }
    }

    /// <summary>
    /// Represents the reranking model.
    /// 表示重排序模型。
    /// </summary>
    public class Reranking_Model
    {
        /// <summary>
        /// Gets or sets the name of the reranking provider.
        /// 获取或设置重排序提供者的名称。
        /// </summary>
        public string? reranking_provider_name { get; set; }

        /// <summary>
        /// Gets or sets the name of the reranking model.
        /// 获取或设置重排序模型的名称。
        /// </summary>
        public string? reranking_model_name { get; set; }
    }

    /// <summary>
    /// Represents the weights for the retrieval model.
    /// 表示检索模型的权重。
    /// </summary>
    public class Weights
    {
        /// <summary>
        /// Gets or sets the keyword setting.
        /// 获取或设置关键词设置。
        /// </summary>
        public Keyword_Setting? keyword_setting { get; set; }

        /// <summary>
        /// Gets or sets the vector setting.
        /// 获取或设置向量设置。
        /// </summary>
        public Vector_Setting? vector_setting { get; set; }
    }

    /// <summary>
    /// Represents the keyword setting for the weights.
    /// 表示权重的关键词设置。
    /// </summary>
    public class Keyword_Setting
    {
        /// <summary>
        /// Gets or sets the weight for keywords.
        /// 获取或设置关键词的权重。
        /// </summary>
        public double keyword_weight { get; set; }
    }

    /// <summary>
    /// Represents the vector setting for the weights.
    /// 表示权重的向量设置。
    /// </summary>
    public class Vector_Setting
    {
        /// <summary>
        /// Gets or sets the weight for vectors.
        /// 获取或设置向量的权重。
        /// </summary>
        public double vector_weight { get; set; }

        /// <summary>
        /// Gets or sets the name of the embedding model.
        /// 获取或设置嵌入模型的名称。
        /// </summary>
        public string? embedding_model_name { get; set; }

        /// <summary>
        /// Gets or sets the name of the embedding provider.
        /// 获取或设置嵌入提供者的名称。
        /// </summary>
        public string? embedding_provider_name { get; set; }
    }

    /// <summary>
    /// Represents the external knowledge information.
    /// 表示外部知识信息。
    /// </summary>
    public class External_Knowledge_Info
    {
        /// <summary>
        /// Gets or sets the external knowledge identifier.
        /// 获取或设置外部知识标识符。
        /// </summary>
        public string? external_knowledge_id { get; set; }

        /// <summary>
        /// Gets or sets the external knowledge API identifier.
        /// 获取或设置外部知识 API 标识符。
        /// </summary>
        public string? external_knowledge_api_id { get; set; }

        /// <summary>
        /// Gets or sets the name of the external knowledge API.
        /// 获取或设置外部知识 API 的名称。
        /// </summary>
        public string? external_knowledge_api_name { get; set; }

        /// <summary>
        /// Gets or sets the endpoint of the external knowledge API.
        /// 获取或设置外部知识 API 的端点。
        /// </summary>
        public string? external_knowledge_api_endpoint { get; set; }
    }

    /// <summary>
    /// Represents the external retrieval model.
    /// 表示外部检索模型。
    /// </summary>
    public class External_Retrieval_Model
    {
        /// <summary>
        /// Gets or sets the top K results to retrieve.
        /// 获取或设置要检索的前 K 结果。
        /// </summary>
        public long top_k { get; set; }

        /// <summary>
        /// Gets or sets the score threshold.
        /// 获取或设置分数阈值。
        /// </summary>
        public double score_threshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether score threshold is enabled.
        /// 获取或设置一个值，指示是否启用分数阈值。
        /// </summary>
        public bool score_threshold_enabled { get; set; }
    }

#pragma warning restore IDE1006 // Naming Styles
}