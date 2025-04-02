using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 响应对象，包含消息列表等信息。
    /// Response object containing message list and other information.
    /// </summary>
    public class GetConversationHistoryMessagesResponse
    {
        /// <summary>
        /// 返回条数，若传入超过系统限制，返回系统限制数量。
        /// The number of items to return. If the input exceeds the system limit, the system limit will be returned.
        /// </summary>
        public long? limit { get; set; }

        /// <summary>
        /// 是否存在下一页。
        /// Indicates whether there is a next page.
        /// </summary>
        public bool? has_more { get; set; }

        /// <summary>
        /// 消息列表。
        /// List of messages.
        /// </summary>
        public List<ConversationHistoryMessagesDataItem>? data { get; set; }

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
                    DeserializeGetConversationHistoryMessagesResponse(value!);
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
        public virtual void DeserializeGetConversationHistoryMessagesResponse(string json)
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

                    if (jsonNode["data"] is not null)
                    {
                        this.data = new List<ConversationHistoryMessagesDataItem>();
                        foreach (var itemNode in jsonNode["data"]!.AsArray())
                        {
                            var dataItem = new ConversationHistoryMessagesDataItem();
                            try
                            {
                                dataItem.id = itemNode!["id"]!?.GetValue<string>();
                            }
                            catch { }

                            try
                            {
                                dataItem.conversation_id = itemNode!["conversation_id"]?.GetValue<string>();
                            }
                            catch { }

                            try
                            {
                                if (itemNode!["inputs"] is not null)
                                {
                                    dataItem.inputs = new Dictionary<string, object>();
                                    foreach (var inputPair in itemNode["inputs"]!.AsObject())
                                    {
                                        try
                                        {
                                            dataItem.inputs[inputPair.Key] = inputPair.Value!.ToString();
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                dataItem.query = itemNode!["query"]?.GetValue<string>();
                            }
                            catch { }

                            try
                            {
                                dataItem.answer = itemNode!["answer"]?.GetValue<string>();
                            }
                            catch { }

                            try
                            {
                                dataItem.message_files = ParseMessageFiles(itemNode!["message_files"]!);
                            }
                            catch { }

                            try
                            {
                                dataItem.feedback = ParseFeedback(itemNode!["feedback"]!);
                            }
                            catch { }

                            try
                            {
                                if (itemNode!["retriever_resources"] is not null)
                                {
                                    dataItem.retriever_resources = new List<object>();
                                    foreach (var resourceNode in itemNode!["retriever_resources"]!.AsArray())
                                    {
                                        try
                                        {
                                            dataItem.retriever_resources.Add(resourceNode!.ToString());
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                dataItem.created_at = itemNode!["created_at"]!.GetValue<long?>();
                            }
                            catch { }

                            try
                            {
                                dataItem.agent_thoughts = ParseAgentThoughts(itemNode!["agent_thoughts"]!);
                            }
                            catch { }

                            this.data.Add(dataItem);
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFilesNode"></param>
        /// <returns></returns>
        public virtual List<MessageFile> ParseMessageFiles(JsonNode messageFilesNode)
        {
            var messageFiles = new List<MessageFile>();
            if (messageFilesNode is not null)
            {
                foreach (var fileNode in messageFilesNode.AsArray())
                {
                    var messageFile = new MessageFile();
                    try
                    {
                        messageFile.id = fileNode!["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        messageFile.type = fileNode!["type"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        messageFile.url = fileNode!["url"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        messageFile.belongs_to = fileNode!["belongs_to"]?.GetValue<string>();
                    }
                    catch { }

                    messageFiles.Add(messageFile);
                }
            }
            return messageFiles;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedbackNode"></param>
        /// <returns></returns>
        public virtual Feedback ParseFeedback(JsonNode feedbackNode)
        {
            var feedback = new Feedback();
            if (feedbackNode is not null)
            {
                try
                {
                    feedback.rating = feedbackNode["rating"]?.GetValue<string>();
                }
                catch { }
            }
            return feedback;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agentThoughtsNode"></param>
        /// <returns></returns>
        public virtual List<AgentThought> ParseAgentThoughts(JsonNode agentThoughtsNode)
        {
            var agentThoughts = new List<AgentThought>();
            if (agentThoughtsNode is not null)
            {
                foreach (var thoughtNode in agentThoughtsNode.AsArray())
                {
                    var agentThought = new AgentThought();
                    try
                    {
                        agentThought.id = thoughtNode!["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.message_id = thoughtNode!["message_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.position = thoughtNode!["position"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        agentThought.thought = thoughtNode!["thought"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.observation = thoughtNode!["observation"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.tool = thoughtNode!["tool"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.tool_input = thoughtNode!["tool_input"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        agentThought.created_at = thoughtNode!["created_at"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        if (thoughtNode!["message_files"] is not null)
                        {
                            agentThought.message_files = new List<string>();
                            foreach (var fileIdNode in thoughtNode!["message_files"]!.AsArray())
                            {
                                try
                                {
                                    agentThought.message_files.Add(fileIdNode!.GetValue<string>());
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }

                    agentThoughts.Add(agentThought);
                }
            }
            return agentThoughts;
        }

    }

    /// <summary>
    /// 会话历史消息数据项，包含消息的详细信息。
    /// Conversation history message data item containing detailed information about the message.
    /// </summary>
    public class ConversationHistoryMessagesDataItem
    {
        /// <summary>
        /// 消息 ID。
        /// Message ID.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 会话 ID。
        /// Conversation ID.
        /// </summary>
        public string? conversation_id { get; set; }

        /// <summary>
        /// 用户输入参数。
        /// User input parameters.
        /// </summary>
        public Dictionary<string, object>? inputs { get; set; }

        /// <summary>
        /// 用户输入 / 提问内容。
        /// User input/question content.
        /// </summary>
        public string? query { get; set; }

        /// <summary>
        /// 回答消息内容。
        /// Answer message content.
        /// </summary>
        public string? answer { get; set; }

        /// <summary>
        /// 消息文件。
        /// Message files.
        /// </summary>
        public List<MessageFile>? message_files { get; set; }

        /// <summary>
        /// 反馈信息。
        /// Feedback information.
        /// </summary>
        public Feedback? feedback { get; set; }

        /// <summary>
        /// 引用和归属分段列表。
        /// List of referenced and attributed segments.
        /// </summary>
        public List<object>? retriever_resources { get; set; }

        /// <summary>
        /// 创建时间戳，如：1705395332。
        /// Creation timestamp, e.g., 1705395332.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// Agent思考内容（仅Agent模式下不为空）。
        /// Agent's thought content (not empty only in Agent mode).
        /// </summary>
        public List<AgentThought>? agent_thoughts { get; set; }


    }

    /// <summary>
    /// 消息文件，包含文件的相关信息。
    /// Message file containing relevant information about the file.
    /// </summary>
    public class MessageFile
    {
        /// <summary>
        /// 文件的 ID。
        /// File ID.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 文件类型，image 图片。
        /// File type, e.g., "image" for pictures.
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 预览图片地址。
        /// Preview image URL.
        /// </summary>
        public string? url { get; set; }

        /// <summary>
        /// 文件归属方，user 或 assistant。
        /// File owner, either "user" or "assistant".
        /// </summary>
        public string? belongs_to { get; set; }
    }

    /// <summary>
    /// 反馈信息，包含点赞或点踩信息。
    /// Feedback information, including like or dislike.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// 点赞 like / 点踩 dislike。
        /// Like or dislike.
        /// </summary>
        public string? rating { get; set; }
    }

    /// <summary>
    /// Agent思考内容项，包含Agent思考的详细信息。
    /// Agent thought item containing detailed information about the Agent's thought.
    /// </summary>
    public class AgentThought
    {
        /// <summary>
        /// agent_thought ID，每一轮Agent迭代都会有一个唯一的id。
        /// Agent thought ID, each round of Agent iteration has a unique ID.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 消息唯一ID。
        /// Unique message ID.
        /// </summary>
        public string? message_id { get; set; }

        /// <summary>
        /// agent_thought在消息中的位置，如第一轮迭代position为1。
        /// The position of the agent thought in the message, e.g., 1 for the first iteration.
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// agent的思考内容。
        /// Agent's thought content.
        /// </summary>
        public string? thought { get; set; }

        /// <summary>
        /// 工具调用的返回结果。
        /// Result returned from tool invocation.
        /// </summary>
        public string? observation { get; set; }

        /// <summary>
        /// 使用的工具列表，以 ; 分割多个工具。
        /// List of used tools, separated by ';'.
        /// </summary>
        public string? tool { get; set; }

        /// <summary>
        /// 工具的输入，JSON格式的字符串(object)。如：{"dalle3": {"prompt": "a cute cat"}}
        /// Tool input, a JSON-formatted string (object). For example: {"dalle3": {"prompt": "a cute cat"}}
        /// </summary>
        public string? tool_input { get; set; }

        /// <summary>
        /// 创建时间戳，如：1705395332。
        /// Creation timestamp, e.g., 1705395332.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 当前agent_thought 关联的文件ID。
        /// File IDs associated with the current agent thought.
        /// </summary>
        public List<string>? message_files { get; set; }
    }

}
