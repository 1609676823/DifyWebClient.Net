using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    ///  /// 返回 App 输出的流式块，Content-Type 为 text/event-stream。 每个流式块均为 data: 开头，块之间以 \n\n 即两个换行符分隔
    /// Returns the stream chunks outputted by the App, Content-Type is text/event-stream. Each streaming chunk starts with data:, separated by two newline characters \n\n
    /// </summary>
    public class SSEEventResponseBase
    {
        /// <summary>
        /// 事件类型(message, agent_message, agent_thought, message_file, message_end, tts_message, tts_message_end, message_replace, error, ping)
        /// Event type(message, agent_message, agent_thought, message_file, message_end, tts_message, tts_message_end, message_replace, error, ping)
        /// </summary>
        [JsonPropertyName("event")]
        //public string @event { get; set; } = string.Empty;
        public virtual string? Event { get; set; }
        /// <summary>
        /// 获取到的json
        /// </summary>
        [JsonIgnore]
        public virtual string? RealJsonstring { get; set; }

        /// <summary>
        /// 程序事件结束标记，SSE结束标记，非dify给出，由框架通过SSE结束进行判断
        /// </summary>
        [JsonIgnore]
        public bool IsCompletedSSE { get; set; } = false;
    }
}
