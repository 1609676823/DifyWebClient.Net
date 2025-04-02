using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyWebClient.Net
{
    /// <summary>
    /// 文件转换器，协助上传文件使用
    /// </summary>
    public class FileToBinaryConverter
    {
        /// <summary>
        /// 将 Base64 字符串转换为二进制数据
        /// Converts a Base64 string to binary data
        /// </summary>
        /// <param name="base64String">Base64 字符串 / Base64 string</param>
        /// <returns>二进制数据 / Binary data</returns>
        /// <exception cref="ArgumentException">当 Base64 字符串为空或 null 时抛出 / Thrown when the Base64 string is null or empty</exception>
        public static byte[] ConvertBase64ToBinary(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentException("Base64 string cannot be null or empty.");
            }

            return System.Convert.FromBase64String(base64String);
        }

        /// <summary>
        /// 将文件路径指向的文件内容转换为二进制数据
        /// Converts the contents of a file specified by the file path to binary data
        /// </summary>
        /// <param name="filePath">文件路径 / File path</param>
        /// <returns>二进制数据 / Binary data</returns>
        /// <exception cref="ArgumentException">当文件路径为空或 null 时抛出 / Thrown when the file path is null or empty</exception>
        /// <exception cref="System.IO.FileNotFoundException">当文件未找到时抛出 / Thrown when the file is not found</exception>
        public static byte[] ConvertFileToBinary(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.");
            }

            if (!System.IO.File.Exists(filePath))
            {
                throw new System.IO.FileNotFoundException("File not found.", filePath);
            }

            return System.IO.File.ReadAllBytes(filePath);
        }

        /// <summary>
        /// 将 URL 指向的内容转换为二进制数据
        /// Converts the contents of a URL to binary data
        /// </summary>
        /// <param name="url">URL 地址 / URL address</param>
        /// <returns>二进制数据 / Binary data</returns>
        /// <exception cref="ArgumentException">当 URL 为空或 null 时抛出 / Thrown when the URL is null or empty</exception>
        /// <exception cref="Exception">当从 URL 获取数据时出错时抛出 / Thrown when there is an error fetching data from the URL</exception>
        public static byte[] ConvertUrlToBinary(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be null or empty.");
            }

            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsByteArrayAsync().Result;
                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new Exception("Error fetching data from URL: " + e.Message, e);
            }
        }


        /// <summary>
        /// 此方法用于将字节数组转换为文件并保存到指定路径。
        /// This method is used to convert a byte array into a file and save it to the specified path.
        /// </summary>
        /// <param name="filebyte">要转换为文件的字节数组。The byte array to be converted into a file.</param>
        /// <param name="filepath">文件要保存到的路径。The path where the file will be saved.</param>
        public static void ConvertByteArrayToFile(byte[] filebyte, string filepath)
        {
            try
            {
                // 将字节数组写入指定的文件路径。
                // Write the byte array to the specified file path.
                File.WriteAllBytes(filepath, filebyte);
            }
            catch (Exception ex)
            {
                // 这里可以根据需要添加日志记录等操作。
                // Here, you can add operations such as logging according to your needs.
                throw new Exception("Error ConvertByteArrayToFile;" + ex.Message);
            }
        }

        /// <summary>
        /// 此方法用于将字节数组转换为 Base64 编码的字符串。
        /// This method is used to convert a byte array to a Base64-encoded string.
        /// </summary>
        /// <param name="filebyte">要转换的字节数组。The byte array to be converted.</param>
        /// <returns>Base64 编码的字符串。A Base64-encoded string.</returns>
        public static string ConvertByteArrayToBase64(byte[] filebyte)
        {
            return Convert.ToBase64String(filebyte);
        }
    }
}
