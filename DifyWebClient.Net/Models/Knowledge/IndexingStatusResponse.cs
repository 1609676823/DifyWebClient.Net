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
    /// 索引状态响应类，包含一组索引状态数据项。
    /// Indexing status response class, containing a collection of indexing status data items.
    /// </summary>
    public class IndexingStatusResponse
    {
        /// <summary>
        /// 索引状态数据项列表。
        /// List of indexing status data items.
        /// </summary>
        public System.Collections.Generic.List<IndexingStatusDataItem>? data { get; set; }
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
                    DeserializeIndexingStatusResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        private void DeserializeIndexingStatusResponse(string json)
        {
            var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(json);
            if (jsonNode != null && jsonNode["data"] != null)
            {
                try
                {
                    JsonArray? dataArray = System.Text.Json.Nodes.JsonArray.Parse(jsonNode["data"]!.ToJsonString()) as JsonArray;
                    
                    this.data = new System.Collections.Generic.List<IndexingStatusDataItem>();

                    foreach (var itemNode in dataArray!)
                    {
                        var dataItem = new IndexingStatusDataItem();

                        try
                        {
                            dataItem.id = itemNode!["id"]?.GetValue<string>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.indexing_status = itemNode!["indexing_status"]?.GetValue<string>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.processing_started_at = itemNode!["processing_started_at"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.parsing_completed_at = itemNode!["parsing_completed_at"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.cleaning_completed_at = itemNode!["cleaning_completed_at"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.splitting_completed_at = itemNode!["splitting_completed_at"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.completed_at = itemNode!["completed_at"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.paused_at = itemNode!["paused_at"]?.GetValue<object>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.error = itemNode!["error"]?.GetValue<object>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.stopped_at = itemNode!["stopped_at"]?.GetValue<object>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.completed_segments = itemNode!["completed_segments"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dataItem.total_segments = itemNode!["total_segments"]?.GetValue<long?>();
                        }
                        catch
                        {
                        }

                        this.data.Add(dataItem);
                    }
                }
                catch
                {
                    // 可根据实际情况添加日志记录等操作
                }
            }
        }

    }

    /// <summary>
    /// 索引状态数据项类，包含单个索引状态数据项的详细信息。
    /// Indexing status data item class, containing detailed information of a single indexing status data item.
    /// </summary>
    public class IndexingStatusDataItem
    {
        /// <summary>
        /// 数据项的唯一标识符。
        /// Unique identifier of the data item.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 索引状态，例如 "completed" 表示已完成。
        /// Indexing status, e.g., "completed" indicates completion.
        /// </summary>
        public string? indexing_status { get; set; }

        /// <summary>
        /// 处理开始的时间戳。
        /// Timestamp when the processing started.
        /// </summary>
        public long? processing_started_at { get; set; }

        /// <summary>
        /// 解析完成的时间戳。
        /// Timestamp when the parsing was completed.
        /// </summary>
        public long? parsing_completed_at { get; set; }

        /// <summary>
        /// 清理完成的时间戳。
        /// Timestamp when the cleaning was completed.
        /// </summary>
        public long? cleaning_completed_at { get; set; }

        /// <summary>
        /// 拆分完成的时间戳。
        /// Timestamp when the splitting was completed.
        /// </summary>
        public long? splitting_completed_at { get; set; }

        /// <summary>
        /// 整体完成的时间戳。
        /// Timestamp when the overall process was completed.
        /// </summary>
        public long? completed_at { get; set; }

        /// <summary>
        /// 暂停的时间戳，如果未暂停则为 null。
        /// Timestamp when the process was paused, null if not paused.
        /// </summary>
        public object? paused_at { get; set; }

        /// <summary>
        /// 错误信息，如果没有错误则为 null。
        /// Error information, null if there is no error.
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 停止的时间戳，如果未停止则为 null。
        /// Timestamp when the process was stopped, null if not stopped.
        /// </summary>
        public object? stopped_at { get; set; }

        /// <summary>
        /// 已完成的分段数量。
        /// Number of completed segments.
        /// </summary>
        public long? completed_segments { get; set; }

        /// <summary>
        /// 总分段数量。
        /// Total number of segments.
        /// </summary>
        public long? total_segments { get; set; }
    }


}
