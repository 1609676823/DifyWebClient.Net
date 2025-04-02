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
    /// event: workflow_started workflow 开始执行
    /// event: workflow_started workflow starts execution
    /// </summary>
    public class WorkflowStartedEventResponse : SSEEventResponseBase
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
        /// 工作流运行的唯一标识
        /// Unique identifier of the workflow run
        /// </summary>
        public string? workflow_run_id { get; set; }

        /// <summary>
        /// 工作流相关数据
        /// Workflow related data
        /// </summary>
        public WorkflowData? data { get; set; }

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
                    DeserializeWorkflowStartedEventResponse(value!);
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
        public virtual void DeserializeWorkflowStartedEventResponse(string json)
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
                    workflow_run_id = jsonNode["workflow_run_id"]?.GetValue<string>();
                }
                catch { }

                var dataNode = jsonNode["data"];
                if (dataNode != null)
                {
                    data = new WorkflowData();
                    try
                    {
                        data.id = dataNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.workflow_id = dataNode["workflow_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.sequence_number = dataNode["sequence_number"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        data.created_at = dataNode["created_at"]?.GetValue<long?>();
                    }
                    catch { }

                    var inputsNode = dataNode["inputs"];
                    if (inputsNode != null)
                    {

                      
                        data.inputs = new Dictionary<string, object>();
                        try
                        {

                            foreach (var keyValue in inputsNode.AsObject()) 
                            {
                                this.data.inputs.Add(keyValue.Key,keyValue.Value!);
                            }
                            //this.data.inputs = inputsNode.AsObject().ToDictionary(
                            //  prop => prop.Key,
                            //  prop => prop.Value!.GetValue<object>());
                        }
                        catch 
                        {

                           // throw;
                        }
                      
                     
                    }
                }
            }
            catch { }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowData
    {
        /// <summary>
        /// 与 workflow_run_id 相同，工作流运行的唯一标识
        /// Same as workflow_run_id, Unique identifier of the workflow run
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 工作流的唯一标识
        /// Unique identifier of the workflow
        /// </summary>
        public string? workflow_id { get; set; }

        /// <summary>
        /// 序列号
        /// Sequence number
        /// </summary>
        public int? sequence_number { get; set; }

        /// <summary>
        /// 工作流输入参数
        /// Workflow input parameters
        /// </summary>
        public Dictionary<string,object>? inputs { get; set; }

        /// <summary>
        /// 数据创建时间戳
        /// Data creation timestamp
        /// </summary>
        public long? created_at { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowInputs
    {
        /// <summary>
        /// 系统查询内容
        /// System query content
        /// </summary>
        [JsonPropertyName("sys.query")]
        public string? sys_query { get; set; }

        /// <summary>
        /// 系统文件列表
        /// System file list
        /// </summary>
        [JsonPropertyName("sys.files")]
        public string[]? sys_files { get; set; }

        /// <summary>
        /// 系统会话 ID
        /// System conversation ID
        /// </summary>
        [JsonPropertyName("sys.conversation_id")]
        public string? sys_conversation_id { get; set; }

        /// <summary>
        /// 系统用户 ID
        /// System user ID
        /// </summary>
        [JsonPropertyName("sys.user_id")]
        public string? sys_user_id { get; set; }

        /// <summary>
        /// 系统对话计数
        /// System dialogue count
        /// </summary>
        [JsonPropertyName("sys.dialogue_count")]
        public int? sys_dialogue_count { get; set; }

        /// <summary>
        /// 系统应用 ID
        /// System app ID
        /// </summary>
        [JsonPropertyName("sys.app_id")]
        public string? sys_app_id { get; set; }

        /// <summary>
        /// 系统工作流 ID
        /// System workflow ID
        /// </summary>
        [JsonPropertyName("sys.workflow_id")]
        public string? sys_workflow_id { get; set; }

        /// <summary>
        /// 系统工作流运行 ID
        /// System workflow run ID
        /// </summary>
        [JsonPropertyName("sys.workflow_run_id")]
        public string? sys_workflow_run_id { get; set; }
    }

}
