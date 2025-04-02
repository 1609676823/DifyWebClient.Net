using DifyWebClient.Net.Enum;
using DifyWebClient.Net.Models;
using DifyWebClient.Net.Models.ChatApp;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DifyWebClient.Net.ApiClients
{
    /// <summary>
    /// 对话型应用 API 管理器
    /// Chat App API
    /// </summary>
    public class ChatAppWebClient: DifyApiClientBase
    {
        /// <summary>
        /// 对话型应用 API 管理器
        /// Chat App API
        /// </summary>
        public ChatAppWebClient() : base() { }
        /// <summary>
        /// 对话型应用 API 管理器
        /// Chat App API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="apikey"></param>
        public ChatAppWebClient(string url, string apikey) : base(url, apikey)
        {

        }

        /// <summary>
        /// 创建会话消息异步。
        /// Send a request to the chat application.
        /// </summary>
        /// <param name="sendChatMessageRequestModel"></param>
        public async Task<ChatCompletionResponse> SendChatMessageAsync(ChatMessageRequest sendChatMessageRequestModel) 
        { 
            string requestjson= System.Text.Json.JsonSerializer.Serialize(sendChatMessageRequestModel,JsonSerializerOptions);
            string url = Url + "chat-messages";
            bool streamResponse = false;
            if (ResponseMode.Streaming.Equals(sendChatMessageRequestModel.response_mode,StringComparison.OrdinalIgnoreCase))
            {
                streamResponse=true;
            }
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson, null, streamResponse,"chat-messages");
            ChatCompletionResponse chatCompletionResponse = new ChatCompletionResponse();
            chatCompletionResponse.RealJsonstring = resjosn;
            return chatCompletionResponse;
        }
        /// <summary>
        /// 创建会话消息。
        /// Send a request to the chat application.
        /// </summary>
        /// <param name="sendChatMessageRequestModel"></param>
        /// <returns></returns>
        public ChatCompletionResponse SendChatMessage(ChatMessageRequest sendChatMessageRequestModel)
        {

            Task<ChatCompletionResponse> task = SendChatMessageAsync(sendChatMessageRequestModel);
            task.Wait();
            return task.Result;
        }

        #region 上传文件，放到base类

       
        ///// <summary>
        /////异步 上传文件 上传文件并在发送消息时使用，可实现图文多模态理解。 支持您的应用程序所支持的所有格式。 上传的文件仅供当前终端用户使用。
        /////Async  Upload a file for use when sending messages, enabling multimodal understanding of images and text. Supports any formats that are supported by your application. Uploaded files are for use by the current end-user only.
        ///// </summary>
        ///// <param name="filebytes">要上传的文件</param>
        ///// <param name="filename">文件名</param>
        ///// <param name="user">用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。</param>
        ///// <returns></returns>
        //public async Task<FileUploadResponse> FileUploadAsync(Byte[] filebytes, string filename,string user="")
        //{
          
        //   // string requestjson = System.Text.Json.JsonSerializer.Serialize(createDocumentByFileRequest, JsonSerializerOptions);
        //    string url = Url + "files/upload";

        //    MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
        //    if (!string.IsNullOrWhiteSpace(user)) 
        //    {
        //        multipartFormDataContent.Add(new StringContent(user), "user");
        //    }
        //    var fileContent = new ByteArrayContent(filebytes);
        //    fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
        //    multipartFormDataContent.Add(fileContent, "file", filename);
        //    string resjosn = await SendRequestByFormDataAsync(url, multipartFormDataContent);

        //    FileUploadResponse fileUploadResponse = new FileUploadResponse();
        //    fileUploadResponse.RealJsonstring = resjosn;
        //    return fileUploadResponse;
        //}

        ///// <summary>
        ///// 上传文件 上传文件并在发送消息时使用，可实现图文多模态理解。 支持您的应用程序所支持的所有格式。 上传的文件仅供当前终端用户使用。
        ///// Upload a file for use when sending messages, enabling multimodal understanding of images and text. Supports any formats that are supported by your application. Uploaded files are for use by the current end-user only.
        ///// </summary>
        ///// <param name="filebytes">要上传的文件</param>
        ///// <param name="filename">文件名</param>
        ///// <param name="user">用户标识，用于定义终端用户的身份，必须和发送消息接口传入 user 保持一致。</param>
        ///// <returns></returns>
        //public FileUploadResponse FileUpload(Byte[] filebytes, string filename, string user = "")
        //{

        //    Task<FileUploadResponse> task = FileUploadAsync(filebytes, filename, user);
        //    task.Wait();
        //    return task.Result;
        //}

        #endregion

        /// <summary>
        /// 停止响应异步 仅支持流式模式。
        /// Stop Generate Async Only supported in streaming mode.
        /// </summary>
        /// <param name="task_id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<CommonResultResponse> StopGenerateAsync(string task_id,string user)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("user", user);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "chat-messages/" + task_id + "/stop";
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
        /// 消息反馈（点赞）异步 消息终端用户反馈、点赞，方便应用开发者优化输出预期。
        /// Message Feedback Async End-users can provide feedback messages, facilitating application developers to optimize expected outputs.
        /// </summary>
        /// <param name="message_id">消息 ID</param>
        /// <param name="rating">点赞 like, 点踩 dislike, 撤销点赞 null / Upvote as like, downvote as dislike, revoke upvote as null</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。/ User identifier, defined by the developer's rules, must be unique within the application.</param>
        /// <param name="content">消息反馈的具体信息。/ The specific content of message feedback.</param>
        /// <returns></returns>
        public async Task<CommonResultResponse> MessageFeedbackAsync(string message_id, string rating,string user,string content="")
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("rating", rating);
            RequestObject.Add("user", user);
            RequestObject.Add("content", content);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "messages/" + message_id + "/feedbacks";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            CommonResultResponse commonResultResponse = new CommonResultResponse();
            commonResultResponse.RealJsonstring = resjosn;
            return commonResultResponse;
        }

        /// <summary>
        /// 消息反馈（点赞）消息终端用户反馈、点赞，方便应用开发者优化输出预期。
        /// Message Feedback End-users can provide feedback messages, facilitating application developers to optimize expected outputs.
        /// </summary>
        /// <param name="message_id">消息 ID</param>
        /// <param name="rating">点赞 like, 点踩 dislike, 撤销点赞 null / Upvote as like, downvote as dislike, revoke upvote as null</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。/ User identifier, defined by the developer's rules, must be unique within the application.</param>
        /// <param name="content">消息反馈的具体信息。/ The specific content of message feedback.</param>
        /// <returns></returns>
        public CommonResultResponse MessageFeedback(string message_id, string rating, string user, string content = "")
        {
            Task<CommonResultResponse> task = MessageFeedbackAsync(message_id, rating, user, content);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取下一轮建议问题列表异步
        /// Get Conversation History Messages Async
        /// </summary>
        /// <param name="message_id">Message ID</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一 / User identifier, used to define the identity of the end-user for retrieval and statistics. Should be uniquely defined by the developer within the application.</param>
        /// <returns></returns>
        public async Task<GetNextSuggestedQuestionsResponse> GetNextSuggestedQuestionsAsync(string message_id, string user)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.Add("user", user); 
            string url = Url + "messages/"+ message_id+ "/suggested";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetNextSuggestedQuestionsResponse response = new GetNextSuggestedQuestionsResponse();
            response.RealJsonstring = resjosn;
            return response;
        }

        /// <summary>
        /// 获取下一轮建议问题列表
        /// Get Conversation History Messages
        /// </summary>
        /// <param name="message_id">Message ID</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一 / User identifier, used to define the identity of the end-user for retrieval and statistics. Should be uniquely defined by the developer within the application.</param>
        /// <returns></returns>

        public GetNextSuggestedQuestionsResponse GetNextSuggestedQuestions(string message_id, string user)
        {
            Task<GetNextSuggestedQuestionsResponse> task = GetNextSuggestedQuestionsAsync(message_id, user);
            task.Wait();
            return task.Result;
        }
        /// <summary>
        /// 获取会话历史消息 异步
        /// Get Conversation History Messages Async
        /// </summary>
        /// <param name="conversation_id">会话 ID</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。</param>
        /// <param name="first_id">当前页第一条聊天记录的 ID，默认 null</param>
        /// <param name="limit">一次请求返回多少条聊天记录，默认 20 条</param>
        /// <returns></returns>
        public async Task<GetConversationHistoryMessagesResponse> GetConversationHistoryMessagesAsync(string conversation_id,string user,string first_id="",long limit=20)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.Add("user", user);
            queryParameters.Add("conversation_id", conversation_id);
            queryParameters.Add("first_id", first_id);
            if (limit >= 0) { queryParameters.Add("limit", limit.ToString()); }
            string url = Url + "messages";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetConversationHistoryMessagesResponse getConversationHistoryMessagesResponse = new GetConversationHistoryMessagesResponse();
            getConversationHistoryMessagesResponse.RealJsonstring = resjosn;
            return getConversationHistoryMessagesResponse;
        }
        /// <summary>
        /// 获取会话历史消息
        /// Get Conversation History Messages
        /// </summary>
        /// <param name="conversation_id">会话 ID</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。</param>
        /// <param name="first_id">当前页第一条聊天记录的 ID，默认 null</param>
        /// <param name="limit">一次请求返回多少条聊天记录，默认 20 条</param>
        /// <returns></returns>
        public GetConversationHistoryMessagesResponse GetConversationHistoryMessages( string conversation_id, string user, string first_id = "", long limit = 20)
        {
            Task<GetConversationHistoryMessagesResponse> task = GetConversationHistoryMessagesAsync(conversation_id, user, first_id, limit);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取会话列表异步 获取当前用户的会话列表，默认返回最近的 20 条。
        /// Get Conversations Async Retrieve the conversation list for the current user, defaulting to the most recent 20 entries.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="last_id"></param>
        /// <param name="limit"></param>
        /// <param name="sort_by"></param>
        /// <returns></returns>
        public async Task<GetConversationsResponse> GetConversationsAsync(string user, string last_id = "", long limit = 20,string sort_by= ConversationsSortBy.UpdatedAtDesc)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.Add("user", user);
            queryParameters.Add("last_id", last_id);
            queryParameters.Add("limit", limit.ToString());
            if (!string.IsNullOrWhiteSpace(sort_by)) {queryParameters.Add("sort_by",sort_by); }
            string url = Url + "conversations";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetConversationsResponse getConversationsResponse = new GetConversationsResponse();
            getConversationsResponse.RealJsonstring = resjosn;
            return getConversationsResponse;
        }

        /// <summary>
        /// 获取会话列表 获取当前用户的会话列表，默认返回最近的 20 条。
        /// Get Conversations Retrieve the conversation list for the current user, defaulting to the most recent 20 entries.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="last_id"></param>
        /// <param name="limit"></param>
        /// <param name="sort_by"></param>
        /// <returns></returns>
        public GetConversationsResponse GetConversations(string user, string last_id = "", long limit = 20, string sort_by = ConversationsSortBy.UpdatedAtDesc)
        {
            Task<GetConversationsResponse> task = GetConversationsAsync(user, last_id, limit, sort_by);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 删除会话异步
        /// Delete Conversation Async
        /// </summary>
        /// <param name="conversation_id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<CommonResultResponse> DeleteConversationAsync(string conversation_id,string user)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("user", user);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "conversations/" + conversation_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Delete, requestjson);
            CommonResultResponse commonResultResponse = new CommonResultResponse();
            commonResultResponse.RealJsonstring = resjosn;
            return commonResultResponse;
        }

        /// <summary>
        /// 删除会话
        /// Delete Conversation
        /// </summary>
        /// <param name="conversation_id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public CommonResultResponse DeleteConversation(string conversation_id, string user)
        {
            Task<CommonResultResponse> task = DeleteConversationAsync(conversation_id, user);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 会话重命名异步;对会话进行重命名，会话名称用于显示在支持多会话的客户端上。
        /// Conversation Rename Async; Rename the session, the session name is used for display on clients that support multiple sessions.
        /// </summary>
        /// <param name="conversation_id"></param>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="auto_generate"></param>
        /// <returns></returns>
        public async Task<ConversationRenameResponse> ConversationRenameAsync(string conversation_id, string name, string user, bool auto_generate=false)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("name", name);
            RequestObject.Add("user", user);
            RequestObject.Add("auto_generate", auto_generate);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "conversations/" + conversation_id + "/name";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            ConversationRenameResponse conversationRenameResponse   = new ConversationRenameResponse();
            conversationRenameResponse.RealJsonstring = resjosn;
            return conversationRenameResponse;
        }

        /// <summary>
        /// 会话重命名 对会话进行重命名，会话名称用于显示在支持多会话的客户端上。
        /// Conversation Rename Rename the session, the session name is used for display on clients that support multiple sessions.
        /// </summary>
        /// <param name="conversation_id"></param>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="auto_generate"></param>
        /// <returns></returns>
        public ConversationRenameResponse ConversationRename(string conversation_id, string name, string user, bool auto_generate = false)
        {
            Task<ConversationRenameResponse> task = ConversationRenameAsync(conversation_id, name, user, auto_generate);
            task.Wait();
            return task.Result;
        }
        /// <summary>
        /// 文字转语音异步
        /// Text to Audio Async
        /// </summary>
        /// <param name="text">语音生成内容。如果没有传 message-id的话，则会使用这个字段的内容</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。</param>
        /// <param name="message_id">Dify 生成的文本消息，那么直接传递生成的message-id 即可，后台会通过 message_id 查找相应的内容直接合成语音信息。如果同时传 message_id 和 text，优先使用 message_id。</param>
        /// <returns></returns>
        public async Task<Byte[]> TextToAudioAsync(string text, string user, string message_id="")
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("message_id", message_id);
            RequestObject.Add("text", text);
            RequestObject.Add("user", user);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "text-to-audio";
            Byte[] bytes = await SendRequestAsByteAsync(url, HttpMethod.Post, requestjson);
            return bytes;
        }

        /// <summary>
        /// 文字转语音
        /// Text to Audio
        /// </summary>
        /// <param name="text">语音生成内容。如果没有传 message-id的话，则会使用这个字段的内容</param>
        /// <param name="user">用户标识，由开发者定义规则，需保证用户标识在应用内唯一。</param>
        /// <param name="message_id">Dify 生成的文本消息，那么直接传递生成的message-id 即可，后台会通过 message_id 查找相应的内容直接合成语音信息。如果同时传 message_id 和 text，优先使用 message_id。</param>
        /// <returns></returns>
        public Byte[] TextToAudio(string text, string user, string message_id = "")
        {
            Task<Byte[]> task = TextToAudioAsync(text, user, message_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 语音转文字异步
        /// Speech to Text Async
        /// </summary>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<AudioToTextResponse> AudioToTextAsync(Byte[] filebytes, string filename)
        {
            string url = Url + "audio-to-text";
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(filebytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(CommonHelper.GetMimeType(filename));
            multipartFormDataContent.Add(fileContent, "file", filename);
            string resjosn = await SendRequestByFormDataAsync(url, multipartFormDataContent);
            AudioToTextResponse audioToTextResponse = new AudioToTextResponse();
            audioToTextResponse.RealJsonstring = resjosn;
            return audioToTextResponse;
        }

        /// <summary>
        /// 语音转文字
        /// Speech to Text
        /// </summary>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public AudioToTextResponse AudioToText(Byte[] filebytes, string filename)
        {
            Task<AudioToTextResponse> task = AudioToTextAsync(filebytes, filename);
            task.Wait();
            return task.Result;
        }

        #region 转移到基对象

       
        ///// <summary>
        ///// 获取应用基本信息异步
        ///// Get Application Basic Information Async
        ///// </summary>
        ///// <returns></returns>
        //public async Task<GetInfoResponse> GetInfoAsync()
        //{
        //    string url = Url + "info";
        //    string resjosn = await SendRequestAsync(url, HttpMethod.Get);
        //    GetInfoResponse response = new GetInfoResponse();
        //    response.RealJsonstring = resjosn;
        //    return response;
        //}

        ///// <summary>
        ///// 获取应用基本信息
        ///// Get Application Basic Information
        ///// </summary>
        ///// <returns></returns>
        //public GetInfoResponse GetInfo()
        //{
        //    Task<GetInfoResponse> task = GetInfoAsync();
        //    task.Wait();
        //    return task.Result;
        //}

        ///// <summary>
        ///// 获取应用参数异步 用于进入页面一开始，获取功能开关、输入参数名称、类型及默认值等使用。
        ///// Get Application Async; Parameters Information Used at the start of entering the page to obtain information such as features, input parameter names, types, and default values.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<GetParametersResponse> GetParametersAsync()
        //{
        //    string url = Url + "parameters";
        //    string resjosn = await SendRequestAsync(url, HttpMethod.Get);
        //    GetParametersResponse response = new GetParametersResponse();
        //    response.RealJsonstring = resjosn;
        //    return response;
        //}
        ///// <summary>
        ///// 获取应用参数 用于进入页面一开始，获取功能开关、输入参数名称、类型及默认值等使用。
        ///// Get Application Parameters Information Used at the start of entering the page to obtain information such as features, input parameter names, types, and default values.
        ///// </summary>
        ///// <returns></returns>
        //public GetParametersResponse GetParameters()
        //{
        //    Task<GetParametersResponse> task = GetParametersAsync();
        //    task.Wait();
        //    return task.Result;
        //}
        #endregion
        /// <summary>
        /// 获取应用Meta信息异步 用于获取工具icon
        /// Get Application Meta Information Async;Used to get icons of tools in this application
        /// </summary>
        /// <returns></returns>
        public async Task<GetMetaResponse> GetMetaAsync()
        {
            string url = Url + "meta";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetMetaResponse response = new GetMetaResponse();
            response.RealJsonstring = resjosn;
            return response;
        }

        /// <summary>
        /// 获取应用Meta信息 用于获取工具icon
        /// Get Application Meta Information;Used to get icons of tools in this application
        /// </summary>
        /// <returns></returns>
        public GetMetaResponse GetMeta()
        {
            Task<GetMetaResponse> task = GetMetaAsync();
            task.Wait();
            return task.Result;
        }

    }
}
