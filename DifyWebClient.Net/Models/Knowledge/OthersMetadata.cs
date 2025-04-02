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
    /// 其他文档类型 Other document types
    /// </summary>
    public class OthersMetadata : DocMetadata
    {
        /// <summary>
        /// 数据
        /// Data of other types
        /// </summary>
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public OthersMetadata() { }
    }
}
