using DifyWebClient.Net.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Models.Knowledge
{
    /// <summary>
    /// 基于文件进行更新的请求类
    /// Request class for updating by file
    /// </summary>
    public class UpdateByFileRequest
    {
        /// <summary>
        /// 基于文件进行更新的请求类
        /// Request class for updating by file
        /// </summary>
        public UpdateByFileRequest() { }
        /// <summary>
        /// 基于文件进行更新的请求类
        /// Request class for updating by file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="indexing_technique"></param>
        /// <param name="process_rule"></param>
        public UpdateByFileRequest(string name,string indexing_technique, ProcessRule process_rule)
        { 
            this.name = name;
            this.indexing_technique = indexing_technique;
            this.process_rule = process_rule;
        }
        /// <summary>
        /// 文件名，例如 "demo.txt"
        /// File name, e.g., "demo.txt"
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// 索引技术，如 "high_quality"
        /// Indexing technique, e.g., "high_quality"
        /// </summary>
        public string? indexing_technique { get; set; }=IndexingTechnique.HighQuality;

        /// <summary>
        /// 处理规则
        /// Processing rules
        /// </summary>
        public ProcessRule? process_rule { get; set; }= new ProcessRule
        {
            mode = ProcessRuleMode.Custom,
            rules = new Rules
            {
                pre_processing_rules = new List<PreProcessingRule>
            {
                new PreProcessingRule
                {
                    id = "remove_extra_spaces",
                    enabled = true
                },
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
    }
}

