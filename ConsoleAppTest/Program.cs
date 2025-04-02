using DifyWebClient.Net;
using DifyWebClient.Net.ApiClients;
using DifyWebClient.Net.Enum;
using DifyWebClient.Net.Models;
using DifyWebClient.Net.Models.Base;
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
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //workflowAppApiClient.EncodingDefault= Encoding.GetEncoding("GB2312");

            // 禁用鼠标点击等待
            Console.TreatControlCAsInput = true;
            var exit = new ManualResetEvent(false);
            string url = "http://127.0.0.01/v1";
            string apikey = "";

            WorkflowAppApiClient workflowAppApiClient = new WorkflowAppApiClient(url, apikey);
            GetParametersResponse getParametersResponse = workflowAppApiClient.GetParameters();
            Console.WriteLine(getParametersResponse.RealJsonstring);
            Console.WriteLine(getParametersResponse.system_parameters.file_size_limit);
            Console.WriteLine(getParametersResponse.retriever_resource.enabled);



            /*需要保持线程不退出才能获取到*/

            exit.WaitOne();
            //  while (true) {  }
            Console.ReadKey();
        }
    }
}
