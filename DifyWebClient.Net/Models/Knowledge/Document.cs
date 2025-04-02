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
    /// 表示文档的类，包含了文档的各种属性
    /// Represents the document, which contains various attributes of the document.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// 文档的唯一标识符，用于在系统中唯一标识一个文档
        /// Unique identifier of the document, used to uniquely identify a document in the system.
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 文档的位置，可能表示文档在某个列表或存储中的位置
        /// Position of the document, which may indicate the position of the document in a list or storage.
        /// </summary>
        public long position { get; set; } = 0;

        /// <summary>
        /// 数据源类型，指定文档数据的来源类型，如文件、数据库等
        /// Type of the data source, specifying the type of the source from which the document data comes, such as file, database, etc.
        /// </summary>
        public string data_source_type { get; set; } = string.Empty;

        /// <summary>
        /// 数据源信息，包含了与数据源相关的详细信息
        /// Information about the data source, which contains detailed information related to the data source.
        /// </summary>
        public DataSourceInfo data_source_info { get; set; } = new DataSourceInfo();

        /// <summary>
        /// 数据源详细字典，存储了数据源的详细配置信息
        /// Dictionary containing detailed information about the data source, storing detailed configuration information of the data source.
        /// </summary>
        public DataSourceDetailDict data_source_detail_dict { get; set; } = new DataSourceDetailDict();

        /// <summary>
        /// 数据集处理规则的唯一标识符，用于指定文档数据处理的规则
        /// Unique identifier of the dataset processing rule, used to specify the rules for processing the document data.
        /// </summary>
        public string dataset_process_rule_id { get; set; } = string.Empty;

        /// <summary>
        /// 文档的名称，用于标识文档的名称
        /// Name of the document, used to identify the name of the document.
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 文档的创建来源，指示文档是从何处创建的，如用户上传、系统生成等
        /// Source from which the document was created, indicating where the document was created from, such as user upload, system generation, etc.
        /// </summary>
        public string created_from { get; set; } = string.Empty;

        /// <summary>
        /// 创建文档的用户，记录创建该文档的用户信息
        /// User who created the document, recording the information of the user who created the document.
        /// </summary>
        public string created_by { get; set; } = string.Empty;

        /// <summary>
        /// 文档的创建时间（Unix 时间戳），记录文档创建的时间
        /// Creation time of the document (Unix timestamp), recording the time when the document was created.
        /// </summary>
        public long created_at { get; set; } = 0;

        /// <summary>
        /// 文档的 Token 数量，用于衡量文档的长度或复杂度
        /// Number of tokens in the document, used to measure the length or complexity of the document.
        /// </summary>
        public long tokens { get; set; } = 0;

        /// <summary>
        /// 索引状态，指示文档的索引处理状态，如已索引、未索引等
        /// Indexing status, indicating the indexing processing status of the document, such as indexed, not indexed, etc.
        /// </summary>
        public string indexing_status { get; set; } = string.Empty;

        /// <summary>
        /// 错误信息，记录文档创建或处理过程中出现的错误信息
        /// Error information, recording the error information that occurred during the creation or processing of the document.
        /// </summary>
        public string error { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用，指示文档是否处于可用状态
        /// Whether the document is enabled, indicating whether the document is in an available state.
        /// </summary>
        public bool enabled { get; set; } = true;

        /// <summary>
        /// 文档的禁用时间（可为 null），记录文档被禁用的时间
        /// Time when the document was disabled (nullable), recording the time when the document was disabled.
        /// </summary>
        public long? disabled_at { get; set; } = null;

        /// <summary>
        /// 禁用文档的用户，记录禁用该文档的用户信息
        /// User who disabled the document, recording the information of the user who disabled the document.
        /// </summary>
        public string disabled_by { get; set; } = string.Empty;

        /// <summary>
        /// 是否存档，指示文档是否已被存档
        /// Whether the document is archived, indicating whether the document has been archived.
        /// </summary>
        public bool archived { get; set; } = false;

        /// <summary>
        /// 显示状态，指示文档在界面上的显示状态
        /// Display status, indicating the display status of the document on the interface.
        /// </summary>
        public string display_status { get; set; } = string.Empty;

        /// <summary>
        /// 文档的字数统计，记录文档中的字数
        /// Word count of the document, recording the number of words in the document.
        /// </summary>
        public long word_count { get; set; } = 0;

        /// <summary>
        /// 文档的访问次数，记录文档被访问的次数
        /// Number of times the document has been accessed, recording the number of times the document has been accessed.
        /// </summary>
        public long hit_count { get; set; } = 0;

        /// <summary>
        /// 文档的形式，指定文档的格式或类型，如文本、图片等
        /// Form of the document, specifying the format or type of the document, such as text, image, etc.
        /// </summary>
        public string doc_form { get; set; } = string.Empty;

        /// <summary>
        /// 文档的元数据信息，包含了与文档相关的额外信息
        /// Metadata information of the document, containing additional information related to the document.
        /// </summary>
        public object? doc_metadata { get; set; } = null;
    }
}
