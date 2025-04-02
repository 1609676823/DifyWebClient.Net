using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 权限相关类
    /// Permission
    /// </summary>
    public static class Permission
    {
        /// <summary>
        /// 仅自己
        /// Only me
        /// </summary>
        public const string OnlyMe = "only_me";

        /// <summary>
        /// 所有团队成员
        /// All team members
        /// </summary>
        public const string AllTeamMembers = "all_team_members";

        /// <summary>
        /// 部分团队成员
        /// Partial members
        /// </summary>
        public const string PartialMembers = "partial_members";
    }
}
