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
    using System;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.Json.Serialization;

    /// <summary>
    /// 表示通用元数据信息的响应类，包含 ID、类型和名称。
    /// </summary>
    public class CommonMetadataResponse
    {
        /// <summary>
        /// 元数据的唯一标识符。
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 元数据的类型。
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 元数据的名称。
        /// </summary>
        public string? name { get; set; }

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
                    DeserializeCommonMetadataResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// 反序列化 JSON 字符串到当前对象。
        /// </summary>
        /// <param name="json">JSON 字符串。</param>
        public void DeserializeCommonMetadataResponse(string json)
        {
            try
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
                        this.type = jsonNode["type"]?.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.name = jsonNode["name"]?.GetValue<string>();
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}
