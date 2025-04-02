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
    /// 模型用量信息
    /// Model usage information
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// 提示标记数
        /// Prompt tokens
        /// </summary>
        public long? prompt_tokens { get; set; }

        /// <summary>
        /// 提示单位价格
        /// Prompt unit price
        /// </summary>
        public string? prompt_unit_price { get; set; } = string.Empty;

        /// <summary>
        /// 提示价格单位
        /// Prompt price unit
        /// </summary>
        public string? prompt_price_unit { get; set; } = string.Empty;

        /// <summary>
        /// 提示价格
        /// Prompt price
        /// </summary>
        public string? prompt_price { get; set; } = string.Empty;

        /// <summary>
        /// 完成标记数
        /// Completion tokens
        /// </summary>
        public long? completion_tokens { get; set; }

        /// <summary>
        /// 完成单位价格
        /// Completion unit price
        /// </summary>
        public string? completion_unit_price { get; set; } = string.Empty;

        /// <summary>
        /// 完成价格单位
        /// Completion price unit
        /// </summary>
        public string? completion_price_unit { get; set; } = string.Empty;

        /// <summary>
        /// 完成价格
        /// Completion price
        /// </summary>
        public string? completion_price { get; set; } = string.Empty;

        /// <summary>
        /// 总标记数
        /// Total tokens
        /// </summary>
        public long? total_tokens { get; set; }

        /// <summary>
        /// 总价格
        /// Total price
        /// </summary>
        public string? total_price { get; set; } 

        /// <summary>
        /// 货币
        /// Currency
        /// </summary>
        public string? currency { get; set; } = string.Empty;

        /// <summary>
        /// 延迟
        /// Latency
        /// </summary>
        public double? latency { get; set; }
    }


}
