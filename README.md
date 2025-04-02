<p align="center">
  <a href="./README.md"><img alt="简体中文版自述文件" src="https://img.shields.io/badge/简体中文-d9d9d9"></a>
  <a href="./README_EN.md"><img alt="README in Englis" src="https://img.shields.io/badge/English-d9d9d9"></a>
</p>



# DifyWebClient.Net,基于C# .NET 的Dify平台api接入框架
# 使用方式
## 使用Nuget管理器
在Nuget管理器中搜索 DifyWebClient.Net 的最新版，并且安装
## 手动下载引用
https://www.nuget.org/packages/DifyWebClient.Net
## Dify官方手册使用文档如下，可以自行对照API参数:
<br>https://docs.dify.ai/zh-hans
# 集成代码示例如下:
# 知识库集成(KnowledgeApiClient)
## 1.获取知识库列表
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
/*page 页码，可选*/
/*limit 返回条数，可选，默认 20，范围 1-100*/
KnowledgeListResponse knowledgeListResponse = knowledgeApiClient.GetKnowledgeBaseList(page:1,limit:20);
Console.WriteLine(knowledgeListResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(knowledgeListResponse.data.FirstOrDefault().id);
Console.WriteLine(knowledgeListResponse.data.FirstOrDefault().name);
```
## 2.通过文本创建文档
注:(如果是空白知识库，第一次上传，可能需要自己指定CreateDocumentByTextRequest中的 process_rule 相关的参数，否则可能报错;
建议手动在前台上传一个简单的文档设置完知识库之后再进行接口调用！)
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateDocumentResponse createDocumentResponse = knowledgeApiClient.CreateDocumentByText("b842bc31-b7bf-4a40-a950-ff2fdbd9c369", new CreateDocumentByTextRequest("textname", "content of the document"));
Console.WriteLine(createDocumentResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(createDocumentResponse.document.id);
Console.WriteLine(createDocumentResponse.document.name);
```
## 3.通过文件创建文档
注:(如果是空白知识库，第一次上传，可能需要自己指定CreateDocumentByTextRequest中的 process_rule 相关的参数，否则可能报错;
建议手动在前台上传一个简单的文档设置完知识库之后再进行接口调用！)
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateDocumentResponse createDocumentResponse = knowledgeApiClient.CreateDocumentByFile(dataset_id:"b842bc31-b7bf-4a40-a950-ff2fdbd9c369", filebytes:FileToBinaryConverter.ConvertFileToBinary("demo.txt"), filename:"demo.txt");
Console.WriteLine(createDocumentResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(createDocumentResponse.document.id);
Console.WriteLine(createDocumentResponse.document.name);
```
## 4.创建空知识库
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateEmptyKnowledgeResponse emptyKnowledgeResponse = knowledgeApiClient.CreateEmptyKnowledge(new CreateEmptyKnowledgeRequest("testbook"));
Console.WriteLine(emptyKnowledgeResponse.RealJsonstring); /*返回的原始json*/
Console.WriteLine(emptyKnowledgeResponse.id);
Console.WriteLine(emptyKnowledgeResponse.name);
```
## 5.删除知识库
删除接口成功的时候，当前dify版本返回为空值。后续dify官方更新了再补充;
当前若想判断返回的状态，只能通过返回的状态码(StatusCode)判断
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjson = knowledgeApiClient.DeleteKnowledge(dataset_id: "4d57ac25-c6eb-4701-9a82-2446ba948697");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);

```
## 6.知识库文档列表
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetDocumentResponse getDocumentResponse = knowledgeApiClient.GetDocumentList(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369");
Console.WriteLine(getDocumentResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(getDocumentResponse.data);
Console.WriteLine(getDocumentResponse.total);
Console.WriteLine(getDocumentResponse.page);
Console.WriteLine(getDocumentResponse.limit);
```
## 7.通过文本更新文档
注:文件名称需要传入，dify官方接口强制要求
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateDocumentResponse updateDocumentResponse = knowledgeApiClient.UpdateByText(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369", document_id: "b781035b-580e-41f7-9fcf-666fc0a0e27e",new UpdateByTextRequest("editext_"+DateTime.Now.ToString(),"filename.txt"));
Console.WriteLine(updateDocumentResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(updateDocumentResponse.document.id);
Console.WriteLine(updateDocumentResponse.document.name);
```
## 8.通过文件更新文档
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateDocumentResponse updateDocumentResponse = knowledgeApiClient.UpdateByFile(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369", document_id: "b781035b-580e-41f7-9fcf-666fc0a0e27e", filebytes: FileToBinaryConverter.ConvertFileToBinary("demo.txt"), "demo.txt");
Console.WriteLine(updateDocumentResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(updateDocumentResponse.document.id);
Console.WriteLine(updateDocumentResponse.document.name);
```
## 9.获取文档嵌入状态（进度）
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
IndexingStatusResponse indexingStatusResponse = knowledgeApiClient.GetIndexingStatus(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", batch: "20250325054107167379");
Console.WriteLine(indexingStatusResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(indexingStatusResponse.data.FirstOrDefault().completed_segments);
Console.WriteLine(indexingStatusResponse.data.FirstOrDefault().indexing_status);
```
## 10.删除文档
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonResultResponse commonResult = knowledgeApiClient.DeleteDocument(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "cdcde78b-7cc3-4f21-b581-cef6f37dfbd2");
Console.WriteLine(commonResult.RealJsonstring);/*返回的原始json*/
Console.WriteLine(commonResult.result);
```
## 11.查询文档分段
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetSegmentsResponse getSegmentsResponse = knowledgeApiClient.GetSegments(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab");
Console.WriteLine(getSegmentsResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(getSegmentsResponse.total);
Console.WriteLine(getSegmentsResponse.limit);
Console.WriteLine(getSegmentsResponse.page);
```
## 12.新增分段
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
AddChunksResponse addChunksResponse = knowledgeApiClient.AddChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab",new AddChunksRequest("What is the capital city of China?","The capital city of China is Beijing"));
Console.WriteLine(addChunksResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(addChunksResponse.data.FirstOrDefault().id);
Console.WriteLine(addChunksResponse.data.FirstOrDefault().status);
```
## 13.删除文档分段
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonResultResponse commonResult = knowledgeApiClient.DeleteChunk(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab", segment_id: "a68e046c-7928-4419-be2a-277e86714abe");
Console.WriteLine(commonResult.RealJsonstring);/*返回的原始json*/
Console.WriteLine(commonResult.result);
```
## 14.更新文档分段
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateChunkResponse updateChunkResponse = knowledgeApiClient.UpdateChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab", segment_id: "2b2b6290-60d5-44b3-8a0f-2ba5b627976c",new UpdateChunkRequest("What is the capital city of China?", "The capital city of China is Beijing"));
Console.WriteLine(updateChunkResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(updateChunkResponse.data.id);
Console.WriteLine(updateChunkResponse.data.document_id);
Console.WriteLine(updateChunkResponse.data.position);
```
## 15.获取上传文件
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetUploadFileResponse getUploadFileResponse = knowledgeApiClient.GetUploadFile(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab");
Console.WriteLine(getUploadFileResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(getUploadFileResponse.name);
Console.WriteLine(getUploadFileResponse.download_url);
```
## 16.检索知识库
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
RetrieveChunksResponse retrieveChunksResponse = knowledgeApiClient.RetrieveChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", new RetrieveChunksRequest("testquery"));
Console.WriteLine(retrieveChunksResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(retrieveChunksResponse.records.FirstOrDefault().segment.document_id);
Console.WriteLine(retrieveChunksResponse.records.FirstOrDefault().segment.content);
```
## 17.查询知识库元数据列表
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetMetadataResponse getMetadataResponse = knowledgeApiClient.GetMetadataList(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
Console.WriteLine(getMetadataResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(getMetadataResponse.doc_metadata.FirstOrDefault().id);
Console.WriteLine(getMetadataResponse.doc_metadata.FirstOrDefault().name);
```
## 18.新增元数据
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonMetadataResponse commonMetadataResponse = knowledgeApiClient.CreateMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",name: "test");
Console.WriteLine(commonMetadataResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(commonMetadataResponse.id);
Console.WriteLine(commonMetadataResponse.name);
Console.WriteLine(commonMetadataResponse.type);
```
## 19.更新元数据
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonMetadataResponse commonMetadataResponse = knowledgeApiClient.UpdateMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",metadata_id: "58ab2199-98ff-4e65-90d9-6afa859f1953", name: "test");
Console.WriteLine(commonMetadataResponse.RealJsonstring);/*返回的原始json*/
Console.WriteLine(commonMetadataResponse.id);
Console.WriteLine(commonMetadataResponse.name);
Console.WriteLine(commonMetadataResponse.type);
```
## 20.删除元数据
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.DeleteMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",metadata_id: "52046a8d-62f0-4e82-acf2-43a7b8876548");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 21.禁用内置元数据
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.DisableBuiltinMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 22.启用内置元数据
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.EnableBuiltinMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 23.更新文档元数据
当前版本测试时，元数据的名称属性(metadata_name)必须传递，要保证和系统中的一致。否则更新会失败
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.UpdateDocumentsMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",new UpdateDocumentsMetadataRequest(document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab",metadata_id: "857a5f5a-749a-441d-bbd0-4c9ea84b46f1", metadata_value: "testvalue", metadata_name: "test"));
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```

# 对话型应用集成(ChatAppApiClient)
## 1.发送对话消息
### 1.1阻塞(blocking)
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
ChatCompletionResponse  chatCompletionResponse = chatAppWebClient.SendChatMessage(new ChatMessageRequest("你好") { });
Console.WriteLine(chatCompletionResponse.answer);
```
### 1.2.流式(streaming)
#### 1.2.1 IObservable可观察序列代码示例:
```
static void Main(string[] args)
{
    // 禁用鼠标点击等待
    Console.TreatControlCAsInput = true;
    var exit = new ManualResetEvent(false);

    /*ChatAppWebClient初始化*/
    ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
    var task = chatAppWebClient.SendChatMessageAsync(new ChatMessageRequest("你好", ResponseMode.Streaming){ user="user"});

    /*1.event: message */
    chatAppWebClient.ObservChunkChatReceived.OfType<MessageEventResponse>().Subscribe(eventdata =>
    {   
        /* LLM 返回文本块事件*/
        Console.Write(eventdata.answer);
    });

    /*2.event: message_end*/
    chatAppWebClient.ObservChunkChatReceived.OfType<MessageEndEventResponse>().Subscribe(eventdata =>
    {
        /*消息结束事件，收到此事件则代表流式返回结束。*/
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("total_tokens:" + eventdata.metadata.usage.total_tokens);
        Console.WriteLine("total_price:" + eventdata.metadata.usage.total_price);
    });

    /*3.event: message_file*/
    chatAppWebClient.ObservChunkChatReceived.OfType<MessageFileEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*4.event: tts_message*/
    chatAppWebClient.ObservChunkChatReceived.OfType<TtsMessageEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*5.event: tts_message_end*/
    chatAppWebClient.ObservChunkChatReceived.OfType<TtsMessageEndEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*6.event: message_replace*/
    chatAppWebClient.ObservChunkChatReceived.OfType<MessageReplaceEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*7.event: workflow_started*/
    chatAppWebClient.ObservChunkChatReceived.OfType<WorkflowStartedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*8.event: node_started*/
    chatAppWebClient.ObservChunkChatReceived.OfType<NodeStartedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*9.event: node_finished*/
    chatAppWebClient.ObservChunkChatReceived.OfType<NodeFinishedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*10.event: workflow_finished*/
    chatAppWebClient.ObservChunkChatReceived.OfType<WorkflowFinishedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*11.event: error*/
    chatAppWebClient.ObservChunkChatReceived.OfType<ErrorEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*12.event: ping*/
    chatAppWebClient.ObservChunkChatReceived.OfType<PingEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    /*需要保持线程不退出才能获取到*/
    exit.WaitOne();
    // while (true) {}
}
```
#### 1.2.2 EventHandler事件处理器代码示例:
```
static void Main(string[] args)
{
    // 禁用鼠标点击等待
    Console.TreatControlCAsInput = true;
    var exit = new ManualResetEvent(false);

    /*ChatAppWebClient初始化*/
    ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
    var task = chatAppWebClient.SendChatMessageAsync(new ChatMessageRequest("你好", ResponseMode.Streaming){ user="user"});

    chatAppWebClient.EventChunkChatReceived += (o, eventdata) =>
    {
        if (eventdata is MessageEventResponse messageEvent)
        {
            /* LLM 返回文本块事件*/
            Console.Write(messageEvent.answer);
        }
        if (eventdata is MessageEndEventResponse messageEndEvent)
        {
            /*消息结束事件，收到此事件则代表流式返回结束。*/
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("total_tokens:" + messageEndEvent.metadata.usage.total_tokens);
            Console.WriteLine("total_price:" + messageEndEvent.metadata.usage.total_price);
        }
        if (eventdata is MessageFileEventResponse messageFileEvent)
        {
            //Console.Write(messageFileEvent.RealJsonstring);
        }
        if (eventdata is TtsMessageEventResponse ttsMessageEvent)
        {
            //Console.Write(ttsMessageEvent.RealJsonstring);
        }
        if (eventdata is TtsMessageEndEventResponse ttsMessageEndEvent)
        {
            //Console.Write(ttsMessageEndEvent.RealJsonstring);
        }
        if (eventdata is MessageReplaceEventResponse messageReplaceEvent)
        {
            //Console.Write(messageReplaceEvent.RealJsonstring);
        }
        if (eventdata is WorkflowStartedEventResponse workflowStartedEvent)
        {
            //Console.Write(workflowStartedEvent.RealJsonstring);
        }
         if (eventdata is NodeStartedEventResponse nodeStartedEventResponse)
        {
            //Console.Write(nodeStartedEventResponse.RealJsonstring);
        }
        if (eventdata is NodeFinishedEventResponse nodeFinishedEvent)
        {
            //Console.Write(nodeFinishedEvent.RealJsonstring);
        }
        if (eventdata is WorkflowFinishedEventResponse workflowFinishedEvent)
        {
            //Console.Write(workflowFinishedEvent.RealJsonstring);
        }
        if (eventdata is ErrorEventResponse errorEvent)
        {
            //Console.Write(errorEvent.RealJsonstring);
        }
        if (eventdata is PingEventResponse pingEvent)
        {
            //Console.Write(pingEvent.RealJsonstring);
        }
    };

    /*需要保持线程不退出才能获取到*/
    exit.WaitOne();
    // while (true) {}
}

```
## 2.上传文件
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
FileUploadResponse  fileUploadResponse= chatAppWebClient.FileUpload(FileToBinaryConverter.ConvertFileToBinary("demo.txt"),"demo.txt");
Console.WriteLine(fileUploadResponse.id);
Console.WriteLine(fileUploadResponse.name);
Console.WriteLine(fileUploadResponse.size);
```
## 3.停止响应
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = chatAppWebClient.StopGenerate(task_id: "27eb7263-8de2-434e-8251-738974167ff4",user:"user");
Console.WriteLine(commonResultResponse.result);
Console.WriteLine(commonResultResponse.RealJsonstring);
```
## 4.消息反馈（点赞）
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
/*点赞 like*/
CommonResultResponse likeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Like, user: "user", content: "message feedback information");
Console.WriteLine(likeResponse.result);
Console.WriteLine(likeResponse.RealJsonstring);
/*点踩 dislike*/
CommonResultResponse dislikeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Dislike, user: "user", content: "message feedback information");
Console.WriteLine(dislikeResponse.result);
Console.WriteLine(dislikeResponse.RealJsonstring);
/*撤销点赞 null*/
CommonResultResponse revokeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Revoke, user: "user");
Console.WriteLine(revokeResponse.result);
Console.WriteLine(revokeResponse.RealJsonstring);
```
## 5.获取下一轮建议问题列表
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetNextSuggestedQuestionsResponse getNextSuggestedQuestions = chatAppWebClient.GetNextSuggestedQuestions(message_id: "253890ef-b723-4323-996a-a36a9d83a4ba", user: "user");
Console.WriteLine(getNextSuggestedQuestions.RealJsonstring);
if (getNextSuggestedQuestions.data != null&& getNextSuggestedQuestions.data.Count>0) 
{
    foreach (var item in getNextSuggestedQuestions.data)
    {
        Console.WriteLine(item);
    }
}
```
## 6.获取会话历史消息
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetConversationHistoryMessagesResponse conversationHistoryMessagesResponse = chatAppWebClient.GetConversationHistoryMessages(user: "user", conversation_id: "1d84b8e7-3ebe-4897-b96e-568ac010d422");
Console.WriteLine(conversationHistoryMessagesResponse.RealJsonstring);
Console.WriteLine(conversationHistoryMessagesResponse.data.FirstOrDefault().answer);
```
## 7.获取会话列表
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetConversationsResponse getConversationsResponse = chatAppWebClient.GetConversations(user: "user");
Console.WriteLine(getConversationsResponse.data.FirstOrDefault().id);
Console.WriteLine(getConversationsResponse.data.FirstOrDefault().name);
```
## 8.删除会话
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = chatAppWebClient.DeleteConversation(conversation_id: "ca8f4d2f-ef43-483d-b2fd-d6f2cea15187",user:"user");
Console.WriteLine(commonResultResponse.RealJsonstring);
Console.WriteLine(commonResultResponse.result);
```
## 9.会话重命名
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
ConversationRenameResponse conversationRenameResponse = chatAppWebClient.ConversationRename(conversation_id: "1d84b8e7-3ebe-4897-b96e-568ac010d422", name:"testname",user:"user");
Console.WriteLine(conversationRenameResponse.RealJsonstring);
Console.WriteLine(conversationRenameResponse.id);
Console.WriteLine(conversationRenameResponse.name);
```
## 10.文字转语音
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
Byte[] filebyte=chatAppWebClient.TextToAudio(text: "中文语音测试", user: "user");
FileToBinaryConverter.ConvertByteArrayToFile(filebyte, "test.mp3");
```
## 11.语音转文字
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
AudioToTextResponse audioToTextResponse = chatAppWebClient.AudioToText(filebytes:FileToBinaryConverter.ConvertFileToBinary("test.mp3"), filename:"test.mp3");
Console.WriteLine(audioToTextResponse.RealJsonstring);
Console.WriteLine(audioToTextResponse.text);
```
## 12.获取应用基本信息
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetInfoResponse getInfoResponse= chatAppWebClient.GetInfo();
Console.WriteLine(getInfoResponse.RealJsonstring);
Console.WriteLine(getInfoResponse.name);
Console.WriteLine(getInfoResponse.description);
```
## 13.获取应用参数
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetParametersResponse getParametersResponse= chatAppWebClient.GetParameters();
Console.WriteLine(getParametersResponse.RealJsonstring);
Console.WriteLine(getParametersResponse.system_parameters.file_size_limit);
Console.WriteLine(getParametersResponse.retriever_resource.enabled);
```
## 14.获取应用Meta信息(用于获取工具icon)
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetMetaResponse getMetaResponse = chatAppWebClient.GetMeta();
Console.WriteLine(getMetaResponse.RealJsonstring);
Console.WriteLine(getMetaResponse.tool_icons.FirstOrDefault().Key);
Console.WriteLine(getMetaResponse.tool_icons.FirstOrDefault().Value);
```

# Workflow 应用集成(WorkflowAppApiClient)
## 1.执行 workflow
### 1.1 阻塞(blocking)
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
Dictionary<string,object> inputkeyValuePairs = new Dictionary<string,object>();
inputkeyValuePairs.Add("custquery", "你好");
//inputkeyValuePairs.Add("custquery", "总结一下这个文档");
//List<FileListElement> fileListElements = new List<FileListElement>();
//fileListElements.Add(new FileListElement(upload_file_id: "d2af54fc-eb7f-417e-a980-65cac240ded6"));
//inputkeyValuePairs.Add("custfile", fileListElements);
ExecuteWorkflowRequest executeWorkflowRequest  = new ExecuteWorkflowRequest(inputkeyValuePairs,user:"user", ResponseMode.Blocking);
CompletionResponse completionResponse =workflowAppApiClient.ExecuteWorkflow(executeWorkflowRequest);
Console.WriteLine(completionResponse.RealJsonstring);
Console.WriteLine(completionResponse.data.outputs["text"].ToString());
```
### 1.2.流式(streaming)
#### 1.2.1 IObservable可观察序列代码示例:
```
static void Main(string[] args)
{
    // 禁用鼠标点击等待
    Console.TreatControlCAsInput = true;
    var exit = new ManualResetEvent(false);

    WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
    Dictionary<string, object> inputkeyValuePairs = new Dictionary<string, object>();
    inputkeyValuePairs.Add("custquery", "你好");

    var task = workflowAppApiClient.ExecuteWorkflowAsync(
        new ExecuteWorkflowRequest(inputkeyValuePairs, user: "user", ResponseMode.Streaming)
    );

    // event: workflow_started
    workflowAppApiClient.ObservChunkChatReceived.OfType<WorkflowStartedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    // event: node_started
    workflowAppApiClient.ObservChunkChatReceived.OfType<NodeStartedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    // event: node_finished
    workflowAppApiClient.ObservChunkChatReceived.OfType<NodeFinishedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    // event: workflow_finished
    workflowAppApiClient.ObservChunkChatReceived.OfType<WorkflowFinishedEventResponse>().Subscribe(eventdata =>
    {
        //Console.Write(eventdata.RealJsonstring);
    });

    // event: wtext_chunk
    workflowAppApiClient.ObservChunkChatReceived.OfType<TextChunkEventResponse>().Subscribe(eventdata =>
    {
        Console.Write(eventdata.data.text);
    });

    // 需要保持线程不退出才能获取到
    exit.WaitOne();
    // while (true) {}
}
```
#### 1.2.2 EventHandler事件处理器代码示例:
```
static void Main(string[] args)
{
    // 禁用鼠标点击等待
    Console.TreatControlCAsInput = true;
    var exit = new ManualResetEvent(false);

    WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
    Dictionary<string, object> inputkeyValuePairs = new Dictionary<string, object>();
    inputkeyValuePairs.Add("custquery", "你好");

    var task = workflowAppApiClient.ExecuteWorkflowAsync(
        new ExecuteWorkflowRequest(inputkeyValuePairs, user: "user", ResponseMode.Streaming)
    );

    workflowAppApiClient.EventChunkChatReceived += (o, eventdata) =>
    {
        if (eventdata is WorkflowStartedEventResponse workflowStartedEvent)
        {
            //Console.Write(workflowStartedEvent.RealJsonstring);
        }
        if (eventdata is NodeStartedEventResponse nodeStartedEventResponse)
        {
            //Console.Write(nodeStartedEventResponse.RealJsonstring);
        }
        if (eventdata is NodeFinishedEventResponse nodeFinishedEvent)
        {
            //Console.Write(nodeFinishedEvent.RealJsonstring);
        }
        if (eventdata is WorkflowFinishedEventResponse workflowFinishedEvent)
        {
            //Console.Write(workflowFinishedEvent.RealJsonstring);
        }
        if (eventdata is TextChunkEventResponse textChunkEvent)
        {
            Console.Write(textChunkEvent.data.text);
        }
    };

    // 需要保持线程不退出才能获取到
    exit.WaitOne();
    // while (true) {}
}
```

## 2.获取workflow执行情况
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetWorkflowRunDetailResponse getWorkflowRunDetailResponse = workflowAppApiClient.GetWorkflowRunDetail(workflow_id: "88cc6bb5-161a-4ae2-98b1-256036ee3ba2");
Console.WriteLine(getWorkflowRunDetailResponse.RealJsonstring);
Console.WriteLine(getWorkflowRunDetailResponse.inputs["custquery"].ToString());
Console.WriteLine(getWorkflowRunDetailResponse.outputs["text"].ToString());
```
## 3.停止响应(仅支持流式模式)
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = workflowAppApiClient.StopGenerate(task_id: "985be951-4915-47df-a9c7-7910b85b2f45",user:"user");
Console.WriteLine(commonResultResponse.RealJsonstring);
Console.WriteLine(commonResultResponse.result);
```
## 4.上传文件
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
FileUploadResponse  fileUploadResponse= workflowAppApiClient.FileUpload(FileToBinaryConverter.ConvertFileToBinary("demo.txt"),"demo.txt");
Console.WriteLine(fileUploadResponse.id);
Console.WriteLine(fileUploadResponse.name);
Console.WriteLine(fileUploadResponse.size);
```
## 5.获取 workflow 日志
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetWorkflowLogsResponse getWorkflowLogsResponse = workflowAppApiClient.GetWorkflowLogs();
Console.WriteLine(getWorkflowLogsResponse.RealJsonstring);
Console.WriteLine(getWorkflowLogsResponse.data.FirstOrDefault().id);
```
## 6.获取应用基本信息
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetInfoResponse getInfoResponse= workflowAppApiClient.GetInfo();
Console.WriteLine(getInfoResponse.RealJsonstring);
Console.WriteLine(getInfoResponse.name);
Console.WriteLine(getInfoResponse.description);
```
## 7.获取应用参数
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetParametersResponse getParametersResponse= workflowAppApiClient.GetParameters();
Console.WriteLine(getParametersResponse.RealJsonstring);
Console.WriteLine(getParametersResponse.system_parameters.file_size_limit);
Console.WriteLine(getParametersResponse.retriever_resource.enabled);
```



