using KFC_MGMT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class BrandController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        public static async Task<List<GetBrandForm>> GetBrandList()
        {
            //chargement de la liste des marques dans une liste pour linq
            IEnumerable<Brand> brandList = null;
            List<GetBrandForm> getbrandformList = new List<GetBrandForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Brand/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    brandList = JsonConvert.DeserializeObject<List<Brand>>(EmpResponse);
                }

                foreach (Brand brand in brandList)
                {
                    getbrandformList.Add(AutoMapper<Brand, GetBrandForm>.AutoMap(brand));
                }
            }
            return getbrandformList;
        }

        // GET: Brand
        public async Task<ActionResult> Index()
        {
            IEnumerable<Brand> brandList = null;
            List<GetBrandForm> getbrandformList = new List<GetBrandForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Brand/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    brandList = JsonConvert.DeserializeObject<List<Brand>>(EmpResponse);
                }

                foreach (Brand brand in brandList)
                {
                    getbrandformList.Add(AutoMapper<Brand, GetBrandForm>.AutoMap(brand));
                }
            }
            return View(getbrandformList);

        }
        // GET: Brand/Details/5
        public async Task<ActionResult> Details(string id)
        {
            Brand ModelGlobal = default(Brand);
            GetBrandForm ModelLocal = default(GetBrandForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Brand/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Brand>(EmpResponse);
                    ModelLocal = AutoMapper<Brand, GetBrandForm>.AutoMap(ModelGlobal);
                }

            }
            return View(ModelLocal);

        }

        public async Task<EditBrandForm> GetDetails(string id)
        {
            Brand ModelGlobal = default(Brand);
            EditBrandForm ModelLocal = default(EditBrandForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Brand/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Brand>(EmpResponse);
                    ModelLocal = AutoMapper<Brand, EditBrandForm>.AutoMap(ModelGlobal);
                }

            }
            return ModelLocal;
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddBrandForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Brand brand = new Brand
                {
                    Name = formulaire.Name
                };
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(brand));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    
                    HttpResponseMessage Res = await client.PostAsync($"Brand/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Brand/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await GetDetails(id));
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditBrandForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Brand brand = new Brand
                {
                    IdBrand = id,
                    Name = formulaire.Name
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(brand));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync("Brand/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, [Bind]DeleteBrandForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Brand/Delete/{id}");

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
