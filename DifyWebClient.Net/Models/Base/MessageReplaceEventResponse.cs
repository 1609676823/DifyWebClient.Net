using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using DifyWebClient.Net.Models.ChatApp;

namespace DifyWebClient.Net.Models.Base
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// event: message_replace 消息内容替换事件。 开启内容审查和审查输出内容时，若命中了审查条件，则会通过此事件替换消息内容为预设回复
    /// event: message_replace Message content replacement event. When output content moderation is enabled, if the content is flagged, then the message content will be replaced with a preset reply through this event
    /// </summary>

    public class MessageReplaceEventResponse : SSEEventResponseBase
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
        /// 被替换的原消息内容
        /// The original message content to be replaced
        /// </summary>
        public string? original_message { get; set; }

        /// <summary>
        /// 替换后的新消息内容
        /// The new message content after replacement
        /// </summary>
        public string? replaced_message { get; set; }

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
                    DeserializeMessageReplaceEventResponse(value!);
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
        public virtual void DeserializeMessageReplaceEventResponse(string json)
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
                    original_message = jsonNode["original_message"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    replaced_message = jsonNode["replaced_message"]?.GetValue<string>();
                }
                catch { }
            }
            catch { }
        }
    }
}
