using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 音频转文字的响应类，用于封装音频转换后的文本结果。
    /// The response class for audio-to-text conversion, used to encapsulate the text result after audio conversion.
    /// </summary>
    public class AudioToTextResponse
    {
        /// <summary>
        /// 音频转文字后的文本内容
        /// The text content after audio-to-text conversion.
        /// </summary>
        public string? text { get; set; }

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
                    DeserializeAudioToTextResponse(value!);
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
        public virtual void DeserializeAudioToTextResponse(string json)
        {
            
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    this.text = jsonNode["text"]?.GetValue<string>();
                }
                catch (Exception)
                {

                 
                }
               
            }
        }
    }
}
