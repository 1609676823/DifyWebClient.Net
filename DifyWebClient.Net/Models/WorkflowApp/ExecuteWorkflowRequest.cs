using DifyWebClient.Net.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.WorkflowApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006


    /// <summary>
    /// 执行工作流的请求类
    /// Request class for executing a workflow
    /// </summary>
    public class ExecuteWorkflowRequest
    {
        /// <summary>
        /// 执行工作流的请求类
        /// Request class for executing a workflow
        /// </summary>
        public ExecuteWorkflowRequest() { }
        /// <summary>
        /// 执行工作流的请求类
        /// Request class for executing a workflow
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="user"></param>
        /// <param name="response_mode">streaming: 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回。 - blocking: 阻塞模式，等待执行完毕后返回结果。（请求若流程较长可能会被中断）。</param> 
        public ExecuteWorkflowRequest(Dictionary<string, object> inputs, string user="user",string response_mode= ResponseMode.Blocking)
        { 
            this.inputs= inputs;
            this.user= user;
            this.response_mode= response_mode;
        }
        /// <summary>
        /// 必需参数，允许传入 App 定义的各变量值。
        /// 该参数包含了多组键值对（Key/Value pairs），每组的键对应一个特定变量，每组的值则是该变量的具体值。
        /// 变量可以是文件列表类型。文件列表类型变量适用于传入文件结合文本理解并回答问题，
        /// 仅当模型支持该类型文件解析能力时可用。
        /// Required. Allows passing in values for various variables defined in the App.
        /// This parameter contains multiple key-value pairs. Each key corresponds to a specific variable,
        /// and each value is the specific value of that variable.
        /// Variables can be of the file list type. File list type variables are used for passing in files
        /// to combine with text understanding and answer questions, and are only available when the model
        /// supports the parsing ability of that file type.
        /// </summary>
        public Dictionary<string, object>? inputs { get; set; }

        /// <summary>
        /// 必需参数，返回响应模式。
        /// 支持的模式有：
        /// - streaming: 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回。
        /// - blocking: 阻塞模式，等待执行完毕后返回结果。（请求若流程较长可能会被中断）。
        /// 由于 Cloudflare 限制，请求会在 100 秒超时无返回后中断。
        /// Required. Response mode.
        /// Supported modes are:
        /// - streaming: Streaming mode (recommended). Based on SSE (Server-Sent Events), it provides a streaming
        ///              response similar to a typewriter output.
        /// - blocking: Blocking mode, returns the result after the execution is completed. (The request may be
        ///             interrupted if the process is long). Due to Cloudflare restrictions, the request will
        ///             be interrupted after a 100-second timeout with no response.
        /// </summary>
        public string? response_mode { get; set; }=ResponseMode.Blocking;

        /// <summary>
        /// 必需参数，用户标识，用于定义终端用户的身份，方便检索、统计。
        /// 由开发者定义规则，需保证用户标识在应用内唯一。
        /// Required. User identifier, used to define the identity of the end - user for easy retrieval and statistics.
        /// The rules are defined by the developer, and the user identifier must be unique within the application.
        /// </summary>
        public string? user { get; set; } = "user";
    }

    /// <summary>
    /// 文件列表类型变量的元素类
    /// Element class for file list type variables
    /// </summary>
    public class FileListElement
    {
        /// <summary>
        /// 文件列表类型变量的元素类
        /// Element class for file list type variables
        /// </summary>
        public FileListElement() { }
        /// <summary>
        /// 文件列表类型变量的元素类
        /// Element class for file list type variables
        /// </summary>
        /// <param name="upload_file_id"></param>
        /// <param name="type"></param>
        /// <param name="transfer_method"></param>
        /// <param name="url"></param>
        public FileListElement(string upload_file_id,string type= FilesType.Document,string transfer_method= TransferMethod.LocalFile,string? url=null) 
        {
            this.upload_file_id=upload_file_id;
            this.type=type;
            this.transfer_method=transfer_method;
            this.url=url;
        }
        /// <summary>
        /// 文件类型。
        /// 支持的类型有：
        /// - document: 具体类型包含 'TXT', 'MD', 'MARKDOWN', 'PDF', 'HTML', 'XLSX', 'XLS', 'DOCX', 'CSV', 'EML', 'MSG', 'PPTX', 'PPT', 'XML', 'EPUB'
        /// - image: 具体类型包含 'JPG', 'JPEG', 'PNG', 'GIF', 'WEBP', 'SVG'
        /// - audio: 具体类型包含 'MP3', 'M4A', 'WAV', 'WEBM', 'AMR'
        /// - video: 具体类型包含 'MP4', 'MOV', 'MPEG', 'MPGA'
        /// - custom: 具体类型包含其他文件类型
        /// File type.
        /// Supported types are:
        /// - document: Specific types include 'TXT', 'MD', 'MARKDOWN', 'PDF', 'HTML', 'XLSX', 'XLS', 'DOCX', 'CSV', 'EML', 'MSG', 'PPTX', 'PPT', 'XML', 'EPUB'
        /// - image: Specific types include 'JPG', 'JPEG', 'PNG', 'GIF', 'WEBP', 'SVG'
        /// - audio: Specific types include 'MP3', 'M4A', 'WAV', 'WEBM', 'AMR'
        /// - video: Specific types include 'MP4', 'MOV', 'MPEG', 'MPGA'
        /// - custom: Specific types include other file types
        /// </summary>
        public string? type { get; set; } = FilesType.Document;

        /// <summary>
        /// 文件传递方式。
        /// 支持的方式有：
        /// - remote_url: 通过图片地址传递
        /// - local_file: 通过上传文件传递
        /// File transfer method.
        /// Supported methods are:
        /// - remote_url: Transfer via image URL
        /// - local_file: Transfer via uploading a file
        /// </summary>
        public string? transfer_method { get; set; } = TransferMethod.LocalFile;

        /// <summary>
        /// 图片地址，仅当传递方式为 remote_url 时使用
        /// Image URL, used only when the transfer method is 'remote_url'
        /// </summary>
        public string? url { get; set; }

        /// <summary>
        /// 上传文件 ID，仅当传递方式为 local_file 时使用
        /// Uploaded file ID, used only when the transfer method is 'local_file'
        /// </summary>
        public string? upload_file_id { get; set; }
    }
}