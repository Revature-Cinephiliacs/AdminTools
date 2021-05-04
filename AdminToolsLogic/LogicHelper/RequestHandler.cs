using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using AdminToolsModels.LogicModels;
using RestSharp;

namespace AdminToolsLogic.LogicHelper
{
    public class RequestHandler
    {
        Dictionary<ReportType, string> apiUrls;
        public RequestHandler()
        {
            if (Debugger.IsAttached)
            {
                apiUrls = new Dictionary<ReportType, string>()
                {
                    { ReportType.Discussion,"https://localhost:5002/"},
                    { ReportType.Comment,"https://localhost:5002/"},
                    { ReportType.Review,"https://localhost:5009/"},
                };
            }
            else
            {
                apiUrls = new Dictionary<ReportType, string>()
                {
                    {ReportType.Discussion,"http://20.45.6.142/"},
                    {ReportType.Comment,"http://20.45.6.142/"},
                    {ReportType.Review,"http://20.189.30.176/"},
                };
            }
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
        public async Task<IRestResponse> Sendrequest(ReportType api, string urlExtension, Method method, string token, dynamic body = null)
        {
            var client = new RestClient(apiUrls[api] + urlExtension);
            client.Timeout = -1;
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);

            if (body != null)
            {
                request.AddParameter("application/json", JsonSerializer.Serialize(body), ParameterType.RequestBody);
            }

            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine("response.Content");
            Console.WriteLine(response.Content);
            return response;
        }
    }
}
