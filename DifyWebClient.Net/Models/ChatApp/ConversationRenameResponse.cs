using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;


namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 对话重命名响应类，用于表示对话重命名操作后的响应数据。
    /// Conversation rename response class, used to represent the response data after the conversation rename operation.
    /// </summary>
    public class ConversationRenameResponse
    {
        /// <summary>
        /// 对话的唯一标识符。
        /// The unique identifier of the conversation.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 对话的名称。
        /// The name of the conversation.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 用户输入的参数，以键值对的形式存储。
        /// User input parameters, stored in the form of key - value pairs.
        /// </summary>
        public Dictionary<string, object>? inputs { get; set; }

        /// <summary>
        /// 对话的状态，例如 "normal" 表示正常状态。
        /// The status of the conversation, for example, "normal" indicates the normal state.
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 对话的介绍信息，可能为空字符串。
        /// Introduction information of the conversation, which may be an empty string.
        /// </summary>
        public string? introduction { get; set; }

        /// <summary>
        /// 对话的创建时间戳，使用长整型存储以支持更大范围的值。
        /// The creation timestamp of the conversation, stored as a long integer to support a wider range of values.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 对话的更新时间戳，使用长整型存储以支持更大范围的值。
        /// The update timestamp of the conversation, stored as a long integer to support a wider range of values.
        /// </summary>
        public long? updated_at { get; set; }

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
                    DeserializeConversationRenameResponse(value!);
                }
                catch (Exception)
                {
                    // 异常处理部分，这里可以根据实际需求添加日志记录等操作
                    // Exception handling section. Here, you can add operations such as log recording according to actual needs.
                }
            }
        }

        /// <summary>
        /// 从 JSON 字符串反序列化对话重命名响应对象。
        /// Deserialize the conversation rename response object from a JSON string.
        /// </summary>
        /// <param name="json">待反序列化的 JSON 字符串。The JSON string to be deserialized.</param>
        private void DeserializeConversationRenameResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is not null)
                {
                    try
                    {
                        // 尝试解析对话的唯一标识符
                        // Try to parse the unique identifier of the conversation
                        this.id = jsonNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        // 尝试解析对话的名称
                        // Try to parse the name of the conversation
                        this.name = jsonNode["name"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        if (jsonNode["inputs"] is not null)
                        {
                            this.inputs = new Dictionary<string, object>();
                            foreach (var inputPair in jsonNode["inputs"]!.AsObject())
                            {
                                try
                                {
                                    // 尝试将输入参数的键值对添加到字典中
                                    // Try to add the key - value pairs of input parameters to the dictionary
                                    this.inputs[inputPair.Key] = inputPair.Value!.ToString();
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        // 尝试解析对话的状态
                        // Try to parse the status of the conversation
                        this.status = jsonNode["status"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        // 尝试解析对话的介绍信息
                        // Try to parse the introduction information of the conversation
                        this.introduction = jsonNode["introduction"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        // 尝试解析对话的创建时间戳
                        // Try to parse the creation timestamp of the conversation
                        this.created_at = jsonNode["created_at"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        // 尝试解析对话的更新时间戳
                        // Try to parse the update timestamp of the conversation
                        this.updated_at = jsonNode["updated_at"]?.GetValue<long?>();
                    }
                    catch { }
                }
            }
            catch (JsonException)
            {
                // 处理 JSON 解析异常
                // Handle JSON parsing exceptions
            }
            catch (Exception)
            {
                // 处理其他异常
                // Handle other exceptions
            }
        }
    }


}
