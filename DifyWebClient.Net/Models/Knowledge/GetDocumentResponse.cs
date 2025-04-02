using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace DifyWebClient.Net.Models.Knowledge
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 获取文档响应类，包含文档数据列表以及分页相关信息。
    /// Get document response class, which contains the document data list and pagination-related information.
    /// </summary>
    public class GetDocumentResponse
    {
        /// <summary>
        /// 文档数据列表。
        /// Document data list.
        /// </summary>
        public List<DataItem>? data { get; set; }

        /// <summary>
        /// 是否还有更多数据。
        /// Indicates whether there is more data.
        /// </summary>
        public bool? has_more { get; set; }

        /// <summary>
        /// 每页显示的数据数量限制。
        /// Limit of the number of data items displayed per page.
        /// </summary>
        public long? limit { get; set; }

        /// <summary>
        /// 数据的总数量。
        /// Total number of data items.
        /// </summary>
        public long? total { get; set; }

        /// <summary>
        /// 当前页码。
        /// Current page number.
        /// </summary>
        public long? page { get; set; }

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
                   DeserializeGetDocumentResponse(value!);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
        }

        /// <summary>
        /// json解析
        /// </summary>
        /// <param name="json"></param>
        public virtual void DeserializeGetDocumentResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode is not null)
            {
                try
                {
                    this.data = new List<DataItem>();
                    var dataArray = jsonNode["data"]?.AsArray();
                    if (dataArray != null)
                    {
                        foreach (var item in dataArray)
                        {
                            var dataItem = new DataItem();
                            dataItem.id = item!["id"]?.GetValue<string>();
                            dataItem.position = item["position"]?.GetValue<long>();
                            dataItem.data_source_type = item["data_source_type"]?.GetValue<string>();

                            dataItem.data_source_info = new DataSourceInfo();
                            var dataSourceInfoNode = item["data_source_info"];
                            dataItem.data_source_info.upload_file_id = dataSourceInfoNode!["upload_file_id"]!.GetValue<string>();

                            dataItem.data_source_detail_dict = new DataSourceDetailDict();
                            var dataSourceDetailDictNode = item["data_source_detail_dict"];
                            dataItem.data_source_detail_dict.upload_file = new UploadFile();
                            var uploadFileNode = dataSourceDetailDictNode?["upload_file"];
                            dataItem.data_source_detail_dict.upload_file.id = uploadFileNode?["id"]?.GetValue<string>();
                            dataItem.data_source_detail_dict.upload_file.name = uploadFileNode?["name"]?.GetValue<string>();
                            dataItem.data_source_detail_dict.upload_file.size = uploadFileNode?["size"]?.GetValue<long>();
                            dataItem.data_source_detail_dict.upload_file.extension = uploadFileNode?["extension"]?.GetValue<string>();
                            dataItem.data_source_detail_dict.upload_file.mime_type = uploadFileNode?["mime_type"]?.GetValue<string>();
                            dataItem.data_source_detail_dict.upload_file.created_by = uploadFileNode?["created_by"]?.GetValue<string>();
                            dataItem.data_source_detail_dict.upload_file.created_at = uploadFileNode?["created_at"]?.GetValue<double>();

                            dataItem.dataset_process_rule_id = item["dataset_process_rule_id"]?.GetValue<string>();
                            dataItem.name = item["name"]?.GetValue<string>();
                            dataItem.created_from = item["created_from"]?.GetValue<string>();
                            dataItem.created_by = item["created_by"]?.GetValue<string>();
                            dataItem.created_at = item["created_at"]?.GetValue<long>();
                            dataItem.tokens = item["tokens"]?.GetValue<long>();
                            dataItem.indexing_status = item["indexing_status"]?.GetValue<string>();
                            dataItem.error = item["error"];
                            dataItem.enabled = item["enabled"]?.GetValue<bool>();
                            dataItem.disabled_at = item["disabled_at"];
                            dataItem.disabled_by = item["disabled_by"];
                            dataItem.archived = item["archived"]?.GetValue<bool>();
                            dataItem.display_status = item["display_status"]?.GetValue<string>();
                            dataItem.word_count = item["word_count"]?.GetValue<long>();
                            dataItem.hit_count = item["hit_count"]?.GetValue<long>();
                            dataItem.doc_form = item["doc_form"]?.GetValue<string>();
                            dataItem.doc_metadata = item["doc_metadata"];

                            this.data.Add(dataItem);
                        }
                    }
                }
                catch { }

                try
                {
                    this.has_more = jsonNode["has_more"]?.GetValue<bool>();
                }
                catch { }

                try
                {
                    this.limit = jsonNode["limit"]?.GetValue<long>();
                }
                catch { }

                try
                {
                    this.total = jsonNode["total"]?.GetValue<long>();
                }
                catch { }

                try
                {
                    this.page = jsonNode["page"]?.GetValue<long>();
                }
                catch { }
            }
        }
    }

    /// <summary>
    /// 单个文档数据项类，包含文档的详细信息。
    /// Single document data item class, which contains detailed information of a document.
    /// </summary>
    public class DataItem
    {
        /// <summary>
        /// 文档的唯一标识符。
        /// Unique identifier of the document.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 文档的位置序号。
        /// Position sequence number of the document.
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 数据源的类型。
        /// Type of the data source.
        /// </summary>
        public string? data_source_type { get; set; }

        /// <summary>
        /// 数据源的相关信息。
        /// Information related to the data source.
        /// </summary>
        public DataSourceInfo? data_source_info { get; set; }

        /// <summary>
        /// 数据源的详细信息字典。
        /// Dictionary of detailed information of the data source.
        /// </summary>
        public DataSourceDetailDict? data_source_detail_dict { get; set; }

        /// <summary>
        /// 数据集处理规则的唯一标识符。
        /// Unique identifier of the dataset processing rule.
        /// </summary>
        public string? dataset_process_rule_id { get; set; }

        /// <summary>
        /// 文档的名称。
        /// Name of the document.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 文档的创建来源。
        /// Creation source of the document.
        /// </summary>
        public string? created_from { get; set; }

        /// <summary>
        /// 创建文档的用户的唯一标识符。
        /// Unique identifier of the user who created the document.
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// 文档的创建时间戳。
        /// Creation timestamp of the document.
        /// </summary>
        public long? created_at { get; set; }

        /// <summary>
        /// 文档的令牌数量。
        /// Number of tokens of the document.
        /// </summary>
        public long? tokens { get; set; }

        /// <summary>
        /// 文档的索引状态。
        /// Indexing status of the document.
        /// </summary>
        public string? indexing_status { get; set; }

        /// <summary>
        /// 文档处理过程中可能出现的错误信息。
        /// Error information that may occur during the document processing.
        /// </summary>
        public object? error { get; set; }

        /// <summary>
        /// 文档是否启用。
        /// Indicates whether the document is enabled.
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 文档的禁用时间戳。
        /// Disable timestamp of the document.
        /// </summary>
        public object? disabled_at { get; set; }

        /// <summary>
        /// 禁用文档的用户的唯一标识符。
        /// Unique identifier of the user who disabled the document.
        /// </summary>
        public object? disabled_by { get; set; }

        /// <summary>
        /// 文档是否已归档。
        /// Indicates whether the document is archived.
        /// </summary>
        public bool? archived { get; set; }

        /// <summary>
        /// 文档的显示状态。
        /// Display status of the document.
        /// </summary>
        public string? display_status { get; set; }

        /// <summary>
        /// 文档的总字数。
        /// Total number of words of the document.
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 文档的命中次数。
        /// Number of hits of the document.
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 文档的格式。
        /// Format of the document.
        /// </summary>
        public string? doc_form { get; set; }

        /// <summary>
        /// 文档的元数据。
        /// Metadata of the document.
        /// </summary>
        public object? doc_metadata { get; set; }
    }

}