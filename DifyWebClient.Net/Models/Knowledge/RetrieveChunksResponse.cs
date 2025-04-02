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
    /// 检索块响应类，包含查询信息和记录列表。
    /// Retrieve chunks response class, containing query information and a list of records.
    /// </summary>
    public class RetrieveChunksResponse
    {
        /// <summary>
        /// 查询信息，包含查询内容。
        /// Query information, including the query content.
        /// </summary>
        public RetrieveChunksResponseQuery? query { get; set; }

        /// <summary>
        /// 记录列表，每个记录包含一个块信息。
        /// List of records, each record contains a segment information.
        /// </summary>
        public List<RetrieveChunksResponseRecord>? records { get; set; }

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
        public string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value;
                try
                {
                    DeserializeRetrieveChunksResponse(value!);
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
        public virtual void DeserializeRetrieveChunksResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        var queryNode = jsonNode["query"];
                        if (queryNode != null)
                        {
                            this.query = new RetrieveChunksResponseQuery
                            {
                                content = queryNode["content"]?.GetValue<string>()
                            };
                        }
                    }
                    catch { }

                    try
                    {
                        var recordsNode = jsonNode["records"];
                        if (recordsNode is JsonArray recordsArray)
                        {
                            this.records = new List<RetrieveChunksResponseRecord>();
                            foreach (var recordNode in recordsArray)
                            {
                                var record = new RetrieveChunksResponseRecord();
                                try
                                {
                                    var segmentNode = recordNode!["segment"];
                                    if (segmentNode != null)
                                    {
                                        var segment = new RetrieveChunksResponseSegment();
                                        try
                                        {
                                            segment.id = segmentNode["id"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.position = segmentNode["position"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.document_id = segmentNode["document_id"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.content = segmentNode["content"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.sign_content = segmentNode["sign_content"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.word_count = segmentNode["word_count"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.tokens = segmentNode["tokens"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.index_node_id = segmentNode["index_node_id"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.index_node_hash = segmentNode["index_node_hash"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.hit_count = segmentNode["hit_count"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.enabled = segmentNode["enabled"]?.GetValue<bool>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.status = segmentNode["status"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.created_by = segmentNode["created_by"]?.GetValue<string>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.created_at = segmentNode["created_at"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.indexing_at = segmentNode["indexing_at"]?.GetValue<long>();
                                        }
                                        catch { }
                                        try
                                        {
                                            segment.completed_at = segmentNode["completed_at"]?.GetValue<long>();
                                        }
                                        catch { }

                                        try
                                        {
                                            var keywordsNode = segmentNode["keywords"];
                                            if (keywordsNode is JsonArray keywordsArray)
                                            {
                                                segment.keywords = new List<string>();
                                                foreach (var keywordNode in keywordsArray)
                                                {
                                                    try
                                                    {
                                                        segment.keywords.Add(keywordNode!.GetValue<string>());
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch { }

                                        try
                                        {
                                            var documentNode = segmentNode["document"];
                                            if (documentNode != null)
                                            {
                                                segment.document = new RetrieveChunksResponseDocument();
                                                try
                                                {
                                                    segment.document.id = documentNode["id"]?.GetValue<string>();
                                                }
                                                catch { }
                                                try
                                                {
                                                    segment.document.data_source_type = documentNode["data_source_type"]?.GetValue<string>();
                                                }
                                                catch { }
                                                try
                                                {
                                                    segment.document.name = documentNode["name"]?.GetValue<string>();
                                                }
                                                catch { }
                                            }
                                        }
                                        catch { }

                                        record.segment = segment;
                                    }
                                }
                                catch { }

                                this.records.Add(record);
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
    }

    /// <summary>
    /// 检索块查询类，包含查询内容。
    /// Retrieve chunks query class, containing the query content.
    /// </summary>
    public class RetrieveChunksResponseQuery
    {
        /// <summary>
        /// 查询的具体内容。
        /// The specific content of the query.
        /// </summary>
        public string? content { get; set; }
    }

    /// <summary>
    /// 检索块记录类，包含块信息、子块、得分和 t-SNE 位置。
    /// Retrieve chunks record class, containing segment information, child chunks, score, and t-SNE position.
    /// </summary>
    public class RetrieveChunksResponseRecord
    {
        /// <summary>
        /// 块信息，包含块的各种属性。
        /// Segment information, including various attributes of the segment.
        /// </summary>
        public RetrieveChunksResponseSegment? segment { get; set; }

        /// <summary>
        /// 子块信息，可为空。
        /// Child chunks information, can be null.
        /// </summary>
        public object? child_chunks { get; set; }

        /// <summary>
        /// 得分信息，可为空。
        /// Score information, can be null.
        /// </summary>
        public object? score { get; set; }

        /// <summary>
        /// t-SNE 位置信息，可为空。
        /// t-SNE position information, can be null.
        /// </summary>
        public object? tsne_position { get; set; }
    }

    /// <summary>
    /// 检索块段类，包含块的详细信息。
    /// Retrieve chunks segment class, containing detailed information of the segment.
    /// </summary>
    public class RetrieveChunksResponseSegment
    {
        /// <summary>
        /// 块的唯一标识符。
        /// The unique identifier of the segment.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 块的位置编号。
        /// The position number of the segment.
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 文档的唯一标识符。
        /// The unique identifier of the document.
        /// </summary>
        public string? document_id { get; set; }

        /// <summary>
        /// 块的内容。
        /// The content of the segment.
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 块的签名内容。
        /// The signed content of the segment.
        /// </summary>
        public string? sign_content { get; set; }

        /// <summary>
        /// 答案信息，可为空。
        /// Answer information, can be null.
        /// </summary>
        public object? answer { get; set; }

        /// <summary>
        /// 块的字数。
        /// The word count of the segment.
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 块的标记数。
        /// The token count of the segment.
        /// </summary>
        public long? tokens { get; set; }

        /// <summary>
        /// 块的关键词列表。
        /// The list of keywords of the segment.
        /// </summary>
        public List<string>? keywords { get; set; }

        /// <summary>
        /// 索引节点的唯一标识符。
        /// The unique identifier of the index node.
        /// </summary>
        public string? index_node_id { get; set; }

        /// <summary>
        /// 索引节点的哈希值。
        /// The hash value of the index node.
        /// </summary>
        public string? index_node_hash { get; set; }

        /// <summary>
        /// 命中次数。
        /// The hit count.
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 启用状态。
        /// The enabled status.
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 禁用时间，可为空。
        /// The disabled time, can be null.
        /// </summary>
        public object? disabled_at { get; set; }

        /// <summary>
        /// 禁用者，可为空。
        /// The person who disabled it, can be null.
        /// </summary>
        public object? disabled_by { get; set; }

        /// <summary>
        /// 状态信息。
        /// The status information.
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 创建者的唯一标识符。
        /// The unique identifier of the creator.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 创建时间。
        /// The creation time.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 索引时间。
        /// The indexing time.
        /// </summary>
        public long? indexing_at { get; set; }

        /// <summary>
        /// 完成时间。
        /// The completion time.
        /// </summary>
        public long? completed_at { get; set; }

        /// <summary>
        /// 错误信息，可为空。
        /// Error information, can be null.
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 停止时间，可为空。
        /// The stop time, can be null.
        /// </summary>
        public object? stopped_at { get; set; }

        /// <summary>
        /// 文档信息，包含文档的各种属性。
        /// Document information, including various attributes of the document.
        /// </summary>
        public RetrieveChunksResponseDocument? document { get; set; }
    }

    /// <summary>
    /// 检索块文档类，包含文档的详细信息。
    /// Retrieve chunks document class, containing detailed information of the document.
    /// </summary>
    public class RetrieveChunksResponseDocument
    {
        /// <summary>
        /// 文档的唯一标识符。
        /// The unique identifier of the document.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 数据源类型。
        /// The data source type.
        /// </summary>
        public string? data_source_type { get; set; }

        /// <summary>
        /// 文档的名称。
        /// The name of the document.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 文档类型，可为空。
        /// The document type, can be null.
        /// </summary>
        public object? doc_type { get; set; }

        /// <summary>
        /// 文档元数据，可为空。
        /// The document metadata, can be null.
        /// </summary>
        public object? doc_metadata { get; set; }
    }
}
