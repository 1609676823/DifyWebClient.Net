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
    /// 添加块请求对象，包含多个段（segments）
    /// Add Chunk Request object, containing multiple segments
    /// </summary>
    public class AddChunksRequest
    {
        /// <summary>
        /// 添加块请求对象，包含多个段（segments）
        /// Add Chunk Request object, containing multiple segments
        /// </summary>
        public AddChunksRequest() { }

        /// <summary>
        /// 添加块请求对象，只包含1个段（segments）
        /// Add Chunk Request object, containing 1 segments
        /// </summary>
        /// <param name="content">(text) 文本内容/问题内容，必填</param>
        /// <param name="answer"> (text) 答案内容，非必填，如果知识库的模式为 QA 模式则传值</param>
        /// <param name="keywords">(list) 关键字，非必填</param>
        public AddChunksRequest(string content,string answer="", List<string>? keywords=null) 
        {
            this.segments = new List<AddChunksRequestSegment>();
            this.segments.Add(new AddChunksRequestSegment());
            this.segments.FirstOrDefault()!.content = content;
            this.segments.FirstOrDefault()!.answer = content;

            if (keywords == null)
            {
                this.segments.FirstOrDefault()!.keywords = new List<string>();
            }
            else { this.segments.FirstOrDefault()!.keywords = keywords; }
        }
        /// <summary>
        /// 段（segments）列表
        /// List of segments
        /// </summary>
        public List<AddChunksRequestSegment>? segments { get; set; } = new List<AddChunksRequestSegment>();
    }

    /// <summary>
    /// 段（segment）对象，包含内容、答案和关键词
    /// Segment object, containing content, answer, and keywords
    /// </summary>
    public class AddChunksRequestSegment
    {
        /// <summary>
        /// 内容，表示段的主要信息
        /// Content, representing the main information of the segment
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 答案，对应段的内容的答案
        /// Answer, corresponding to the answer of the segment's content
        /// </summary>
        public string? answer { get; set; }

        /// <summary>
        ///关键词列表，与段相关联的关键词
        /// List of keywords, keywords associated with the segment
        /// </summary>
        public List<string>? keywords { get; set; }
    }
}
