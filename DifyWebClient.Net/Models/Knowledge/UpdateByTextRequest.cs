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
    /// 通过文本更新文档,此接口基于已存在知识库，在此知识库的基础上通过文本更新文档
    /// Update a Document with Text，This API is based on an existing knowledge and updates the document through text based on this knowledge.
    /// </summary>
    public class UpdateByTextRequest
    {
        /// <summary>
        /// 通过文本更新文档,此接口基于已存在知识库，在此知识库的基础上通过文本更新文档
        /// Update a Document with Text，This API is based on an existing knowledge and updates the document through text based on this knowledge.
        /// </summary>
        public UpdateByTextRequest() { }
        /// <summary>
        /// 通过文本更新文档,此接口基于已存在知识库，在此知识库的基础上通过文本更新文档
        /// Update a Document with Text，This API is based on an existing knowledge and updates the document through text based on this knowledge.
        /// </summary>
        /// <param name="text">更新文本</param>
        /// <param name="name">更新文档的名称,若不赋值，文档名称会变成空</param>
        public UpdateByTextRequest(string text,string name) 
        { 
            this.text = text;
            this.name = name;
        }
        /// <summary>
        /// 文档名称 若不赋值，文档名称会变成空
        /// Document name 
        /// </summary>

        public string? name { get; set; } = "modify_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

        /// <summary>
        /// 文档内容（选填）
        /// Document content (optional)
        /// </summary>
        public string? text { get; set; }

        /// <summary>
        /// 处理规则（选填）
        /// Processing rules
        /// </summary>
        public ProcessRule? process_rule { get; set; }
    }

}
