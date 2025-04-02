using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 响应类，包含操作结果信息。
    ///  response class, containing information about the operation result.
    /// </summary>
    public class CommonResultResponse
    {
        /// <summary>
        /// 操作结果，例如 "success" 表示操作成功。
        /// The result of the operation, e.g., "success" indicates the operation was successful.
        /// </summary>
        public string? result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? status { get; set; }


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
                    DeserializeDeleteDocumentResponse(value!);
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
        public virtual void DeserializeDeleteDocumentResponse(string json)
        {
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(json);
            if (jsonNode is not null)
            {
                try
                {
                    this.result = jsonNode["result"]?.GetValue<string>();
                }
                catch
                {
                    // 可根据实际情况添加日志记录等操作
                }
                try
                {
                    this.code = jsonNode["code"]?.GetValue<string>();
                }
                catch
                {
                    // 可根据实际情况添加日志记录等操作
                }
                try
                {
                    this.message = jsonNode["message"]?.GetValue<string>();
                }
                catch
                {
                    // 可根据实际情况添加日志记录等操作
                }
                try
                {
                    this.status = jsonNode["status"]?.GetValue<long>();
                }
                catch
                {
                    // 可根据实际情况添加日志记录等操作
                }
            }
        }
    }
}
