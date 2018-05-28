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
    
    public class InstalledEquipementController : Controller
    {
        public string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        // GET: Equipement
        public async Task<ActionResult> Index()
        {
            IEnumerable<InstalledEquipement> InstalledEquipementList = null;
            List<GetInstalledEquipementForm> getInstalledEquipementformList = new List<GetInstalledEquipementForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("InstalledEquipment/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    InstalledEquipementList = JsonConvert.DeserializeObject<List<InstalledEquipement>>(EmpResponse);
                }
                foreach (InstalledEquipement InstalledEquipement in InstalledEquipementList)
                {
                    getInstalledEquipementformList.Add(AutoMapper<InstalledEquipement, GetInstalledEquipementForm>.AutoMap(InstalledEquipement));
                }
            }
            return View(getInstalledEquipementformList);

        }

        // GET: Equipement/Details/5
        public async Task<ActionResult> Details(int id)
        {
            InstalledEquipement ModelGlobal = default(InstalledEquipement);
            GetInstalledEquipementForm ModelLocal = default(GetInstalledEquipementForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"InstalledEquipment/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<InstalledEquipement>(EmpResponse);
                    ModelLocal = AutoMapper<InstalledEquipement, GetInstalledEquipementForm>.AutoMap(ModelGlobal);
                }                
            }
            return View(ModelLocal);
        }

        // GET: Equipement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipement/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddInstalledEquipementForm formulaire)
        {
            if (ModelState.IsValid)
            {
                InstalledEquipement equip = new InstalledEquipement
                {
                   IdCar=formulaire.IdCar,
                   IdEquipement = formulaire.IdEquipement
               };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(equip));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"InstalledEquipment/Create", content);

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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipement/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditInstalledEquipementForm formulaire)
        {
            if (ModelState.IsValid)
            {
                InstalledEquipement equip = new InstalledEquipement
                {
                    IdInstalledEquipement=formulaire.IdInstalledEquipement,
                    IdCar = formulaire.IdCar,
                    IdEquipement = formulaire.IdEquipement
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(equip));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"InstalledEquipment/Update", content);

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

                    HttpResponseMessage Res = await client.DeleteAsync($"InstalledEquipment/Delete/{id}");

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
