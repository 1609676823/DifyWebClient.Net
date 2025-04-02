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
    /// 批量添加块操作的响应结果类
    /// Response class for the operation of adding chunks in batches
    /// </summary>
    public class AddChunksResponse
    {
        /// <summary>
        /// 数据列表，包含多个块数据项
        /// List of data, containing multiple chunk data items
        /// </summary>
        public List<AddChunksDataItem>? data { get; set; }

        /// <summary>
        /// 文档格式，如 "text_model"
        /// Document format, such as "text_model"
        /// </summary>
        public string? doc_form { get; set; }

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
                    DeserializeAddChunksResponse(value!);
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
        public virtual void DeserializeAddChunksResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is null) return;

                if (jsonNode["data"] is JsonArray dataArray)
                {
                    this.data = new List<AddChunksDataItem>();
                    foreach (var item in dataArray)
                    {
                        var dataItem = new AddChunksDataItem();

                        try
                        {
                            dataItem.id = item!["id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.position = item!["position"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.document_id = item!["document_id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.content = item!["content"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.sign_content = item!["sign_content"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.answer = item!["answer"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            dataItem.word_count = item!["word_count"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.tokens = item!["tokens"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.index_node_id = item!["index_node_id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.index_node_hash = item!["index_node_hash"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.hit_count = item!["hit_count"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.enabled = item!["enabled"]?.GetValue<bool>();
                        }
                        catch { }

                        try
                        {
                            dataItem.disabled_at = item!["disabled_at"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            dataItem.disabled_by = item!["disabled_by"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            dataItem.status = item!["status"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.created_by = item!["created_by"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            dataItem.created_at = item!["created_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.updated_at = item!["updated_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.updated_by = item!["updated_by"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            dataItem.indexing_at = item!["indexing_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.completed_at = item!["completed_at"]?.GetValue<long>();
                        }
                        catch { }

                        try
                        {
                            dataItem.error = item!["error"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            dataItem.stopped_at = item!["stopped_at"]?.GetValue<object>();
                        }
                        catch { }

                        try
                        {
                            if (item!["keywords"] is JsonArray keywordsArray)
                            {
                                dataItem.keywords = new List<string>();
                                foreach (var keyword in keywordsArray)
                                {
                                    dataItem.keywords.Add(keyword!.GetValue<string>());
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            if (item!["child_chunks"] is JsonArray childChunksArray)
                            {
                                dataItem.child_chunks = new List<object>();
                                foreach (var childChunk in childChunksArray)
                                {
                                    dataItem.child_chunks.Add(childChunk!.GetValue<object>());
                                }
                            }
                        }
                        catch { }

                        this.data.Add(dataItem);
                    }
                }

                try
                {
                    this.doc_form = jsonNode["doc_form"]?.GetValue<string>();
                }
                catch { }
            }
            catch { }
        }
    }

    /// <summary>
    /// 批量添加块操作中的单个数据项类
    /// Single data item class in the operation of adding chunks in batches
    /// </summary>
    public class AddChunksDataItem
    {
        /// <summary>
        /// 数据项的唯一标识符
        /// Unique identifier of the data item
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 数据项的位置编号
        /// Position number of the data item
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 关联文档的唯一标识符
        /// Unique identifier of the associated document
        /// </summary>
        public string? document_id { get; set; }

        /// <summary>
        /// 数据项的内容
        /// Content of the data item
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 用于签名的内容，通常与 content 相同
        /// Content used for signing, usually the same as content
        /// </summary>
        public string? sign_content { get; set; }

        /// <summary>
        /// 数据项的答案，可能为 null
        /// Answer of the data item, may be null
        /// </summary>
        public object? answer { get; set; }

        /// <summary>
        /// 内容的单词数量
        /// Number of words in the content
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 内容的令牌数量
        /// Number of tokens in the content
        /// </summary>
        public long? tokens { get; set; }

        /// <summary>
        /// 内容的关键词列表
        /// List of keywords in the content
        /// </summary>
        public List<string>? keywords { get; set; }

        /// <summary>
        /// 索引节点的唯一标识符
        /// Unique identifier of the index node
        /// </summary>
        public string? index_node_id { get; set; }

        /// <summary>
        /// 索引节点的哈希值
        /// Hash value of the index node
        /// </summary>
        public string? index_node_hash { get; set; }

        /// <summary>
        /// 数据项的命中次数
        /// Number of hits of the data item
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 数据项是否启用的标志
        /// Flag indicating whether the data item is enabled
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 数据项禁用的时间，可能为 null
        /// Time when the data item was disabled, may be null
        /// </summary>
        public object? disabled_at { get; set; }

        /// <summary>
        /// 禁用数据项的用户或操作标识，可能为 null
        /// Identifier of the user or operation that disabled the data item, may be null
        /// </summary>
        public object? disabled_by { get; set; }

        /// <summary>
        /// 数据项的状态，如 "completed"
        /// Status of the data item, such as "completed"
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 创建数据项的用户的唯一标识符
        /// Unique identifier of the user who created the data item
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 数据项创建的时间戳
        /// Timestamp when the data item was created
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 数据项更新的时间戳
        /// Timestamp when the data item was updated
        /// </summary>
        public long? updated_at { get; set; }

        /// <summary>
        /// 更新数据项的用户或操作标识，可能为 null
        /// Identifier of the user or operation that updated the data item, may be null
        /// </summary>
        public object? updated_by { get; set; }

        /// <summary>
        /// 数据项索引的时间戳
        /// Timestamp when the data item was indexed
        /// </summary>
        public long? indexing_at { get; set; }

        /// <summary>
        /// 数据项完成处理的时间戳
        /// Timestamp when the data item completed processing
        /// </summary>
        public long? completed_at { get; set; }

        /// <summary>
        /// 数据项处理过程中出现的错误信息，可能为 null
        /// Error information that occurred during the processing of the data item, may be null
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 数据项停止处理的时间，可能为 null
        /// Time when the data item stopped processing, may be null
        /// </summary>
        public object? stopped_at { get; set; }

        /// <summary>
        /// 子块列表，目前为空
        /// List of child chunks, currently empty
        /// </summary>
        public List<object>? child_chunks { get; set; }
    }
}
