using KFC_MGMT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class BuyerController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        public static async Task<List<GetBuyerForm>> GetBuyerList()
        {
            //chargement de la liste des acheteurs dans une liste pour linq
            IEnumerable<Buyer> buyerList = null;
            List<GetBuyerForm> getBuyerformList = new List<GetBuyerForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Buyer/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    buyerList = JsonConvert.DeserializeObject<List<Buyer>>(EmpResponse);
                }

                foreach (Buyer Buyer in buyerList)
                {
                    getBuyerformList.Add(AutoMapper<Buyer, GetBuyerForm>.AutoMap(Buyer));
                }
            }
            return getBuyerformList;
        }
        
        // GET: Buyer
        public async Task<ActionResult> Index()
        {
            IEnumerable<Buyer> buyerList = null;
            List<GetBuyerForm> getbuyerformList = new List<GetBuyerForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Buyer/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    buyerList = JsonConvert.DeserializeObject<List<Buyer>>(EmpResponse);
                }

                foreach (Buyer buyer in buyerList)
                {
                    getbuyerformList.Add(AutoMapper<Buyer, GetBuyerForm>.AutoMap(buyer));
                }
            }
            return View(getbuyerformList);

        }

        // GET: Buyer/Details/5
        public async Task<ActionResult> Details(string id)
        {
            Buyer ModelGlobal = default(Buyer);
            GetBuyerForm ModelLocal = default(GetBuyerForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"Buyer/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Buyer>(EmpResponse);
                    ModelLocal = AutoMapper<Buyer, GetBuyerForm>.AutoMap(ModelGlobal);
                }
            }
            return View(ModelLocal);
        }

        public async Task<EditBuyerForm> GetDetails(string id)
        {
            Buyer ModelGlobal = default(Buyer);
            EditBuyerForm ModelLocal = default(EditBuyerForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"Buyer/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Buyer>(EmpResponse);
                    ModelLocal = AutoMapper<Buyer, EditBuyerForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddBuyerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Buyer buyer = new Buyer
                {                
                FirstName = formulaire.FirstName,
                LastName  = formulaire.LastName,
                Email = formulaire.Email,
                Phone = formulaire.Phone,
                Street = formulaire.Street,
                Number = formulaire.Number.ToString(),
                Zip = formulaire.Zip,
                Locality  = formulaire.Locality,
                Country = formulaire.Country,
                Account = formulaire.Account
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(buyer));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Buyer/Create/", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }                   
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Buyer/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await GetDetails(id));
        }

        // POST: Buyer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditBuyerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Buyer buyer = new Buyer
                {
                    IdBuyer = id,
                    FirstName = formulaire.FirstName,
                    LastName = formulaire.LastName,
                    Email = formulaire.Email,
                    Phone = formulaire.Phone,
                    Street = formulaire.Street,
                    Number = formulaire.Number.ToString(),
                    Zip = formulaire.Zip,
                    Locality = formulaire.Locality,
                    Country = formulaire.Country,
                    Account = formulaire.Account
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(buyer));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Buyer/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Buyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buyer/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteBuyerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Buyer/Delete/{id}");

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
