using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
   
    /// <summary>
    /// 更新文档元数据的请求类
    /// Request class for updating document metadata
    /// </summary>
    public class UpdateDocumentsMetadataRequest
    {
        /// <summary>
        /// 更新文档元数据的请求类
        /// Request class for updating document metadata
        /// </summary>
        public UpdateDocumentsMetadataRequest() { }

        /// <summary>
        /// 更新文档元数据的请求类，若需要传递多个，请自己实例化metadata_list属性
        /// </summary>
        /// <param name="document_id">文档id</param>
        /// <param name="metadata_id">元数据的id</param>
        /// <param name="metadata_value">元数据的值</param>
        /// <param name="metadata_name">必须传递元数据的名称，要保证和系统中的一致。否则更新失败</param>
        public UpdateDocumentsMetadataRequest(string document_id,string metadata_id, string metadata_value, string metadata_name)
        {
            this.operation_data= new List<DocumentMetadata>();
            DocumentMetadata documentMetadata = new DocumentMetadata();
            documentMetadata.document_id = document_id;
            documentMetadata.metadata_list= new List<MetadataItem>();
            documentMetadata.metadata_list.Add(new MetadataItem() { id= metadata_id,value=metadata_value,name= metadata_name });
            this.operation_data.Add(documentMetadata);

        }
        /// <summary>
        /// 操作数据列表，包含文档及其元数据信息
        /// List of operation data, containing document and its metadata information
        /// </summary>
        public List<DocumentMetadata>? operation_data { get; set; }=new List<DocumentMetadata>();
    }

    /// <summary>
    /// 文档元数据类，包含文档 ID 和元数据列表
    /// Document metadata class, containing document ID and metadata list
    /// </summary>
    public class DocumentMetadata
    {
       
        /// <summary>
        /// 文档的唯一标识符
        /// Unique identifier of the document
        /// </summary>
        public string? document_id { get; set; }

        /// <summary>
        /// 文档的元数据项列表
        /// List of metadata items for the document
        /// </summary>
        public List<MetadataItem>? metadata_list { get; set; }=new List<MetadataItem>();    
    }

    /// <summary>
    /// 元数据项类，包含元数据的 ID、值和名称
    /// Metadata item class, containing metadata ID, value and name
    /// </summary>
    public class MetadataItem
    {
        /// <summary>
        /// 元数据项的唯一标识符
        /// Unique identifier of the metadata item
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// 元数据项的值
        /// Value of the metadata item
        /// </summary>
        public string? value { get; set; }

        /// <summary>
        /// 元数据项的名称
        /// Name of the metadata item
        /// </summary>
        public string? name { get; set; }
    }
}
