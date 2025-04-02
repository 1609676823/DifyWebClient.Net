using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006


    /// <summary>
    /// 用于获取元数据的响应类。
    /// This class represents the response for getting metadata.
    /// </summary>
    public class GetMetaResponse
    {
        /// <summary>
        /// 工具图标字典，存储工具图标的相关信息。
        /// A dictionary that stores information related to tool icons.
        /// </summary>
        public Dictionary<string, object>? tool_icons { get; set; }

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
                    DeserializeGetMetaResponse(value!);
                }
                catch { }
            }
        }

        /// <summary>
        /// 从 JSON 字符串反序列化到当前对象
        /// Deserialize from JSON string to the current object
        /// </summary>
        /// <param name="json">JSON 字符串</param>
        private void DeserializeGetMetaResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode is not null)
                {
                    try
                    {
                        var toolIconsNode = jsonNode["tool_icons"];
                        if (toolIconsNode is not null)
                        {
                            tool_icons = new Dictionary<string, object>();
                            if (toolIconsNode is JsonObject toolIconsObject)
                            {
                                foreach (var property in toolIconsObject)
                                {
                                    try
                                    {
                                        tool_icons[property.Key] = property.Value!;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
    }

}
