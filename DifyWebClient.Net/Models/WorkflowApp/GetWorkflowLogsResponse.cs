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
    /// 获取 Workflow 日志的响应类
    /// Response class for getting workflow logs
    /// </summary>
    public class GetWorkflowLogsResponse
    {
        /// <summary>
        /// 当前页码
        /// Current page number
        /// </summary>
        public long? page { get; set; }

        /// <summary>
        /// 每页条数
        /// Number of items per page
        /// </summary>
        public long? limit { get; set; }

        /// <summary>
        /// 总条数
        /// Total number of items
        /// </summary>
        public long? total { get; set; }

        /// <summary>
        /// 是否还有更多数据
        /// Whether there is more data
        /// </summary>
        public bool? has_more { get; set; }

        /// <summary>
        /// 当前页码的数据
        /// Data of the current page
        /// </summary>
        public List<WorkflowLogsDataItem>? data { get; set; }

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
                    DeserializeGetWorkflowLogsResponse(value!);
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
        public virtual void DeserializeGetWorkflowLogsResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        if (jsonNode["page"] != null)
                        {
                            this.page = Convert.ToInt64(jsonNode["page"]!.ToString());
                        }
                    }
                    catch { }

                    try
                    {
                        if (jsonNode["limit"] != null)
                        {
                            this.limit = Convert.ToInt64(jsonNode["limit"]!.ToString());
                        }
                    }
                    catch { }

                    try
                    {
                        if (jsonNode["total"] != null)
                        {
                            this.total = Convert.ToInt64(jsonNode["total"]!.ToString());
                        }
                    }
                    catch { }

                    try
                    {
                        if (jsonNode["has_more"] != null)
                        {
                            this.has_more = Convert.ToBoolean(jsonNode["has_more"]!.ToString());
                        }
                    }
                    catch { }

                    this.data = new List<WorkflowLogsDataItem>();
                    var dataArray = jsonNode["data"]?.AsArray();
                    if (dataArray != null)
                    {
                        foreach (var item in dataArray)
                        {
                            var dataItem = new WorkflowLogsDataItem();

                            try
                            {
                                if (item!["id"] != null)
                                {
                                    dataItem.id = Convert.ToString(item["id"]);
                                }
                            }
                            catch { }

                            try
                            {
                                if (item!["created_from"] != null)
                                {
                                    dataItem.created_from = Convert.ToString(item["created_from"]);
                                }
                            }
                            catch { }

                            try
                            {
                                if (item!["created_by_role"] != null)
                                {
                                    dataItem.created_by_role = Convert.ToString(item["created_by_role"]);
                                }
                            }
                            catch { }

                            try
                            {
                                if (item!["created_by_account"] != null)
                                {
                                    dataItem.created_by_account = Convert.ToString(item["created_by_account"]);
                                }
                            }
                            catch { }

                            try
                            {
                                if (item!["created_at"] != null)
                                {
                                    dataItem.created_at = Convert.ToInt64(item["created_at"]!.ToString());
                                }
                            }
                            catch { }

                            var workflowRunNode = item!["workflow_run"];
                            if (workflowRunNode != null)
                            {
                                dataItem.workflow_run = new WorkflowLogsWorkflowRun();

                                try
                                {
                                    if (workflowRunNode["id"] != null)
                                    {
                                        dataItem.workflow_run.id = Convert.ToString(workflowRunNode["id"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["version"] != null)
                                    {
                                        dataItem.workflow_run.version = Convert.ToString(workflowRunNode["version"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["status"] != null)
                                    {
                                        dataItem.workflow_run.status = Convert.ToString(workflowRunNode["status"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["error"] != null)
                                    {
                                        dataItem.workflow_run.error = Convert.ToString(workflowRunNode["error"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["elapsed_time"] != null)
                                    {
                                        dataItem.workflow_run.elapsed_time = Convert.ToDouble(workflowRunNode["elapsed_time"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["total_tokens"] != null)
                                    {
                                        dataItem.workflow_run.total_tokens = Convert.ToInt64(workflowRunNode["total_tokens"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["total_steps"] != null)
                                    {
                                        dataItem.workflow_run.total_steps = Convert.ToInt64(workflowRunNode["total_steps"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["created_at"] != null)
                                    {
                                        dataItem.workflow_run.created_at = Convert.ToInt64(workflowRunNode["created_at"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["finished_at"] != null)
                                    {
                                        dataItem.workflow_run.finished_at = Convert.ToInt64(workflowRunNode["finished_at"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (workflowRunNode["exceptions_count"] != null)
                                    {
                                        dataItem.workflow_run.exceptions_count = Convert.ToInt64(workflowRunNode["exceptions_count"]!.ToString());
                                    }
                                }
                                catch { }
                            }

                            var createdByEndUserNode = item["created_by_end_user"];
                            if (createdByEndUserNode != null)
                            {
                                dataItem.created_by_end_user = new WorkflowLogsCreatedByEndUser();

                                try
                                {
                                    if (createdByEndUserNode["id"] != null)
                                    {
                                        dataItem.created_by_end_user.id = Convert.ToString(createdByEndUserNode["id"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (createdByEndUserNode["type"] != null)
                                    {
                                        dataItem.created_by_end_user.type = Convert.ToString(createdByEndUserNode["type"]);
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (createdByEndUserNode["is_anonymous"] != null)
                                    {
                                        dataItem.created_by_end_user.is_anonymous = Convert.ToBoolean(createdByEndUserNode["is_anonymous"]!.ToString());
                                    }
                                }
                                catch { }

                                try
                                {
                                    if (createdByEndUserNode["session_id"] != null)
                                    {
                                        dataItem.created_by_end_user.session_id = Convert.ToString(createdByEndUserNode["session_id"]);
                                    }
                                }
                                catch { }
                            }

                            this.data.Add(dataItem);
                        }
                    }
                }
            }
            catch { }
        }
    }

    /// <summary>
    /// Workflow 执行日志相关信息
    /// Workflow execution log related information
    /// </summary>
    public class WorkflowLogsWorkflowRun
    {
        /// <summary>
        /// 标识
        /// Identifier
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 版本
        /// Version
        /// </summary>
        public string? version { get; set; }

        /// <summary>
        /// 执行状态, running / succeeded / failed / stopped
        /// Execution status, running / succeeded / failed / stopped
        /// </summary>
        public string? status { get; set; }

        /// <summary>
        /// (可选) 错误
        /// (Optional) Error
        /// </summary>
        public string? error { get; set; }

        /// <summary>
        /// 耗时，单位秒
        /// Elapsed time in seconds
        /// </summary>
        public double? elapsed_time { get; set; }

        /// <summary>
        /// 消耗的 token 数量
        /// Total number of tokens consumed
        /// </summary>
        public long? total_tokens { get; set; }

        /// <summary>
        /// 执行步骤长度
        /// Total number of execution steps
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

        /// <summary>
        /// 异常数量
        /// Number of exceptions
        /// </summary>
        public long? exceptions_count { get; set; }
    }

    /// <summary>
    /// 用户相关信息
    /// User related information
    /// </summary>
    public class WorkflowLogsCreatedByEndUser
    {
        /// <summary>
        /// 标识
        /// Identifier
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 类型
        /// Type
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 是否匿名
        /// Whether it is anonymous
        /// </summary>
        public bool? is_anonymous { get; set; }

        /// <summary>
        /// 会话标识
        /// Session identifier
        /// </summary>
        public string? session_id { get; set; }
    }

    /// <summary>
    /// 单条数据项
    /// Single data item
    /// </summary>
    public class WorkflowLogsDataItem
    {
        /// <summary>
        /// 标识
        /// Identifier
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// Workflow 执行日志
        /// Workflow execution log
        /// </summary>
        public WorkflowLogsWorkflowRun? workflow_run { get; set; }

        /// <summary>
        /// 来源
        /// Source
        /// </summary>
        public string? created_from { get; set; }

        /// <summary>
        /// 角色
        /// Role
        /// </summary>
        public string? created_by_role { get; set; }

        /// <summary>
        /// (可选) 帐号
        /// (Optional) Account
        /// </summary>
        public string? created_by_account { get; set; }

        /// <summary>
        /// 用户
        /// User
        /// </summary>
        public WorkflowLogsCreatedByEndUser? created_by_end_user { get; set; }

        /// <summary>
        /// 创建时间
        /// Creation time
        /// </summary>
        public long? created_at { get; set; }
    }
}
