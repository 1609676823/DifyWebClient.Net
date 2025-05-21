using DifyWebClient.Net;
using DifyWebClient.Net.ApiClients;
using DifyWebClient.Net.Enum;
using DifyWebClient.Net.Models;
using DifyWebClient.Net.Models.Base;
using DifyWebClient.Net.Models.ChatApp;
using DifyWebClient.Net.Models.Knowledge;
using DifyWebClient.Net.Models.WorkflowApp;
using System.Net;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*ChatAppWebClient初始化*/
            ChatAppWebClient chatAppWebClient = new ChatAppWebClient("http://127.0.0.1/v1", "key");
            var task = chatAppWebClient.SendChatMessageAsync(new ChatMessageRequest("你好", ResponseMode.Streaming) { user = "user" });

            foreach (var rsp in chatAppWebClient.ObservChunkChatReceived)
            {
                if (rsp is MessageEventResponse)
                {
                    MessageEventResponse? eventdata = rsp as MessageEventResponse;
                    Console.Write(eventdata!.answer);
                   
                }
                if (rsp.IsCompletedSSE)
                {

                }

            }

            var task1 = chatAppWebClient.SendChatMessageAsync(new ChatMessageRequest("介绍一下你自己", ResponseMode.Streaming) { user = "user" });

          
            foreach (var rsp in chatAppWebClient.ObservChunkChatReceived)
            {
                if (rsp is MessageEventResponse)
                {
                    MessageEventResponse? eventdata = rsp as MessageEventResponse;
                    Console.Write(eventdata!.answer);
                }


            }
            Console.ReadKey();
        }
    }
}
