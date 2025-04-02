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
    /// 主响应类，包含文档元数据列表和内置字段启用状态。
    /// </summary>
    public class GetMetadataResponse
    {
        /// <summary>
        /// 文档元数据列表。
        /// </summary>
        public List<GetMetadataResponseDocMetadata>? doc_metadata { get; set; }

        /// <summary>
        /// 内置字段是否启用。
        /// </summary>
        public bool? built_in_field_enabled { get; set; }

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
                    DeserializeGetMetadataResponse(value!);
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
        public void DeserializeGetMetadataResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        var docMetadataNode = jsonNode["doc_metadata"];
                        if (docMetadataNode is JsonArray docMetadataArray)
                        {
                            this.doc_metadata = new List<GetMetadataResponseDocMetadata>();
                            foreach (var metadataNode in docMetadataArray)
                            {
                                var metadata = new GetMetadataResponseDocMetadata();
                                try
                                {
                                    metadata.id = metadataNode!["id"]?.GetValue<string>();
                                }
                                catch { }
                                try
                                {
                                    metadata.name = metadataNode!["name"]?.GetValue<string>();
                                }
                                catch { }
                                try
                                {
                                    metadata.type = metadataNode!["type"]?.GetValue<string>();
                                }
                                catch { }
                                try
                                {
                                    metadata.count = metadataNode!["count"]?.GetValue<long>();
                                }
                                catch { }
                                this.doc_metadata.Add(metadata);
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        this.built_in_field_enabled = jsonNode["built_in_field_enabled"]?.GetValue<bool>();
                    }
                    catch { }
                }
            }
            catch { }
        }
    }

    /// <summary>
    /// 文档元数据类，包含元数据的基本信息。
    /// </summary>
    public class GetMetadataResponseDocMetadata
    {
        /// <summary>
        /// 元数据的唯一标识符。
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 元数据的名称。
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 元数据的类型。
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 元数据的计数。
        /// </summary>
        public long? count { get; set; }
    }
}
