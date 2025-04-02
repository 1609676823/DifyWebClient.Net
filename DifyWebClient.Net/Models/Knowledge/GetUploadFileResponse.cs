using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 获取上传文件响应类
    /// Get Upload File Response
    /// </summary>
    public class GetUploadFileResponse
    {
        /// <summary>
        /// 文件的唯一标识符。
        /// The unique identifier of the file.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 文件的名称。
        /// The name of the file.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 文件的大小，以字节为单位。
        /// The size of the file, in bytes.
        /// </summary>
        public long? size { get; set; }

        /// <summary>
        /// 文件的扩展名。
        /// The extension of the file.
        /// </summary>
        public string? extension { get; set; }

        /// <summary>
        /// 文件预览的URL。
        /// The URL for file preview.
        /// </summary>
        public string? url { get; set; }

        /// <summary>
        /// 文件下载的URL。
        /// The URL for file download.
        /// </summary>
        public string? download_url { get; set; }

        /// <summary>
        /// 文件的MIME类型。
        /// The MIME type of the file.
        /// </summary>
        public string? mime_type { get; set; }

        /// <summary>
        /// 创建文件的用户的唯一标识符。
        /// The unique identifier of the user who created the file.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 文件创建的时间戳。
        /// The timestamp when the file was created.
        /// </summary>
        public double? created_at { get; set; }

        /// <summary>
        /// The real JSON string representation of the response.
        /// 响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        private string? realJsonstring = string.Empty;

        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        public string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value;
                try
                {
                    DeserializeGetUploadFileResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }
        /// <summary>
        /// 解析json
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeGetUploadFileResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    this.id = jsonNode["id"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.name = jsonNode["name"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.size = jsonNode["size"]?.GetValue<long?>();
                }
                catch { }

                try
                {
                    this.extension = jsonNode["extension"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.url = jsonNode["url"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.download_url = jsonNode["download_url"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.mime_type = jsonNode["mime_type"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.created_by = jsonNode["created_by"]?.GetValue<string>();
                }
                catch { }

                try
                {
                    this.created_at = jsonNode["created_at"]?.GetValue<double?>();
                }
                catch { }
            }
        }

    }
}
