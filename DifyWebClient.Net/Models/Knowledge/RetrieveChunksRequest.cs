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
    /// 检索块请求类，包含查询信息和检索模型配置。
    /// Retrieve chunks request class, containing query information and retrieval model configuration.
    /// </summary>
    public class RetrieveChunksRequest
    {
        /// <summary>
        /// 检索块请求类，包含查询信息和检索模型配置。
        /// Retrieve chunks request class, containing query information and retrieval model configuration.
        /// </summary>
        public RetrieveChunksRequest() { }
        /// <summary>
        /// 检索块请求类，包含查询信息和检索模型配置。
        /// Retrieve chunks request class, containing query information and retrieval model configuration. 
        /// </summary>
        /// <param name="query"></param>
        public RetrieveChunksRequest(string query) 
        { 
            this.query = query;
        }
        /// <summary>
        /// 查询关键词，例如“热更新”。
        /// Query keyword, e.g., "Hot update".
        /// </summary>
        public string? query { get; set; }

        /// <summary>
        /// 检索模型的配置信息。
        /// Configuration information of the retrieval model.
        /// </summary>
        public RetrieveChunksRequestRetrievalModel? retrieval_model { get; set; } = new RetrieveChunksRequestRetrievalModel
        {
            search_method = SearchMethod.KeywordSearch,
            reranking_enable = false,
            reranking_mode = null,
            reranking_model = new RetrieveChunksRequestRerankingModel
            {
                reranking_provider_name = "",
                reranking_model_name = ""
            },
            weights = null,
            //top_k = 1,
            score_threshold_enabled = false,
            score_threshold = null
        };
    }

    /// <summary>
    /// 检索块请求的检索模型类，定义了检索的方法、重排序设置等。
    /// Retrieval model class for retrieve chunks request, defining retrieval methods, re - ranking settings, etc.
    /// </summary>
    public class RetrieveChunksRequestRetrievalModel
    {
        /// <summary>
        /// 搜索方法，如“keyword_search”表示关键词搜索。
        /// Search method, e.g., "keyword_search" indicates keyword search.
        /// </summary>
        public string? search_method { get; set; }

        /// <summary>
        /// 是否启用重排序功能。
        /// Whether to enable the re - ranking function.
        /// </summary>
        public bool? reranking_enable { get; set; }

        /// <summary>
        /// 重排序模式，可为 null。
        /// Re - ranking mode, can be null.
        /// </summary>
        public object? reranking_mode { get; set; }

        /// <summary>
        /// 重排序模型的详细信息。
        /// Detailed information of the re - ranking model.
        /// </summary>
        public RetrieveChunksRequestRerankingModel? reranking_model { get; set; }

        /// <summary>
        /// 权重信息，可为 null。
        /// Weight information, can be null.
        /// </summary>
        public object? weights { get; set; }

        /// <summary>
        /// 检索结果的前 k 个。
        /// The top k retrieval results.
        /// </summary>
        public long? top_k { get; set; }

        /// <summary>
        /// 是否启用分数阈值过滤。
        /// Whether to enable score threshold filtering.
        /// </summary>
        public bool? score_threshold_enabled { get; set; }

        /// <summary>
        /// 分数阈值，可为 null。
        /// Score threshold, can be null.
        /// </summary>
        public object? score_threshold { get; set; }
    }

    /// <summary>
    /// 检索块请求的重排序模型类，包含提供者名称和模型名称。
    /// Re - ranking model class for retrieve chunks request, containing the provider name and model name.
    /// </summary>
    public class RetrieveChunksRequestRerankingModel
    {
        /// <summary>
        /// 重排序模型的提供者名称。
        /// The provider name of the re - ranking model.
        /// </summary>
        public string? reranking_provider_name { get; set; }

        /// <summary>
        /// 重排序模型的名称。
        /// The name of the re - ranking model.
        /// </summary>
        public string? reranking_model_name { get; set; }
    }


}
