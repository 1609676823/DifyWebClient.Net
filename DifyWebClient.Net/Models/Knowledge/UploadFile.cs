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
    /// 上传文件类，包含了上传文件的各种属性
    /// Uploaded file class, which contains various attributes of the uploaded file.
    /// </summary>
    public class UploadFile
    {
        /// <summary>
        /// 上传文件的唯一标识符，用于在系统中唯一标识一个上传文件
        /// Unique identifier of the uploaded file, used to uniquely identify an uploaded file in the system.
        /// </summary>
        public string? id { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件的名称，用于标识上传文件的名称
        /// Name of the uploaded file, used to identify the name of the uploaded file.
        /// </summary>
        public string? name { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件的大小，记录文件的大小
        /// Size of the uploaded file, recording the size of the file.
        /// </summary>
        public long? size { get; set; } = 0;

        /// <summary>
        /// 上传文件的扩展名，指示文件的类型
        /// Extension of the uploaded file, indicating the type of the file.
        /// </summary>
        public string? extension { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件的 MIME 类型，用于指定文件的媒体类型
        /// MIME type of the uploaded file, used to specify the media type of the file.
        /// </summary>
        public string? mime_type { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件的用户，记录上传该文件的用户信息
        /// User who uploaded the file, recording the information of the user who uploaded the file.
        /// </summary>
        public string? created_by { get; set; } = string.Empty;

        /// <summary>
        /// 上传文件的创建时间，记录文件上传的时间
        /// Creation time of the uploaded file, recording the time when the file was uploaded.
        /// </summary>
        public double? created_at { get; set; } = 0;
    }
}
