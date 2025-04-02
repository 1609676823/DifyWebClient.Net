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
    /// event: node_finished node 执行结束，成功失败同一事件中不同状态
    /// event: node_finished node execution ends, success or failure in different states in the same event
    /// </summary>
    public class NodeFinishedEventResponse : SSEEventResponseBase
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
        public NodeFinishedData? data { get; set; }

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
                    DeserializeNodeFinishedEventResponse(value!);
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
        public virtual void DeserializeNodeFinishedEventResponse(string json)
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
                    this.data = new NodeFinishedData();

                    try
                    {
                        this.data.id = dataNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.node_id = dataNode["node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.node_type = dataNode["node_type"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.title = dataNode["title"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.index = dataNode["index"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        this.data.predecessor_node_id = dataNode["predecessor_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    var inputsNode = dataNode["inputs"];
                    if (inputsNode != null)
                    {
                        this.data.inputs = new Dictionary<string, object>();
                        try
                        {

                            foreach (var keyValue in inputsNode.AsObject())
                            {
                                this. data.inputs.Add(keyValue.Key, keyValue.Value!);
                            }
                            
                        }
                        catch
                        {

                            
                        }
                       
                    }

                    this.data.process_data = dataNode["process_data"]?.ToString();

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
                        this.data.status = dataNode["status"]?.GetValue<string>();
                    }
                    catch { }

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
                        this.data.execution_metadata = dataNode["execution_metadata"]?.ToString();
                    }
                    catch { }

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
                        this.data.files = dataNode["files"]?.AsArray().Select(x => x!.GetValue<string>()).ToArray();
                    }
                    catch { }

                    try
                    {
                        this.data.parallel_id = dataNode["parallel_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.parallel_start_node_id = dataNode["parallel_start_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.parent_parallel_id = dataNode["parent_parallel_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.parent_parallel_start_node_id = dataNode["parent_parallel_start_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.iteration_id = dataNode["iteration_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.data.loop_id = dataNode["loop_id"]?.GetValue<string>();
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
    public class NodeFinishedData
    {
        /// <summary>
        /// 数据唯一标识
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 节点的唯一标识
        /// </summary>
        public string? node_id { get; set; }

        /// <summary>
        /// 节点的类型
        /// </summary>
        public string? node_type { get; set; }

        /// <summary>
        /// 节点的标题
        /// </summary>
        public string? title { get; set; }

        /// <summary>
        /// 节点的索引
        /// </summary>
        public int? index { get; set; }

        /// <summary>
        /// 前一个节点的 ID
        /// </summary>
        public string? predecessor_node_id { get; set; }

        /// <summary>
        /// 节点输入信息
        /// </summary>
        public Dictionary<string,object>? inputs { get; set; }

        /// <summary>
        /// 节点过程数据
        /// </summary>
        public string? process_data { get; set; }

        /// <summary>
        /// 节点输出信息
        /// </summary>
        public Dictionary<string, object>? outputs { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        public string? error { get; set; }

        /// <summary>
        /// 耗时（秒）
        /// </summary>
        public double? elapsed_time { get; set; }

        /// <summary>
        /// 执行元数据
        /// </summary>
        public string? execution_metadata { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 结束时间戳
        /// </summary>
        public long? finished_at { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        public string[]? files { get; set; }

        /// <summary>
        /// 并行执行的 ID
        /// </summary>
        public string? parallel_id { get; set; }

        /// <summary>
        /// 并行执行开始节点的 ID
        /// </summary>
        public string? parallel_start_node_id { get; set; }

        /// <summary>
        /// 父并行执行的 ID
        /// </summary>
        public string? parent_parallel_id { get; set; }

        /// <summary>
        /// 父并行执行开始节点的 ID
        /// </summary>
        public string? parent_parallel_start_node_id { get; set; }

        /// <summary>
        /// 迭代 ID
        /// </summary>
        public string? iteration_id { get; set; }

        /// <summary>
        /// 循环 ID
        /// </summary>
        public string? loop_id { get; set; }
    }
    ///// <summary>
    ///// 
    ///// </summary>
    //public class NodeInputs
    //{
    //    /// <summary>
    //    /// 系统查询内容
    //    /// </summary>
    //    [JsonPropertyName("sys.query")]
    //    public string? sys_query { get; set; }

    //    /// <summary>
    //    /// 系统文件列表
    //    /// </summary>
    //    [JsonPropertyName("sys.files")]
    //    public string[]? sys_files { get; set; }

    //    /// <summary>
    //    /// 系统会话 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.conversation_id")]
    //    public string? sys_conversation_id { get; set; }

    //    /// <summary>
    //    /// 系统用户 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.user_id")]
    //    public string? sys_user_id { get; set; }

    //    /// <summary>
    //    /// 系统对话计数
    //    /// </summary>
    //    [JsonPropertyName("sys.dialogue_count")]
    //    public int? sys_dialogue_count { get; set; }

    //    /// <summary>
    //    /// 系统应用 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.app_id")]
    //    public string? sys_app_id { get; set; }

    //    /// <summary>
    //    /// 系统工作流 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.workflow_id")]
    //    public string? sys_workflow_id { get; set; }

    //    /// <summary>
    //    /// 系统工作流运行 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.workflow_run_id")]
    //    public string? sys_workflow_run_id { get; set; }
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public class NodeOutputs
    //{
    //    /// <summary>
    //    /// 系统查询内容
    //    /// </summary>
    //    [JsonPropertyName("sys.query")]
    //    public string? sys_query { get; set; }

    //    /// <summary>
    //    /// 系统文件列表
    //    /// </summary>
    //    [JsonPropertyName("sys.files")]
    //    public string[]? sys_files { get; set; }

    //    /// <summary>
    //    /// 系统会话 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.conversation_id")]
    //    public string? sys_conversation_id { get; set; }

    //    /// <summary>
    //    /// 系统用户 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.user_id")]
    //    public string? sys_user_id { get; set; }

    //    /// <summary>
    //    /// 系统对话计数
    //    /// </summary>
    //    [JsonPropertyName("sys.dialogue_count")]
    //    public int? sys_dialogue_count { get; set; }

    //    /// <summary>
    //    /// 系统应用 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.app_id")]
    //    public string? sys_app_id { get; set; }

    //    /// <summary>
    //    /// 系统工作流 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.workflow_id")]
    //    public string? sys_workflow_id { get; set; }

    //    /// <summary>
    //    /// 系统工作流运行 ID
    //    /// </summary>
    //    [JsonPropertyName("sys.workflow_run_id")]
    //    public string? sys_workflow_run_id { get; set; }
    //}
}

