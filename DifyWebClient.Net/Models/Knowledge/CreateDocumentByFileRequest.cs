using DifyWebClient.Net.Enum;
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
    /// <summary>
    /// 此接口基于已存在知识库，在此知识库的基础上通过文本创建新的文档。
    /// This API is based on an existing knowledge and creates a new document through text based on this knowledge.
    /// 创建文档的文件请求类，包含创建文档所需的各项信息。
    /// Request class for creating a document from a file, containing various information required for document creation.
    /// </summary>
    public class CreateDocumentByFileRequest
    {
        /// <summary>
        /// 创建文档的文件请求类，包含创建文档所需的各项信息。
        /// Request class for creating a document from a file, containing various information required for document creation.
        /// </summary>
        public CreateDocumentByFileRequest() { }
        /// <summary>
        /// 源文档 ID（选填）。
        /// 用于重新上传文档或修改文档清洗、分段配置，缺失的信息从源文档复制。
        /// 源文档不可为归档的文档。
        /// 当传入 original_document_id 时，代表文档进行更新操作，process_rule 为可填项目，不填默认使用源文档的分段方式。
        /// 未传入 original_document_id 时，代表文档进行新增操作，process_rule 为必填。
        /// Original document ID (optional).
        /// Used for re - uploading a document or modifying document cleaning and segmentation configurations. Missing information will be copied from the source document.
        /// The source document cannot be an archived document.
        /// When original_document_id is provided, it indicates a document update operation, and process_rule is optional. If not provided, the segmentation method of the source document will be used by default.
        /// When original_document_id is not provided, it indicates a new document creation operation, and process_rule is required.
        /// </summary>
        public string original_document_id { get; set; } = string.Empty;

        /// <summary>
        /// 索引方式。
        /// high_quality 高质量：使用 embedding 模型进行嵌入，构建为向量数据库索引。
        /// economy 经济：使用 keyword table index 的倒排索引进行构建。
        /// Indexing technique.
        /// high_quality: Use an embedding model for embedding and build a vector database index.
        /// economy: Use an inverted index of keyword table index for construction.
        /// </summary>
        public string indexing_technique { get; set; } = IndexingTechnique.HighQuality;

        /// <summary>
        /// 索引内容的形式。
        /// text_model text 文档直接 embedding，经济模式默认为该模式。
        /// hierarchical_model parent - child 模式。
        /// qa_model QA 模式：为分片文档生成 QA 对，然后对问题进行 embedding。
        /// Form of the indexed content.
        /// text_model: Directly embed the text document. This is the default mode for the economy mode.
        /// hierarchical_model: Parent - child mode.
        /// qa_model: QA mode. Generate QA pairs for the segmented document and then embed the questions.
        /// </summary>
        public string? doc_form { get; set; } = DocForm.TextModel;

        /// <summary>
        /// 在 QA 模式下，指定文档的语言，例如：English、Chinese。
        /// In the QA mode, specify the language of the document, e.g., English, Chinese.
        /// </summary>
        public string? doc_language { get; set; } = DocLanguage.Chinese;

        /// <summary>
        /// 处理规则。
        /// Processing rules.
        /// </summary>
        public ProcessRule process_rule { get; set; } = new ProcessRule
        {
            mode = ProcessRuleMode.Custom,
            rules = new Rules
            {
                pre_processing_rules = new List<PreProcessingRule>
              {
                    new PreProcessingRule {
                id = "remove_extra_spaces",
                enabled = true },
            //new PreProcessingRule
            //{
            //    id = "remove_urls_emails",
            //    enabled = true
            //}
               },
                segmentation = new Segmentation
                {
                    separator = "###",
                    max_tokens = 500
                }
            }
        };


        ///// <summary>
        ///// 需要上传的文件。
        ///// The file to be uploaded.
        ///// </summary>
        //public System.IO.Stream file { get; set; }

        /// <summary>
        /// 检索模式。
        /// Retrieval mode.
        /// </summary>
        public RetrievalModel? retrieval_model { get; set; }=new RetrievalModel();

        /// <summary>
        /// Embedding 模型名称。
        /// Name of the embedding model.
        /// </summary>
        public string embedding_model { get; set; } = string.Empty;

        /// <summary>
        /// Embedding 模型供应商。
        /// Provider of the embedding model.
        /// </summary>
        public string embedding_model_provider { get; set; } = string.Empty;
    }




}
