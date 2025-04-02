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
    /// metadata (object) 元数据
    /// metadata (object) Metadata
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// 模型用量信息
        /// Model usage information
        /// </summary>
        public Usage usage { get; set; } = new Usage();

        /// <summary>
        /// 引用和归属分段列表
        /// Citation and Attribution List
        /// </summary>
        public List<RetrieverResource> retriever_resources { get; set; } = new List<RetrieverResource>();
    }

}
