using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AdminToolsModels.LogicModels;
using Newtonsoft.Json;
using RestSharp;

namespace AdminToolsLogic.LogicHelper
{
    public class RequestHandler
    {
        Dictionary<ReportType, string> apiUrls;
        public RequestHandler()
        {
                apiUrls = new Dictionary<ReportType, string>()
                {
                    {ReportType.Discussion,"http://20.45.6.142/"},
                    {ReportType.Comment,"http://20.45.6.142/"},
                    {ReportType.Review,"http://20.189.30.176/"},
                };
        }

        /// <summary>
        /// Send a requet to other apis
        /// </summary>
        /// <param name="api"></param>
        /// <param name="urlExtension"></param>
        /// <param name="method"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Sendrequest(ReportType api, string urlExtension, Method method, string token, dynamic body = null)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            string path = apiUrls[api] + urlExtension;
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(path, data);
            if(response.IsSuccessStatusCode)
            {   
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
