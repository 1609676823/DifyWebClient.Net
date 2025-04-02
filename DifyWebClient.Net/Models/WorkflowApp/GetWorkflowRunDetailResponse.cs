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
    /// 该类用于表示获取工作流运行详细信息的响应结构。
    /// This class represents the response structure for getting workflow run details.
    /// </summary>
    public class GetWorkflowRunDetailResponse
    {
        /// <summary>
        /// 工作流运行的唯一标识符
        /// Unique identifier for the workflow run
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 关联的工作流的唯一标识符
        /// Unique identifier for the associated workflow
        /// </summary>
        public string? workflow_id { get; set; }

        /// <summary>
        /// 工作流运行的状态，如 succeeded（成功）等
        /// Status of the workflow run, e.g., succeeded
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// 工作流运行的输入参数，以 JSON 字符串形式存储
        /// Input parameters for the workflow run, stored as a JSON string
        /// </summary>
        public Dictionary<string, object>? inputs { get; set; }

        /// <summary>
        /// 工作流运行的输出结果，以 JSON 字符串形式存储
        /// Output results of the workflow run, stored as a JSON string
        /// </summary>
        public Dictionary<string, object>? outputs { get; set; }

        /// <summary>
        /// 工作流运行过程中出现的错误信息，若没有错误则为 null
        /// Error information during the workflow run, null if no error occurred
        /// </summary>
        public string? error { get; set; }

        /// <summary>
        /// 工作流运行的总步骤数
        /// Total number of steps in the workflow run
        /// </summary>
        public long? total_steps { get; set; }

        /// <summary>
        /// 工作流运行所消耗的总令牌数
        /// Total number of tokens consumed in the workflow run
        /// </summary>
        public long? total_tokens { get; set; }

        /// <summary>
        /// 工作流运行开始的时间
        /// Time when the workflow run started
        /// </summary>
        public string? created_at { get; set; }

        /// <summary>
        /// 工作流运行结束的时间
        /// Time when the workflow run finished
        /// </summary>
        public string? finished_at { get; set; }

        /// <summary>
        /// 工作流运行所花费的总时间（秒）
        /// Total time (in seconds) taken for the workflow run
        /// </summary>
        public double? elapsed_time { get; set; }

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
                    DeserializeGetWorkflowRunDetailResponse(value!);
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

        public virtual void DeserializeGetWorkflowRunDetailResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode is null)
            {
                return;
            }

            try
            {
                this.id = Convert.ToString(jsonNode["id"]);
            }
            catch
            {
            }

            try
            {
                this.workflow_id = Convert.ToString(jsonNode["workflow_id"]);
            }
            catch
            {
            }

            try
            {
                this.status = Convert.ToString(jsonNode["status"]);
            }
            catch
            {
            }

            try
            {
               
                string inputjson = jsonNode["inputs"]!.ToString();
                var inputsputsNode = JsonNode.Parse(inputjson);
                if (inputsputsNode != null)
                {
                    this.inputs = new Dictionary<string, object>();
                    foreach (var keyValue in inputsputsNode.AsObject())
                    {
                        this.inputs.Add(keyValue.Key, (keyValue.Value!));
                    }
                }
            }
            catch
            {
            }

            try
            {
                string outputsjson = jsonNode["outputs"]!.ToString();
                var outputsNode = JsonNode.Parse(outputsjson);
                if (outputsNode != null)
                {
                    this.outputs = new Dictionary<string, object>();
                    foreach (var keyValue in outputsNode.AsObject())
                    {
                        this.outputs.Add(keyValue.Key, (keyValue.Value!));
                    }
                }
            }
            catch
            {
            }

            try
            {
                this.error = Convert.ToString(jsonNode["error"]);
            }
            catch
            {
            }

            try
            {
                var totalStepsNode = jsonNode["total_steps"];
                this.total_steps = totalStepsNode is not null ? Convert.ToInt64(totalStepsNode) : null;
            }
            catch
            {
            }

            try
            {
                var totalTokensNode = jsonNode["total_tokens"];
                this.total_tokens = totalTokensNode is not null ? Convert.ToInt64(totalTokensNode) : null;
            }
            catch
            {
            }

            try
            {
                this.created_at = Convert.ToString(jsonNode["created_at"]);
            }
            catch
            {
            }

            try
            {
                this.finished_at = Convert.ToString(jsonNode["finished_at"]);
            }
            catch
            {
            }

            try
            {
                var elapsedTimeNode = jsonNode["elapsed_time"];
                this.elapsed_time = elapsedTimeNode is not null ? Convert.ToDouble(elapsedTimeNode) : null;
            }
            catch
            {
            }
        }

    }
}
