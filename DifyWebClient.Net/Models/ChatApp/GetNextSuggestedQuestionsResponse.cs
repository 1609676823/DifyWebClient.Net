using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006

    /// <summary>
    /// 获取下一组建议问题的响应类
    /// Response class for getting the next set of suggested questions
    /// </summary>
    public class GetNextSuggestedQuestionsResponse
    {
        /// <summary>
        /// 操作结果，通常为 "success" 或 "error"
        /// Operation result, usually "success" or "error"
        /// </summary>
        public string? result { get; set; }

        /// <summary>
        /// 建议问题列表
        /// List of suggested questions
        /// </summary>
        public List<string>? data { get; set; }
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
                    DeserializeGetNextSuggestedQuestionsResponse(value!);
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
        public virtual void DeserializeGetNextSuggestedQuestionsResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        this.result = jsonNode["result"]?.GetValue<string>();
                    }
                    catch
                    {
                    }

                    this.data = new List<string>();
                    var dataNode = jsonNode["data"];
                    if (dataNode != null && dataNode is JsonArray dataArray)
                    {
                        foreach (var item in dataArray)
                        {
                            try
                            {
                                if (item != null)
                                {
                                    this.data.Add(item.GetValue<string>());
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

    }
}
