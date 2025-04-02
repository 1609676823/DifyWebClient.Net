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
    /// event: message LLM 返回文本块事件，即：完整的文本以分块的方式输出。
    /// </summary>
    public class MessageEventResponse : SSEEventResponseBase
    {
        /// <summary>
        /// LLM 返回文本块事件，即：完整的文本以分块的方式输出。
        /// LLM returns text chunk event, i.e., the complete text is output in a chunked fashion.
        /// </summary>
        [JsonPropertyName("event")]
        public override string? Event { get; set; }

        /// <summary>
        /// 会话 ID
        /// Conversation ID
        /// </summary>
        public string? conversation_id { get; set; }

        /// <summary>
        /// 消息唯一 ID
        /// Unique message ID
        /// </summary>
        public string? message_id { get; set; }

        /// <summary>
        /// 创建时间戳，如：1705395332
        /// Creation timestamp, e.g., 1705395332
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// Task ID, used for request tracking and the below Stop Generate API
        /// </summary>
        public string? task_id { get; set; }

        /// <summary>
        /// 与 message_id 相同，消息唯一 ID
        /// Same as message_id, Unique message ID
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// LLM 返回文本块内容
        /// LLM returned text chunk content
        /// </summary>
        public string? answer { get; set; }

        /// <summary>
        /// 从变量选择器相关数据列表
        /// Data list related to the variable selector
        /// </summary>
        public List<string>? from_variable_selector { get; set; }

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
                    DeserializeMessageChunkResponse(value!);
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
        public virtual void DeserializeMessageChunkResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is null) return;

                try
                {
                    Event = jsonNode["event"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    conversation_id = jsonNode["conversation_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    message_id = jsonNode["message_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    created_at = jsonNode["created_at"]?.GetValue<long?>();
                }
                catch { }

                try
                {
                    task_id = jsonNode["task_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    id = jsonNode["id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    answer = jsonNode["answer"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    var fromVariableSelectorNode = jsonNode["from_variable_selector"];
                    if (fromVariableSelectorNode is not null && fromVariableSelectorNode is JsonArray)
                    {
                        from_variable_selector = new List<string>();
                        foreach (var item in fromVariableSelectorNode.AsArray())
                        {
                            from_variable_selector.Add(item!.GetValue<string>());
                        }
                    }
                }
                catch { }
            }
            catch { }
        }
    }

}
