using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestClient.Http
{
   
    public class ApiClientHttpTools
    {
        public HttpClient Client;

        public ApiClientHttpTools(string url, HttpClient client = null)
        {
            try
            {
                Client = client ?? new HttpClient { BaseAddress = new Uri(url) };
            }
            catch(Exception ex)
            {
                throw new Exception("Could not inicialize HttpClient",ex);
            }
        }

        public HttpResponseMessage GetFromServer(string url, HttpClient client)
        {
            
            var task = client.GetAsync(url);

            task.Wait();
            return task.Result;
        }
    }
}
