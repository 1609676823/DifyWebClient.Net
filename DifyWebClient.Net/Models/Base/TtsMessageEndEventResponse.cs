using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using DifyWebClient.Net.Models.ChatApp;

namespace DifyWebClient.Net.Models.Base
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// event: tts_message_end TTS 音频流结束事件，收到这个事件表示音频流返回结束
    /// event: tts_message_end TTS audio stream end event, receiving this event indicates the end of the audio stream
    /// </summary>
    public class TtsMessageEndEventResponse : SSEEventResponseBase
    {
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
        /// 表示 TTS 消息是否成功结束
        /// Indicates whether the TTS message ended successfully
        /// </summary>
        public bool? is_success { get; set; }

        /// <summary>
        /// 如果 TTS 消息结束失败，此为错误信息
        /// Error message if the TTS message ended unsuccessfully
        /// </summary>
        public string? error_message { get; set; }

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
                    DeserializeTtsMessageEndEventResponse(value!);
                }
                catch (Exception)
                {
                    // 可添加日志记录等操作
                }
            }
        }

        /// <summary>
        /// 解析 json
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeTtsMessageEndEventResponse(string json)
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
                    is_success = jsonNode["is_success"]?.GetValue<bool?>();
                }
                catch { }

                try
                {
                    error_message = jsonNode["error_message"]?.GetValue<string>();
                }
                catch { }
            }
            catch { }
        }
    }
}
