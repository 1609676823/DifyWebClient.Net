using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.ChatApp
{
    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006 
    /// <summary>
    /// (array[RetrieverResource]) 引用和归属分段列表
    /// (array[RetrieverResource]) Citation and Attribution List
    /// </summary>
    public class RetrieverResource
    {
        /// <summary>
        /// 数据集 ID
        /// Dataset ID
        /// </summary>
        public string? dataset_id { get; set; } = string.Empty;

        /// <summary>
        /// 数据集名称
        /// Dataset Name
        /// </summary>
        public string? dataset_name { get; set; } = string.Empty;

        /// <summary>
        /// 文档 ID
        /// Document ID
        /// </summary>
        public string? document_id { get; set; } = string.Empty;

        /// <summary>
        /// 文档名称
        /// Document Name
        /// </summary>
        public string? document_name { get; set; } = string.Empty;

        /// <summary>
        /// 数据源类型
        /// Data Source Type
        /// </summary>
        public string? data_source_type { get; set; } = string.Empty;

        /// <summary>
        /// 段 ID
        /// Segment ID
        /// </summary>
        public string? segment_id { get; set; } = string.Empty;

        /// <summary>
        /// 获取方式
        /// How it was retrieved
        /// </summary>
        public string? retriever_from { get; set; } = string.Empty;

        /// <summary>
        /// 评分
        /// Score
        /// </summary>
        public double? score { get; set; }

        /// <summary>
        /// 文档元数据
        /// Document metadata
        /// </summary>
        public object? doc_metadata { get; set; }

        /// <summary>
        /// 内容
        /// Content
        /// </summary>
        public string? content { get; set; } = string.Empty;

        /// <summary>
        /// 位置
        /// Position
        /// </summary>
        public long? position { get; set; }

        /// <summary>
        /// 命中计数
        /// Hit count
        /// </summary>
        public long? hit_count { get; set; }

        /// <summary>
        /// 单词计数
        /// Word count
        /// </summary>
        public long? word_count { get; set; }

        /// <summary>
        /// 分段位置
        /// Segment position
        /// </summary>
        public long? segment_position { get; set; }

        /// <summary>
        /// 索引节点哈希值
        /// Index node hash value
        /// </summary>
        public string? index_node_hash { get; set; }

        /// <summary>
        /// 页面对象
        /// Page object
        /// </summary>
        public object? page { get; set; }

    }

}
