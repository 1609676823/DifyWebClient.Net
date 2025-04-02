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
    /// 更新块请求类
    /// Update chunk request class
    /// </summary>
    public class UpdateChunkRequest
    {
        /// <summary>
        /// 更新块请求类
        /// Update chunk request class
        /// </summary>
        public UpdateChunkRequest() { }
        /// <summary>
        /// 更新块请求类
        /// </summary>
        /// <param name="content">文本内容/问题内容，必填</param>
        /// <param name="answer">答案内容，非必填，如果知识库的模式为 QA 模式则传值</param>
        /// <param name="keywords">关键字，非必填</param>

        public UpdateChunkRequest(string content, string answer = "", List<string>? keywords = null) 
        { 
            this.segment = new UpdateChunkSegment();
            this.segment.content = content;
            this.segment.answer = answer;
            if (keywords == null)
            {
                this.segment.keywords = new List<string>();
            }
            else
            {
                this.segment.keywords = keywords;
            }
        }
        /// <summary>
        /// 分段信息
        /// Segment information
        /// </summary>
        public UpdateChunkSegment? segment { get; set; }=new UpdateChunkSegment(); 
        


    }

    /// <summary>
    /// 更新块分段类
    /// Update chunk segment class
    /// </summary>
    public class UpdateChunkSegment
    {
       
        /// <summary>
        /// 文本内容/问题内容，必填
        /// Text content/Question content, required
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 答案内容，非必填，如果知识库的模式为 QA 模式则传值
        /// Answer content, not required. Pass a value if the knowledge base is in QA mode.
        /// </summary>
        public string? answer { get; set; }

        /// <summary>
        /// 关键字，非必填
        /// Keywords, not required
        /// </summary>
        public List<string>? keywords { get; set; }= new List<string>();

        /// <summary>
        /// 是否启用，值为 false 或 true，非必填
        /// Whether it is enabled, value is false or true, not required
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 是否重新生成子分段，非必填
        /// Whether to regenerate child chunks, not required
        /// </summary>
        public bool? regenerate_child_chunks { get; set; }=false;
    }
}
