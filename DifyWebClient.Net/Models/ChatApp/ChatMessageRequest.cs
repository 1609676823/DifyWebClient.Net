using DifyWebClient.Net.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 发送聊天消息请求模型
    /// Send a request to the chat application.
    /// </summary>
    public class ChatMessageRequest
    {
        /// <summary>
        /// 发送聊天消息请求模型
        /// Send a request to the chat application.
        /// </summary>

        public ChatMessageRequest() { }
        /// <summary>
        /// 发送聊天消息请求模型
        /// Send a request to the chat application.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="conversation_id"></param>
        /// <param name="user"></param>
        /// <param name="response_mode"></param>
        public ChatMessageRequest(string query,string conversation_id, string user, string response_mode)
        {
            this.query = query;
            this.conversation_id = conversation_id;
            this.user = user;
            this.response_mode = response_mode;

        }
        /// <summary>
        /// 发送聊天消息请求模型
        /// </summary>
        /// <param name="query"></param>
        /// <param name="user"></param>
        /// <param name="response_mode"></param>
        public ChatMessageRequest(string query,string user, string response_mode)
        {
            this.query = query;
            this.conversation_id = conversation_id;
            this.user = user;
            this.response_mode = response_mode;

        }

        /// <summary>
        /// 发送聊天消息请求模型
        /// Send a request to the chat application.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="response_mode"></param>
        /// 
        public ChatMessageRequest(string query,string response_mode = ResponseMode.Blocking)
        {
            this.query = query;
            this.response_mode = response_mode;
        }
        /// <summary>
        /// 允许传入 App 定义的各变量值。inputs 参数包含了多组键值对（Key/Value pairs），每组的键对应一个特定变量，每组的值则是该变量的具体值。
        /// Allows the entry of various variable values defined by the App. The inputs parameter contains multiple key/value pairs, with each key corresponding to a specific variable and each value being the specific value for that variable. Default {}
        /// </summary>
        public Dictionary<string, object> inputs { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 用户输入/提问内容。
        /// User Input/Question content.
        /// </summary>
        public string query { get; set; } = string.Empty;

        /// <summary>
        /// 请求响应模式：
        /// streaming: 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回。
        /// blocking: 阻塞模式，等待执行完毕后返回结果。（请求若流程较长可能会被中断）。
        /// The mode of response return, supporting:
        /// streaming Streaming mode (recommended), implements a typewriter-like output through SSE (Server-Sent Events).
        /// blocking Blocking mode, returns result after execution is complete. (Requests may be interrupted if the process is long) Due to Cloudflare restrictions, the request will be interrupted without a return after 100 seconds. Note: blocking mode is not supported in Agent Assistant mode.
        /// </summary>
        public string response_mode { get; set; } = ResponseMode.Blocking;

        /// <summary>
        /// （选填）会话 ID，需要基于之前的聊天记录继续对话，必须传之前消息的 conversation_id。
        /// Conversation ID, to continue the conversation based on previous chat records, it is necessary to pass the previous message's conversation_id.
        /// </summary>
        public string conversation_id { get; set; } = string.Empty;

        /// <summary>
        /// 用户标识，用于定义终端用户的身份，方便检索、统计。由开发者定义规则，需保证用户标识在应用内唯一。
        /// User identifier, used to define the identity of the end-user for retrieval and statistics. Should be uniquely defined by the developer within the application.
        /// </summary>
        public string user { get; set; } = "user";

        /// <summary>
        /// （选填）自动生成标题，默认 true。 若设置为 false，则可通过调用会话重命名接口并设置 auto_generate 为 true 实现异步生成标题。
        /// Auto-generate title, default is true. If set to false, can achieve async title generation by calling the conversation rename API and setting auto_generate to true
        /// </summary>
        public bool auto_generate_name { get; set; } = true;
        /// <summary>
        /// 上传的文件。
        /// File list, suitable for inputting files (images) combined with text understanding and answering questions, available only when the model supports Vision capability.
        /// </summary>
        public List<FileModel>? files { get; set; } = null;
    }

    /// <summary>
    /// 文件模型
    /// File model
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// 支持类型：图片 image（目前仅支持图片格式）
        /// Supported type: image (currently only supports image type)
        /// </summary>
        public string type { get; set; } = string.Empty;

        /// <summary>
        /// 传递方式:
        /// remote_url: 图片地址。
        /// local_file: 上传文件。
        /// Transfer method:
        /// remote_url for image URL.
        /// local_file for file upload.
        /// </summary>
        public string transfer_method { get; set; } = string.Empty;

        /// <summary>
        /// 图片地址。（仅当传递方式为 remote_url 时）
        /// Image URL (when the transfer method is remote_url)
        /// </summary>
        public string url { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件 ID。（仅当传递方式为 local_file 时）
        /// Uploaded file ID, which must be obtained by uploading through the File Upload API in advance (when the transfer method is local_file)
        /// </summary>
        public string upload_file_id { get; set; } = string.Empty;
    }

}