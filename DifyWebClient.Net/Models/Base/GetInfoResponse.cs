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
    /// 用于获取应用信息响应的类，包含应用的名称、描述和标签等信息。
    /// Class used for the response of getting application information, including the application's name, description, and tags.
    /// </summary>
    public class GetInfoResponse
    {
        /// <summary>
        /// 应用程序的名称
        /// The name of the application
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 应用程序的描述信息
        /// The description of the application
        /// </summary>
        public string? description { get; set; }

        /// <summary>
        /// 应用程序的标签列表
        /// The list of tags for the application
        /// </summary>
        public List<string>? tags { get; set; }
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
                    DeserializeGetInfoResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }
        /// <summary>
        /// 从 JSON 字符串反序列化到当前对象
        /// Deserialize from JSON string to the current object
        /// </summary>
        /// <param name="json">JSON 字符串</param>
        public virtual void DeserializeGetInfoResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    name = jsonNode["name"]?.GetValue<string>();
                }
                catch
                {
                }

                try
                {
                    description = jsonNode["description"]?.GetValue<string>();
                }
                catch
                {
                }

                tags = new List<string>();
                var tagArray = jsonNode["tags"] as JsonArray;
                if (tagArray != null)
                {
                    foreach (var tagNode in tagArray)
                    {
                        try
                        {
                            if (tagNode != null)
                            {
                                tags.Add(tagNode.GetValue<string>());
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}
