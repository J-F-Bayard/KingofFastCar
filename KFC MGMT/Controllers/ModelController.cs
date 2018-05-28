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
using System.Linq;

namespace KFC_MGMT.Controllers
{
    public class ModelController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }
        
        public static async Task<List<GetModelForm>> GetModelList()
        {
            //chargement de la liste des modeles dans une liste pour linq
            IEnumerable<Model> modelList = null;
            List<GetModelForm> getmodelformList = new List<GetModelForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Model/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<Model>>(EmpResponse);
                }

                foreach (Model model in modelList)
                {
                    getmodelformList.Add(AutoMapper<Model, GetModelForm>.AutoMap(model));
                }
            }
            return getmodelformList;
        }

        // GET: Model
        public async Task<ActionResult> Index()
        {
            List<GetBrandForm> getbrandList = await BrandController.GetBrandList();
            List<GetModelForm> getmodelList = await ModelController.GetModelList();

            foreach (var item in getmodelList)
            {
                var data = (from b in getbrandList
                            where b.IdBrand == item.IdBrand
                            select b.Name).FirstOrDefault();

                item.BrandName = data;                
            }
            
            return View(getmodelList);

        }

        // GET: Model/Details/5
        public async Task<ActionResult> Details(string id)
        {
            List<GetBrandForm> getbrandList = await BrandController.GetBrandList();

            Model ModelGlobal = default(Model);
            GetModelForm ModelLocal = default(GetModelForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Model/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Model>(EmpResponse);
                    ModelLocal = AutoMapper<Model, GetModelForm>.AutoMap(ModelGlobal);
                }                
            }

            ModelLocal.BrandName = (from b in getbrandList
                                    where b.IdBrand == ModelLocal.IdBrand
                                    select b.Name).FirstOrDefault();

            return View(ModelLocal);
        }

        public async Task<EditModelForm> GetDetails(string id)
        {
            Model ModelGlobal = default(Model);
            EditModelForm ModelLocal = default(EditModelForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Model/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Model>(EmpResponse);
                    ModelLocal = AutoMapper<Model, EditModelForm>.AutoMap(ModelGlobal);
                }
            }
            
            return ModelLocal;
        }

        // GET: Model/Create
        public async Task<ActionResult> Create()
        {
            List<SelectListItem> getbrandformList = new List<SelectListItem>();
            List<GetBrandForm> getbrandList = await BrandController.GetBrandList();

            foreach (GetBrandForm Brand in getbrandList)
            {
                getbrandformList.Add(new SelectListItem { Text = Brand.Name, Value = Brand.IdBrand.ToString() });
            }

            var model = new AddModelForm
            {
                BrandList = getbrandformList
            };
            return View(model);
        }

        // POST: Model/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddModelForm formulaire)
        {
            if (ModelState.IsValid)
            {            
                Model model = new Model
                {
                    IdBrand = Convert.ToInt32(formulaire.BrandName),
                    Name = formulaire.Name
                };
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //HTTP POST
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Model/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Model/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            List<SelectListItem> getbrandformList = new List<SelectListItem>();
            List<GetBrandForm> getbrandList = await BrandController.GetBrandList();

            EditModelForm model = new EditModelForm();
            model = await GetDetails(id);

            foreach (GetBrandForm Brand in getbrandList)
            {
                getbrandformList.Add(new SelectListItem { Text = Brand.Name, Value = Brand.IdBrand.ToString() });
            }

            model.BrandList = getbrandformList;
            return View(model);
        }

        // POST: Model/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditModelForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Model model = new Model
                {
                    IdModel = id,
                    IdBrand = Convert.ToInt32(formulaire.BrandName),
                    Name = formulaire.Name
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(model));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Model/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Model/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            List<GetBrandForm> getbrandList = await BrandController.GetBrandList();
            
            Model ModelGlobal = default(Model);
            DeleteModelForm ModelLocal = default(DeleteModelForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Model/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Model>(EmpResponse);
                    ModelLocal = AutoMapper<Model, DeleteModelForm>.AutoMap(ModelGlobal);
                }
            }

            ModelLocal.BrandName = (from b in getbrandList
                                    where b.IdBrand == ModelLocal.IdBrand
                                    select b.Name).FirstOrDefault();

            return View(ModelLocal);
        }

        // POST: Model/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteModelForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Model/Delete/{id}");

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
