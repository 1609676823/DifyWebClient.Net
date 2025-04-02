using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace DifyWebClient.Net.Models.Base
{

    // 禁用 IDE1006 命名风格警告
    // Disable the IDE1006 naming style warning
#pragma warning disable IDE1006
    /// <summary>
    /// 用于获取参数响应的类，包含了各种配置参数信息。
    /// Class used for the response of getting parameters, containing various configuration parameter information.
    /// </summary>
    public class GetParametersResponse
    {
        /// <summary>
        /// 开场陈述内容
        /// The content of the opening statement
        /// </summary>
        public string? opening_statement { get; set; }

        /// <summary>
        /// 建议的问题列表
        /// The list of suggested questions
        /// </summary>
        public List<string>? suggested_questions { get; set; }

        /// <summary>
        /// 回答后建议问题的配置信息
        /// Configuration information for suggested questions after an answer
        /// </summary>
        public SuggestedQuestionsAfterAnswer? suggested_questions_after_answer { get; set; }

        /// <summary>
        /// 语音转文本的配置信息
        /// Configuration information for speech-to-text
        /// </summary>
        public SpeechToText? speech_to_text { get; set; }

        /// <summary>
        /// 文本转语音的配置信息
        /// Configuration information for text-to-speech
        /// </summary>
        public TextToSpeech? text_to_speech { get; set; }

        /// <summary>
        /// 检索器资源的配置信息
        /// Configuration information for the retriever resource
        /// </summary>
        public ParametersResponseRetrieverResource? retriever_resource { get; set; }

        /// <summary>
        /// 注释回复的配置信息
        /// Configuration information for annotation reply
        /// </summary>
        public AnnotationReply? annotation_reply { get; set; }

        /// <summary>
        /// 更多类似内容的配置信息
        /// Configuration information for more like this
        /// </summary>
        public MoreLikeThis? more_like_this { get; set; }

        /// <summary>
        /// 用户输入表单的配置信息列表
        /// The list of configuration information for user input forms
        /// </summary>
        public List<Dictionary<string,object>>? user_input_form { get; set; }

        /// <summary>
        /// 敏感词规避的配置信息
        /// Configuration information for sensitive word avoidance
        /// </summary>
        public SensitiveWordAvoidance? sensitive_word_avoidance { get; set; }

        /// <summary>
        /// 文件上传的配置信息
        /// Configuration information for file upload
        /// </summary>
        public FileUpload? file_upload { get; set; }

        /// <summary>
        /// 系统参数的配置信息
        /// Configuration information for system parameters
        /// </summary>
        public SystemParameters? system_parameters { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        private string? realJsonstring = null;

        /// <summary>
        /// 获取或设置响应的真实 JSON 字符串表示。
        /// Gets or sets the real JSON string representation of the response.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public string? RealJsonstring
        {
            get { return realJsonstring; }
            set
            {
                realJsonstring = value;
                try
                {
                    DeserializeGetParametersResponse(value!);
                }
                catch
                {
                    // 这里可以添加日志记录等操作，当前只是简单忽略异常
                }
            }
        }

        private void DeserializeGetParametersResponse(string json)
        {
            var jsonNode = JsonNode.Parse(json);
            if (jsonNode != null)
            {
                try
                {
                    opening_statement = jsonNode["opening_statement"]?.GetValue<string>();
                }
                catch
                {
                }

                try
                {
                    suggested_questions = new List<string>();
                    var suggestedQuestionsArray = jsonNode["suggested_questions"] as JsonArray;
                    if (suggestedQuestionsArray != null)
                    {
                        foreach (var item in suggestedQuestionsArray)
                        {
                            if (item != null)
                            {
                                suggested_questions.Add(item.GetValue<string>());
                            }
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    suggested_questions_after_answer = new SuggestedQuestionsAfterAnswer();
                    var suggestedQuestionsAfterAnswerNode = jsonNode["suggested_questions_after_answer"];
                    if (suggestedQuestionsAfterAnswerNode != null)
                    {
                        try
                        {
                            suggested_questions_after_answer.enabled = suggestedQuestionsAfterAnswerNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    speech_to_text = new SpeechToText();
                    var speechToTextNode = jsonNode["speech_to_text"];
                    if (speechToTextNode != null)
                    {
                        try
                        {
                            speech_to_text.enabled = speechToTextNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    text_to_speech = new TextToSpeech();
                    var textToSpeechNode = jsonNode["text_to_speech"];
                    if (textToSpeechNode != null)
                    {
                        try
                        {
                            text_to_speech.enabled = textToSpeechNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                        try
                        {
                            text_to_speech.voice = textToSpeechNode["voice"]?.GetValue<string>();
                        }
                        catch
                        {
                        }
                        try
                        {
                            text_to_speech.language = textToSpeechNode["language"]?.GetValue<string>();
                        }
                        catch
                        {
                        }
                        try
                        {
                            text_to_speech.autoPlay = textToSpeechNode["autoPlay"]?.GetValue<string>();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    retriever_resource = new ParametersResponseRetrieverResource();
                    var ParametersResponseRetrieverResourceNode = jsonNode["retriever_resource"];
                    if (ParametersResponseRetrieverResourceNode != null)
                    {
                        try
                        {
                            retriever_resource.enabled = ParametersResponseRetrieverResourceNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    annotation_reply = new AnnotationReply();
                    var annotationReplyNode = jsonNode["annotation_reply"];
                    if (annotationReplyNode != null)
                    {
                        try
                        {
                            annotation_reply.enabled = annotationReplyNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    more_like_this = new MoreLikeThis();
                    var moreLikeThisNode = jsonNode["more_like_this"];
                    if (moreLikeThisNode != null)
                    {
                        try
                        {
                            more_like_this.enabled = moreLikeThisNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    user_input_form = new List<Dictionary<string, object>>();
                    var userInputFormArray = jsonNode["user_input_form"] as JsonArray;
                    foreach (JsonNode itemuserInput in userInputFormArray!)
                    {
                        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                        foreach (var keyValue in itemuserInput.AsObject())
                        {
                            keyValuePairs.Add(keyValue.Key, keyValue.Value!);
                        }
                        user_input_form.Add(keyValuePairs);
                    }

                }
                catch
                {
                }

                try
                {
                    sensitive_word_avoidance = new SensitiveWordAvoidance();
                    var sensitiveWordAvoidanceNode = jsonNode["sensitive_word_avoidance"];
                    if (sensitiveWordAvoidanceNode != null)
                    {
                        try
                        {
                            sensitive_word_avoidance.enabled = sensitiveWordAvoidanceNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    file_upload = new FileUpload();
                    var fileUploadNode = jsonNode["file_upload"];
                    if (fileUploadNode != null)
                    {
                        try
                        {
                            file_upload.image = new ImageUpload();
                            var imageNode = fileUploadNode["image"];
                            if (imageNode != null)
                            {
                                try
                                {
                                    file_upload.image.enabled = imageNode["enabled"]?.GetValue<bool>() ?? false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.image.number_limits = imageNode["number_limits"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.image.transfer_methods = new List<string>();
                                    var transferMethodsArray = imageNode["transfer_methods"] as JsonArray;
                                    if (transferMethodsArray != null)
                                    {
                                        foreach (var method in transferMethodsArray)
                                        {
                                            if (method != null)
                                            {
                                                file_upload.image.transfer_methods.Add(method.GetValue<string>());
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.enabled = fileUploadNode["enabled"]?.GetValue<bool>() ?? false;
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.allowed_file_types = new List<string>();
                            var allowedFileTypesArray = fileUploadNode["allowed_file_types"] as JsonArray;
                            if (allowedFileTypesArray != null)
                            {
                                foreach (var type in allowedFileTypesArray)
                                {
                                    if (type != null)
                                    {
                                        file_upload.allowed_file_types.Add(type.GetValue<string>());
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.allowed_file_extensions = new List<string>();
                            var allowedFileExtensionsArray = fileUploadNode["allowed_file_extensions"] as JsonArray;
                            if (allowedFileExtensionsArray != null)
                            {
                                foreach (var ext in allowedFileExtensionsArray)
                                {
                                    if (ext != null)
                                    {
                                        file_upload.allowed_file_extensions.Add(ext.GetValue<string>());
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.allowed_file_upload_methods = new List<string>();
                            var allowedFileUploadMethodsArray = fileUploadNode["allowed_file_upload_methods"] as JsonArray;
                            if (allowedFileUploadMethodsArray != null)
                            {
                                foreach (var method in allowedFileUploadMethodsArray)
                                {
                                    if (method != null)
                                    {
                                        file_upload.allowed_file_upload_methods.Add(method.GetValue<string>());
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.number_limits = fileUploadNode["number_limits"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                        try
                        {
                            file_upload.fileUploadConfig = new FileUploadConfig();
                            var configNode = fileUploadNode["fileUploadConfig"];
                            if (configNode != null)
                            {
                                try
                                {
                                    file_upload.fileUploadConfig.file_size_limit = configNode["file_size_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.fileUploadConfig.batch_count_limit = configNode["batch_count_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.fileUploadConfig.image_file_size_limit = configNode["image_file_size_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.fileUploadConfig.video_file_size_limit = configNode["video_file_size_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.fileUploadConfig.audio_file_size_limit = configNode["audio_file_size_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    file_upload.fileUploadConfig.workflow_file_upload_limit = configNode["workflow_file_upload_limit"]?.GetValue<long>() ?? 0;
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    system_parameters = new SystemParameters();
                    var systemParametersNode = jsonNode["system_parameters"];
                    if (systemParametersNode != null)
                    {
                        try
                        {
                            system_parameters.image_file_size_limit = systemParametersNode["image_file_size_limit"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                        try
                        {
                            system_parameters.video_file_size_limit = systemParametersNode["video_file_size_limit"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                        try
                        {
                            system_parameters.audio_file_size_limit = systemParametersNode["audio_file_size_limit"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                        try
                        {
                            system_parameters.file_size_limit = systemParametersNode["file_size_limit"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                        try
                        {
                            system_parameters.workflow_file_upload_limit = systemParametersNode["workflow_file_upload_limit"]?.GetValue<long>() ?? 0;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }

    /// <summary>
    /// 回答后建议问题的配置类
    /// Configuration class for suggested questions after an answer
    /// </summary>
    public class SuggestedQuestionsAfterAnswer
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 语音转文本的配置类
    /// Configuration class for speech-to-text
    /// </summary>
    public class SpeechToText
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 文本转语音的配置类
    /// Configuration class for text-to-speech
    /// </summary>
    public class TextToSpeech
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 语音类型
        /// Voice type
        /// </summary>
        public string? voice { get; set; }

        /// <summary>
        /// 语言类型
        /// Language type
        /// </summary>
        public string? language { get; set; }

        /// <summary>
        /// 自动播放状态
        /// Auto-play status
        /// </summary>
        public string? autoPlay { get; set; }
    }

    /// <summary>
    /// 检索器资源的配置类
    /// Configuration class for the retriever resource
    /// </summary>
    public class ParametersResponseRetrieverResource
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 注释回复的配置类
    /// Configuration class for annotation reply
    /// </summary>
    public class AnnotationReply
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 更多类似内容的配置类
    /// Configuration class for more like this
    /// </summary>
    public class MoreLikeThis
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 用户输入表单项的配置类
    /// Configuration class for user input form items
    /// </summary>
    public class UserInputFormItem
    {
        /// <summary>
        /// 选择项的配置信息
        /// Configuration information for the select item
        /// </summary>
        public SelectItem? select { get; set; }
    }

    /// <summary>
    /// 选择项的配置类
    /// Configuration class for the select item
    /// </summary>
    public class SelectItem
    {
        /// <summary>
        /// 变量名
        /// Variable name
        /// </summary>
        public string? variable { get; set; }

        /// <summary>
        /// 标签名
        /// Label name
        /// </summary>
        public string? label { get; set; }

        /// <summary>
        /// 类型
        /// Type
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 最大长度
        /// Maximum length
        /// </summary>
        public long? max_length { get; set; }

        /// <summary>
        /// 是否为必填项
        /// Whether it is a required field
        /// </summary>
        public bool? required { get; set; }

        /// <summary>
        /// 选项列表
        /// List of options
        /// </summary>
        public List<string>? options { get; set; }
    }

    /// <summary>
    /// 敏感词规避的配置类
    /// Configuration class for sensitive word avoidance
    /// </summary>
    public class SensitiveWordAvoidance
    {
        /// <summary>
        /// 是否启用
        /// Whether it is enabled
        /// </summary>
        public bool? enabled { get; set; }
    }

    /// <summary>
    /// 文件上传的配置类
    /// Configuration class for file upload
    /// </summary>
    public class FileUpload
    {
        /// <summary>
        /// 图片上传的配置信息
        /// Configuration information for image upload
        /// </summary>
        public ImageUpload? image { get; set; }

        /// <summary>
        /// 是否启用文件上传
        /// Whether file upload is enabled
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 允许的文件类型列表
        /// List of allowed file types
        /// </summary>
        public List<string>? allowed_file_types { get; set; }

        /// <summary>
        /// 允许的文件扩展名列表
        /// List of allowed file extensions
        /// </summary>
        public List<string>? allowed_file_extensions { get; set; }

        /// <summary>
        /// 允许的文件上传方式列表
        /// List of allowed file upload methods
        /// </summary>
        public List<string>? allowed_file_upload_methods { get; set; }

        /// <summary>
        /// 文件数量限制
        /// File number limit
        /// </summary>
        public long? number_limits { get; set; }

        /// <summary>
        /// 文件上传的详细配置信息
        /// Detailed configuration information for file upload
        /// </summary>
        public FileUploadConfig? fileUploadConfig { get; set; }
    }

    /// <summary>
    /// 图片上传的配置类
    /// Configuration class for image upload
    /// </summary>
    public class ImageUpload
    {
        /// <summary>
        /// 是否启用图片上传
        /// Whether image upload is enabled
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 图片数量限制
        /// Image number limit
        /// </summary>
        public long? number_limits { get; set; }

        /// <summary>
        /// 传输方式列表
        /// List of transfer methods
        /// </summary>
        public List<string>? transfer_methods { get; set; }
    }

    /// <summary>
    /// 文件上传的详细配置类
    /// Detailed configuration class for file upload
    /// </summary>
    public class FileUploadConfig
    {
        /// <summary>
        /// 文件大小限制
        /// File size limit
        /// </summary>
        public long? file_size_limit { get; set; }

        /// <summary>
        /// 批量数量限制
        /// Batch count limit
        /// </summary>
        public long? batch_count_limit { get; set; }

        /// <summary>
        /// 图片文件大小限制
        /// Image file size limit
        /// </summary>
        public long? image_file_size_limit { get; set; }

        /// <summary>
        /// 视频文件大小限制
        /// Video file size limit
        /// </summary>
        public long? video_file_size_limit { get; set; }

        /// <summary>
        /// 音频文件大小限制
        /// Audio file size limit
        /// </summary>
        public long? audio_file_size_limit { get; set; }

        /// <summary>
        /// 工作流文件上传限制
        /// Workflow file upload limit
        /// </summary>
        public long? workflow_file_upload_limit { get; set; }
    }

    /// <summary>
    /// 系统参数的配置类
    /// Configuration class for system parameters
    /// </summary>
    public class SystemParameters
    {
        /// <summary>
        /// 图片文件大小限制
        /// Image file size limit
        /// </summary>
        public long? image_file_size_limit { get; set; }

        /// <summary>
        /// 视频文件大小限制
        /// Video file size limit
        /// </summary>
        public long? video_file_size_limit { get; set; }

        /// <summary>
        /// 音频文件大小限制
        /// Audio file size limit
        /// </summary>
        public long? audio_file_size_limit { get; set; }

        /// <summary>
        /// 文件大小限制
        /// File size limit
        /// </summary>
        public long? file_size_limit { get; set; }

        /// <summary>
        /// 工作流文件上传限制
        /// Workflow file upload limit
        /// </summary>
        public long? workflow_file_upload_limit { get; set; }
    }

}
