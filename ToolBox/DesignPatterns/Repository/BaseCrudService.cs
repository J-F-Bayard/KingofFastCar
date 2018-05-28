using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolBox.API;
using ToolBox.DesignPatterns.Repository;

namespace ToolBox.DesignPatterns.Repository
{
    public abstract class BaseCrudService<TEntity, TKey> : BaseService, IDataService<TEntity, TKey>
        where TEntity : class, new()
    {
        private string ControllerName { get; set; }
        private ISerializer Serializer { get; set; }

        public BaseCrudService(string ControllerName, string Uri, ISerializer Serializer) : base(Uri)
        {
            this.Serializer = Serializer;
            this.ControllerName = ControllerName;
        }

        public TEntity Create(TEntity Entity)
        {
            using (HttpClient client = GetClient())
            {
                using (HttpResponseMessage response = PostResponse($"{ControllerName}", client, Serializer.SerializeObject(Entity)))
                    return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<TEntity>().Result : null;
            }
        }

        public bool Delete(TKey Key)
        {
            using (HttpClient client = GetClient())
            {
                using (HttpResponseMessage response = DeleteResponse($"{ControllerName}/{Key}", client))
                    return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<bool>().Result : false;
            }
        }

        public IEnumerable<TEntity> Get()
        {
            using (HttpClient client = GetClient())
            {
                using (HttpResponseMessage response = GetResponse($"{ControllerName}", client))
                    return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<IEnumerable<TEntity>>().Result : null;
            }
        }

        public TEntity Get(TKey Key)
        {
            using (HttpClient client = GetClient())
            {
                using (HttpResponseMessage response = GetResponse($"{ControllerName}/{Key}", client))
                    return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<TEntity>().Result : null;
            }
        }

        public bool Update(TEntity Entity)
        {
            using (HttpClient client = GetClient())
            {
                using (HttpResponseMessage response = PutResponse($"{ControllerName}", client, Serializer.SerializeObject(Entity)))
                    return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<bool>().Result : false;
            }
        }

    }
}
