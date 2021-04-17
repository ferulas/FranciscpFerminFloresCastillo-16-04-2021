using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestClient.Models;

namespace TestClient.Http
{
    public abstract class ServiceClientHttpServiceBase
    {
        protected readonly ApiClientHttpTools _serviceHttpTools;

        protected readonly HttpClient _httpClient;

        protected string _serviceUrl;

        protected abstract string GetServiceUrl();

        protected ServiceClientHttpServiceBase()
        {
            _serviceUrl = GetServiceUrl();
            _serviceHttpTools = new ApiClientHttpTools(_serviceUrl);
            _httpClient = _serviceHttpTools.Client;
        }

        private static T HandleResponseMessage<T>(HttpResponseMessage response) where T : class
        {
            try
            {
                var readTask = response.Content.ReadAsStringAsync();
                readTask.Wait();
                var reply = readTask.Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Invalid status from server: {response.StatusCode}; reply: {reply}");

                var send = JsonConvert.DeserializeObject<JSendReply<T>>(reply);
                return send.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected string LocalUrl
        {
            get
            {
                return "https://jsonplaceholder.typicode.com/";
            }
        }

        public T GetAsync<T>(string requestUri) where T : class
        {
            return HandleResponseMessage<T>(_serviceHttpTools.GetFromServer(requestUri, _serviceHttpTools.Client));
        }

        public List<Album> GetAsyncAlbums(string requestUri)
        {
            var readTask = _serviceHttpTools.GetFromServer(requestUri, _serviceHttpTools.Client).Content.ReadAsStringAsync();
            readTask.Wait();
            var reply = readTask.Result;

           
            //var send = JsonConvert.DeserializeObject<JSendReply<T>>(reply);
            //return send.Data;
            return JsonConvert.DeserializeObject<List<Album>>(reply);
        }

        public List<Photo> GetAsyncPhotos(string requestUri)
        {
            var readTask = _serviceHttpTools.GetFromServer(requestUri, _serviceHttpTools.Client).Content.ReadAsStringAsync();
            readTask.Wait();
            var reply = readTask.Result;

            return JsonConvert.DeserializeObject<List<Photo>>(reply);
        }

        public List<Comments> GetAsyncComments(string requestUri)
        {
            var readTask = _serviceHttpTools.GetFromServer(requestUri, _serviceHttpTools.Client).Content.ReadAsStringAsync();
            readTask.Wait();
            var reply = readTask.Result;

            return JsonConvert.DeserializeObject<List<Comments>>(reply);
        }



    }

    
}
