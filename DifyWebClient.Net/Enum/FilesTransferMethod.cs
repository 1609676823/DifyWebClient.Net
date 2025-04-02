using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// transfer_method (string) 传递方式
    /// transfer_method (string) Transfer method
    /// </summary>
    public static class FilesTransferMethod
    {
        /// <summary>
        /// remote_url: 图片地址,url 图片地址。（仅当传递方式为 remote_url 时）。
        /// url (string) Image URL (when the transfer method is remote_url
        /// </summary>
        public const string Remote_url = "remote_url";
        /// <summary>
        ///local_file: 上传文件,upload_file_id 上传文件 ID。（仅当传递方式为 local_file 时）
        ///upload_file_id (string) Uploaded file ID, which must be obtained by uploading through the File Upload API in advance (when the transfer method is local_file
        /// </summary>
        public const string Local_file = "local_file";
    }
}
