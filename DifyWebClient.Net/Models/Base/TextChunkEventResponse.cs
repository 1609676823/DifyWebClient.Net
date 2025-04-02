using DifyWebClient.Net.Models.ChatApp;
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
    /// 文本块事件响应类，用于表示接收到的文本块事件相关的响应数据。
    /// Text chunk event response class, used to represent the response data related to the received text chunk event.
    /// </summary>
    public class TextChunkEventResponse : SSEEventResponseBase
    {
        ///// <summary>
        ///// 事件类型，这里为文本块事件。
        ///// The type of the event, here it is a text chunk event.
        ///// </summary>
        //public string? @event { get; set; }

        /// <summary>
        /// 工作流运行的唯一标识符。
        /// The unique identifier of the workflow run.
        /// </summary>
        public string? workflow_run_id { get; set; }

        /// <summary>
        /// 任务的唯一标识符。
        /// The unique identifier of the task.
        /// </summary>
        public string? task_id { get; set; }

        /// <summary>
        /// 文本块事件的数据部分。
        /// The data part of the text chunk event.
        /// </summary>
        public TextChunkEvenData? data { get; set; }

        [JsonIgnore]
        private string realJsonstring = string.Empty;

        /// <summary>
        /// Gets or sets the real JSON string representation of the response.
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// </summary>
        [JsonIgnore]
        public override string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value!;
                try
                {
                    DeserializeTextChunkEventResponse(value!);
                }
                catch (Exception)
                {
                    // 可添加日志记录等操作
                }
            }
        }
        /// <summary>
        /// 从 JSON 字符串反序列化到当前对象
        /// Deserialize from JSON string to the current object
        /// </summary>
        /// <param name="json">JSON 字符串</param>
        public virtual void DeserializeTextChunkEventResponse(string json)
        {
            try
            {
                var jsonNode = JsonNode.Parse(json);
                if (jsonNode != null)
                {
                    try
                    {
                        this.Event = jsonNode["event"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.workflow_run_id = jsonNode["workflow_run_id"]?.GetValue<string>();
                    }
                    catch { }

                    try
                    {
                        this.task_id = jsonNode["task_id"]?.GetValue<string>();
                    }
                    catch { }

                    var dataNode = jsonNode["data"];
                    if (dataNode != null)
                    {
                        this.data = new TextChunkEvenData();
                        try
                        {
                            this.data.text = dataNode["text"]?.GetValue<string>();
                        }
                        catch { }

                        try
                        {
                            this.data.from_variable_selector = dataNode["from_variable_selector"]?
                                                               .AsArray()
                                                               .Select(n => n!.GetValue<string>())
                                                               .ToList();
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

    }

    /// <summary>
    /// 文本块事件数据类，包含文本块事件的详细数据。
    /// Text chunk event data class, containing the detailed data of the text chunk event.
    /// </summary>
    public class TextChunkEvenData
    {
        /// <summary>
        /// 文本内容。
        /// The text content.
        /// </summary>
        public string? text { get; set; }

        /// <summary>
        /// 来自变量选择器的信息列表。
        /// A list of information from the variable selector.
        /// </summary>
        public List<string>? from_variable_selector { get; set; }
    }

}
