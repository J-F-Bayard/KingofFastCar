using KFC_MGMT.Models;
using KFC_MGMT.Models.Forms;
using KFC_MGMT.Models.Forms.Car;
using KFC_MGMT.Models.Forms.Charges;
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
    public class ChargeController : Controller
    {
        public string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }
        
        //public async Task<List<GetBrandForm>> GetBrandName()
        //{
        //    //chargement de la liste des marques dans une liste pour linq
        //    List<Brand> BrandList = new List<Brand>();
        //    IEnumerable<Brand> brandList = null;
        //    List<GetBrandForm> getbrandformList = new List<GetBrandForm>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage Res = await client.GetAsync("Brand/Get");
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
        //            brandList = JsonConvert.DeserializeObject<List<Brand>>(EmpResponse);
        //        }

        //        foreach (Brand brand in brandList)
        //        {
        //            getbrandformList.Add(AutoMapper<Brand, GetBrandForm>.AutoMap(brand));
        //        }
        //    }
        //    return getbrandformList;
        //}

        //public async Task<List<GetBrandForm>> GetModelName()
        //{
        //    //chargement de la liste des marques dans une liste pour linq
        //    IEnumerable<Model> modelList = null;
        //    List<GetBrandForm> getmodelformList = new List<GetBrandForm>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage Res = await client.GetAsync("Model/Get");
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
        //            modelList = JsonConvert.DeserializeObject<List<Model>>(EmpResponse);
        //        }

        //        foreach (Model model in modelList)
        //        {
        //            getmodelformList.Add(AutoMapper<Model, GetBrandForm>.AutoMap(model));
        //        }
        //    }
        //    List<GetBrandForm> getbrandformList = await GetBrandName();

        //    foreach (var item in getmodelformList)
        //    {
        //        var data = (from b in getbrandformList
        //                    where b.IdBrand == item.IdBrand
        //                    select b.Name).FirstOrDefault();

        //        item.Name = data + " - " + item.Name;
        //    }

        //    return getmodelformList;
        //}

        public async Task<List<GetCarForm>> GetCarName()
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

            foreach (var item in getcarformList)
            {
                var data = (from b in getmodelformList
                            where b.IdBrand == item.IdModel
                            select b.Name).FirstOrDefault();

                item.ModelName = data;
            }

            return getcarformList;
        }



        // GET: Charge
        public async Task<ActionResult> Index()
        {
            IEnumerable<Charge> chargeList = null;
            List<GetChargeForm> getChargeformList = new List<GetChargeForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Charge/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    chargeList = JsonConvert.DeserializeObject<List<Charge>>(EmpResponse);
                }
                foreach (Charge charge in chargeList)
                {
                    getChargeformList.Add(AutoMapper<Charge, GetChargeForm>.AutoMap(charge));
                }
            }

            List<GetProviderForm> getproviderformList = await ProviderController.GetProviderList();
            List<GetHistoryForm> gethistoryformList = await HistoryController.GetHistoryList();
            List<GetCarForm> getCarformList = await CarController.GetCarList();

            foreach (var item in gethistoryformList)
            {
                item.CarName = (from b in getCarformList
                            where b.IdCar == item.IdCar
                            select b.ChassisNumber).FirstOrDefault();

                item.CarName = item.CarName+" - "+ (from b in getCarformList
                                where b.IdCar == item.IdCar
                                select b.ModelName).FirstOrDefault();

            }

            foreach (var item in getChargeformList)
            {
                item.ProviderName = (from b in getproviderformList
                            orderby b.Name
                            where b.IdProvider == item.IdProvider
                            select b.Name).FirstOrDefault();

                item.Carname = (from b in gethistoryformList
                            orderby b.IdHistory
                            where b.IdHistory == item.IdHistory
                            select b.CarName).FirstOrDefault();
            }
            return View(getChargeformList);
        }

        // GET: Charge/Details/5
        public async Task<ActionResult> Details(string id)
        {   
            Charge ModelGlobal = default(Charge);
            GetChargeForm ModelLocal = default(GetChargeForm);

            List<GetProviderForm> getproviderformList = await ProviderController.GetProviderList();
            List<GetHistoryForm> gethistoryformList = await HistoryController.GetHistoryList();
            List<GetCarForm> getCarformList = await CarController.GetCarList();

            foreach (var item in gethistoryformList)
            {
                item.CarName = (from b in getCarformList
                                where b.IdCar == item.IdCar
                                select b.ChassisNumber).FirstOrDefault();

                item.CarName = item.CarName + " - " + (from b in getCarformList
                                                       where b.IdCar == item.IdCar
                                                       select b.ModelName).FirstOrDefault();
            }
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Charge/Get/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    ModelGlobal = JsonConvert.DeserializeObject<Charge>(EmpResponse);
                    ModelLocal = AutoMapper<Charge, GetChargeForm>.AutoMap(ModelGlobal);
                }                
            }


            ModelLocal.ProviderName = (from b in getproviderformList
                                     orderby b.Name
                                     where b.IdProvider == ModelLocal.IdProvider
                                     select b.Name).FirstOrDefault();

            ModelLocal.Carname = (from b in gethistoryformList
                                orderby b.IdHistory
                                where b.IdHistory == ModelLocal.IdHistory
                                select b.CarName).FirstOrDefault();
            

            //ModelLocal.ProviderName = (from b in getproviderformList
            //                        orderby b.Text
            //                        where b.Value == ModelLocal.IdProvider.ToString()
            //                        select b.Text).FirstOrDefault();


            return View(ModelLocal);
        }

        // GET: Provider/Details/5
        public async Task<EditChargeForm> GetDetails(string id)
        {
            Charge ModelGlobal = default(Charge);
            EditChargeForm ModelLocal = default(EditChargeForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Charge/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Charge>(EmpResponse);
                    ModelLocal = AutoMapper<Charge, EditChargeForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: Charge/Create
        public async Task<ActionResult> Create()
        {
            List<GetProviderForm> providerList = await ProviderController.GetProviderList();
            List<SelectListItem> getproviderformList = new List<SelectListItem>();
            foreach (GetProviderForm Provider in providerList)
            {
                getproviderformList.Add(new SelectListItem { Text = Provider.Name, Value = Provider.IdProvider.ToString() });
            }

            List<GetCarForm> carList = await CarController.GetCarList();
            List<SelectListItem> getcarformList = new List<SelectListItem>();
            foreach (GetCarForm Car in carList)
            {
                getcarformList.Add(new SelectListItem { Text = Car.ChassisNumber + " - " + Car.ModelName, Value = Car.IdCar.ToString() });
            }

            List<GetHistoryForm> historyList = await HistoryController.GetHistoryList();
            List<SelectListItem> gethistoryformList = new List<SelectListItem>();            
            foreach (GetHistoryForm History in historyList)
            {
                var data = (from b in carList
                            where b.IdCar == History.IdCar
                            select b.ChassisNumber).FirstOrDefault();
                var data2 = (from b in carList
                            where b.IdCar == History.IdCar
                            select b.ModelName).FirstOrDefault();

                gethistoryformList.Add(new SelectListItem { Text = data+" - "+data2, Value = History.IdHistory.ToString() });

            }

            var model = new AddChargeForm
            {   
                HistoryList = gethistoryformList,
                ProviderList = getproviderformList
            };
            return View(model);
        }

        // POST: Charge/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddChargeForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Charge charge = new Charge
                {
                    IdHistory = Convert.ToInt32(formulaire.HistoryName),
                    IdProvider =Convert.ToInt32(formulaire.ProviderName),
                    Entitled=formulaire.Entitled,
                    Amount=formulaire.Amount,
                    BillNumber=formulaire.BillNumber,
                    DeliveryDate=formulaire.DeliveryDate
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(charge));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"Charge/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: Charge/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            EditChargeForm model = new EditChargeForm();
            model = await GetDetails(id);

            List<GetCarForm> carList = await CarController.GetCarList();
            List<SelectListItem> getcarformList = new List<SelectListItem>();
            foreach (GetCarForm Car in carList)
            {
                getcarformList.Add(new SelectListItem { Text = Car.ChassisNumber + " - " + Car.ModelName, Value = Car.IdCar.ToString() });
            }

            List<GetHistoryForm> historyList = await HistoryController.GetHistoryList();
            List<SelectListItem> gethistoryformList = new List<SelectListItem>();

            foreach (GetHistoryForm History in historyList)
            {
                var data = (from b in carList
                            where b.IdCar == History.IdCar
                            select b.ChassisNumber).FirstOrDefault();
                var data2 = (from b in carList
                             where b.IdCar == History.IdCar
                             select b.ModelName).FirstOrDefault();

                gethistoryformList.Add(new SelectListItem
                                        {
                                        Selected = (History.IdHistory == Convert.ToInt32(model.HistoryId)),
                                        Text = data + " - " + data2,
                                        Value = History.IdHistory.ToString()
                                        });

            }

            List<GetProviderForm> providerList = await ProviderController.GetProviderList();
            List<SelectListItem> getproviderformList = new List<SelectListItem>();
            foreach (GetProviderForm Provider in providerList)
            {
                getproviderformList.Add(new SelectListItem { Text = Provider.Name, Value = Provider.IdProvider.ToString() });
            }
            
            model.ProviderList = getproviderformList;
            model.HistoryList = gethistoryformList;
            return View(model);
        }

        // POST: Charge/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditChargeForm formulaire)
        {
            if (ModelState.IsValid)
            {
                Charge charge = new Charge
                {
                    IdCharge=formulaire.IdCharge,
                    IdHistory = Convert.ToInt32(formulaire.HistoryId),
                    IdProvider = Convert.ToInt32(formulaire.ProviderName),
                    Entitled = formulaire.Entitled,
                    Amount = formulaire.Amount,
                    BillNumber = formulaire.BillNumber,
                    DeliveryDate = formulaire.DeliveryDate
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(charge));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"Charge/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Charge/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Charge ModelGlobal = default(Charge);
            DeleteChargeForm ModelLocal = default(DeleteChargeForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Charge/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Charge>(EmpResponse);
                    ModelLocal = AutoMapper<Charge, DeleteChargeForm>.AutoMap(ModelGlobal);
                }
            }

            List<GetCarForm> carList = await CarController.GetCarList();
            List<SelectListItem> getcarformList = new List<SelectListItem>();
            foreach (GetCarForm Car in carList)
            {
                getcarformList.Add(new SelectListItem { Text = Car.ChassisNumber + " - " + Car.ModelName, Value = Car.IdCar.ToString() });
            }

            List<GetProviderForm> providerList = await ProviderController.GetProviderList();
            List<SelectListItem> getproviderformList = new List<SelectListItem>();
            foreach (GetProviderForm Provider in providerList)
            {
                getproviderformList.Add(new SelectListItem { Text = Provider.Name, Value = Provider.IdProvider.ToString() });
            }

            List<GetHistoryForm> historyList = await HistoryController.GetHistoryList();
            List<SelectListItem> gethistoryformList = new List<SelectListItem>();

            foreach (GetHistoryForm History in historyList)
            {
                var data = (from b in carList
                            where b.IdCar == History.IdCar
                            select b.ChassisNumber).FirstOrDefault();
                var data2 = (from b in carList
                             where b.IdCar == History.IdCar
                             select b.ModelName).FirstOrDefault();

                gethistoryformList.Add(new SelectListItem
                {
                    Selected = (History.IdHistory == ModelLocal.IdHistory),
                    Text = data + " - " + data2,
                    Value = History.IdHistory.ToString()
                });

            }

           

            ModelLocal.HistoryName = (from b in gethistoryformList
                                      where b.Value == ModelLocal.IdHistory.ToString()
                                      select b.Text).FirstOrDefault();

            ModelLocal.ProviderName = (from b in getproviderformList
                                    where b.Value == ModelLocal.IdProvider.ToString()
                                    select b.Text).FirstOrDefault();

            return View(ModelLocal);
        }

        // POST: Charge/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteChargeForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"Charge/Delete/{id}");

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
