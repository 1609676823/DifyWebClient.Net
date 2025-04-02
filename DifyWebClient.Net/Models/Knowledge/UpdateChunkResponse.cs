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
    /// 表示更新块响应的类。
    /// Represents the class for update chunk response.
    /// </summary>
    public class UpdateChunkResponse
    {
        /// <summary>
        /// 更新块响应的数据。
        /// The data of the update chunk response.
        /// </summary>
        public UpdateChunkResponseData? data { get; set; }

        /// <summary>
        /// 文档的格式。
        /// The format of the document.
        /// </summary>
        public string? doc_form { get; set; }

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
                    DeserializeUpdateChunkResponse(value!);
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
        public virtual void DeserializeUpdateChunkResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is not null)
                {
                    var dataNode = jsonNode["data"];
                    if (dataNode is not null)
                    {
                        this.data = new UpdateChunkResponseData();
                        try
                        {
                            this.data.id = dataNode["id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.position = dataNode["position"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.document_id = dataNode["document_id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.content = dataNode["content"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.sign_content = dataNode["sign_content"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.answer = dataNode["answer"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            this.data.word_count = dataNode["word_count"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.tokens = dataNode["tokens"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.keywords = dataNode["keywords"]?.AsArray().Select(x => x!.GetValue<string>()).ToList();
                        }
                        catch { }

                        try
                        {
                            this.data.index_node_id = dataNode["index_node_id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.index_node_hash = dataNode["index_node_hash"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.hit_count = dataNode["hit_count"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.enabled = dataNode["enabled"]?.GetValue<bool>();
                        }
                        catch { }

                        try
                        {
                            this.data.disabled_at = dataNode["disabled_at"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            this.data.disabled_by = dataNode["disabled_by"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            this.data.status = dataNode["status"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.created_by = dataNode["created_by"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.created_at = dataNode["created_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.updated_at = dataNode["updated_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.updated_by = dataNode["updated_by"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.indexing_at = dataNode["indexing_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.completed_at = dataNode["completed_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            this.data.error = dataNode["error"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            this.data.stopped_at = dataNode["stopped_at"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            this.data.child_chunks = dataNode["child_chunks"]?.AsArray().Select(x => x!.GetValue<object>()).ToList();
                        }
                        catch { }
                    }

                    try
                    {
                        this.doc_form = jsonNode["doc_form"]?.GetValue<string>();
                    }
                    catch { }
                }
            }
            catch (Exception)
            {
                // 处理解析 JSON 节点时的异常
            }
        }
    }

    /// <summary>
    /// 表示更新块响应数据的类。
    /// Represents the class for update chunk response data.
    /// </summary>
    public class UpdateChunkResponseData
    {
        /// <summary>
        /// 唯一标识符。
        /// Unique identifier.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 位置信息。
        /// Position information.
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 文档的唯一标识符。
        /// Unique identifier of the document.
        /// </summary>
        public string? document_id { get; set; }

        /// <summary>
        /// 内容信息。
        /// Content information.
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 签名内容。
        /// Signed content.
        /// </summary>
        public string? sign_content { get; set; }

        /// <summary>
        /// 答案信息，可能为空。
        /// Answer information, may be null.
        /// </summary>
        public object? answer { get; set; }

        /// <summary>
        /// 单词数量。
        /// Number of words.
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 令牌数量。
        /// Number of tokens.
        /// </summary>
        public long? tokens { get; set; }

        /// <summary>
        /// 关键词列表。
        /// List of keywords.
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
        /// Hit count.
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 是否启用的标志。
        /// Flag indicating whether it is enabled.
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 禁用的时间，可能为空。
        /// Disabled time, may be null.
        /// </summary>
        public object? disabled_at { get; set; }

        /// <summary>
        /// 执行禁用操作的主体，可能为空。
        /// The entity that performed the disable operation, may be null.
        /// </summary>
        public object? disabled_by { get; set; }

        /// <summary>
        /// 状态信息。
        /// Status information.
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 创建者的唯一标识符。
        /// Unique identifier of the creator.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 创建的时间戳。
        /// Creation timestamp.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 更新的时间戳。
        /// Update timestamp.
        /// </summary>
        public long? updated_at { get; set; }

        /// <summary>
        /// 执行更新操作的主体的唯一标识符。
        /// Unique identifier of the entity that performed the update operation.
        /// </summary>
        public string? updated_by { get; set; }

        /// <summary>
        /// 索引操作的时间戳。
        /// Indexing timestamp.
        /// </summary>
        public long? indexing_at { get; set; }

        /// <summary>
        /// 完成操作的时间戳。
        /// Completion timestamp.
        /// </summary>
        public long? completed_at { get; set; }

        /// <summary>
        /// 错误信息，可能为空。
        /// Error information, may be null.
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 停止的时间，可能为空。
        /// Stopped time, may be null.
        /// </summary>
        public object? stopped_at { get; set; }

        /// <summary>
        /// 子块列表。
        /// List of child chunks.
        /// </summary>
        public List<object>? child_chunks { get; set; }
    }

}
