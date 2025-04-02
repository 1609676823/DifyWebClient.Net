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
    /// GitHub同步文档 GitHub document
    /// </summary>
    public class SyncedFromGithubMetadata : DocMetadata
    {
        /// <summary>
        /// 仓库名称
        /// Repository name
        /// </summary>
        public string RepositoryName { get; set; } = string.Empty;

        /// <summary>
        /// 仓库描述
        /// Repository description
        /// </summary>
        public string RepositoryDescription { get; set; } = string.Empty;

        /// <summary>
        /// 仓库所有者/组织
        /// Repository owner or organization
        /// </summary>
        public string RepositoryOwnerOrganization { get; set; } = string.Empty;

        /// <summary>
        /// 代码文件名
        /// Code filename
        /// </summary>
        public string CodeFilename { get; set; } = string.Empty;

        /// <summary>
        /// 代码文件路径
        /// Code file path
        /// </summary>
        public string CodeFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 编程语言
        /// Programming language
        /// </summary>
        public string ProgrammingLanguage { get; set; } = string.Empty;

        /// <summary>
        /// GitHub链接
        /// GitHub link
        /// </summary>
        public string GithubLink { get; set; } = string.Empty;

        /// <summary>
        /// 开源许可证
        /// Open source license
        /// </summary>
        public string OpenSourceLicense { get; set; } = string.Empty;

        /// <summary>
        /// 提交日期
        /// Commit date
        /// </summary>
        public string CommitDate { get; set; } = string.Empty;

        /// <summary>
        /// 提交作者
        /// Commit author
        /// </summary>
        public string CommitAuthor { get; set; } = string.Empty;

        /// <summary>
        /// 构造方法
        /// Constructor
        /// </summary>
        public SyncedFromGithubMetadata() { }
    }
}
