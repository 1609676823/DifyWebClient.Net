using DifyWebClient.Net.Models;
using DifyWebClient.Net.Models.WorkflowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.ApiClients
{
    /// <summary>
    /// Workflow 应用 API 管理器
    /// </summary>
    public class WorkflowAppApiClient: DifyApiClientBase
    {
        /// <summary>
        /// Workflow 应用 API 管理器
        /// </summary>
        public WorkflowAppApiClient() : base() { }
        /// <summary>
        /// Workflow 应用 API 管理器
        /// </summary>
        /// <param name="url"></param>
        /// <param name="apikey"></param>
        public WorkflowAppApiClient(string url, string apikey) : base(url, apikey)
        {

        }

        /// <summary>
        /// 执行 workflow 异步
        /// ExecuteWorkflow Async
        /// </summary>
        /// <param name="executeWorkflowRequest"></param>
        /// <returns></returns>
        public async Task<CompletionResponse> ExecuteWorkflowAsync(ExecuteWorkflowRequest executeWorkflowRequest)
        {
            string requestjson = System.Text.Json.JsonSerializer.Serialize(executeWorkflowRequest, JsonSerializerOptions);
            string url = Url + "workflows/run";
            bool streamResponse = false;
            if (Enum.ResponseMode.Streaming.Equals(executeWorkflowRequest.response_mode, StringComparison.OrdinalIgnoreCase))
            {
                streamResponse = true;
            }
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson, null, streamResponse, "workflowsrun");
            CompletionResponse completionResponse = new CompletionResponse();
            completionResponse.RealJsonstring = resjosn;
            return completionResponse;
        }
        /// <summary>
        /// 执行 workflow
        /// ExecuteWorkflow
        /// </summary>
        /// <param name="executeWorkflowRequest"></param>
        /// <returns></returns>
        public CompletionResponse ExecuteWorkflow(ExecuteWorkflowRequest executeWorkflowRequest)
        {

            Task<CompletionResponse> task = ExecuteWorkflowAsync(executeWorkflowRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取workflow执行情况异步
        /// Get Workflow Run Detail Async
        /// </summary>
        /// <param name="workflow_id"></param>
        /// <returns></returns>
        public async Task<GetWorkflowRunDetailResponse> GetWorkflowRunDetailAsync(string workflow_id)
        {
            
            string url = Url + "workflows/run/"+ workflow_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetWorkflowRunDetailResponse getWorkflowRunDetailResponse = new GetWorkflowRunDetailResponse();
            getWorkflowRunDetailResponse.RealJsonstring = resjosn;
            return getWorkflowRunDetailResponse;
        }

        /// <summary>
        /// 获取workflow执行情况
        /// Get Workflow Run Detail
        /// </summary>
        /// <param name="workflow_id"></param>
        /// <returns></returns>
        public GetWorkflowRunDetailResponse GetWorkflowRunDetail(string workflow_id)
        {
            Task<GetWorkflowRunDetailResponse> task = GetWorkflowRunDetailAsync(workflow_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 停止响应异步 仅支持流式模式。
        /// Stop Generate Async Only supported in streaming mode.
        /// </summary>
        /// <param name="task_id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<CommonResultResponse> StopGenerateAsync(string task_id, string user)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("user", user);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "workflows/tasks/" + task_id + "/stop";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            CommonResultResponse commonResultResponse = new CommonResultResponse();
            commonResultResponse.RealJsonstring = resjosn;
            return commonResultResponse;
        }
        /// <summary>
        /// 停止响应 仅支持流式模式。
        /// Stop Generate Only supported in streaming mode.
        /// </summary>
        /// <param name="task_id">task_id (string) 任务 ID，可在流式返回 Chunk 中获取</param>
        /// <param name="user">user (string) Required 用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致</param>
        /// <returns></returns>
        public CommonResultResponse StopGenerate(string task_id, string user)
        {
            Task<CommonResultResponse> task = StopGenerateAsync(task_id, user);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取 workflow 日志异步 倒序返回workflow日志
        /// Get Workflow Logs Async;  Returns workflow logs, with the first page returning the latest {limit} messages, i.e., in reverse order.
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="status"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<GetWorkflowLogsResponse> GetWorkflowLogsAsync(string keyword = "", string status="", long page = 1, long limit = 20)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters.Add("keyword", keyword);
            }
            if (!string.IsNullOrWhiteSpace(status))
            {
                queryParameters.Add("status", status);
            }
            if (page >= 0) { queryParameters.Add("page", page.ToString()); }
            if (limit >= 0) { queryParameters.Add("limit", limit.ToString()); }
            string url = Url + "workflows/logs";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetWorkflowLogsResponse getWorkflowLogsResponse = new GetWorkflowLogsResponse();
            getWorkflowLogsResponse.RealJsonstring = resjosn;
            return getWorkflowLogsResponse;
        }

        /// <summary>
        /// 获取 workflow 日志 倒序返回workflow日志
        /// Get Workflow Logs Returns workflow logs, with the first page returning the latest {limit} messages, i.e., in reverse order.
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="status"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public GetWorkflowLogsResponse GetWorkflowLogs(string keyword = "", string status = "", long page = 1, long limit = 20)
        {
            Task<GetWorkflowLogsResponse> task = GetWorkflowLogsAsync(keyword, status, page, limit);
            task.Wait();
            return task.Result;
        }
    }
}
