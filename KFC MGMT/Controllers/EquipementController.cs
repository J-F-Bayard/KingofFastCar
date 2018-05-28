using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KFCKFC_MGMT.Models;
using System.Configuration;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class EquipementController : Controller
    {
        public string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        // GET: Equipement
        public async Task<ActionResult> Index()
        {
            IEnumerable<Equipement> equipementList = null;
            List<GetEquipementForm> getEquipformList = new List<GetEquipementForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Equipment/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    equipementList = JsonConvert.DeserializeObject<List<Equipement>>(EmpResponse);
                }
                foreach (Equipement equip in equipementList)
                {
                    getEquipformList.Add(AutoMapper<Equipement, GetEquipementForm>.AutoMap(equip));
                }
            }
            return View(getEquipformList);

        }

        // GET: Equipement/Details/5
        public async Task<ActionResult> Details(string id)
        {
            Equipement ModelGlobal = default(Equipement);
            GetEquipementForm ModelLocal = default(GetEquipementForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Equipment/Get/{id}");
                
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    ModelGlobal = JsonConvert.DeserializeObject<Equipement>(EmpResponse);
                    ModelLocal = AutoMapper<Equipement, GetEquipementForm>.AutoMap(ModelGlobal);
                }
            }
            return View(ModelLocal);

        }

        public async Task<EditEquipementForm> GetDetails(string id)
        {
            Equipement ModelGlobal = default(Equipement);
            EditEquipementForm ModelLocal = default(EditEquipementForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Equipment/Get/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    ModelGlobal = JsonConvert.DeserializeObject<Equipement>(EmpResponse);
                    ModelLocal = AutoMapper<Equipement, EditEquipementForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;

        }

        // GET: Equipement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipement/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddEquipementForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Equipement equip = new Equipement
                {
                    Name = formulaire.Name,
                    Description = formulaire.Description
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(equip));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Equipment/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Equipement/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await GetDetails(id));
        }

        // POST: Equipement/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditEquipementForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Equipement equip = new Equipement
                {
                    IdEquipement=formulaire.IdEquipement,
                    Name = formulaire.Name,
                    Description = formulaire.Description
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(equip));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Equipment/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Equipement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipement/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DeleteEquipementForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Equipment/Delete/{id}");

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
