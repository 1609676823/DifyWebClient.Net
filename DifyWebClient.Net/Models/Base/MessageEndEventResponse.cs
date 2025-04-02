using DifyWebClient.Net.Models.ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Base
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 消息结束块响应类
    /// Message end chunk response class
    /// </summary>
    public class MessageEndEventResponse : SSEEventResponseBase
    {
        /// <summary>
        /// 事件类型，值为 "message_end"
        /// Event type, with a value of "message_end"
        /// </summary>
        public override string? Event { get; set; }

        /// <summary>
        /// 对话的唯一标识符
        /// Unique identifier for the conversation
        /// </summary>
        public string? conversation_id { get; set; }

        /// <summary>
        /// 消息的唯一标识符
        /// Unique identifier for the message
        /// </summary>
        public string? message_id { get; set; }

        /// <summary>
        /// 消息创建的时间戳
        /// Timestamp when the message was created
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 任务的唯一标识符
        /// Unique identifier for the task
        /// </summary>
        public string? task_id { get; set; }

        /// <summary>
        /// 与消息 ID 相同的唯一标识符
        /// Unique identifier same as the message ID
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 消息的元数据信息
        /// Metadata information of the message
        /// </summary>
        public Metadata? metadata { get; set; }

        /// <summary>
        /// 关联的文件列表
        /// List of associated files
        /// </summary>
        public List<object>? files { get; set; }

        [JsonIgnore]
        private string realJsonstring = string.Empty;

        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        public override string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value!;
                try
                {
                    DeserializeMessageEndChunkResponse(value!);
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
        private void DeserializeMessageEndChunkResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is not null)
                {
                    try
                    {
                        Event = jsonNode["event"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        conversation_id = jsonNode["conversation_id"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        message_id = jsonNode["message_id"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        created_at = jsonNode["created_at"]?.GetValue<long?>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        task_id = jsonNode["task_id"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        id = jsonNode["id"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    try
                    {
                        var metadataNode = jsonNode["metadata"];
                        if (metadataNode is not null)
                        {
                            metadata = new Metadata();
                            try
                            {
                                var resourcesArray = metadataNode["retriever_resources"]?.AsArray();
                                if (resourcesArray is not null)
                                {
                                    metadata.retriever_resources = new List<RetrieverResource>();
                                    foreach (var resourceNode in resourcesArray)
                                    {
                                        var resource = new RetrieverResource();
                                        try
                                        {
                                            resource.position = resourceNode!["position"]?.GetValue<long?>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.dataset_id = resourceNode!["dataset_id"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.dataset_name = resourceNode!["dataset_name"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.document_id = resourceNode!["document_id"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.document_name = resourceNode!["document_name"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.data_source_type = resourceNode!["data_source_type"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.segment_id = resourceNode!["segment_id"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.retriever_from = resourceNode!["retriever_from"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.score = resourceNode!["score"]?.GetValue<double?>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.hit_count = resourceNode!["hit_count"]?.GetValue<long?>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.word_count = resourceNode!["word_count"]?.GetValue<long?>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.segment_position = resourceNode!["segment_position"]?.GetValue<long?>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.index_node_hash = resourceNode!["index_node_hash"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.content = resourceNode!["content"]?.GetValue<string>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            resource.page = resourceNode!["page"]?.GetValue<object>();
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            //var docMetadataNode = resourceNode!["doc_metadata"];
                                            //if (docMetadataNode is not null)
                                            //{
                                            //    resource.doc_metadata = new Dictionary<string, string>();
                                            //    foreach (var property in docMetadataNode.AsObject())
                                            //    {
                                            //        try
                                            //        {
                                            //            resource.doc_metadata[property.Key] = property!.Value!.GetValue<string>();
                                            //        }
                                            //        catch
                                            //        {
                                            //        }
                                            //    }
                                            //}

                                            resource.doc_metadata = resourceNode!["doc_metadata"]!;
                                        }
                                        catch
                                        {
                                        }
                                        metadata.retriever_resources.Add(resource);
                                    }
                                }
                            }
                            catch
                            {
                            }

                            try
                            {
                                metadata.usage = new Usage();
                                var usageNode = metadataNode["usage"];
                                if (usageNode is not null)
                                {
                                    try
                                    {
                                        metadata.usage.prompt_tokens = usageNode["prompt_tokens"]?.GetValue<long?>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.prompt_unit_price = usageNode["prompt_unit_price"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.prompt_price_unit = usageNode["prompt_price_unit"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.prompt_price = usageNode["prompt_price"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.completion_tokens = usageNode["completion_tokens"]?.GetValue<long?>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.completion_unit_price = usageNode["completion_unit_price"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.completion_price_unit = usageNode["completion_price_unit"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.completion_price = usageNode["completion_price"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.total_tokens = usageNode["total_tokens"]?.GetValue<long?>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.total_price = usageNode["total_price"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.currency = usageNode["currency"]?.GetValue<string>();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        metadata.usage.latency = usageNode["latency"]?.GetValue<double?>();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        files = jsonNode["files"]?.AsArray().Select(x => (object)x!).ToList()!;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

    }
}

