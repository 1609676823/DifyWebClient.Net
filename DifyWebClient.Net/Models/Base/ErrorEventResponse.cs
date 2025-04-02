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
    /// event: error 流式输出过程中出现的异常会以 stream event 形式输出，收到异常事件后即结束
    /// event: error Exceptions that occur during the streaming process will be output in the form of stream events, and reception of an error event will end the stream
    /// </summary>
    public class ErrorEventResponse : SSEEventResponseBase
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
        /// 错误代码
        /// Error code
        /// </summary>
        public string? error_code { get; set; }

        /// <summary>
        /// 错误消息
        /// Error message
        /// </summary>
        public string? error_message { get; set; }

        /// <summary>
        /// 错误发生的位置（如工作流 ID、节点 ID 等，可选）
        /// Location where the error occurred (e.g., workflow ID, node ID, etc., optional)
        /// </summary>
        public string? error_location { get; set; }

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
                    DeserializeErrorEventResponse(value!);
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
        public virtual void DeserializeErrorEventResponse(string json)
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
                    error_code = jsonNode["error_code"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    error_message = jsonNode["error_message"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    error_location = jsonNode["error_location"]?.GetValue<string>();
                }
                catch { }
            }
            catch { }
        }
    }
}
