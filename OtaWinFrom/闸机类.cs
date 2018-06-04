using DocomSDK.Ticket.Data;
using FengjingSDK461.Helpers;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace OtaWinFrom
{
    public class 闸机类
    {
        /// <summary>  
        /// HttpClient实现Post请求(异步)  
        /// </summary>  
        public static async Task<Result<TicketResult>> Post<T>(T request, string action)
        {
            string url = "http://localhost:52615/api/Ota/" + action;
            //设置HttpClientHandler的AutomaticDecompression  
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）  
            using (var http = new HttpClient(handler))
            {
                string data = JsonConvert.SerializeObject(request);
                //创建一个处理序列化的DataContractJsonSerializer
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream();
                serializer.WriteObject(ms, request);
                //一定要在这设定Position
                ms.Position = 0;
                //将MemoryStream转成HttpContent
                HttpContent content = new StreamContent(ms);
                //一定要设定Header
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //await异步等待回应  
                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值  
                var httpResponseMessage = response.EnsureSuccessStatusCode();
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var resultData = await response.Content.ReadAsStringAsync();
                    var result = JsonHelper.JsonToObject<Result<TicketResult>>(resultData);
                    return result;
                }
                return new Result<TicketResult>();
            }

        }
    }
}
