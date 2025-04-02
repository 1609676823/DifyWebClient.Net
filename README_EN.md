<p align="center">
<a href="./README_EN.md"><img alt="English README" src="https://img.shields.io/badge/English-d9d9d9"></a>
<a href="./README.md"><img alt="Simplified Chinese README" src="https://img.shields.io/badge/简体中文-d9d9d9"></a>
</p>

# DifyWebClient.Net, A Dify platform API integration framework based on C# .NET
# Usage
## Using Nuget Manager
Search for the latest version of DifyWebClient.Net in the Nuget Manager and install it.
## Manual Download and Reference
https://www.nuget.org/packages/DifyWebClient.Net
## Dify official manual documentation is as follows, you can refer to the API parameters:
<br>https://docs.dify.ai/en
# Integration code examples are as follows:
# Knowledge Base Integration (KnowledgeApiClient)
## 1. Get Knowledge Base List
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
/*page Page number, optional*/
/*limit Number of returns, optional, default is 20, range is 1-100*/
KnowledgeListResponse knowledgeListResponse = knowledgeApiClient.GetKnowledgeBaseList(page:1,limit:20);
Console.WriteLine(knowledgeListResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(knowledgeListResponse.data.FirstOrDefault().id);
Console.WriteLine(knowledgeListResponse.data.FirstOrDefault().name);
```
## 2. Create Document by Text
Note: (If it is a blank knowledge base, for the first upload, you may need to specify the relevant parameters in CreateDocumentByTextRequest's process_rule, otherwise it may report an error; It is recommended to manually upload a simple document in the front end and set up the knowledge base before making an interface call!)
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateDocumentResponse createDocumentResponse = knowledgeApiClient.CreateDocumentByText("b842bc31-b7bf-4a40-a950-ff2fdbd9c369", new CreateDocumentByTextRequest("textname", "content of the document"));
Console.WriteLine(createDocumentResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(createDocumentResponse.document.id);
Console.WriteLine(createDocumentResponse.document.name);
```
## 3. Create Document by File
Note: (If it is a blank knowledge base, for the first upload, you may need to specify the relevant parameters in CreateDocumentByTextRequest's process_rule, otherwise it may report an error; It is recommended to manually upload a simple document in the front end and set up the knowledge base before making an interface call!)
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateDocumentResponse createDocumentResponse = knowledgeApiClient.CreateDocumentByFile(dataset_id:"b842bc31-b7bf-4a40-a950-ff2fdbd9c369", filebytes:FileToBinaryConverter.ConvertFileToBinary("demo.txt"));
Console.WriteLine(createDocumentResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(createDocumentResponse.document.id);
Console.WriteLine(createDocumentResponse.document.name);
```
## 4. Create Empty Knowledge Base
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CreateEmptyKnowledgeResponse emptyKnowledgeResponse = knowledgeApiClient.CreateEmptyKnowledge(new CreateEmptyKnowledgeRequest("testbook"));
Console.WriteLine(emptyKnowledgeResponse.RealJsonstring); /*Original JSON returned*/
Console.WriteLine(emptyKnowledgeResponse.id);
Console.WriteLine(emptyKnowledgeResponse.name);
```
## 5. Delete Knowledge Base
When the delete interface is successful, the current version of Dify returns a null value. It will be supplemented after the official update of Dify;
Currently, if you want to determine the status of the return, you can only judge by the status code (StatusCode).
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjson = knowledgeApiClient.DeleteKnowledge(dataset_id: "4d57ac25-c6eb-4701-9a82-2446ba948697");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);

```
## 6. Document List of Knowledge Base
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetDocumentResponse getDocumentResponse = knowledgeApiClient.GetDocumentList(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369");
Console.WriteLine(getDocumentResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(getDocumentResponse.data);
Console.WriteLine(getDocumentResponse.total);
Console.WriteLine(getDocumentResponse.page);
Console.WriteLine(getDocumentResponse.limit);
```
## 7. Update Document by Text
Note: The file name needs to be passed in, the official Dify interface mandates it.
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateDocumentResponse updateDocumentResponse = knowledgeApiClient.UpdateByText(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369", document_id: "b781035b-580e-41f7-9fcf-666fc0a0e27e",new UpdateByTextRequest("textname", "updated content of the document"));
Console.WriteLine(updateDocumentResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(updateDocumentResponse.document.id);
Console.WriteLine(updateDocumentResponse.document.name);
```
## 8. Update Document by File
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateDocumentResponse updateDocumentResponse = knowledgeApiClient.UpdateByFile(dataset_id: "b842bc31-b7bf-4a40-a950-ff2fdbd9c369", document_id: "b781035b-580e-41f7-9fcf-666fc0a0e27e", filebytes: FileToBinaryConverter.ConvertFileToBinary("demo.txt"));
Console.WriteLine(updateDocumentResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(updateDocumentResponse.document.id);
Console.WriteLine(updateDocumentResponse.document.name);
```
## 9. Get Document Embedding Status (Progress)
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
IndexingStatusResponse indexingStatusResponse = knowledgeApiClient.GetIndexingStatus(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", batch: "20250325054107167379");
Console.WriteLine(indexingStatusResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(indexingStatusResponse.data.FirstOrDefault().completed_segments);
Console.WriteLine(indexingStatusResponse.data.FirstOrDefault().indexing_status);
```
## 10. Delete Document
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonResultResponse commonResult = knowledgeApiClient.DeleteDocument(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "cdcde78b-7cc3-4f21-b581-cef6f37dfbd2");
Console.WriteLine(commonResult.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(commonResult.result);
```
## 11. Query Document Segments
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetSegmentsResponse getSegmentsResponse = knowledgeApiClient.GetSegments(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab");
Console.WriteLine(getSegmentsResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(getSegmentsResponse.total);
Console.WriteLine(getSegmentsResponse.limit);
Console.WriteLine(getSegmentsResponse.page);
```
## 12. Add Segment
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
AddChunksResponse addChunksResponse = knowledgeApiClient.AddChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab",new AddChunksRequest("What is this segment about?"));
Console.WriteLine(addChunksResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(addChunksResponse.data.FirstOrDefault().id);
Console.WriteLine(addChunksResponse.data.FirstOrDefault().status);
```
## 13. Delete Document Segment
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonResultResponse commonResult = knowledgeApiClient.DeleteChunk(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab", segment_id: "a68e046c-7928-4e5a-9d2c-6f8e1c7e6d2f");
Console.WriteLine(commonResult.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(commonResult.result);
```
## 14. Update Document Segment
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
UpdateChunkResponse updateChunkResponse = knowledgeApiClient.UpdateChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab", segment_id: "2b2b6290-4e6c-4f6f-9f3e-72e3f9d7c6f3", new UpdateChunksRequest("Updated segment content"));
Console.WriteLine(updateChunkResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(updateChunkResponse.data.id);
Console.WriteLine(updateChunkResponse.data.document_id);
Console.WriteLine(updateChunkResponse.data.position);
```
## 15. Get Uploaded File
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetUploadFileResponse getUploadFileResponse = knowledgeApiClient.GetUploadFile(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab");
Console.WriteLine(getUploadFileResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(getUploadFileResponse.name);
Console.WriteLine(getUploadFileResponse.download_url);
```
## 16. Retrieve Knowledge Base
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
RetrieveChunksResponse retrieveChunksResponse = knowledgeApiClient.RetrieveChunks(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb", new RetrieveChunksRequest("testquery"));
Console.WriteLine(retrieveChunksResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(retrieveChunksResponse.records.FirstOrDefault().segment.document_id);
Console.WriteLine(retrieveChunksResponse.records.FirstOrDefault().segment.content);
```
## 17. Query Knowledge Base Metadata List
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
GetMetadataResponse getMetadataResponse = knowledgeApiClient.GetMetadataList(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
Console.WriteLine(getMetadataResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(getMetadataResponse.doc_metadata.FirstOrDefault().id);
Console.WriteLine(getMetadataResponse.doc_metadata.FirstOrDefault().name);
```
## 18. Add Metadata
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonMetadataResponse commonMetadataResponse = knowledgeApiClient.CreateMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",name: "test");
Console.WriteLine(commonMetadataResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(commonMetadataResponse.id);
Console.WriteLine(commonMetadataResponse.name);
Console.WriteLine(commonMetadataResponse.type);
```
## 19. Update Metadata
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
CommonMetadataResponse commonMetadataResponse = knowledgeApiClient.UpdateMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",metadata_id: "58ab2199-98ff-4e65-90d9-6afa859f1953", name: "test");
Console.WriteLine(commonMetadataResponse.RealJsonstring);/*Original JSON returned*/
Console.WriteLine(commonMetadataResponse.id);
Console.WriteLine(commonMetadataResponse.name);
Console.WriteLine(commonMetadataResponse.type);
```
## 20. Delete Metadata
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.DeleteMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",metadata_id: "52046a8d-62f0-4e82-acf2-43a7b8876548");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 21. Disable Built-in Metadata
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.DisableBuiltinMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 22. Enable Built-in Metadata
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.EnableBuiltinMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb");
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```
## 23. Update Document Metadata
During current version testing, the metadata_name attribute must be passed and must be consistent with the system, otherwise the update will fail.
```
KnowledgeApiClient knowledgeApiClient = new KnowledgeApiClient("http://127.0.0.1/v1", "apikey") { };
string resjosn = knowledgeApiClient.UpdateDocumentsMetadata(dataset_id: "1a847d4f-3005-42a9-99f3-b32b9ee873eb",new UpdateDocumentsMetadataRequest(document_id: "0c6fa40a-ef7b-4083-9e99-2e9a321a27ab",metadata_name: "test"));
HttpStatusCode statuscode = knowledgeApiClient.httpResponseMessage.StatusCode;
Console.WriteLine((int)statuscode);
```

# Dialog Application Integration (ChatAppApiClient)
## 1. Send Dialog Message
### 1.1 Blocking
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
ChatCompletionResponse  chatCompletionResponse = chatAppWebClient.SendChatMessage(new ChatMessageRequest("Hello") { });
Console.WriteLine(chatCompletionResponse.answer);
```
### 1.2 Streaming
#### 1.2.1 IObservable Observable Sequence Code Example:
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
#### 1.2.2 Code Example of the EventHandler Event Processor:
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
## 2. Upload File
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
FileUploadResponse fileUploadResponse = chatAppWebClient.FileUpload(FileToBinaryConverter.ConvertFileToBinary("demo.txt"), "demo.txt");
Console.WriteLine(fileUploadResponse.id);
Console.WriteLine(fileUploadResponse.name);
Console.WriteLine(fileUploadResponse.size);
```

## 3. Stop Response
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = chatAppWebClient.StopGenerate(task_id: "27eb7263-8de2-434e-8251-738974167ff4", user: "user");
Console.WriteLine(commonResultResponse.result);
Console.WriteLine(commonResultResponse.RealJsonstring);
```

## 4. Message Feedback (Like/Dislike)
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
/* Like */
CommonResultResponse likeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Like, user: "user", content: "message feedback information");
Console.WriteLine(likeResponse.result);
Console.WriteLine(likeResponse.RealJsonstring);
/* Dislike */
CommonResultResponse dislikeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Dislike, user: "user", content: "message feedback information");
Console.WriteLine(dislikeResponse.result);
Console.WriteLine(dislikeResponse.RealJsonstring);
/* Revoke Like */
CommonResultResponse revokeResponse = chatAppWebClient.MessageFeedback(message_id: "da18c4a5-2dfc-4c86-9707-52db0dda35a2", rating: FeedbacksRating.Revoke, user: "user");
Console.WriteLine(revokeResponse.result);
Console.WriteLine(revokeResponse.RealJsonstring);
```

## 5. Get Next Suggested Questions
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetNextSuggestedQuestionsResponse getNextSuggestedQuestions = chatAppWebClient.GetNextSuggestedQuestions(message_id: "253890ef-b723-4323-996a-a36a9d83a4ba", user: "user");
Console.WriteLine(getNextSuggestedQuestions.RealJsonstring);
if (getNextSuggestedQuestions.data != null && getNextSuggestedQuestions.data.Count > 0) 
{
    foreach (var item in getNextSuggestedQuestions.data)
    {
        Console.WriteLine(item);
    }
}
```

## 6. Get Conversation History Messages
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetConversationHistoryMessagesResponse conversationHistoryMessagesResponse = chatAppWebClient.GetConversationHistoryMessages(user: "user", conversation_id: "1d84b8e7-3ebe-4897-b96e-568ac010d422");
Console.WriteLine(conversationHistoryMessagesResponse.RealJsonstring);
Console.WriteLine(conversationHistoryMessagesResponse.data.FirstOrDefault().answer);
```

## 7. Get Conversations List
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetConversationsResponse getConversationsResponse = chatAppWebClient.GetConversations(user: "user");
Console.WriteLine(getConversationsResponse.data.FirstOrDefault().id);
Console.WriteLine(getConversationsResponse.data.FirstOrDefault().name);
```

## 8. Delete Conversation
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = chatAppWebClient.DeleteConversation(conversation_id: "ca8f4d2f-ef43-483d-b2fd-d6f2cea15187", user: "user");
Console.WriteLine(commonResultResponse.RealJsonstring);
Console.WriteLine(commonResultResponse.result);
```

## 9. Rename Conversation
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
ConversationRenameResponse conversationRenameResponse = chatAppWebClient.ConversationRename(conversation_id: "1d84b8e7-3ebe-4897-b96e-568ac010d422", name: "testname", user: "user");
Console.WriteLine(conversationRenameResponse.RealJsonstring);
Console.WriteLine(conversationRenameResponse.id);
Console.WriteLine(conversationRenameResponse.name);
```

## 10. Text to Speech
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
Byte[] filebyte = chatAppWebClient.TextToAudio(text: "Chinese speech test", user: "user");
FileToBinaryConverter.ConvertByteArrayToFile(filebyte, "test.mp3");
```

## 11. Speech to Text
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
AudioToTextResponse audioToTextResponse = chatAppWebClient.AudioToText(filebytes: FileToBinaryConverter.ConvertFileToBinary("test.mp3"), filename: "test.mp3");
Console.WriteLine(audioToTextResponse.RealJsonstring);
Console.WriteLine(audioToTextResponse.text);
```

## 12. Get Application Basic Information
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetInfoResponse getInfoResponse = chatAppWebClient.GetInfo();
Console.WriteLine(getInfoResponse.RealJsonstring);
Console.WriteLine(getInfoResponse.name);
Console.WriteLine(getInfoResponse.description);
```

## 13. Get Application Parameters
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetParametersResponse getParametersResponse = chatAppWebClient.GetParameters();
Console.WriteLine(getParametersResponse.RealJsonstring);
Console.WriteLine(getParametersResponse.system_parameters.file_size_limit);
Console.WriteLine(getParametersResponse.retriever_resource.enabled);
```

## 14. Get Application Meta Information (for tool icons)
```
ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "apikey");
GetMetaResponse getMetaResponse = chatAppWebClient.GetMeta();
Console.WriteLine(getMetaResponse.RealJsonstring);
Console.WriteLine(getMetaResponse.tool_icons.FirstOrDefault().Key);
Console.WriteLine(getMetaResponse.tool_icons.FirstOrDefault().Value);
```
# Workflow Application Integration (WorkflowAppApiClient)
## 1.Execute a workflow
### 1.1 Blocking
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
### 1.2 Streaming
#### 1.2.1 IObservable Observable Sequence Code Example:
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
#### 1.2.2 Code Example of the EventHandler Event Processor:
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
## 2. Get Workflow Execution Status
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetWorkflowRunDetailResponse getWorkflowRunDetailResponse = workflowAppApiClient.GetWorkflowRunDetail(workflow_id: "88cc6bb5-161a-4ae2-98b1-256036ee3ba2");
Console.WriteLine(getWorkflowRunDetailResponse.RealJsonstring);
Console.WriteLine(getWorkflowRunDetailResponse.inputs["custquery"].ToString());
Console.WriteLine(getWorkflowRunDetailResponse.outputs["text"].ToString());
```

## 3. Stop Response (Stream Mode Only)
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
CommonResultResponse commonResultResponse = workflowAppApiClient.StopGenerate(task_id: "985be951-4915-47df-a9c7-7910b85b2f45", user: "user");
Console.WriteLine(commonResultResponse.RealJsonstring);
Console.WriteLine(commonResultResponse.result);
```

## 4. Upload File
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
FileUploadResponse fileUploadResponse = workflowAppApiClient.FileUpload(FileToBinaryConverter.ConvertFileToBinary("demo.txt"), "demo.txt");
Console.WriteLine(fileUploadResponse.id);
Console.WriteLine(fileUploadResponse.name);
Console.WriteLine(fileUploadResponse.size);
```

## 5. Get Workflow Logs
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetWorkflowLogsResponse getWorkflowLogsResponse = workflowAppApiClient.GetWorkflowLogs();
Console.WriteLine(getWorkflowLogsResponse.RealJsonstring);
Console.WriteLine(getWorkflowLogsResponse.data.FirstOrDefault().id);
```

## 6. Get Application Basic Information
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetInfoResponse getInfoResponse = workflowAppApiClient.GetInfo();
Console.WriteLine(getInfoResponse.RealJsonstring);
Console.WriteLine(getInfoResponse.name);
Console.WriteLine(getInfoResponse.description);
```

## 7. Get Application Parameters
```
WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient("http://127.0.0.1/v1", "apikey");
GetParametersResponse getParametersResponse= workflowAppApiClient.GetParameters();
Console.WriteLine(getParametersResponse.RealJsonstring);
Console.WriteLine(getParametersResponse.system_parameters.file_size_limit);
Console.WriteLine(getParametersResponse.retriever_resource.enabled);
```