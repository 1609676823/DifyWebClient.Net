using DifyWebClient.Net.Models.Knowledge;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using DifyWebClient.Net.Models;
using DifyWebClient.Net.Models.Base;
namespace DifyWebClient.Net.ApiClients
{
    /// <summary>
    /// 知识库API管理器
    /// </summary>
    public class KnowledgeApiClient : DifyApiClientBase
    {
        /// <summary>
        /// 知识库API管理器
        /// </summary>
        public KnowledgeApiClient() : base() { }
        /// <summary>
        /// 知识库API管理器
        /// </summary>
        /// <param name="url"></param>
        /// <param name="apikey"></param>
        public KnowledgeApiClient(string url, string apikey) : base(url, apikey)
        {

        }

        /// <summary>
        /// 获取知识库列表异步
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="limit">返回条数，默认 20，范围 1-100</param>
        /// <returns></returns>

        public async Task<KnowledgeListResponse> GetKnowledgeBaseListAsync(long page = 1, long limit = 20)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            if (page >= 0) { queryParameters.Add("page", page.ToString()); }
            if (limit >= 0) { queryParameters.Add("limit", limit.ToString()); }
            string url = Url + "datasets";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            KnowledgeListResponse knowledgeListResponseModel = new KnowledgeListResponse();
            // Models.Knowledge.KnowledgeListResponseModel myObject = JsonSerializer.Deserialize<Models.Knowledge.KnowledgeListResponseModel>(resjosn, JsonSerializerOptions)!;
            knowledgeListResponseModel.RealJsonstring = resjosn;
            return knowledgeListResponseModel;
        }

