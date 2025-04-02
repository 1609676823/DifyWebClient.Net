using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 响应返回模式支持
    /// The mode of response return, supporting
    /// </summary>
    public static class ResponseMode
    {
        /// <summary>
        /// 流式模式（推荐）。基于 SSE（Server-Sent Events）实现类似打字机输出方式的流式返回。
        /// Streaming mode (recommended), implements a typewriter-like output through SSE (Server-Sent Events)
        /// </summary>
        public const string Streaming = "streaming";
        /// <summary>
        ///  阻塞模式，等待执行完毕后返回结果。（请求若流程较长可能会被中断）。 由于 Cloudflare 限制，请求会在 100 秒超时无返回后中断。 注：Agent模式下不允许blocking。
        /// Blocking mode, returns result after execution is complete. (Requests may be interrupted if the process is long) Due to Cloudflare restrictions, the request will be interrupted without a return after 100 seconds. Note: blocking mode is not supported in Agent Assistant mode
        /// </summary>
        public const string Blocking = "blocking";

    }
}
