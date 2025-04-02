using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net.Enum
{
    /// <summary>
    /// 文件列表，适用于传入文件结合文本理解并回答问题，仅当模型支持 Vision 能力时可用。type(string) 支持类型：
    /// File list, suitable for inputting files combined with text understanding and answering questions, available only when the model supports Vision capability.type(string) Supported type
    /// </summary>
    public static class FilesType
    {
        /// <summary>
        /// document ('TXT', 'MD', 'MARKDOWN', 'PDF', 'HTML', 'XLSX', 'XLS', 'DOCX', 'CSV', 'EML', 'MSG', 'PPTX', 'PPT', 'XML', 'EPUB')
        /// </summary>
        public const string Document = "document";
        /// <summary>
        /// image ('JPG', 'JPEG', 'PNG', 'GIF', 'WEBP', 'SVG')
        /// </summary>
        public const string Image = "image";
        /// <summary>
        /// audio ('MP3', 'M4A', 'WAV', 'WEBM', 'AMR')
        /// </summary>
        public const string Audio = "audio";
        /// <summary>
        /// video ('MP4', 'MOV', 'MPEG', 'MPGA')
        /// </summary>
        public const string Video = "video";
        /// <summary>
        /// custom (Other file types)
        /// </summary>
        public const string Custom = "custom";
    }
}
