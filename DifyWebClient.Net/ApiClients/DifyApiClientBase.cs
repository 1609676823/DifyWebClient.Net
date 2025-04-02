using DifyWebClient.Net.Models.Base;
using DifyWebClient.Net.Models.ChatApp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Web;

namespace DifyWebClient.Net.ApiClients
{
    /// <summary>
    /// DifyWebClient的Base实例
    /// </summary>
    public class DifyApiClientBase : IDisposable
    {


        /// <summary>
        /// 超时
        /// </summary>
        public int RequestTimeoutMilliseconds { get; set; } = 300 * 1000;
        /// <summary>
        /// 最后一个DifyWebClient的实例
        /// </summary>
        public static DifyApiClientBase? Instance { get; set; }

        /// <summary>
        /// DifyWebClient的Base实例
        /// </summary>
        public DifyApiClientBase() { Instance = this; }
        /// <summary>
        ///  DifyWebClient实例
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="apikey">apikey</param>
        public DifyApiClientBase(string url, string apikey)
        {
            Url = url;
            ApiKey = apikey;
            Instance = this;
        }

        private string url = string.Empty;
        /// <summary>
        /// api地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set
            {
                url = GetServerUrl(value);
            }
        }

        /// <summary>
        /// ApiKey
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// 可观察序列 数据流返回的结果
        /// </summary>
        public IObservable<string> AllWebStreamDataReceived => _allWebStreamDataReceived.AsObservable();

        /// <summary>
        /// 
        /// </summary>
        private readonly Subject<string> _allWebStreamDataReceived = new Subject<string>();

        /// <summary>
        /// 返回 App 输出的流式块
        /// </summary>
        public IObservable<SSEEventResponseBase> ObservChunkChatReceived => _observChunkChatReceived.AsObservable();
        private readonly Subject<SSEEventResponseBase> _observChunkChatReceived = new Subject<SSEEventResponseBase>();

        /// <summary>
        /// 事件处理器
        /// </summary>
        public event EventHandler<string> AllEventResponseReceived = delegate { };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        private void OnAllEventResponseReceived(string response)
        {
            this.AllEventResponseReceived?.Invoke(this, response);
        }
        /// <summary>
        ///返回 App 输出的流式块 事件处理器
        /// </summary>
        public event EventHandler<SSEEventResponseBase> EventChunkChatReceived = delegate { };
        private void OnChunkChatReceived(SSEEventResponseBase chunkChatCompletionResponse)
        {
            this.EventChunkChatReceived?.Invoke(this, chunkChatCompletionResponse);
        }




        ///// <summary>
        ///// 允许html敏感字符串
        ///// </summary>
        //public static JsonSerializerOptions UnsafeJsonSerializerOptions { get; set; } = new JsonSerializerOptions()
        //{
        //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //    WriteIndented = true,
        //    DefaultIgnoreCondition= JsonIgnoreCondition.WhenWritingNull,
        //    PropertyNameCaseInsensitive = true

        //};
        /// <summary>
        /// json选项设置
        /// </summary>
        public static JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions()
        {

            //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Default,
            WriteIndented = true,
            //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            MaxDepth = int.MaxValue,
        };

