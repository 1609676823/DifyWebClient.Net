using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 该静态类包含用于对对话进行排序的常量。默认 -updated_at(按更新时间倒序排列)
    /// This static class contains constants used for sorting conversations.
    /// </summary>
    public static class ConversationsSortBy
    {
        /// <summary>
        /// 表示按创建时间升序排序的选项。
        /// Represents the option to sort conversations by creation time in ascending order.
        /// </summary>
        public const string CreatedAtAsc = "created_at";

        /// <summary>
        /// 表示按创建时间降序排序的选项。
        /// Represents the option to sort conversations by creation time in descending order.
        /// </summary>
        public const string CreatedAtDesc = "-created_at";

        /// <summary>
        /// 表示按更新时间升序排序的选项。
        /// Represents the option to sort conversations by update time in ascending order.
        /// </summary>
        public const string UpdatedAtAsc = "updated_at";

        /// <summary>
        /// 表示按更新时间降序排序的选项。
        /// Represents the option to sort conversations by update time in descending order.
        /// </summary>
        public const string UpdatedAtDesc = "-updated_at";
    }
}
