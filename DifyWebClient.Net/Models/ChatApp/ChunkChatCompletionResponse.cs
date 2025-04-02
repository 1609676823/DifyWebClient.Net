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
    /// 返回 App 输出的流式块，Content-Type 为 text/event-stream。 每个流式块均为 data: 开头，块之间以 \n\n 即两个换行符分隔
    /// Returns the stream chunks outputted by the App, Content-Type is text/event-stream. Each streaming chunk starts with data:, separated by two newline characters \n\n
    /// </summary>
    public class ChunkChatCompletionResponse
    {
        /// <summary>
        /// 返回 App 输出的流式块，Content-Type 为 text/event-stream。 每个流式块均为 data: 开头，块之间以 \n\n 即两个换行符分隔
        /// Returns the stream chunks outputted by the App, Content-Type is text/event-stream. Each streaming chunk starts with data:, separated by two newline characters \n\n
        /// </summary>
        public ChunkChatCompletionResponse() { }
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
        ///  App 模式，固定为 chat
        ///  mode (string) App mode, fixed as chat
        /// </summary>
        public string? mode { get; set; }

        /// <summary>
        /// LLM 返回文本块内容
        /// LLM returned text chunk content
        /// </summary>
        public string? answer { get; set; }

        /// <summary>
        /// 创建时间戳
        /// Creation timestamp, e.g., 1705395332
        /// </summary>
        public long created_at { get; set; }

        /// <summary>
        /// agent_thought ID，每一轮Agent迭代都会有一个唯一的id
        /// Agent thought ID, every iteration has a unique agent thought ID
        /// </summary>
        public string? id { get; set; } 

        /// <summary>
        /// agent_thought在消息中的位置，如第一轮迭代position为1
        /// Position of current agent thought, each message may have multiple thoughts in order.
        /// </summary>
        public long position { get; set; }

        /// <summary>
        /// agent的思考内容
        /// What LLM is thinking about
        /// </summary>
        public string? thought { get; set; } 

        /// <summary>
        /// 工具调用的返回结果
        /// Response from tool calls
        /// </summary>
        public string? observation { get; set; } 

        /// <summary>
        /// 使用的工具列表，以 ; 分割多个工具
        /// A list of tools represents which tools are called, split by ;
        /// </summary>
        public string? tool { get; set; } 

        /// <summary>
        /// 工具的输入，JSON格式的字符串(object)
        /// Input of tools in JSON format. Like: {"dalle3": {"prompt": "a cute cat"}}.
        /// </summary>
        public string? tool_input { get; set; } 

        /// <summary>
        /// 当前 agent_thought 关联的文件ID
        /// Refer to message_file event
        /// </summary>
        public List<string> message_files { get; set; } = new List<string>();

        /// <summary>
        /// 文件类型，目前仅为image
        /// File type, only allow "image" currently
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 文件归属，user或assistant，该接口返回仅为 assistant
        /// Belongs to, it will only be an 'assistant' here
        /// </summary>
        public string? belongs_to { get; set; }

        /// <summary>
        /// 文件访问地址
        /// Remote url of file
        /// </summary>
        public string? url { get; set; } 

        /// <summary>
        /// 元数据
        /// Metadata
        /// </summary>
        public Metadata metadata { get; set; } = new Metadata();

        /// <summary>
        /// 语音合成之后的音频块使用 Base64 编码之后的文本内容，播放的时候直接 base64 解码送入播放器即可
        /// The audio after speech synthesis, encoded in base64 text content, when playing, simply decode the base64 and feed it into the player
        /// </summary>
        public string? audio { get; set; } 

        /// <summary>
        /// HTTP 状态码
        /// HTTP status code
        /// </summary>
        public long status { get; set; }

        /// <summary>
        /// 错误码
        /// Error code
        /// </summary>
        public string? code { get; set; } 

        /// <summary>
        /// 错误消息
        /// Error message
        /// </summary>
        public string? message { get; set; }

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
                    DeserializeChunkChatResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// 是否最后一条信息
        /// </summary>
        [JsonIgnore]
        public bool IsLastMessage=false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeChunkChatResponse(string json)
        {

            JsonNode jsonNode = JsonNode.Parse(json)!;
            if (jsonNode != null)
            {
                try
                {
                    this.Event = jsonNode["event"]!.GetValue<string>();
                    if ("message_end".Equals(this.Event, StringComparison.OrdinalIgnoreCase))
                    {
                        this.IsLastMessage = true;
                    }
                    else 
                    { 
                        this.IsLastMessage = false; 
                    }
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
                    this.id = jsonNode["id"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.position = jsonNode["position"]!.GetValue<long>();
                }
                catch { }

                try
                {
                    this.thought = jsonNode["thought"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.observation = jsonNode["observation"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.tool = jsonNode["tool"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.tool_input = jsonNode["tool_input"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.message_files = new List<string>();
                    if (jsonNode["message_files"] is JsonArray messageFilesArray)
                    {
                        foreach (var item in messageFilesArray)
                        {
                            this.message_files.Add(item!.GetValue<string>());
                        }
                    }
                }
                catch { }

                try
                {
                    this.type = jsonNode["type"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.belongs_to = jsonNode["belongs_to"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.url = jsonNode["url"]!.GetValue<string>();
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

                try
                {
                    this.audio = jsonNode["audio"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.status = jsonNode["status"]!.GetValue<long>();
                }
                catch { }

                try
                {
                    this.code = jsonNode["code"]!.GetValue<string>();
                }
                catch { }

                try
                {
                    this.message = jsonNode["message"]!.GetValue<string>();
                }
                catch { }
            }
        }
    }

}