        private bool useUnsafeRelaxedJsonEscaping = false;
        /// <summary>
        /// 使用对编码内容不太严格的内置 JavaScript 编码器实例
        /// </summary>
        public bool UseUnsafeRelaxedJsonEscaping
        {
            get { return useUnsafeRelaxedJsonEscaping; }
            set
            {
                if (value)
                {
                    JsonSerializerOptions = new JsonSerializerOptions()
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        WriteIndented = true,
                        // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        PropertyNameCaseInsensitive = true,
                        MaxDepth = int.MaxValue,
                    };
                }
                else
                {
                    JsonSerializerOptions = new JsonSerializerOptions()
                    {
                        // Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        WriteIndented = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.Always,
                        PropertyNameCaseInsensitive = true,
                        MaxDepth = int.MaxValue,
                    };

                }

                useUnsafeRelaxedJsonEscaping = value;
            }
        }

        /// <summary>
        /// 真实请求的body的记录，只是记录，不携带这个请求
        /// </summary>
        public string RealRequestBody { get; set; } = string.Empty;

        /// <summary>
        /// 真实请求的URL的记录，只是记录，不携带这个请求
        /// </summary>
        public string RealRequestUrl { get; set; } = string.Empty;
        /// <summary>
        /// 真实请求的FormData的记录,只是记录，不携带这个请求
        /// </summary>
        public MultipartFormDataContent? RealRequesFormData { get; set; } = new MultipartFormDataContent();

        /// <summary>
        /// 
        /// </summary>
        public HttpClient? httpClient;

        /// <summary>
        /// 
        /// </summary>

        public HttpResponseMessage? httpResponseMessage;

        /// <summary>
        /// 
        /// </summary>
        public Encoding EncodingDefault { get; set; } =Encoding.UTF8;
        /// <summary>
        /// 异步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="postData"></param>
        /// <param name="queryParameters"></param>
        /// <param name="streamResponse"></param>
        /// <param name="ApiType"></param>
        /// <param name="multipartFormData"></param>
        /// <returns></returns>
        public virtual async Task<Byte[]> SendRequestAsByteAsync(string url, HttpMethod method, object? postData = null, Dictionary<string, string>? queryParameters = null, bool streamResponse = false, string ApiType = "", MultipartFormDataContent? multipartFormData = null)
        {
            RealRequestBody = string.Empty;
            //string content = string.Empty;
            //Byte[]? bytes = null;

            using (httpClient = new HttpClient())
            {
                // if (!string.IsNullOrEmpty(ApiKey))
                //{
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);
                // }
                // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Set the timeout for the request
                httpClient.Timeout = TimeSpan.FromMilliseconds(RequestTimeoutMilliseconds);

                Uri? RequestUri;
                if (queryParameters != null && queryParameters.Count > 0)
                {
                    RequestUri = new Uri(url + "?" + CreateQueryString(queryParameters)); // 设置请求的 URI  
                }
                else
                {
                    RequestUri = new Uri(url); // 设置请求的 URI  
                }

                RealRequestUrl = RequestUri.ToString();
                // Create the request message
                var request = new HttpRequestMessage(method, RequestUri);


                // Set the request content if postData is provided
                //if (!string.IsNullOrEmpty(postData))


                if (postData != null)
                {
                    Type type = postData.GetType();
                    string json = string.Empty;
                    if (type != null && "String".Equals(type.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        json = postData.ToString()!;
                    }
                    else
                    {
                        json = System.Text.Json.JsonSerializer.Serialize(postData, JsonSerializerOptions);
                    }


                    RealRequestBody = json;
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                }

                if (multipartFormData != null)
                {
                    RealRequesFormData = multipartFormData;
                    request.Content = multipartFormData;
                }
                //try
                //{

                // Send the request and get the response
                using (var response = await httpClient.SendAsync(request, streamResponse ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead))
                {
                    // response.EnsureSuccessStatusCode();

                    if (streamResponse)
                    {
                        StringBuilder streamcontent = new StringBuilder();
                        // Get the response stream
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        using (var streamReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                        {
                            string? line;
                            while ((line = await streamReader.ReadLineAsync()) != null)
                            {
                                streamcontent.AppendLine(line);

                                if (UseUnsafeRelaxedJsonEscaping)
                                {

                                    string resline = CommonHelper.DecodeJson(line);
                                    line = resline;


                                }
                                ProcessServerSentEventsData(line, ApiType);

                            }
                        }

                        // content = streamcontent.ToString();
                        httpResponseMessage = response;
                        return EncodingDefault.GetBytes(streamcontent.ToString());
                    }
                    else
                    {
                        // Get the full response content
                        byte[] responseByte = await response.Content.ReadAsByteArrayAsync();
                        httpResponseMessage = response;
                        return responseByte;

                        //content = Encoding.UTF8.GetString(responseByte);

                        //if (UseUnsafeRelaxedJsonEscaping)
                        //{
                        //    //string readableString = System.Text.RegularExpressions.Regex.Unescape(content);
                        //    string readableString = CommonHelper.DecodeJson(content);
                        //    content = readableString;
                        //}






                        // Console.WriteLine(content);
                    }

                }
                // }
                //catch (Exception ex)
                //{
                //    content = ex.Message;
                //    //throw ;
                //}
                //return Encoding.UTF8.GetBytes(content);
            }
        }

        /// <summary>
        /// SendRequestByFormDataAsync
        /// </summary>
        /// <param name="url"></param>
        /// <param name="multipartFormData"></param>
        /// <param name="method"></param>
        /// <param name="queryParameters"></param>
        /// <param name="streamResponse"></param>
        /// <param name="ApiType"></param>
        /// <returns></returns>
        public virtual async Task<string> SendRequestByFormDataAsync(string url, MultipartFormDataContent? multipartFormData = null, HttpMethod? method = null, Dictionary<string, string>? queryParameters = null, bool streamResponse = false, string ApiType = "")
        {
            method = method ?? HttpMethod.Post;
            return await SendRequestAsync(url, method, null, queryParameters, streamResponse, ApiType, multipartFormData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="postData"></param>
        /// <param name="queryParameters"></param>
        /// <param name="streamResponse"></param>
        /// <param name="ApiType"></param>
        /// <param name="multipartFormData"></param>
        /// <returns></returns>
        public virtual async Task<string> SendRequestAsync(string url, HttpMethod method, object? postData = null, Dictionary<string, string>? queryParameters = null, bool streamResponse = false, string ApiType = "", MultipartFormDataContent? multipartFormData = null)
        {

            string responsecontent = string.Empty;
            try
            {
                Byte[] bytes = await SendRequestAsByteAsync(url, method, postData, queryParameters, streamResponse, ApiType, multipartFormData);
                responsecontent = EncodingDefault.GetString(bytes);
                if (UseUnsafeRelaxedJsonEscaping)
                {
                    responsecontent = CommonHelper.DecodeJson(responsecontent);
                }
            }
            catch (Exception ex)
            {
                responsecontent = ex.Message;
                // throw;
            }
            return responsecontent;
        }
        /// <summary>
        /// SSE返回数据处理
        /// </summary>
        /// <param name="ChunknResponse"></param>
        /// <param name="ApiType"></param>
        public virtual void ProcessServerSentEventsData(string ChunknResponse, string ApiType = "")
        {

            if (string.IsNullOrWhiteSpace(ChunknResponse)) { return; }
            _allWebStreamDataReceived.OnNext(ChunknResponse);
            OnAllEventResponseReceived(ChunknResponse);
            SSEEventResponseBase chunkChatResponseBase = new SSEEventResponseBase();
            //if ("chat-messages".Equals(ApiType, StringComparison.OrdinalIgnoreCase))
            {

                string chunkjson = CommonHelper.RemoveDataPrefix(ChunknResponse);
                if (UseUnsafeRelaxedJsonEscaping)
                {
                    chunkjson = CommonHelper.DecodeJson(chunkjson);
                }
                try
                {
                    JsonNode jsonNode = JsonNode.Parse(chunkjson)!;
                    string chunkevent = jsonNode!["event"]!.GetValue<string>();
                    /*1.event: message LLM 返回文本块事件，即：完整的文本以分块的方式输出。*/
                    if ("message".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageEventResponse messageChunkResponse = new MessageEventResponse();
                        messageChunkResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = messageChunkResponse;

                    }

                    /*2.event: message_file 文件事件，表示有新文件需要展示*/
                    if ("message_file".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageFileEventResponse messageFileEventResponse = new MessageFileEventResponse();
                        messageFileEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = messageFileEventResponse;
                    }

                    /*3.event: message_end 消息结束事件，收到此事件则代表流式返回结束*/
                    if ("message_end".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageEndEventResponse messageEndChunkResponse = new MessageEndEventResponse();
                        messageEndChunkResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = messageEndChunkResponse;
                    }

                    /*4.event: tts_message TTS 音频流事件，即：语音合成输出。内容是Mp3格式的音频块，使用 base64 编码后的字符串，播放的时候直接解码即可。(开启自动播放才有此消息)*/
                    if ("tts_message".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        TtsMessageEventResponse ttsMessageResponse = new TtsMessageEventResponse();
                        ttsMessageResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = ttsMessageResponse;
                    }

                    /*5.event: tts_message_end TTS 音频流结束事件，收到这个事件表示音频流返回结束。*/
                    if ("tts_message_end".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        TtsMessageEndEventResponse ttsMessageEndEventResponse = new TtsMessageEndEventResponse();
                        ttsMessageEndEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = ttsMessageEndEventResponse;
                    }

                    /*6.event: message_replace 消息内容替换事件。 开启内容审查和审查输出内容时，若命中了审查条件，则会通过此事件替换消息内容为预设回复。*/
                    if ("message_replace".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageReplaceEventResponse messageReplaceEventResponse = new MessageReplaceEventResponse();
                        messageReplaceEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = messageReplaceEventResponse;
                    }

                    /*7.event: workflow_started workflow 开始执行*/
                    if ("workflow_started".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        WorkflowStartedEventResponse workflowStartedEventResponse = new WorkflowStartedEventResponse();
                        workflowStartedEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = workflowStartedEventResponse;
                    }

                    /*8.event: node_started node 开始执行*/
                    if ("node_started".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        NodeStartedEventResponse nodeStartedEventResponse = new NodeStartedEventResponse();
                        nodeStartedEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = nodeStartedEventResponse;
                    }

                    /*9.event: node_finished node 执行结束，成功失败同一事件中不同状态*/
                    if ("node_finished".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        NodeFinishedEventResponse nodeFinishedEventResponse = new NodeFinishedEventResponse();
                        nodeFinishedEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = nodeFinishedEventResponse;
                    }

                    /*10.event: workflow_finished workflow 执行结束，成功失败同一事件中不同状态*/
                    if ("workflow_finished".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        WorkflowFinishedEventResponse workflowFinishedEventResponse = new WorkflowFinishedEventResponse();
                        workflowFinishedEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = workflowFinishedEventResponse;
                    }

                    /*11.event: error 流式输出过程中出现的异常会以 stream event 形式输出，收到异常事件后即结束*/
                    if ("error".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        ErrorEventResponse errorEventResponse = new ErrorEventResponse();
                        errorEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = errorEventResponse;
                    }

                    /*12.event: ping 每 10s 一次的 ping 事件，保持连接存活*/
                    if ("ping".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        PingEventResponse pingEventResponse = new PingEventResponse();
                        pingEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = pingEventResponse;
                    }

                    /*text_chunk*/
                    if ("text_chunk".Equals(chunkevent, StringComparison.OrdinalIgnoreCase))
                    {
                        TextChunkEventResponse textChunkEventResponse = new TextChunkEventResponse();
                        textChunkEventResponse.RealJsonstring = chunkjson;
                        chunkChatResponseBase = textChunkEventResponse;
                    }



                }
                catch (Exception) { chunkChatResponseBase.RealJsonstring = chunkjson; }





            }

            _observChunkChatReceived.OnNext(chunkChatResponseBase);
            OnChunkChatReceived(chunkChatResponseBase);

        }
        ///// <summary>
        ///// 同步请求
        ///// </summary>
        ///// <param name="url"></param>
        ///// <param name="method"></param>
        ///// <param name="postData"></param>
        ///// <param name="queryParameters"></param>
        ///// <param name="streamResponse"></param>
        ///// <returns></returns>

        // public virtual string SendRequest(string url, HttpMethod method, object? postData = null, Dictionary<string, string>? queryParameters = null, bool streamResponse = false)
        // {
        //     string content = string.Empty;
        //     Task<string> task = SendRequestAsync(url, method, postData, queryParameters, streamResponse);
        //     task.Wait();
        //     content= task.Result;
        //     return content;
        // }

        /// <summary>
        /// 创建 Query 参数的字符串表示形式
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        // 创建 Query 参数的字符串表示形式
        public string CreateQueryString(Dictionary<string, string> parameters)
        {
            StringBuilder queryString = new StringBuilder();
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                if (queryString.Length > 0)
                {
                    queryString.Append("&");
                }
                queryString.Append(parameter.Key).Append("=").Append(WebUtility.UrlEncode(parameter.Value));
            }
            return queryString.ToString();
        }

        /// <summary>
        /// url地址补充/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetServerUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            try
            {
                if (!url.EndsWith("/"))
                {
                    return url + "/";
                }
            }
            catch (Exception)
            {

                //throw;
            }

            return url;
        }

        /******************公共访问api**************************************************************************************************************************/
        #region 公共方法


        /// <summary>
        ///异步 上传文件 上传文件并在发送消息时使用，可实现图文多模态理解。 支持您的应用程序所支持的所有格式。 上传的文件仅供当前终端用户使用。
        ///Async  Upload a file for use when sending messages, enabling multimodal understanding of images and text. Supports any formats that are supported by your application. Uploaded files are for use by the current end-user only.
        /// </summary>
        /// <param name="filebytes">要上传的文件</param>
        /// <param name="filename">文件名</param>
        /// <param name="user">用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。</param>
        /// <returns></returns>
        public virtual async Task<FileUploadResponse> FileUploadAsync(Byte[] filebytes, string filename, string user = "")
        {

            // string requestjson = System.Text.Json.JsonSerializer.Serialize(createDocumentByFileRequest, JsonSerializerOptions);
            string url = Url + "files/upload";

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            if (!string.IsNullOrWhiteSpace(user))
            {
                multipartFormDataContent.Add(new StringContent(user), "user");
            }
            var fileContent = new ByteArrayContent(filebytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            multipartFormDataContent.Add(fileContent, "file", filename);
            string resjosn = await SendRequestByFormDataAsync(url, multipartFormDataContent);

            FileUploadResponse fileUploadResponse = new FileUploadResponse();
            fileUploadResponse.RealJsonstring = resjosn;
            return fileUploadResponse;
        }

        /// <summary>
        /// 上传文件 上传文件并在发送消息时使用，可实现图文多模态理解。 支持您的应用程序所支持的所有格式。 上传的文件仅供当前终端用户使用。
        /// Upload a file for use when sending messages, enabling multimodal understanding of images and text. Supports any formats that are supported by your application. Uploaded files are for use by the current end-user only.
        /// </summary>
        /// <param name="filebytes">要上传的文件</param>
        /// <param name="filename">文件名</param>
        /// <param name="user">用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。</param>
        /// <returns></returns>
        public virtual FileUploadResponse FileUpload(Byte[] filebytes, string filename, string user = "")
        {

            Task<FileUploadResponse> task = FileUploadAsync(filebytes, filename, user);
            task.Wait();
            return task.Result;
        }

       
      


        /// <summary>
        /// 获取应用基本信息异步
        /// Get Application Basic Information Async
        /// </summary>
        /// <returns></returns>
        public virtual async Task<GetInfoResponse> GetInfoAsync()
        {
            string url = Url + "info";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetInfoResponse response = new GetInfoResponse();
            response.RealJsonstring = resjosn;
            return response;
        }

        /// <summary>
        /// 获取应用基本信息
        /// Get Application Basic Information
        /// </summary>
        /// <returns></returns>
        public virtual GetInfoResponse GetInfo()
        {
            Task<GetInfoResponse> task = GetInfoAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取应用参数异步 用于进入页面一开始，获取功能开关、输入参数名称、类型及默认值等使用。
        /// Get Application Async; Parameters Information Used at the start of entering the page to obtain information such as features, input parameter names, types, and default values.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<GetParametersResponse> GetParametersAsync()
        {
            string url = Url + "parameters";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetParametersResponse response = new GetParametersResponse();
            response.RealJsonstring = resjosn;
            return response;
        }
        /// <summary>
        /// 获取应用参数 用于进入页面一开始，获取功能开关、输入参数名称、类型及默认值等使用。
        /// Get Application Parameters Information Used at the start of entering the page to obtain information such as features, input parameter names, types, and default values.
        /// </summary>
        /// <returns></returns>
        public virtual GetParametersResponse GetParameters()
        {
            Task<GetParametersResponse> task = GetParametersAsync();
            task.Wait();
            return task.Result;
        }

        #endregion

        // IDisposable implementation
        private bool disposed = false;
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (disposing)
                {

                    // 释放托管资源
                    _allWebStreamDataReceived?.Dispose();
                    _observChunkChatReceived?.Dispose();
                    httpClient?.Dispose();
                    httpResponseMessage?.Dispose();
                    // 移除事件处理程序
                    if (AllEventResponseReceived != null)
                    {
                        foreach (Delegate d in AllEventResponseReceived.GetInvocationList())
                        {
                            AllEventResponseReceived -= (EventHandler<string>)d;
                        }
                    }

                    if (EventChunkChatReceived != null)
                    {
                        foreach (Delegate d in EventChunkChatReceived.GetInvocationList())
                        {
                            EventChunkChatReceived -= (EventHandler<SSEEventResponseBase>)d;
                        }
                    }

                    // 清空所有字段
                    Url = string.Empty;
                    ApiKey = string.Empty;
                    Instance = null;
                    RealRequestBody = string.Empty;
                    useUnsafeRelaxedJsonEscaping = false;
                }
                // 释放非托管资源（如果有的话）
                disposed = true;
            }
        }
        /// <summary>
        /// ~符号用于定义类的析构函数（destructor）,当垃圾回收器（garbage collector）决定释放对象时，会调用这个方法。析构函数用于执行清理操作
        /// </summary>
        ~DifyApiClientBase()
        {
            Dispose(false);
        }
    }
}
