using DifyWebClient.Net.Enum;
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
    /// 创建空知识库的请求模型
    /// Create an Empty Knowledge Base model
    /// </summary>
    public class CreateEmptyKnowledgeRequest
    {
        /// <summary>
        /// 创建空知识库的请求模型
        /// Create an Empty Knowledge Base model
        /// </summary>
        public CreateEmptyKnowledgeRequest() { }

        /// <summary>
        /// 创建空知识库的请求模型
        /// Create an Empty Knowledge Base model
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="indexing_technique"></param>
        /// <param name="permission"></param>
        public CreateEmptyKnowledgeRequest(string name,string description="",string indexing_technique = IndexingTechnique.HighQuality, string permission = Permission.OnlyMe) 
        {
            this.name = name;
            this.description = description;
            this.indexing_technique = indexing_technique;
            this.permission = permission;
        }


        /// <summary>
        /// 知识库名称（必填）
        /// Knowledge name (Required)
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 知识库描述（选填）
        /// Knowledge description (optional)
        /// </summary>
        public string description { get; set; } = string.Empty;

        /// <summary>
        /// 索引模式（选填，建议填写）
        /// 可选值: 
        /// high_quality - 高质量
        /// economy - 经济
        /// 
        /// Index technique (optional, it is recommended to fill in)
        /// Available values:
        /// high_quality - High quality
        /// economy - Economy
        /// </summary>
        public string indexing_technique { get; set; } =IndexingTechnique.HighQuality;

        /// <summary>
        /// 权限（选填，默认 only_me）
        /// 可选值: 
        /// only_me - 仅自己
        /// all_team_members - 所有团队成员
        /// partial_members - 部分团队成员
        /// 
        /// Permission (optional, default: only_me)
        /// Available values:
        /// only_me - Only me
        /// all_team_members - All team members
        /// partial_members - Partial members
        /// </summary>
        public string permission { get; set; } = Permission.OnlyMe;

        /// <summary>
        /// Provider（选填，默认 vendor）
        /// 可选值: 
        /// vendor - 上传文件
        /// external - 外部知识库
        /// 
        /// Provider (optional, default: vendor)
        /// Available values:
        /// vendor - Vendor
        /// external - External knowledge
        /// </summary>
        public string provider { get; set; } = Provider.Vendor;

        /// <summary>
        /// 外部知识库 API_ID（选填）
        /// External knowledge API ID (optional)
        /// </summary>
        public string external_knowledge_api_id { get; set; } = string.Empty;

        /// <summary>
        /// 外部知识库 ID（选填）
        /// External knowledge ID (optional)
        /// </summary>
        public string external_knowledge_id { get; set; } = string.Empty;
    }

}
