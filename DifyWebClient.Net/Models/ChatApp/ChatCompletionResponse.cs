using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 返回完整的 App 结果，Content-Type 为 application/json。
    /// Returns the complete App result, Content-Type is application/json.
    /// </summary>
    /// <summary>
    /// 当 response_mode 为 blocking 时，返回 ChatCompletionResponse object。 当 response_mode 为 streaming时，返回 ChunkChatCompletionResponse object 流式序列。
    /// When response_mode is blocking, return a CompletionResponse object. When response_mode is streaming, return a ChunkCompletionResponse stream.
    /// </summary>
    public class ChatCompletionResponse
    {
        /// <summary>
        /// 事件类型(message, agent_message, agent_thought, message_file, message_end, tts_message, tts_message_end, message_replace, error, ping)
        /// Event type(message, agent_message, agent_thought, message_file, message_end, tts_message, tts_message_end, message_replace, error, ping)
        /// </summary>
        [JsonPropertyName("event")]
        //public string @event { get; set; } = string.Empty;
        public string? Event { get; set; } 

        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// Task ID, used for request tracking and the stop response interface below
        /// </summary>
        public string? task_id { get; set; } 
        /// <summary>
        /// 消息唯一 ID
        /// Unique message ID
        /// </summary>
        public string? message_id { get; set; } 
        /// <summary>
        /// 会话 ID
        /// Conversation ID
        /// </summary>
        public string? conversation_id { get; set; } 
        /// <summary>
        /// App 模式，固定为 chat
        /// App mode, fixed as chat
        /// </summary>
        public string? mode { get; set; } 
        /// <summary>
        /// 完整回复内容
        /// Complete response content
        /// </summary>
        public string? answer { get; set; }
        /// <summary>
        /// 元数据
        /// Metadata
        /// </summary>
        public Metadata? metadata { get; set; } = new Metadata();
        /// <summary>
        /// 创建时间戳
        /// Creation timestamp, e.g., 1705395332
        /// </summary>
        public long created_at { get; set; }

        [JsonIgnore]
        private string realJsonstring = string.Empty;

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
                realJsonstring = value!;
                try
                {
                    DeserializeChatCompletionResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeChatCompletionResponse(string json)
        {
            JsonNode? jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    this.Event = jsonNode["event"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.task_id = jsonNode["task_id"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.message_id = jsonNode["message_id"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.conversation_id = jsonNode["conversation_id"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.mode = jsonNode["mode"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.answer = jsonNode["answer"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.created_at = jsonNode["created_at"]!.GetValue<long>();
                }
                catch { }

                try
                {
                    this.metadata = new Metadata();
                    if (jsonNode["metadata"] is JsonObject metadataObject)
                    {
                        try
                        {
                            this.metadata.usage = new Usage();
                            if (metadataObject["usage"] is JsonObject usageObject)
                            {
                                try
                                {
                                    this.metadata.usage.prompt_tokens = usageObject["prompt_tokens"]!.GetValue<long>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.prompt_unit_price = usageObject["prompt_unit_price"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.prompt_price_unit = usageObject["prompt_price_unit"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.prompt_price = usageObject["prompt_price"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.completion_tokens = usageObject["completion_tokens"]!.GetValue<long>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.completion_unit_price = usageObject["completion_unit_price"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.completion_price_unit = usageObject["completion_price_unit"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.completion_price = usageObject["completion_price"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.total_tokens = usageObject["total_tokens"]!.GetValue<long>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.total_price = usageObject["total_price"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.currency = usageObject["currency"]!.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    this.metadata.usage.latency = usageObject["latency"]!.GetValue<double>();
                                }
                                catch { }
                            }
                        }
                        catch { }

                        try
                        {
                            this.metadata.retriever_resources = new List<RetrieverResource>();
                            if (metadataObject["retriever_resources"] is JsonArray retrieverResourcesArray)
                            {
                                foreach (JsonNode? item in retrieverResourcesArray)
                                {
                                    var resource = new RetrieverResource();

                                    try
                                    {
                                        resource.dataset_id = item!["dataset_id"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.dataset_name = item!["dataset_name"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.document_id = item!["document_id"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.document_name = item!["document_name"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.data_source_type = item!["data_source_type"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.segment_id = item!["segment_id"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.retriever_from = item!["retriever_from"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.score = item!["score"]!.GetValue<double>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.doc_metadata = item!["doc_metadata"]!;
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.content = item!["content"]!.GetValue<string>();
                                    }
                                    catch { }

                                    try
                                    {
                                        resource.position = item!["position"]!.GetValue<long>();
                                    }
                                    catch { }

                                    this.metadata.retriever_resources.Add(resource);
                                }
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
    }




}
