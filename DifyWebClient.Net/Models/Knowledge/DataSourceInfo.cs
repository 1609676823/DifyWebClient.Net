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
    /// 数据源信息类，包含了与数据源相关的信息
    /// Data source information class, which contains information related to the data source.
    /// </summary>
    public class DataSourceInfo
    {
        /// <summary>
        /// 上传文件的唯一标识符，用于标识上传的文件
        /// Unique identifier of the uploaded file, used to identify the uploaded file.
        /// </summary>
        public string upload_file_id { get; set; } = string.Empty;
    }
}
