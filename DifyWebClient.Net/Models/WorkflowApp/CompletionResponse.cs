using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.WorkflowApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 返回完整的 App 结果，Content-Type 为 application/json 。
    /// Returns the complete App result, with Content-Type as application/json.
    /// </summary>
    public class CompletionResponse
    {
        /// <summary>
        /// workflow 执行 ID
        /// workflow execution ID
        /// </summary>
        public string? workflow_run_id { get; set; }

        /// <summary>
        /// 任务 ID，用于请求跟踪和下方的停止响应接口
        /// Task ID, used for request tracking and the stop response interface below
        /// </summary>
        public string? task_id { get; set; }

        /// <summary>
        /// 详细内容
        /// Detailed content
        /// </summary>
        public CompletionData? data { get; set; }

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
                    DeserializeCompletionResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }
        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        public virtual void DeserializeCompletionResponse(string json)
        {
            try
            {
                var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        this.workflow_run_id = jsonNode["workflow_run_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.task_id = jsonNode["task_id"]?.GetValue<string>();
                    }
                    catch { }

                    var dataNode = jsonNode["data"];
                    if (dataNode != null)
                    {
                        this.data = new CompletionData();

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
                            this.data.status = dataNode["status"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            var outputsNode = dataNode["outputs"];
                            if (outputsNode != null)
                            {
                                this.data.outputs = new Dictionary<string, object>();
                                foreach (var keyValue in outputsNode.AsObject())
                                {
                                    this.data.outputs.Add(keyValue.Key,(keyValue.Value!));
                                }
                                //this.data.outputs = outputsNode.AsObject().ToDictionary(
                                //    prop => prop.Key,
                                //    prop => prop.Value!.GetValue<object>());
                            }
                        }
                        catch(Exception ) 
                        {
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
                            this.data.total_tokens = dataNode["total_tokens"]?.GetValue<long?>();
                        }
                        catch { }

                        try
                        {
                            this.data.total_steps = dataNode["total_steps"]?.GetValue<long?>();
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
                    }
                }
            }
            catch { }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CompletionData
    {
        /// <summary>
        /// workflow 执行 ID
        /// workflow execution ID
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 关联 Workflow ID
        /// Associated Workflow ID
        /// </summary>
        public string? workflow_id { get; set; }

        /// <summary>
        /// 执行状态, running / succeeded / failed / stopped
        /// Execution status, values can be: running / succeeded / failed / stopped
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// Optional 输出内容
        /// Optional output content
        /// </summary>
        public Dictionary<string,object>? outputs { get; set; }

        /// <summary>
        /// Optional 错误原因
        /// Optional error reason
        /// </summary>
        public string? error { get; set; }

        /// <summary>
        /// Optional 耗时(s)
        /// Optional elapsed time in seconds
        /// </summary>
        public double? elapsed_time { get; set; }

        /// <summary>
        /// Optional 总使用 tokens
        /// Optional total number of tokens used
        /// </summary>
        public long? total_tokens { get; set; }

        /// <summary>
        /// 总步数（冗余），默认 0
        /// Total number of steps (redundant), default is 0
        /// </summary>
        public long? total_steps { get; set; }

        /// <summary>
        /// 开始时间
        /// Start time
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 结束时间
        /// End time
        /// </summary>
        public long? finished_at { get; set; }
    }
}
