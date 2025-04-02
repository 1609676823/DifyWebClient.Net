using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DifyWebClient.Net
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DecodeUnicode(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string DecodeJson(string json)
        {
            string DecodeJson = string.Empty;
            try
            {
                using (JsonDocument document = JsonDocument.Parse(json))
                {
                    DecodeJson = JsonSerializer.Serialize(document.RootElement, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                }
            }
            catch (Exception)
            {
                DecodeJson = json;
                //throw;
            }
            if (string.IsNullOrWhiteSpace(DecodeJson))
            {
                DecodeJson = json;
            }
            return DecodeJson;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveDataPrefix(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            try
            {


                string trimmedInput = input.Trim();
                int index = trimmedInput.IndexOf("data:", StringComparison.OrdinalIgnoreCase);

                if (index == 0)
                {
                    return trimmedInput.Substring(5).Trim();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return input;
        }


        /// <summary>
        /// 根据文件名或文件完整路径获取对应的 MIME 类型。
        /// Get the corresponding MIME type based on the file name or full file path.
        /// </summary>
        /// <param name="fileInput">文件名或文件完整路径，例如 "example.mp3"、"C:\files\example.mp3" 等。
        /// The file name or full file path, such as "example.mp3", "C:\files\example.mp3", etc.</param>
        /// <returns>返回对应的 MIME 类型，如果未找到匹配则返回 "application/octet-stream"。
        /// Returns the corresponding MIME type, or "application/octet-stream" if no match is found.</returns>
        public static string GetMimeType(string fileInput)
        {
            if (string.IsNullOrEmpty(fileInput))
            {
                return "application/octet-stream";
            }

            // 提取文件扩展名
            string fileExtension = System.IO.Path.GetExtension(fileInput);
            if (string.IsNullOrEmpty(fileExtension))
            {
                return "application/octet-stream";
            }

            fileExtension = fileExtension.TrimStart('.').ToLower();

            switch (fileExtension)
            {
                // 文本类型
                // Text types
                case "txt":
                    return "text/plain"; // 纯文本
                case "csv":
                    return "text/csv"; // CSV 格式文本
                case "html":
                case "htm":
                    return "text/html"; // HTML 网页
                case "css":
                    return "text/css"; // CSS 样式表
                case "js":
                    return "application/javascript"; // JavaScript 脚本

                // 图像类型
                // Image types
                case "jpg":
                case "jpeg":
                    return "image/jpeg"; // JPEG 图像
                case "png":
                    return "image/png"; // PNG 图像
                case "gif":
                    return "image/gif"; // GIF 图像
                case "bmp":
                    return "image/bmp"; // BMP 图像
                case "svg":
                    return "image/svg+xml"; // SVG 矢量图像

                // 音频类型
                // Audio types
                case "mp3":
                case "mpga":
                    return "audio/mpeg"; // MP3 音频
                case "wav":
                    return "audio/wav"; // WAV 音频
                case "m4a":
                    return "audio/mp4"; // M4A 音频

                // 视频类型
                // Video types
                case "mp4":
                    return "video/mp4"; // MP4 视频
                case "mpeg":
                    return "video/mpeg"; // MPEG 视频
                case "webm":
                    return "video/webm"; // WebM 视频

                // 文档类型
                // Document types
                case "pdf":
                    return "application/pdf"; // PDF 文档
                case "doc":
                    return "application/msword"; // 旧版 Word 文档
                case "docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; // 新版 Word 文档
                case "xls":
                    return "application/vnd.ms-excel"; // 旧版 Excel 文档
                case "xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // 新版 Excel 文档
                case "ppt":
                    return "application/vnd.ms-powerpoint"; // 旧版 PowerPoint 文档
                case "pptx":
                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation"; // 新版 PowerPoint 文档

                // 压缩文件类型
                // Compressed file types
                case "zip":
                    return "application/zip"; // ZIP 压缩文件
                case "rar":
                    return "application/vnd.rar"; // RAR 压缩文件
                case "7z":
                    return "application/x-7z-compressed"; // 7-Zip 压缩文件

                default:
                    // 如果未找到匹配的扩展名，则返回通用的二进制数据 MIME 类型。
                    // If no matching extension is found, return the generic binary data MIME type.
                    return "application/octet-stream";
            }
        }


    }
}
