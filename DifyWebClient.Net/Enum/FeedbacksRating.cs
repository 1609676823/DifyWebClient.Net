using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 点赞 like, 点踩 dislike, 撤销点赞 null
    /// Upvote as like, downvote as dislike, revoke upvote as null
    /// </summary>
    public static class FeedbacksRating
    {
        /// <summary>
        /// 点赞 like
        /// Upvote as like
        /// </summary>
        public const string Like = "like";
        /// <summary>
        /// 点踩 dislike
        /// downvote as dislike
        /// </summary>
        public const string Dislike = "dislike";
        /// <summary>
        /// 撤销点赞 null
        /// revoke upvote as null
        /// </summary>
        public const string Revoke = null;
    }
}
