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
    /// event: node_started node 开始执行
    /// node execution started
    /// </summary>
    public class NodeStartedEventResponse : SSEEventResponseBase
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
        public NodeStartedData? data { get; set; }

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
                    DeserializeNodeStartedEventResponse(value!);
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
        public virtual void DeserializeNodeStartedEventResponse(string json)
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
                    workflow_run_id = jsonNode["workflow_run_id"]?.GetValue<string>();
                }
                catch { }

                var dataNode = jsonNode["data"];
                if (dataNode != null)
                {
                    data = new NodeStartedData();
                    try
                    {
                        data.id = dataNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.node_id = dataNode["node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.node_type = dataNode["node_type"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.title = dataNode["title"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.index = dataNode["index"]?.GetValue<int?>();
                    }
                    catch { }

                    try
                    {
                        data.predecessor_node_id = dataNode["predecessor_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        //this.data.inputs = dataNode["inputs"]?.ToString();
                        var inputsNode = dataNode["inputs"];
                        this.data.inputs = new Dictionary<string, object>();
                       
                        foreach (var keyValue in inputsNode!.AsObject())
                        {
                            data.inputs.Add(keyValue.Key, keyValue.Value!);
                        }

                    }
                    catch 
                    { 
                    }


                    try
                    {
                        data.created_at = dataNode["created_at"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        data.extras = dataNode["extras"]?.ToString();
                    }
                    catch { }

                    try
                    {
                        data.parallel_id = dataNode["parallel_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.parallel_start_node_id = dataNode["parallel_start_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.parent_parallel_id = dataNode["parent_parallel_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.parent_parallel_start_node_id = dataNode["parent_parallel_start_node_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.iteration_id = dataNode["iteration_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.loop_id = dataNode["loop_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.parallel_run_id = dataNode["parallel_run_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        data.agent_strategy = dataNode["agent_strategy"]?.GetValue<string>();
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
    public class NodeStartedData
    {
        /// <summary>
        /// 数据唯一标识
        /// Unique identifier of the data
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 节点的唯一标识
        /// Unique identifier of the node
        /// </summary>
        public string? node_id { get; set; }

        /// <summary>
        /// 节点的类型
        /// Type of the node
        /// </summary>
        public string? node_type { get; set; }

        /// <summary>
        /// 节点的标题
        /// Title of the node
        /// </summary>
        public string? title { get; set; }

        /// <summary>
        /// 节点的索引
        /// Index of the node
        /// </summary>
        public int? index { get; set; }

        /// <summary>
        /// 前一个节点的 ID
        /// ID of the predecessor node
        /// </summary>
        public string? predecessor_node_id { get; set; }

        /// <summary>
        /// 节点输入信息
        /// Input information of the node
        /// </summary>
        public Dictionary<string,object>? inputs { get; set; }

        /// <summary>
        /// 创建时间戳
        /// Creation timestamp
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 额外信息
        /// Extra information
        /// </summary>
        public string? extras { get; set; }

        /// <summary>
        /// 并行执行的 ID
        /// ID of the parallel execution
        /// </summary>
        public string? parallel_id { get; set; }

        /// <summary>
        /// 并行执行开始节点的 ID
        /// ID of the start node of the parallel execution
        /// </summary>
        public string? parallel_start_node_id { get; set; }

        /// <summary>
        /// 父并行执行的 ID
        /// ID of the parent parallel execution
        /// </summary>
        public string? parent_parallel_id { get; set; }

        /// <summary>
        /// 父并行执行开始节点的 ID
        /// ID of the start node of the parent parallel execution
        /// </summary>
        public string? parent_parallel_start_node_id { get; set; }

        /// <summary>
        /// 迭代 ID
        /// Iteration ID
        /// </summary>
        public string? iteration_id { get; set; }

        /// <summary>
        /// 循环 ID
        /// Loop ID
        /// </summary>
        public string? loop_id { get; set; }

        /// <summary>
        /// 并行运行 ID
        /// Parallel run ID
        /// </summary>
        public string? parallel_run_id { get; set; }

        /// <summary>
        /// 代理策略
        /// Agent strategy
        /// </summary>
        public string? agent_strategy { get; set; }
    }
}
