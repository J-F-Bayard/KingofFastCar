using KFC_MGMT.Models;
using KFC_MGMT.Models.Forms.Car;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class CarController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        public static async Task<List<GetCarForm>> GetCarList()
        {
            //chargement de la liste des voitures dans une liste pour linq
            IEnumerable<Car> CarList = null;
            List<GetCarForm> getcarformList = new List<GetCarForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Car/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    CarList = JsonConvert.DeserializeObject<List<Car>>(EmpResponse);
                }

                foreach (Car car in CarList)
                {
                    getcarformList.Add(AutoMapper<Car, GetCarForm>.AutoMap(car));
                }
            }
            List<GetModelForm> getmodelformList = await ModelController.GetModelList();
            List<GetBrandForm> getBrandformList = await BrandController.GetBrandList();

            foreach (var item in getmodelformList)
            {
                var data = (from b in getBrandformList
                            where b.IdBrand == item.IdBrand
                            select b.Name).FirstOrDefault();
                item.Name = data + " - " + item.Name;

            }

            foreach (var item in getcarformList)
            {
                var data = (from b in getmodelformList
                            where b.IdModel == item.IdModel
                            select b.Name).FirstOrDefault();

                item.ModelName = data;
            }

            return getcarformList;
        }
        
        // GET: Car
        public async Task<ActionResult> Index()
        {
            List<GetCarForm> getCarformList = await GetCarList();
            return View(getCarformList);
        }

        // GET: Car/Details/5
        public async Task<ActionResult> Details(string id)
        {            
            List<GetCarForm> getCarformList = await GetCarList();

            Car ModelGlobal = default(Car);
            GetCarForm ModelLocal = default(GetCarForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Car/Get/{id}");
                
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    ModelGlobal = JsonConvert.DeserializeObject<Car>(EmpResponse);
                    ModelLocal = AutoMapper<Car, GetCarForm>.AutoMap(ModelGlobal);
                }
            }            

            ModelLocal.ModelName = (from b in getCarformList                                    
                                    where b.IdCar == ModelLocal.IdCar
                                    select b.ModelName).FirstOrDefault();

            return View(ModelLocal);

        }

        public async Task<EditCarForm> GetCarDetails(string id)
        {
            Car ModelGlobal = default(Car);
            EditCarForm ModelLocal = default(EditCarForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Car/Get/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    ModelGlobal = JsonConvert.DeserializeObject<Car>(EmpResponse);
                    ModelLocal = AutoMapper<Car,EditCarForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: Car/Create
        public async Task<ActionResult> Create()
        {            
            List<SelectListItem> getmodelformList = new List<SelectListItem>();
            List<GetModelForm> modelList = await ModelController.GetModelList();
            List<GetBrandForm> brandList = await BrandController.GetBrandList();

            foreach (GetModelForm item in modelList)
            {
                item.Name = (from b in brandList
                             where b.IdBrand == item.IdBrand
                             select b.Name).FirstOrDefault()+" - "+item.Name;
            }

            foreach (GetModelForm Model in modelList)
            {
                getmodelformList.Add(new SelectListItem { Text = Model.Name, Value = Model.IdModel.ToString() });
            }

            var model = new AddCarForm
            {
                ModelList = getmodelformList
            };
            return View(model);
            
        }

        // POST: Car/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddCarForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    ChassisNumber = formulaire.ChassisNumber,
                    IdModel = Convert.ToInt32(formulaire.ModelName),
                    Version = formulaire.Version,
                    Year = formulaire.Year,
                    ChassisType = formulaire.ChassisType,
                    Condition = formulaire.Condition,
                    Mileage = formulaire.Mileage,
                    Power = formulaire.Power,
                    Cylinder = formulaire.Cylinder,
                    Location = formulaire.Location,
                    Fuel = formulaire.Fuel,
                    Transmition = formulaire.Transmition,
                    Color = formulaire.Color,
                    MetalPainting = formulaire.MetalPainting,
                    ServiceBook = formulaire.ServiceBook,
                    LeftHand = formulaire.LeftHand
                    };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(car));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Car/Create/", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Car/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            //return View(await GetCarDetails(id));
            List<Model> modelList = null;
            List<SelectListItem> getmodelformList = new List<SelectListItem>();

            EditCarForm model = new EditCarForm();
            model = await GetCarDetails(id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Model/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<Model>>(EmpResponse);
                }

                foreach (Model Model in modelList)
                {
                    getmodelformList.Add(new SelectListItem
                    {
                        Selected = (Model.IdModel == model.IdModel),
                        Text = Model.Name,
                        Value = Model.IdModel.ToString()
                    });
                }
            }

            model.ModelList = getmodelformList;
            return View(model);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditCarForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    IdCar = formulaire.IdCar,                
                    ChassisNumber = formulaire.ChassisNumber,
                    IdModel = Convert.ToInt32(formulaire.ModelName),
                    Version = formulaire.Version,
                    Year = formulaire.Year,
                    ChassisType = formulaire.ChassisType,
                    Condition = formulaire.Condition,
                    Mileage = formulaire.Mileage,
                    Power = formulaire.Power,
                    Cylinder = formulaire.Cylinder,
                    Location = formulaire.Location,
                    Fuel = formulaire.Fuel,
                    Transmition = formulaire.Transmition,
                    Color = formulaire.Color,
                    MetalPainting = formulaire.MetalPainting,
                    ServiceBook = formulaire.ServiceBook,
                    LeftHand = formulaire.LeftHand
            };
                                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(car));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Car/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            //return View(await GetCarDetails(id));
            List<Model> modelList = null;
            List<SelectListItem> getmodelformList = new List<SelectListItem>();

            EditCarForm temp = new EditCarForm();
            temp = await GetCarDetails(id);

            DeleteCarForm model = new DeleteCarForm
            {
                ChassisNumber = temp.ChassisNumber,
                ChassisType= temp.ChassisType,
                IdCar = temp.IdCar,
                IdModel=temp.IdModel,
                Location=temp.Location,
                Mileage=temp.Mileage,
                ModelName=temp.ModelName,
                Version=temp.Version,
                Year=temp.Year
            };
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Model/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<Model>>(EmpResponse);
                }

                foreach (Model Model in modelList)
                {
                    getmodelformList.Add(new SelectListItem
                    {
                        Selected = (Model.IdModel == model.IdModel),
                        Text = Model.Name,
                        Value = Model.IdModel.ToString()
                    });
                }
            }

            model.ModelName = (from b in getmodelformList
                               orderby b.Text
                                    where b.Value == model.IdModel.ToString()
                                    select b.Text).FirstOrDefault();

            return View(model);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteCarForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Car/Delete/{id}");

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
