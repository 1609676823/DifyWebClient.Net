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
    /// event: workflow_finished workflow 执行结束，成功失败同一事件中不同状态
    /// event: workflow_finished workflow execution ends, success or failure in different states in the same event
    /// </summary>
    public class WorkflowFinishedEventResponse : SSEEventResponseBase
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
        /// 工作流运行的唯一标识
        /// Unique identifier of the workflow run
        /// </summary>
        public string? workflow_run_id { get; set; }

        /// <summary>
        /// 工作流相关数据
        /// Workflow related data
        /// </summary>
        public WorkflowFinishedData? data { get; set; }

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
                    DeserializeWorkflowFinishedEventResponse(value!);
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
        public virtual void DeserializeWorkflowFinishedEventResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is null) return;

                try
                {
                    this.Event = jsonNode["event"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.conversation_id = jsonNode["conversation_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.message_id = jsonNode["message_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.created_at = jsonNode["created_at"]?.GetValue<long?>();
                }
                catch { }

                try
                {
                    this.task_id = jsonNode["task_id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.id = jsonNode["id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.workflow_run_id = jsonNode["workflow_run_id"]?.GetValue<string>();
                }
                catch { }

                var dataNode = jsonNode["data"];
                if (dataNode != null)
                {
                    this.data = new WorkflowFinishedData();

                    try
                    {
                        this.data.id = dataNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.workflow_id = dataNode["workflow_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.sequence_number = dataNode["sequence_number"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        this.data.status = dataNode["status"]?.GetValue<string>();
                    }
                    catch { }

                    var outputsNode = dataNode["outputs"];
                    if (outputsNode != null)
                    {
                        this.data.outputs = new Dictionary<string, object>();
                        try
                        {
                            foreach (var keyValue in outputsNode.AsObject())
                            {
                                this.data.outputs.Add(keyValue.Key, keyValue.Value!);
                            }
                        }
                        catch { }
                    }

                    try
                    {
                        this.data.error = dataNode["error"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.elapsed_time = dataNode["elapsed_time"]?.GetValue<double?>();
                    }
                    catch { }

                    try
                    {
                        this.data.total_tokens = dataNode["total_tokens"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        this.data.total_steps = dataNode["total_steps"]?.GetValue<int?>();
                    }
                    catch { }

                    var createdByNode = dataNode["created_by"];
                    if (createdByNode != null)
                    {
                        this.data.created_by = new CreatedBy();
                        try
                        {
                            this.data.created_by.id = createdByNode["id"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.created_by.user = createdByNode["user"]?.GetValue<string>();
                        }
                        catch { }
                    }

                    try
                    {
                        this.data.created_at = dataNode["created_at"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        this.data.finished_at = dataNode["finished_at"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        this.data.exceptions_count = dataNode["exceptions_count"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        this.data.files = dataNode["files"]?.AsArray().Select(x => x!.GetValue<string>()).ToArray();
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowFinishedData
    {
        /// <summary>
        /// 数据唯一标识
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 工作流的唯一标识
        /// </summary>
        public string? workflow_id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public int? sequence_number { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 工作流输出信息
        /// </summary>
        public Dictionary<string,object>? outputs { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string? error { get; set; }

        /// <summary>
        /// 耗时（秒）
        /// </summary>
        public double? elapsed_time { get; set; }

        /// <summary>
        /// 总令牌数
        /// </summary>
        public int? total_tokens { get; set; }

        /// <summary>
        /// 总步数
        /// </summary>
        public int? total_steps { get; set; }

        /// <summary>
        /// 创建者信息
        /// </summary>
        public CreatedBy? created_by { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 结束时间戳
        /// </summary>
        public long? finished_at { get; set; }

        /// <summary>
        /// 异常数量
        /// </summary>
        public int? exceptions_count { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        public string[]? files { get; set; }
    }
    ///// <summary>
    ///// 
    ///// </summary>
    //public class WorkflowOutputs
    //{
    //    /// <summary>
    //    /// 回答内容
    //    /// </summary>
    //    public string? answer { get; set; }
    //}
    /// <summary>
    /// 
    /// </summary>
    public class CreatedBy
    {
        /// <summary>
        /// 创建者 ID
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 创建者用户标识
        /// </summary>
        public string? user { get; set; }
    }
}
