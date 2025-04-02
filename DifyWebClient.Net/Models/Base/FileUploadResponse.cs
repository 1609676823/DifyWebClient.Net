using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Base
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 成功上传后，服务器会返回文件的 ID 和相关信息。
    /// After successful upload, the server will return the file's ID and related information.
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// 文件的唯一标识符，采用 UUID 格式。
        /// The unique identifier of the file, in UUID format.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 上传文件的名称。
        /// The name of the uploaded file.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 文件的大小，单位为字节。
        /// The size of the file in bytes.
        /// </summary>
        public long? size { get; set; }

        /// <summary>
        /// 文件的扩展名，如 .pdf、.jpg 等。
        /// The extension of the file, such as .pdf, .jpg, etc.
        /// </summary>
        public string? extension { get; set; }

        /// <summary>
        /// 文件的 MIME 类型，用于标识文件的类型。
        /// The MIME type of the file, used to identify the type of the file.
        /// </summary>
        public string? mime_type { get; set; }

        /// <summary>
        /// 上传该文件的用户的唯一标识符，采用 UUID 格式。
        /// The unique identifier of the user who uploaded the file, in UUID format.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 文件上传的时间戳。
        /// The timestamp when the file was uploaded.
        /// </summary>
        public long? created_at { get; set; }

        [JsonIgnore]
        private string realJsonstring = string.Empty;

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
                realJsonstring = value!;
                try
                {
                    DeserializeFileUploadResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// 从 JSON 字符串反序列化数据到当前对象
        /// Deserialize data from JSON string to the current object
        /// </summary>
        /// <param name="json">JSON 字符串</param>
        public virtual void DeserializeFileUploadResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        id = jsonNode["id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        name = jsonNode["name"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        size = jsonNode["size"]?.GetValue<long?>();
                    }
                    catch { }

                    try
                    {
                        extension = jsonNode["extension"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        mime_type = jsonNode["mime_type"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        created_by = jsonNode["created_by"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        created_at = jsonNode["created_at"]?.GetValue<long?>();
                    }
                    catch { }
                }
            }
            catch { }
        }

    }

}
