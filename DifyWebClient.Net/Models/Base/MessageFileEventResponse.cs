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
    /// event: message_file 文件事件，表示有新文件需要展示
    /// event: message_file Message file event, a new file has created by tool
    /// </summary>
    public class MessageFileEventResponse : SSEEventResponseBase
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
        /// 文件名称
        /// File name
        /// </summary>
        public string? file_name { get; set; }

        /// <summary>
        /// 文件类型
        /// File type
        /// </summary>
        public string? file_type { get; set; }

        /// <summary>
        /// 文件大小（字节）
        /// File size in bytes
        /// </summary>
        public long? file_size { get; set; }

        /// <summary>
        /// 文件下载链接
        /// File download link
        /// </summary>
        public string? file_url { get; set; }

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
                    DeserializeMessageFileEventResponse(value!);
                }
                catch (Exception)
                {
                    // 这里可以添加日志记录等操作
                }
            }
        }

        /// <summary>
        /// 解析json
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeMessageFileEventResponse(string json)
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
                    file_name = jsonNode["file_name"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    file_type = jsonNode["file_type"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    file_size = jsonNode["file_size"]?.GetValue<long?>();
                }
                catch { }

                try
                {
                    file_url = jsonNode["file_url"]?.GetValue<string>();
                }
                catch { }
            }
            catch { }
        }
    }
}
