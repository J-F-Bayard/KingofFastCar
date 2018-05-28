using System;
using System.Collections.Generic;
using System.Web.Mvc;
using KFC_MGMT.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class ProviderController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        public static async Task<List<GetProviderForm>> GetProviderList()
        {
            IEnumerable<Provider> providerList = null;
            List<GetProviderForm> getproviderformList = new List<GetProviderForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Provider/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    providerList = JsonConvert.DeserializeObject<List<Provider>>(EmpResponse);
                }

                foreach (Provider provider in providerList)
                {
                    getproviderformList.Add(AutoMapper<Provider, GetProviderForm>.AutoMap(provider));
                }
            }
            return getproviderformList;
        }

        // GET: Provider
        public async Task<ActionResult> Index()
        {
            IEnumerable<Provider> providerList = null;
            List<GetProviderForm> getProviderformList = new List<GetProviderForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Provider/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    providerList = JsonConvert.DeserializeObject<List<Provider>>(EmpResponse);
                }
                foreach (Provider provider in providerList)
                {
                    getProviderformList.Add(AutoMapper<Provider, GetProviderForm>.AutoMap(provider));
                }
            }
            return View(getProviderformList);

        }

        // GET: Provider/Details/5
        public async Task<ActionResult> Details(string id)
        {
            Provider ModelGlobal = default(Provider);
            GetProviderForm ModelLocal = default(GetProviderForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Provider/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Provider>(EmpResponse);
                    ModelLocal = AutoMapper<Provider, GetProviderForm>.AutoMap(ModelGlobal);
                }
                
            }
            return View(ModelLocal);
        }

        // GET: Provider/Details/5
        public async Task<EditProviderForm> GetDetails(string id)
        {
            Provider ModelGlobal = default(Provider);
            EditProviderForm ModelLocal = default(EditProviderForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Provider/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Provider>(EmpResponse);
                    ModelLocal = AutoMapper<Provider, EditProviderForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddProviderForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Provider provider = new Provider
                {                    
                    Name = formulaire.Name,
                    Account = formulaire.Account,
                    Tva = formulaire.Tva,
                    Street = formulaire.Street,
                    Number = formulaire.Number,
                    Zip = formulaire.Zip,
                    Locality = formulaire.Locality,
                    Country = formulaire.Country,
                    Email = formulaire.Email,
                    Phone = formulaire.Phone
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //HTTP POST
                    StringContent content = new StringContent(JsonConvert.SerializeObject(provider));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Provider/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Provider/Edit/5
        public async Task<ActionResult> Edit(string id)
        {            
            return View(await GetDetails(id));
        }

        // POST: Provider/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditProviderForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Provider provider = new Provider
                {
                    IdProvider = id,
                    Name = formulaire.Name,
                    Account = formulaire.Account,
                    Tva = formulaire.Tva,
                    Street = formulaire.Street,
                    Number = formulaire.Number,
                    Zip = formulaire.Zip,
                    Locality = formulaire.Locality,
                    Country = formulaire.Country,
                    Email = formulaire.Email,
                    Phone = formulaire.Phone
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(provider));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Provider/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Provider/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DeleteProviderForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Provider/Delete/{id}");

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