        /// <summary>
        /// 获取知识库列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public KnowledgeListResponse GetKnowledgeBaseList(long page = 1, long limit = 20)
        {

            Task<KnowledgeListResponse> task = GetKnowledgeBaseListAsync(page, limit);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 通过文本创建文档异步 Async
        /// Create a Document from Text 
        /// </summary>
        /// <param name="dataset_id">知识库id</param>
        /// <param name="createByTextRequest">请求结构</param>
        /// <returns></returns>
        public async Task<CreateDocumentResponse> CreateDocumentByTextAsync(string dataset_id, CreateDocumentByTextRequest createByTextRequest)
        {

            string requestjson = System.Text.Json.JsonSerializer.Serialize(createByTextRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/document/create-by-text";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            //KnowledgeListResponse knowledgeListResponseModel = new KnowledgeListResponse();
            //knowledgeListResponseModel.RealJsonstring = resjosn;
            CreateDocumentResponse createDocumentResponse = new CreateDocumentResponse();
            createDocumentResponse.RealJsonstring = resjosn;
            return createDocumentResponse;
        }

        /// <summary>
        ///通过文本创建文档 
        ///Create a Document from Text
        /// </summary>
        /// <param name="dataset_id">知识库id</param>
        /// <param name="createByTextRequest">请求结构</param>
        /// <returns></returns>
        public CreateDocumentResponse CreateDocumentByText(string dataset_id, CreateDocumentByTextRequest createByTextRequest)
        {
            Task<CreateDocumentResponse> task = CreateDocumentByTextAsync(dataset_id, createByTextRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 通过文件创建文档异步 
        /// Create a Document from a File Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <param name="createDocumentByFileRequest"></param>
        /// <returns></returns>
        public async Task<CreateDocumentResponse> CreateDocumentByFileAsync(string dataset_id, Byte[] filebytes, string filename, CreateDocumentByFileRequest? createDocumentByFileRequest = null)
        {
            if (createDocumentByFileRequest == null)
            {
                createDocumentByFileRequest = new CreateDocumentByFileRequest();
            }
            string requestjson = System.Text.Json.JsonSerializer.Serialize(createDocumentByFileRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/document/create-by-file";

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(new StringContent(requestjson), "data");
            var fileContent = new ByteArrayContent(filebytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            multipartFormDataContent.Add(fileContent, "file", filename);
            string resjosn = await SendRequestByFormDataAsync(url, multipartFormDataContent);
            //KnowledgeListResponse knowledgeListResponseModel = new KnowledgeListResponse();
            //knowledgeListResponseModel.RealJsonstring = resjosn;
            CreateDocumentResponse createDocumentResponse = new CreateDocumentResponse();
            createDocumentResponse.RealJsonstring = resjosn;
            return createDocumentResponse;
        }

        /// <summary>
        /// 通过文件创建文档
        /// Create a Document from a File 
        /// </summary>
        /// <param name="dataset_id">知识库id</param>
        /// <param name="filebytes">文件的byte流</param>
        /// <param name="filename">文件名</param>
        /// <param name="createDocumentByFileRequest">请求结构</param>
        /// <returns></returns>
        public CreateDocumentResponse CreateDocumentByFile(string dataset_id, Byte[] filebytes, string filename, CreateDocumentByFileRequest? createDocumentByFileRequest = null)
        {
            Task<CreateDocumentResponse> task = CreateDocumentByFileAsync(dataset_id, filebytes, filename, createDocumentByFileRequest = null);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 创建空知识库异步
        /// Create an Empty Knowledge Base Async
        /// </summary>
        /// <param name="createEmptyKnowledgeRequest"></param>
        /// <returns></returns>
        public async Task<CreateEmptyKnowledgeResponse> CreateEmptyKnowledgeAsync(CreateEmptyKnowledgeRequest createEmptyKnowledgeRequest)
        {
            string requestjson = System.Text.Json.JsonSerializer.Serialize(createEmptyKnowledgeRequest, JsonSerializerOptions);
            string url = Url + "datasets";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            CreateEmptyKnowledgeResponse createEmptyKnowledgeResponse = new CreateEmptyKnowledgeResponse();
            createEmptyKnowledgeResponse.RealJsonstring = resjosn;
            return createEmptyKnowledgeResponse;
        }

        /// <summary>
        /// 创建空知识库
        /// Create an Empty Knowledge Base
        /// </summary>
        /// <param name="createEmptyKnowledgeRequest"></param>
        /// <returns></returns>
        public CreateEmptyKnowledgeResponse CreateEmptyKnowledge(CreateEmptyKnowledgeRequest createEmptyKnowledgeRequest)
        {
            Task<CreateEmptyKnowledgeResponse> task = CreateEmptyKnowledgeAsync(createEmptyKnowledgeRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 删除知识库异步
        /// Delete a Knowledge Base Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public async Task<string> DeleteKnowledgeAsync(string dataset_id)
        {

            string url = Url + "datasets/" + dataset_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Delete);
            return resjosn;
        }

        /// <summary>
        /// 删除知识库
        /// Delete a Knowledge Base
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public string DeleteKnowledge(string dataset_id)
        {
            Task<string> task = DeleteKnowledgeAsync(dataset_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取知识库文档列表 异步
        /// Get the Document List of a Knowledge Base Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<GetDocumentResponse> GetDocumentListAsync(string dataset_id, string keyword = "", long page = 1, long limit = 20)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters.Add("keyword", keyword);
            }
            if (page >= 0) { queryParameters.Add("page", page.ToString()); }
            if (limit >= 0) { queryParameters.Add("limit", limit.ToString()); }
            string url = Url + "datasets/" + dataset_id + "/documents";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetDocumentResponse getDocumentResponse = new GetDocumentResponse();
            getDocumentResponse.RealJsonstring = resjosn;
            return getDocumentResponse;
        }
        /// <summary>
        /// 获取知识库文档列表
        /// Get the Document List of a Knowledge Base
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public GetDocumentResponse GetDocumentList(string dataset_id, string keyword = "", long page = 1, long limit = 20)
        {
            Task<GetDocumentResponse> task = GetDocumentListAsync(dataset_id, keyword, page, limit);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 通过文本更新文档异步
        /// Update a Document with Text Async
        ///This API is based on an existing knowledge and updates the document through text based on this knowledge.
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="updateByTextRequest"></param>
        /// <returns></returns>
        public async Task<UpdateDocumentResponse> UpdateByTextAsync(string dataset_id, string document_id, UpdateByTextRequest updateByTextRequest)
        {

            string requestjson = System.Text.Json.JsonSerializer.Serialize(updateByTextRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/update-by-text";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);

            UpdateDocumentResponse updateDocumentResponse = new UpdateDocumentResponse();
            updateDocumentResponse.RealJsonstring = resjosn;
            return updateDocumentResponse;
        }

        /// <summary>
        /// 通过文本更新文档
        /// Update a Document with Text
        ///This API is based on an existing knowledge and updates the document through text based on this knowledge.
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="updateByTextRequest"></param>
        /// <returns></returns>
        public UpdateDocumentResponse UpdateByText(string dataset_id, string document_id, UpdateByTextRequest updateByTextRequest)
        {
            Task<UpdateDocumentResponse> task = UpdateByTextAsync(dataset_id, document_id, updateByTextRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 通过文件更新文档异步
        /// Update a Document with a File Async
        /// This API is based on an existing knowledge, and updates documents through files based on this knowledge
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <param name="updateByFileRequest"></param>
        /// <returns></returns>
        public async Task<UpdateDocumentResponse> UpdateByFileAsync(string dataset_id, string document_id, Byte[] filebytes, string filename, UpdateByFileRequest? updateByFileRequest = null)
        {
            if (updateByFileRequest == null)
            {
                updateByFileRequest = new UpdateByFileRequest();
            }
            updateByFileRequest.name = filename;
            string requestjson = System.Text.Json.JsonSerializer.Serialize(updateByFileRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/update-by-file";

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(new StringContent(requestjson), "data");
            var fileContent = new ByteArrayContent(filebytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            multipartFormDataContent.Add(fileContent, "file", filename);
            string resjosn = await SendRequestByFormDataAsync(url, multipartFormDataContent);

            UpdateDocumentResponse updateDocumentResponse = new UpdateDocumentResponse();
            updateDocumentResponse.RealJsonstring = resjosn;
            return updateDocumentResponse;
        }

        /// <summary>
        /// 通过文件更新文档
        /// Update a Document with a File 
        /// This API is based on an existing knowledge, and updates documents through files based on this knowledge
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <param name="updateByFileRequest"></param>
        /// <returns></returns>
        public UpdateDocumentResponse UpdateByFile(string dataset_id, string document_id, Byte[] filebytes, string filename, UpdateByFileRequest? updateByFileRequest = null)
        {
            Task<UpdateDocumentResponse> task = UpdateByFileAsync(dataset_id, document_id, filebytes, filename, updateByFileRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取文档嵌入状态（进度）异步
        /// Get Document Embedding Status (Progress) Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public async Task<IndexingStatusResponse> GetIndexingStatusAsync(string dataset_id, string batch)
        {

            string url = Url + "datasets/" + dataset_id + "/documents/" + batch + "/indexing-status";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            IndexingStatusResponse indexingStatusResponse = new IndexingStatusResponse();
            indexingStatusResponse.RealJsonstring = resjosn;
            return indexingStatusResponse;
        }

        /// <summary>
        /// 获取文档嵌入状态（进度）
        /// Get Document Embedding Status (Progress)
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public IndexingStatusResponse GetIndexingStatus(string dataset_id, string batch)
        {
            Task<IndexingStatusResponse> task = GetIndexingStatusAsync(dataset_id, batch);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 删除文档异步
        /// Delete a Document Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <returns></returns>
        public async Task<CommonResultResponse> DeleteDocumentAsync(string dataset_id, string document_id)
        {

            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Delete);
            CommonResultResponse deleteDocumentResponse = new CommonResultResponse();
            deleteDocumentResponse.RealJsonstring = resjosn;
            return deleteDocumentResponse;
        }

        /// <summary>
        /// 删除文档
        /// Delete a Document 
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <returns></returns>
        public CommonResultResponse DeleteDocument(string dataset_id, string document_id)
        {
            Task<CommonResultResponse> task = DeleteDocumentAsync(dataset_id, document_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 查询文档分段 异步
        /// Retrieve Chunks from a Knowledge Base Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<GetSegmentsResponse> GetSegmentsAsync(string dataset_id, string document_id, string keyword = "", long page = 1, long limit = 20)
        {
            // string res = string.Empty;
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(keyword)) { queryParameters.Add("keyword", keyword); }
            if (page >= 0) { queryParameters.Add("page", page.ToString()); }
            if (limit >= 0) { queryParameters.Add("limit", limit.ToString()); }
            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/segments";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get, null, queryParameters);
            GetSegmentsResponse getSegmentsResponse = new GetSegmentsResponse();
            getSegmentsResponse.RealJsonstring = resjosn;
            return getSegmentsResponse;
        }

        /// <summary>
        /// 查询文档分段
        /// Retrieve Chunks from a Knowledge Base
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public GetSegmentsResponse GetSegments(string dataset_id, string document_id, string keyword = "", long page = 1, long limit = 20)
        {
            Task<GetSegmentsResponse> task = GetSegmentsAsync(dataset_id, document_id, keyword, page, limit);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 新增分段 异步
        /// Add Chunks to a Document Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="addChunksRequest"></param>
        /// <returns></returns>
        public async Task<AddChunksResponse> AddChunksAsync(string dataset_id, string document_id, AddChunksRequest addChunksRequest)
        {

            string requestjson = System.Text.Json.JsonSerializer.Serialize(addChunksRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/segments";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);

            AddChunksResponse addChunksResponse = new AddChunksResponse();
            addChunksResponse.RealJsonstring = resjosn;
            return addChunksResponse;
        }

        /// <summary>
        /// 新增分段 
        /// Add Chunks to a Document 
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="addChunksRequest"></param>
        /// <returns></returns>
        public AddChunksResponse AddChunks(string dataset_id, string document_id, AddChunksRequest addChunksRequest)
        {
            Task<AddChunksResponse> task = AddChunksAsync(dataset_id, document_id, addChunksRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 删除文档分段 异步
        /// Delete a Chunk in a Document Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="segment_id"></param>
        /// <returns></returns>
        public async Task<CommonResultResponse> DeleteChunkAsync(string dataset_id, string document_id, string segment_id)
        {

            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/segments/" + segment_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Delete);
            CommonResultResponse deleteDocumentResponse = new CommonResultResponse();
            deleteDocumentResponse.RealJsonstring = resjosn;
            return deleteDocumentResponse;
        }

        /// <summary>
        /// 删除文档分段 
        /// Delete a Chunk in a Document 
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="segment_id"></param>
        /// <returns></returns>
        public CommonResultResponse DeleteChunk(string dataset_id, string document_id, string segment_id)
        {
            Task<CommonResultResponse> task = DeleteChunkAsync(dataset_id, document_id, segment_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 更新文档分段
        /// Update a Chunk in a Document
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="segment_id"></param>
        /// <param name="updateChunkRequest"></param>
        /// <returns></returns>
        public async Task<UpdateChunkResponse> UpdateChunksAsync(string dataset_id, string document_id, string segment_id, UpdateChunkRequest updateChunkRequest)
        {

            string requestjson = System.Text.Json.JsonSerializer.Serialize(updateChunkRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/segments/" + segment_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            UpdateChunkResponse updateChunkResponse = new UpdateChunkResponse();
            updateChunkResponse.RealJsonstring = resjosn;
            return updateChunkResponse;
        }

        /// <summary>
        /// 更新文档分段
        /// Update a Chunk in a Document
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <param name="segment_id"></param>
        /// <param name="updateChunkRequest"></param>
        /// <returns></returns>

        public UpdateChunkResponse UpdateChunks(string dataset_id, string document_id, string segment_id, UpdateChunkRequest updateChunkRequest)
        {
            Task<UpdateChunkResponse> task = UpdateChunksAsync(dataset_id, document_id, segment_id, updateChunkRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 获取上传文件异步
        /// Get Upload File Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <returns></returns>
        public async Task<GetUploadFileResponse> GetUploadFileAsync(string dataset_id, string document_id)
        {

            string url = Url + "datasets/" + dataset_id + "/documents/" + document_id + "/upload-file";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetUploadFileResponse getUploadFileResponse = new GetUploadFileResponse();
            getUploadFileResponse.RealJsonstring = resjosn;
            return getUploadFileResponse;
        }
        /// <summary>
        /// 获取上传文件
        /// Get Upload File
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="document_id"></param>
        /// <returns></returns>
        public GetUploadFileResponse GetUploadFile(string dataset_id, string document_id)
        {
            Task<GetUploadFileResponse> task = GetUploadFileAsync(dataset_id, document_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 检索知识库异步
        /// Retrieve Chunks from a Knowledge Base Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="retrieveChunksRequest"></param>
        /// <returns></returns>
        public async Task<RetrieveChunksResponse> RetrieveChunksAsync(string dataset_id, RetrieveChunksRequest retrieveChunksRequest)
        {
            string requestjson = System.Text.Json.JsonSerializer.Serialize(retrieveChunksRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/retrieve";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            RetrieveChunksResponse retrieveChunksResponse = new RetrieveChunksResponse();
            retrieveChunksResponse.RealJsonstring = resjosn;
            return retrieveChunksResponse;
        }
        /// <summary>
        /// 检索知识库
        /// Retrieve Chunks from a Knowledge Base
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="retrieveChunksRequest"></param>
        /// <returns></returns>

        public RetrieveChunksResponse RetrieveChunks(string dataset_id, RetrieveChunksRequest retrieveChunksRequest)
        {
            Task<RetrieveChunksResponse> task = RetrieveChunksAsync(dataset_id, retrieveChunksRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 查询知识库元数据列表异步
        /// Get Knowledge Metadata List Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public async Task<GetMetadataResponse> GetMetadataListAsync(string dataset_id)
        {

            string url = Url + "datasets/" + dataset_id + "/metadata";
            string resjosn = await SendRequestAsync(url, HttpMethod.Get);
            GetMetadataResponse getMetadataResponse = new GetMetadataResponse();
            getMetadataResponse.RealJsonstring = resjosn;
            return getMetadataResponse;
        }

        /// <summary>
        /// 查询知识库元数据列表
        /// Get Knowledge Metadata List
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public GetMetadataResponse GetMetadataList(string dataset_id)
        {
            Task<GetMetadataResponse> task = GetMetadataListAsync(dataset_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 新增元数据异步
        /// Create a Knowledge Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<CommonMetadataResponse> CreateMetadataAsync(string dataset_id, string name, string type = Enum.MetadataType.TypeString)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("name", name);
            RequestObject.Add("type", type);
            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/metadata";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);

            CommonMetadataResponse commonMetadataResponse = new CommonMetadataResponse();
            commonMetadataResponse.RealJsonstring = resjosn;
            return commonMetadataResponse;
        }

        /// <summary>
        /// 新增元数据
        /// Create a Knowledge Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public CommonMetadataResponse CreateMetadata(string dataset_id, string name, string type = Enum.MetadataType.TypeString)
        {
            Task<CommonMetadataResponse> task = CreateMetadataAsync(dataset_id, name, type);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 更新元数据异步
        /// Update a Knowledge Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="metadata_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<CommonMetadataResponse> UpdateMetadataAsync(string dataset_id, string metadata_id, string name)
        {
            System.Text.Json.Nodes.JsonObject RequestObject = new System.Text.Json.Nodes.JsonObject();
            RequestObject.Add("name", name);

            string requestjson = System.Text.Json.JsonSerializer.Serialize(RequestObject, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/metadata/" + metadata_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);

            CommonMetadataResponse commonMetadataResponse = new CommonMetadataResponse();
            commonMetadataResponse.RealJsonstring = resjosn;
            return commonMetadataResponse;
        }

        /// <summary>
        /// 更新元数据
        /// Update a Knowledge Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="metadata_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public CommonMetadataResponse UpdateMetadata(string dataset_id, string metadata_id, string name)
        {
            Task<CommonMetadataResponse> task = UpdateMetadataAsync(dataset_id, metadata_id, name);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 删除元数据异步
        /// Delete a Knowledge Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="metadata_id"></param>
        /// <returns></returns>
        public async Task<string> DeleteMetadataAsync(string dataset_id, string metadata_id)
        {
            string url = Url + "datasets/" + dataset_id + "/metadata/" + metadata_id;
            string resjosn = await SendRequestAsync(url, HttpMethod.Delete);
            return resjosn;
        }

        /// <summary>
        /// 删除元数据
        /// Delete a Knowledge Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="metadata_id"></param>
        /// <returns></returns>
        public string DeleteMetadata(string dataset_id, string metadata_id)
        {
            Task<string> task = DeleteMetadataAsync(dataset_id, metadata_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 禁用内置元数据异步
        /// Disable Built-in Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public async Task<string> DisableBuiltinMetadataAsync(string dataset_id)
        {
            string url = Url + "datasets/" + dataset_id + "/metadata/built-in/disable";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post);
            return resjosn;
        }
        /// <summary>
        /// 禁用内置元数据
        /// Disable Built-in Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public string DisableBuiltinMetadata(string dataset_id)
        {
            Task<string> task = DisableBuiltinMetadataAsync(dataset_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 启用内置元数据异步
        /// Enable Built-in Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public async Task<string> EnableBuiltinMetadataAsync(string dataset_id)
        {
            string url = Url + "datasets/" + dataset_id + "/metadata/built-in/enable";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post);
            return resjosn;
        }

        /// <summary>
        /// 启用内置元数据
        /// Enable Built-in Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <returns></returns>
        public string EnableBuiltinMetadata(string dataset_id)
        {
            Task<string> task = EnableBuiltinMetadataAsync(dataset_id);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 更新文档元数据异步
        /// Update Documents Metadata Async
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="updateDocumentsMetadataRequest"></param>
        /// <returns></returns>
        public async Task<string> UpdateDocumentsMetadataAsync(string dataset_id, UpdateDocumentsMetadataRequest updateDocumentsMetadataRequest)
        {

            string requestjson = System.Text.Json.JsonSerializer.Serialize(updateDocumentsMetadataRequest, JsonSerializerOptions);
            string url = Url + "datasets/" + dataset_id + "/documents/metadata";
            string resjosn = await SendRequestAsync(url, HttpMethod.Post, requestjson);
            //CommonMetadataResponse commonMetadataResponse = new CommonMetadataResponse();
            //commonMetadataResponse.RealJsonstring = resjosn;
            return resjosn;
        }

        /// <summary>
        /// 更新文档元数据
        /// Update Documents Metadata
        /// </summary>
        /// <param name="dataset_id"></param>
        /// <param name="updateDocumentsMetadataRequest"></param>
        /// <returns></returns>
        public string UpdateDocumentsMetadata(string dataset_id, UpdateDocumentsMetadataRequest updateDocumentsMetadataRequest)
        {
            Task<string> task = UpdateDocumentsMetadataAsync(dataset_id, updateDocumentsMetadataRequest);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <param name="user"></param>
        /// <returns></returns>
#pragma warning disable CS0809
        [Obsolete("此方法在KnowledgeApiClient不可使用！", true)]

        public override FileUploadResponse FileUpload(byte[] filebytes, string filename, string user = "")
        {
            return base.FileUpload(filebytes, filename, user);
        }
        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <param name="filebytes"></param>
        /// <param name="filename"></param>
        /// <param name="user"></param>
        /// <returns></returns>
#pragma warning disable CS0809
        [Obsolete("此方法在KnowledgeApiClient不可使用！", true)]
        public override Task<FileUploadResponse> FileUploadAsync(byte[] filebytes, string filename, string user = "")
        {
            return base.FileUploadAsync(filebytes, filename, user);
        }
        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS0809
        [Obsolete("此方法在KnowledgeApiClient不可使用！", true)]
        public override Task<GetInfoResponse> GetInfoAsync()
        {
            return base.GetInfoAsync();
        }
        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS0809
        public override GetInfoResponse GetInfo()
        {
            return base.GetInfo();
        }
        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS0809
        public override Task<GetParametersResponse> GetParametersAsync()
        {
            return base.GetParametersAsync();
        }

        /// <summary>
        /// 此方法在KnowledgeApiClient不可使用！
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS0809
        public override GetParametersResponse GetParameters()
        {
            return base.GetParameters();
        }

    }

}
