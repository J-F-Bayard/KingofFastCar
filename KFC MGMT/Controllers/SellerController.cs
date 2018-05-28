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
    public class SellerController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        public static async Task<List<GetSellerForm>> GetSellerList()
        {
            //chargement de la liste des vendeurs dans une liste pour linq
            IEnumerable<Seller> sellerList = null;
            List<GetSellerForm> getSellerformList = new List<GetSellerForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Seller/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sellerList = JsonConvert.DeserializeObject<List<Seller>>(EmpResponse);
                }

                foreach (Seller Seller in sellerList)
                {
                    getSellerformList.Add(AutoMapper<Seller, GetSellerForm>.AutoMap(Seller));
                }
            }
            return getSellerformList;
        }


        // GET: Seller
        public async Task<ActionResult> Index()
        {
            IEnumerable<Seller> sellerList = null;
            List<GetSellerForm> getSellerformList = new List<GetSellerForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Seller/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sellerList = JsonConvert.DeserializeObject<List<Seller>>(EmpResponse);
                }
                foreach (Seller seller in sellerList)
                {
                    getSellerformList.Add(AutoMapper<Seller, GetSellerForm>.AutoMap(seller));
                }
            }
            return View(getSellerformList);

        }

        // GET: Seller/Details/5
        public async Task<ActionResult> Details(string id)
        {
            Seller ModelGlobal = default(Seller);
            GetSellerForm ModelLocal = default(GetSellerForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Seller/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Seller>(EmpResponse);
                    ModelLocal = AutoMapper<Seller, GetSellerForm>.AutoMap(ModelGlobal);
                }                
            }
            return View(ModelLocal);
        }

        public async Task<EditSellerForm> GetDetails(string id)
        {
            Seller ModelGlobal = default(Seller);
            EditSellerForm ModelLocal = default(EditSellerForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Seller/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Seller>(EmpResponse);
                    ModelLocal = AutoMapper<Seller, EditSellerForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddSellerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Seller seller = new Seller
                {
                 
                 Name     =formulaire.Name,
                 Tva      =formulaire.Tva,
                 Email    =formulaire.Email,
                 Phone    =formulaire.Phone,
                 Street   =formulaire.Street,
                 Number   =formulaire.Number,
                 Zip      =formulaire.Zip,
                 Locality =formulaire.Locality,
                 Country  =formulaire.Country,
                 Account  =formulaire.Account                 
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(seller));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Seller/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Seller/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await GetDetails(id));
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditSellerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Seller seller = new Seller
                {
                    IdSeller = id,
                    Name = formulaire.Name,
                    Tva = formulaire.Tva,
                    Email = formulaire.Email,
                    Phone = formulaire.Phone,
                    Street = formulaire.Street,
                    Number = formulaire.Number,
                    Zip = formulaire.Zip,
                    Locality = formulaire.Locality,
                    Country = formulaire.Country,
                    Account = formulaire.Account
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(seller));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Seller/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteSellerForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Seller/Delete/{id}");

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
