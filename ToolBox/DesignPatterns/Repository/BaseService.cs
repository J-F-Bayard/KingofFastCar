using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.Repository
{
    public abstract class BaseService
    {
        private string Uri { get; set; }

        protected BaseService(string Uri)
        {
            this.Uri = Uri;
        }

        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            return client;
        }
        protected HttpResponseMessage GetResponse(string path, HttpClient client)
        {
            return client.GetAsync(path).Result;
        }
        protected HttpResponseMessage PostResponse(string path, HttpClient client, StringContent content)
        {
            return client.PostAsync(path, content).Result;
        }
        protected HttpResponseMessage PutResponse(string path, HttpClient client, StringContent content)
        {
            return client.PutAsync(path, content).Result;
        }
        protected HttpResponseMessage DeleteResponse(string path, HttpClient client)
        {
            return client.DeleteAsync(path).Result;
        }
    }
}
