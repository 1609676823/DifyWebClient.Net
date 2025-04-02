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
    /// 获取片段响应类，包含片段数据列表及相关分页等信息。
    /// Get segments response class, containing segment data list and related pagination information.
    /// </summary>
    public class GetSegmentsResponse
    {
        /// <summary>
        /// 片段数据列表。
        /// List of segment data.
        /// </summary>
        public List<SegmentData>? data { get; set; }

        /// <summary>
        /// 文档格式，例如 "text_model"。
        /// Document format, e.g., "text_model".
        /// </summary>
        public string? doc_form { get; set; }

        /// <summary>
        /// 数据总数量。
        /// Total number of data.
        /// </summary>
        public long? total { get; set; }

        /// <summary>
        /// 是否还有更多数据，false 表示没有更多数据。
        /// Whether there is more data, false indicates there is no more data.
        /// </summary>
        public bool? has_more { get; set; }

        /// <summary>
        /// 每页数据的限制数量，例如 20。
        /// Limit number of data per page, e.g., 20.
        /// </summary>
        public long? limit { get; set; }

        /// <summary>
        /// 当前页码，例如 1。
        /// Current page number, e.g., 1.
        /// </summary>
        public long? page { get; set; }
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
                    DeserializeGetSegmentsResponse(value!);
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
        public virtual void DeserializeGetSegmentsResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    if (jsonNode["data"] is JsonArray dataArray)
                    {
                        this.data = new List<SegmentData>();
                        foreach (var itemNode in dataArray)
                        {
                            var segmentData = new SegmentData();
                            try
                            {
                                segmentData.id = itemNode!["id"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.position = itemNode!["position"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.document_id = itemNode!["document_id"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.content = itemNode!["content"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.sign_content = itemNode!["sign_content"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.answer = itemNode!["answer"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                segmentData.word_count = itemNode!["word_count"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.tokens = itemNode!["tokens"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                if (itemNode!["keywords"] is JsonArray keywordArray)
                                {
                                    segmentData.keywords = new List<string>();
                                    foreach (var keywordNode in keywordArray)
                                    {
                                        try
                                        {
                                            segmentData.keywords.Add(keywordNode!.GetValue<string>());
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }
                            try
                            {
                                segmentData.index_node_id = itemNode!["index_node_id"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.index_node_hash = itemNode!["index_node_hash"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.hit_count = itemNode!["hit_count"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.enabled = itemNode!["enabled"]?.GetValue<bool?>() ?? false;
                            }
                            catch { }
                            try
                            {
                                segmentData.disabled_at = itemNode!["disabled_at"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                segmentData.disabled_by = itemNode!["disabled_by"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                segmentData.status = itemNode!["status"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.created_by = itemNode!["created_by"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                segmentData.created_at = itemNode!["created_at"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.updated_at = itemNode!["updated_at"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.updated_by = itemNode!["updated_by"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                segmentData.indexing_at = itemNode!["indexing_at"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.completed_at = itemNode!["completed_at"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                segmentData.error = itemNode!["error"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                segmentData.stopped_at = itemNode!["stopped_at"]?.GetValue<object>();
                            }
                            catch { }
                            try
                            {
                                if (itemNode!["child_chunks"] is JsonArray childChunksArray)
                                {
                                    segmentData.child_chunks = new List<object>();
                                    foreach (var childChunkNode in childChunksArray)
                                    {
                                        try
                                        {
                                            segmentData.child_chunks.Add(childChunkNode!.GetValue<object>());
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }
                            this.data.Add(segmentData);
                        }
                    }
                }
                catch { }

                try
                {
                    this.doc_form = jsonNode["doc_form"]?.GetValue<string>();
                }
                catch { }
                try
                {
                    this.total = jsonNode["total"]?.GetValue<long?>();
                }
                catch { }
                try
                {
                    this.has_more = jsonNode["has_more"]?.GetValue<bool?>();
                }
                catch { }
                try
                {
                    this.limit = jsonNode["limit"]?.GetValue<long?>();
                }
                catch { }
                try
                {
                    this.page = jsonNode["page"]?.GetValue<long?>();
                }
                catch { }
            }
        }
    }

    /// <summary>
    /// 片段数据类，包含单个片段的详细信息。
    /// Segment data class, containing detailed information of a single segment.
    /// </summary>
    public class SegmentData
    {
        /// <summary>
        /// 片段的唯一标识符。
        /// Unique identifier of the segment.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 片段的位置序号。
        /// Position sequence number of the segment.
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 所属文档的唯一标识符。
        /// Unique identifier of the document it belongs to.
        /// </summary>
        public string? document_id { get; set; }

        /// <summary>
        /// 片段的内容。
        /// Content of the segment.
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 片段的签名内容。
        /// Signed content of the segment.
        /// </summary>
        public string? sign_content { get; set; }

        /// <summary>
        /// 片段的答案，可能为空。
        /// Answer of the segment, may be null.
        /// </summary>
        public object? answer { get; set; }

        /// <summary>
        /// 片段的单词数量。
        /// Number of words in the segment.
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 片段的词元数量。
        /// Number of tokens in the segment.
        /// </summary>
        public long? tokens { get; set; }

        /// <summary>
        /// 片段的关键词列表。
        /// List of keywords of the segment.
        /// </summary>
        public List<string>? keywords { get; set; }

        /// <summary>
        /// 索引节点的唯一标识符。
        /// Unique identifier of the index node.
        /// </summary>
        public string? index_node_id { get; set; }

        /// <summary>
        /// 索引节点的哈希值。
        /// Hash value of the index node.
        /// </summary>
        public string? index_node_hash { get; set; }

        /// <summary>
        /// 命中次数。
        /// Number of hits.
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 是否启用，true 表示启用。
        /// Whether it is enabled, true indicates enabled.
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 禁用时间，若未禁用则为 null。
        /// Disable time, null if not disabled.
        /// </summary>
        public object? disabled_at { get; set; }

        /// <summary>
        /// 禁用者，若未禁用则为 null。
        /// Disabler, null if not disabled.
        /// </summary>
        public object? disabled_by { get; set; }

        /// <summary>
        /// 状态，例如 "completed"。
        /// Status, e.g., "completed".
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 创建者的唯一标识符。
        /// Unique identifier of the creator.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 创建时间的时间戳。
        /// Timestamp of the creation time.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 更新时间的时间戳。
        /// Timestamp of the update time.
        /// </summary>
        public long? updated_at { get; set; }

        /// <summary>
        /// 更新者的唯一标识符，若未更新则为 null。
        /// Unique identifier of the updater, null if not updated.
        /// </summary>
        public object? updated_by { get; set; }

        /// <summary>
        /// 索引时间的时间戳。
        /// Timestamp of the indexing time.
        /// </summary>
        public long? indexing_at { get; set; }

        /// <summary>
        /// 完成时间的时间戳。
        /// Timestamp of the completion time.
        /// </summary>
        public long? completed_at { get; set; }

        /// <summary>
        /// 错误信息，若没有错误则为 null。
        /// Error information, null if there is no error.
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 停止时间，若未停止则为 null。
        /// Stop time, null if not stopped.
        /// </summary>
        public object? stopped_at { get; set; }

        /// <summary>
        /// 子片段列表，可能为空。
        /// List of child segments, may be empty.
        /// </summary>
        public List<object>? child_chunks { get; set; }
    }
}
