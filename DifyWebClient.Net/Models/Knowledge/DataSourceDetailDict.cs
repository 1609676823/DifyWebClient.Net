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
    /// 数据源详细字典类，存储了数据源的详细配置信息
    /// Data source detail dictionary class, storing detailed configuration information of the data source.
    /// </summary>
    public class DataSourceDetailDict
    {
        /// <summary>
        /// 上传文件对象，包含了上传文件的各种属性
        /// Uploaded file object, which contains various attributes of the uploaded file.
        /// </summary>
        public UploadFile upload_file { get; set; } = new UploadFile();
    }
}
