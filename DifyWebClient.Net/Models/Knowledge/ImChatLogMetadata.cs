using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 即时通讯记录 Chat log
    /// </summary>
    public class ImChatLogMetadata : DocMetadata
    {
        /// <summary>
        /// 聊天平台
        /// Chat platform of the IM chat log
        /// </summary>
        public string ChatPlatform { get; set; } = string.Empty;

        /// <summary>
        /// 聊天参与者/群组名称
        /// Chat participants or group name
        /// </summary>
        public string ChatParticipantsGroupName { get; set; } = string.Empty;

        /// <summary>
        /// 开始日期
        /// Start date of the IM chat log
        /// </summary>
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// 结束日期
        /// End date of the IM chat log
        /// </summary>
        public string EndDate { get; set; } = string.Empty;

        /// <summary>
        /// 摘要
        /// Summary of the IM chat log
        /// </summary>
        public string Summary { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public ImChatLogMetadata() { }
    }
}
