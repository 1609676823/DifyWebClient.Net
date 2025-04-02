using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// transfer_method  传递方式
    /// Transfer method
    /// </summary>
    public static class TransferMethod
    {
        /// <summary>
        /// 图片地址
        /// Image URL
        /// </summary>
        public const string RemoteUrl = "remote_url";
        /// <summary>
        /// 上传文件
        /// Uploaded file ID, which must be obtained by uploading through the File Upload API in advance (when the transfer method is
        /// </summary>
        public const string LocalFile = "local_file";
    }
}
