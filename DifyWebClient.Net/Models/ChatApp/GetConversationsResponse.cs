using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 获取对话列表的响应类
    /// Get conversations list response class
    /// </summary>
    public class GetConversationsResponse
    {
        /// <summary>
        /// 数据限制数量
        /// Data limit count
        /// </summary>
        public long? limit { get; set; }

        /// <summary>
        /// 是否还有更多数据
        /// Whether there is more data
        /// </summary>
        public bool? has_more { get; set; }

        /// <summary>
        /// 对话数据列表
        /// Conversation data list
        /// </summary>
        public List<ConversationData>? data { get; set; }

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
                    DeserializeGetConversationsResponse(value!);
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
        public virtual void DeserializeGetConversationsResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is not null)
                {
                    try
                    {
                        if (jsonNode["limit"] is not null)
                        {
                            this.limit = jsonNode["limit"]!.GetValue<long?>();
                        }
                    }
                    catch { }

                    try
                    {
                        if (jsonNode["has_more"] is not null)
                        {
                            this.has_more = jsonNode["has_more"]!.GetValue<bool?>();
                        }
                    }
                    catch { }

                    if (jsonNode["data"] is JsonArray dataArray)
                    {
                        this.data = new List<ConversationData>();
                        foreach (var item in dataArray)
                        {
                            if (item is JsonObject dataItem)
                            {
                                var conversationData = new ConversationData();
                                try
                                {
                                    conversationData.id = dataItem["id"]?.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.name = dataItem["name"]?.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.inputs = dataItem["inputs"]?.Deserialize<Dictionary<string, object>>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.status = dataItem["status"]?.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.introduction = dataItem["introduction"]?.GetValue<string>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.created_at = dataItem["created_at"]?.GetValue<long?>();
                                }
                                catch { }

                                try
                                {
                                    conversationData.updated_at = dataItem["updated_at"]?.GetValue<long?>();
                                }
                                catch { }

                                this.data.Add(conversationData);
                            }
                        }
                    }
                }
            }
            catch { }
        }

    }

    /// <summary>
    /// 对话数据类
    /// Conversation data class
    /// </summary>
    public class ConversationData
    {
        /// <summary>
        /// 对话的唯一标识符
        /// Unique identifier of the conversation
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 对话的名称
        /// Name of the conversation
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 对话的输入参数
        /// Input parameters of the conversation
        /// </summary>
        public Dictionary<string, object>? inputs { get; set; }

        /// <summary>
        /// 对话的状态
        /// Status of the conversation
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 对话的简介
        /// Introduction of the conversation
        /// </summary>
        public string? introduction { get; set; }

        /// <summary>
        /// 对话的创建时间戳
        /// Creation timestamp of the conversation
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 对话的更新时间戳
        /// Update timestamp of the conversation
        /// </summary>
        public long? updated_at { get; set; }
    }

}
