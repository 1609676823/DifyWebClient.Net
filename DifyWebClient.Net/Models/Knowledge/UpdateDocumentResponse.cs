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
    /// 更新文档响应类，包含文档信息和批次号。
    /// Update document response class, containing document information and batch number.
    /// </summary>
    public class UpdateDocumentResponse
    {
        /// <summary>
        /// 文档对象，包含文档的详细信息。
        /// Document object, containing detailed information of the document.
        /// </summary>
        public Document? document { get; set; }
        /// <summary>
        /// 批次号，用于标识操作的批次。
        /// Batch number, used to identify the batch of the operation.
        /// </summary>
        public string? batch { get; set; }
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
                    DeserializeUpdateDocumentResponse(value!);
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
        public virtual void DeserializeUpdateDocumentResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                var documentNode = jsonNode["document"];
                if (documentNode != null)
                {
                    this.document = new Document();
                    try
                    {
                        this.document.id = documentNode["id"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.position = documentNode["position"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.data_source_type = documentNode["data_source_type"]!.GetValue<string>();
                    }
                    catch { }

                    var dataSourceInfoNode = documentNode["data_source_info"];
                    if (dataSourceInfoNode != null)
                    {
                        this.document.data_source_info = new DataSourceInfo();
                        try
                        {
                            this.document.data_source_info.upload_file_id = dataSourceInfoNode["upload_file_id"]!.GetValue<string>();
                        }
                        catch { }
                    }

                    var dataSourceDetailDictNode = documentNode["data_source_detail_dict"];
                    if (dataSourceDetailDictNode != null)
                    {
                        this.document.data_source_detail_dict = new DataSourceDetailDict();
                        var uploadFileNode = dataSourceDetailDictNode["upload_file"];
                        if (uploadFileNode != null)
                        {
                            this.document.data_source_detail_dict.upload_file = new UploadFile();
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.id = uploadFileNode["id"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.name = uploadFileNode["name"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.size = uploadFileNode["size"]?.GetValue<long?>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.extension = uploadFileNode["extension"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.mime_type = uploadFileNode["mime_type"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.created_by = uploadFileNode["created_by"]?.GetValue<string>();
                            }
                            catch { }
                            try
                            {
                                this.document.data_source_detail_dict.upload_file.created_at = uploadFileNode["created_at"]?.GetValue<double?>();
                            }
                            catch { }
                        }
                    }

                    try
                    {
                        this.document.dataset_process_rule_id = documentNode["dataset_process_rule_id"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.name = documentNode["name"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.created_from = documentNode["created_from"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.created_by = documentNode["created_by"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.created_at = documentNode["created_at"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.tokens = documentNode["tokens"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.indexing_status = documentNode["indexing_status"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.error = documentNode["error"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.enabled = documentNode["enabled"]!.GetValue<bool>();
                    }
                    catch { }
                    try
                    {
                        this.document.disabled_at = documentNode["disabled_at"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.disabled_by = documentNode["disabled_by"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.archived = documentNode["archived"]!.GetValue<bool>();
                    }
                    catch { }
                    try
                    {
                        this.document.display_status = documentNode["display_status"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.word_count = documentNode["word_count"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.hit_count = documentNode["hit_count"]!.GetValue<long>();
                    }
                    catch { }
                    try
                    {
                        this.document.doc_form = documentNode["doc_form"]!.GetValue<string>();
                    }
                    catch { }
                    try
                    {
                        this.document.doc_metadata = documentNode["doc_metadata"]!.GetValue<object>();
                    }
                    catch { }
                }

                try
                {
                    this.batch = jsonNode["batch"]?.GetValue<string>();
                }
                catch { }
            }
        }


    }

}
